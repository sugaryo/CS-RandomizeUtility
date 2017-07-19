using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeUtility
{
	/// <summary>
	/// ランダマイズ抽出する要素の並び順を指定するオプション
	/// </summary>
	public enum OrderOptions
	{
		/// <summary>
		/// 元の並び順を保持する
		/// </summary>
		KeepOrigin,

		/// <summary>
		/// 元の並び順を無視する（ランダムに並べ替える）
		/// </summary>
		Random,
	}

	public class Randomizer<T>
	{
		/// <summary>
		/// ランダム抽出する要素の母体
		/// </summary>
        private readonly IEnumerable<T> source;

		/// <summary>
		/// ランダム抽出に使用する乱数ジェネレータ
		/// </summary>
        private readonly Random r;

		#region ctor
		/// <param name="source">ランダム抽出する要素の母体</param>
		public Randomizer( IEnumerable<T> source )
        {
            this.source = source;
            this.r = new Random();
        }
		#endregion


		/// <summary>
		/// ランダム抽出
		/// </summary>
		/// <remarks>
		/// このランダマイザに与えられた要素の母体から、指定した要素数だけランダムに抽出します。
		/// </remarks>
		/// 
		/// <param name="count">
		/// ランダム抽出する要素数。
		/// 母数がこの要素数に満たない場合は母数全てを抽出します。
		/// </param>
		/// <param name="order">
		/// ランダム抽出した要素の並び順指定。
		/// デフォルトは OorderOptions.KeepOrigin 
		/// </param>
		/// <returns>指定した要素数でランダム抽出した要素の列挙子</returns>
		/// 
		/// <see cref="Skip(int, int)"/>
		/// <see cref="Take(int, int, int)"/>
		public IEnumerable<T> Randomize( int count, OrderOptions order = OrderOptions.KeepOrigin )
        {
			IEnumerable<T> random = this.Core( count );

			switch ( order )
			{
				case OrderOptions.Random:
					return random.OrderBy( x => Guid.NewGuid() );

				default:
					return random;
			}
		}

		private IEnumerable<T> Core( int count )
		{
			// 抽出数が 0以下 の場合は空の列挙を返す。
            if ( count <= 0 )
            {
                return Enumerable.Empty<T>();
            }

			// 抽出数が 全要素以上 の場合は要素全体を返す。
            int size = this.source.Count();
            if ( size <= count )
            {
                return this.source;
            }

#warning 【改善】↓抽出数が全体の要素数に近づくにつれてランダム性が落ちるので、半数以上抽出する場合は逆ロジックを作りたい。

			// 上記以外（全要素から部分を抽出する必要がある場合）はExtractで抽出する。
			return Extract( size, count );
		}
		/// <summary>
		/// ランダム抽出
		/// </summary>
		/// <param name="size">要素数</param>
		/// <param name="count">抽出数</param>
		/// <returns> <seealso cref="source"/> から 指定された抽出数の要素を返す列挙 </returns>
		private IEnumerable<T> Extract(int size, int count)
		{
			// 要素全体を指定の抽出数でブロック分割し、各ブロックから一件だけ要素を返す。
			// ブロック内の一件に関しては乱数（r.Next）を用いてランダムに抽出する。
			// ※ 現在のロジックでは、↑の方の warning にも書いた通り、
			//    ブロックのサイズが小さくなればなるほど、ランダム性は落ちる。
			//    抽出数が大きくなればなる程、分割されたブロックは小さくなり、
			//    乱数の及ぼす影響範囲が狭くなる為である。
			//    極論、全要素を抽出する場合、ブロックサイズが 1 になりランダム性は無くなる。
			var blocks = Block.As( size, count );

			foreach ( Block block in blocks )
			{
				int dx = r.Next( 0, block.Count );
				int index = block.Begin + dx;

				yield return this.source.ElementAt( index );
			}
		}
    }
}

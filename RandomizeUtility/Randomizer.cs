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
		/// <param name="seed">乱数のシード値</param>
		public Randomizer( IEnumerable<T> source, int? seed = null )
        {
            this.source = source;
			this.r = null == seed 
				? new Random() 
				: new Random( seed.Value );
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
			


			int half = size / 2;
			if ( half < count )
			{
				// 抽出数が半数を超える場合は逆ロジック。
				// 　全体 S個 の要素から「 N個 抽出する 」ロジックを
				// 　全体 S個 の要素から「 (S-N)個 抽出しない 」ロジックにする。
				return Skip( size, size - count );
			}
			else
			{
				// 抽出数が半分以下なら通常ロジック。
				return Take( size, count );
			}
		}
		
		/// <summary>
		/// ランダム抽出（正）
		/// </summary>
		/// <param name="size">要素数</param>
		/// <param name="count">抽出数</param>
		/// <returns> <seealso cref="source"/> から 指定された抽出数の要素を返す列挙 </returns>
		private IEnumerable<T> Take(int size, int count)
		{
			var blocks = Block.As( size, count );
			foreach ( Block block in blocks )
			{
				// 各ブロック毎に一件だけ、返却する要素をランダムに決定する。
				int dx = r.Next( 0, block.Count );
				int index = block.Begin + dx;

				yield return this.source.ElementAt( index );
			}
		}

		/// <summary>
		/// ランダム抽出（反転）
		/// </summary>
		/// <param name="size">要素数</param>
		/// <param name="count">スキップ数</param>
		/// <returns> <seealso cref="source"/> から 指定されたスキップ数の要素を除いて返す列挙 </returns>
		private IEnumerable<T> Skip( int size, int count )
		{
			var blocks = Block.As( size, count );
			foreach ( Block block in blocks )
			{
				// 各ブロック毎に一件だけ、スキップする要素をランダムに決定する。
				int dx = r.Next( 0, block.Count );
				int skip = block.Begin + dx;

				foreach ( int index in block.AsIndexes() )
				{
					if ( index == skip ) continue;

					yield return this.source.ElementAt( index );
				}
			}
		}
    }
}

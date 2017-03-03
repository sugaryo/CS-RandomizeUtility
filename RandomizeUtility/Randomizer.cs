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
            if ( count < 0 )
            {
                return Enumerable.Empty<T>();
            }

            int size = this.source.Count();
            if ( size <= count )
            {
                return this.source;
            }


            int step = size / count;

            return step <= 1
                ? this.Skip( size, size - count )
                : this.Take( size, count, step );
		}


        // 指定した回数スキップする列挙：

        private IEnumerable<T> Skip( int size, int count )
        {
            int step = size / count;
            int tail = size - 1;

#warning ここのロジックバグってる、要修正。
			for ( int n = 0; n < count; n++ )
            {
                int i = n * step;
                int d = r.Next( 0, step );

                int skip = Math.Min( i + d, tail );

                for ( int x = 0; x < step; x++ )
                {
                    int index = i + x;

                    if ( index == skip ) continue;
                    if ( tail < index ) yield break;

                    yield return this.source.ElementAt( index );
                }
            }
        }


        // 指定した回数実行する列挙：
		
        private IEnumerable<T> Take( int size, int count, int step )
        {
            int tail = size - 1;

            for ( int n = 0; n < count; n++ )
            {
                int i = n * step;
                int d = r.Next( 0, step );

                int index = Math.Min( i + d, tail );
                yield return this.source.ElementAt( index );
            }
        }
    }
}

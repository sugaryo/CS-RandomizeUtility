using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeUtility
{
	public enum OrderOptions
	{
		KeepOrigin,
		Random,
	}

	public class Randomizer<T>
	{
        private readonly IEnumerable<T> source;

        private readonly Random r;

        public Randomizer( IEnumerable<T> source )
        {
            this.source = source;

            this.r = new Random();
        }

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

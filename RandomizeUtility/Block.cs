using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeUtility
{
	public class Block
	{
		public int Begin { get; private set; }
		public int End   { get; private set; }
		public int Count { get { return End - Begin + 1; } }

		public Block(int begin, int end)
		{
			this.Begin = Math.Min( begin, end );
			this.End   = Math.Max( begin, end );
		}

		public IEnumerable<int> AsIndexes()
		{
			for ( int i = this.Begin; i < this.Count; i++ )
			{
				yield return i;
			}
		}

		public override string ToString()
		{
			return $"{this.Begin}-{this.End}({this.Count})";
		}

		public static List<Block> As( int size, int n )
		{
			List<Block> blocks = new List<Block>();
			
			decimal seeksize = (decimal)size / (decimal)n;

			// N回のブロック生成を行う。
			decimal index = 0m;
			for ( int i = 0; i < n; i++ )
			{
				int begin = (int)Math.Ceiling(index);

				index += seeksize;

				int end = (int)Math.Ceiling(index)-1;

				Block block = new Block(begin, end);
				blocks.Add( block );
			}


			return blocks;
		}
	}
}

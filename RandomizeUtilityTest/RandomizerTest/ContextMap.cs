using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeUtilityTest.RandomizerTest
{
	class ContextMap<Tkey>
	{
		private readonly Dictionary<Tkey, int> map = new Dictionary<Tkey, int>();

		public IEnumerable<Tkey> Keys
		{
			get { return this.map.Keys; }
		}

		public void Count( Tkey key )
		{
			if ( this.map.ContainsKey( key ) )
			{
				this.map[key]++;
			}
			else
			{
				this.map.Add( key, 1 );
			}
		}

		public void Reset()
		{
			this.map.Clear();
		}

		public int this[Tkey key]
		{
			get { return this.map.ContainsKey( key ) ? this.map[key] : 0; }
		}
	}
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;
using System.Reflection;

namespace RandomizeUtilityTest
{
	// xUnit 的なスマートなアレにしたいなぁ、Assertクラスはイケてないから何か考えたい。できれば追加依存無しで。。。

	[TestClass]
	public class BlockTest
	{
		[TestMethod]
		public void Case10div5_等分割するパターン()
		{
			var test = new {
				S = 10,
				N = 5,
			};

			var block = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, block.Count );

			foreach ( var i in block )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}
		
		[TestMethod]
		public void Case10div3_分割数半分以下で余り有り()
		{
			var test = new {
				S = 10,
				N = 3,
			};

			var block = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, block.Count );

			foreach ( var i in block )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}
		
		[TestMethod]
		public void Case10div7_分割数半分以上で余り有り()
		{
			
			var test = new {
				S = 10,
				N = 7,
			};

			var block = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, block.Count );

			foreach ( var i in block )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}


	}
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;
using System.Reflection;

namespace RandomizeUtilityTest
{
	// xUnit 的なスマートなアレにしたいなぁ、Assertクラスはイケてないから何か考えたい。できれば追加依存無しで。。。

	/// <summary>
	/// ブロックの分割数だけざっくりテスト。内容に関してはDetailの方で検証する。
	/// </summary>
	[TestClass]
	public class BlockTest
	{
		[TestMethod]
		public void CASE0a_10div1_むしろ分割しない()
		{
			var test = new {
				S = 10,
				N = 1,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}
		[TestMethod]
		public void CASE0b_10div10_むしろ全部分割する()
		{
			var test = new {
				S = 10,
				N = 10,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}


		
		[TestMethod]
		public void CASE1a_10div5_等分割するパターン1()
		{
			var test = new {
				S = 10,
				N = 5,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}
		[TestMethod]
		public void CASE1b_10div2_等分割するパターン2()
		{
			var test = new {
				S = 10,
				N = 2,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}

		
		[TestMethod]
		public void CASE2a_10div3_分割数半分以下で余り有り()
		{
			var test = new {
				S = 10,
				N = 3,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}
		
		[TestMethod]
		public void CASE2b_10div7_分割数半分以上で余り有り()
		{
			var test = new {
				S = 10,
				N = 7,
			};

			var blocks = Block.As( test.S, test.N );
			
			Assert.AreEqual( test.N, blocks.Count );

			foreach ( var i in blocks )
			{
				Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
			}
		}

		// テスト結果の表示順を弄れなかったから仕方なく CASE9x でメソッド名を並べてやったが、、、。
	}
}

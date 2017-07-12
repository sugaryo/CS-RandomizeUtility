using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;

namespace RandomizeUtilityTest
{
	// xUnit 的なスマートなアレにしたいなぁ、Assertクラスはイケてないから何か考えたい。できれば追加依存無しで。。。

	/// <summary>
	/// ブロックの分割数だけざっくりテスト。内容に関してはDetailの方で検証する。
	/// </summary>
	[TestClass]
	public class BlockTest
	{
		#region 0. 全分割／無分割
		[TestMethod]
		public void CASE0a_10div1_むしろ分割しない()
		{
			var test = new BlockTestCase( 10, 1 );
			this.ExecTest( test );
		}
		[TestMethod]
		public void CASE0b_10div10_むしろ全部分割する()
		{
			var test = new BlockTestCase( 10, 10 );
			this.ExecTest( test );
		}
		#endregion
		

		#region 1. 10件の等分割系
		[TestMethod]
		public void CASE1a_10div5_等分割するパターン1()
		{
			var test = new BlockTestCase( 10, 5 );
			this.ExecTest( test );
		}
		[TestMethod]
		public void CASE1b_10div2_等分割するパターン2()
		{
			var test = new BlockTestCase( 10, 2 );
			this.ExecTest( test );
		}
		#endregion

		
		#region 2. 割り切れないケース
		[TestMethod]
		public void CASE2a_10div3_分割数半分以下で余り有り()
		{
			var test = new BlockTestCase( 10, 3 );
			this.ExecTest( test );
		}
		[TestMethod]
		public void CASE2b_10div7_分割数半分以上で余り有り()
		{
			var test = new BlockTestCase( 10, 7 );
			this.ExecTest( test );
		}
		#endregion

		
		/// <summary>
		/// テストの共通ロジック
		/// </summary>
		/// <remarks>
		/// 指定したテストの実行条件に応じてブロック分割を行い、
		/// 分割後の詳細な内容をテストします。
		/// </remarks>
		/// <param name="test">テストケース（テストの実行条件）</param>
		/// <seealso cref="BlockTestCase"/>
		private void ExecTest( BlockTestCase test )
		{
			var blocks = Block.As( test.S, test.N );
			
			foreach ( var block in blocks )
			{
				Console.WriteLine( "block : " + block.ToString() );
			}
			
			Assert.AreEqual( test.N, blocks.Count );
		}
	}
}

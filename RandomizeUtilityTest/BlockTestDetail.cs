using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;

namespace RandomizeUtilityTest
{
	[TestClass]
	public class BlockTestDetail
	{
		#region 1. 解り易い10個パターン
		[TestMethod]
		public void CASE1a_10個2分割()
		{
			var test = new BlockTestCase( 10, 2 );
			ExecTest( test );
		}
		[TestMethod]
		public void CASE1b_10個10分割()
		{
			var test = new BlockTestCase( 10, 10 );
			ExecTest( test );
		}
		[TestMethod]
		public void CASE1c_10個7分割()
		{
			var test = new BlockTestCase( 10, 7 );
			ExecTest( test );
		}
		#endregion


		#region 2. 解り易い割り切れる系
		[TestMethod]
		public void CASE2a_99個3分割()
		{
			var test = new BlockTestCase( 99, 3 );
			ExecTest( test );
		}

		[TestMethod]
		public void CASE2a_256個4分割()
		{
			var test = new BlockTestCase( 256, 4 );
			ExecTest( test );
		}

		[TestMethod]
		public void CASE2a_100個5分割()
		{
			var test = new BlockTestCase( 100, 5 );
			ExecTest( test );
		}
		#endregion


		#region 3. 解り易い割り切れない系
		[TestMethod]
		public void CASE3a_100個33分割()
		{
			var test = new BlockTestCase( 100, 33 );
			ExecTest( test );
		}

		[TestMethod]
		public void CASE3b_17個3分割()
		{
			var test = new BlockTestCase( 17, 3 );
			ExecTest( test );
		}
		
		[TestMethod]
		public void CASE3c_49個2分割()
		{
			var test = new BlockTestCase( 49, 2 );
			ExecTest( test );
		}
		#endregion


		#region 4. 複雑系／大量系
		[TestMethod]
		public void CASE4a_10000個10分割()
		{
			var test = new BlockTestCase( 10000, 10 );
			ExecTest( test );
		}

		[TestMethod]
		public void CASE4b_20000個8分割()
		{
			var test = new BlockTestCase( 20000, 8 );
			ExecTest( test );
		}
		
		[TestMethod]
		public void CASE4c_300個99分割()
		{
			var test = new BlockTestCase( 300, 99 );
			ExecTest( test );
		}
		
		[TestMethod]
		public void CASE4d_1000個999分割()
		{
			var test = new BlockTestCase( 1000, 999 );
			ExecTest( test );
		}
		
		/// <summary>
		/// 素数分割
		/// </summary>
		[TestMethod]
		public void CASE4e_9973個13分割()
		{
			var test = new BlockTestCase( 9973, 13 );
			ExecTest( test );
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

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" 
				+ "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				Console.WriteLine( "block : " + block.ToString() );

				if ( 0 == block.Count )
				{
					Assert.Fail( 
						"【ErrorCase2】" 
						+ "要素数が0個のブロックが出現：" 
						+ block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					indexes.Add( i );
				}
			}
			
			Assert.AreEqual( test.S, indexes.Count,
				"【ErrorCase3】" 
				+ "ブロック分割された全体の要素数がおかしくなってる。" 
				+ "多分、重複か欠落が発生している。" );

			for ( int i = 0; i < test.S; i++ )
			{
				int index = indexes[i];
				Console.WriteLine( "index : " + index );
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}
	}
}

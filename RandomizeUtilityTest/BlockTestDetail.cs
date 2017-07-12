using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;

namespace RandomizeUtilityTest
{
	[TestClass]
	public class BlockTestDetail
	{
		[TestMethod]
		public void CASE1a_10個2分割()
		{
			var test = new {
				S = 10,
				N = 2,
			};

			var blocks = Block.As( test.S, test.N );

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" + "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				if ( 0 == block.Count )
				{
					Assert.Fail( "【ErrorCase2】" + "要素数が0個のブロックが出現：" + block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
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
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}

		[TestMethod]
		public void CASE1b_10個10分割()
		{
			var test = new {
				S = 10,
				N = 10,
			};
			
			var blocks = Block.As( test.S, test.N );

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" + "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				if ( 0 == block.Count )
				{
					Assert.Fail( "【ErrorCase2】" + "要素数が0個のブロックが出現：" + block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
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
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}
		[TestMethod]
		public void CASE1c_10個7分割()
		{
			var test = new {
				S = 10,
				N = 7,
			};
			
			var blocks = Block.As( test.S, test.N );

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" + "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				if ( 0 == block.Count )
				{
					Assert.Fail( "【ErrorCase2】" + "要素数が0個のブロックが出現：" + block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
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
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}


		[TestMethod]
		public void CASE2a_99個3分割()
		{
			var test = new {
				S = 99,
				N = 3,
			};
			
			var blocks = Block.As( test.S, test.N );

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" + "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				if ( 0 == block.Count )
				{
					Assert.Fail( "【ErrorCase2】" + "要素数が0個のブロックが出現：" + block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
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
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}

		
		[TestMethod]
		public void CASE2b_100個33分割()
		{
			var test = new {
				S = 99,
				N = 3,
			};
			
			var blocks = Block.As( test.S, test.N );

			List<int> indexes = new List<int>();
			
			Assert.AreEqual( test.N, blocks.Count, 
				"【ErrorCase1】" + "ブロック分割数が指定分割数と合ってない。" );	
			foreach ( Block block in blocks )
			{
				if ( 0 == block.Count )
				{
					Assert.Fail( "【ErrorCase2】" + "要素数が0個のブロックが出現：" + block.ToString() );
				}

				for ( int i = block.Begin; i <= block.End; i++ )
				{
					Console.WriteLine( MethodBase.GetCurrentMethod().ToString() + " : " + i );
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
				Assert.AreEqual( i, index, 
					"【ErrorCase4】"
					+  "ブロック分割のインデックスが不連続になっている。" 
					+ "多分、重複か欠落が発生している。" );
			}
		}
	}
}

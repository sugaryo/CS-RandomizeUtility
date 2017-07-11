using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomizeUtilityTest
{
	[TestClass]
	public class StdTest
	{
		#region 追加のテスト属性
		//
		// テストを作成する際には、次の追加属性を使用できます:
		//
		// クラス内で最初のテストを実行する前に、ClassInitialize を使用してコードを実行してください
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// クラス内のテストをすべて実行したら、ClassCleanup を使用してコードを実行してください
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// 各テストを実行する前に、TestInitialize を使用してコードを実行してください
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// 各テストを実行した後に、TestCleanup を使用してコードを実行してください
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion
		
		[TestMethod]
		public void Success()
		{
			// 特に何もしない。
		}

		[TestMethod]
		public void Fail()
		{
			// 意図的にテストを失敗させる。
			Assert.Fail( "テストを失敗させるよ" );
		}
	}
}

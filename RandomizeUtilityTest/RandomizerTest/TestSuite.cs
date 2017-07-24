using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomizeUtility;

namespace RandomizeUtilityTest.RandomizerTest
{
	[TestClass]
	public class TestSuite
	{
		/// <summary>
		/// テストの負荷係数
		/// </summary>
		/// <remarks>
		/// ランダムロジックなので乱数をある程度収束させる必要があるので、多めに繰り返す。
		/// どのくらい多めにすれば良いかは何とも言えないし、
		/// いくらにした所で運が悪ければテスト失敗する可能性はゼロではない。
		/// 
		/// </remarks>
		private const int VALIDATE_WEIGHT = 10000;

		#region A. 半数以上パターン
		[TestMethod]
		public void CASE_A1_半数以上()
		{
			var test = new TestCase( 50, 30 );
			ExecTest( test );
		}
		[TestMethod]
		public void CASE_A2_半数以上_大()
		{
			var test = new TestCase( 500, 450 );
			ExecTest( test );
		}
		#endregion

		#region B. 半数以下パターン
		[TestMethod]
		public void CASE_B1_半数以下()
		{
			var test = new TestCase( 50, 20 );
			ExecTest( test );
		} 
		[TestMethod]
		public void CASE_B2_半数以下_小()
		{
			var test = new TestCase( 10, 3 );
			ExecTest( test );
		} 
		[TestMethod]
		public void CASE_B3_半数以下_極小()
		{
			var test = new TestCase( 100, 5 );
			ExecTest( test, 10 ); // 100個 から 5個 のランダム抽出で均一になるまで試行するには回数が足りないので 10倍 回す。
		} 
		#endregion
		
		#region C. ちょうど半分
		[TestMethod]
		public void CASE_C1_半分()
		{
			var test = new TestCase( 50, 25 );
			ExecTest( test );
		} 
		#endregion

		private void ExecTest( TestCase test, int power = 1 )
		{
			// データと発生回数を保持するコンテキストマップ
			var context = new ContextMap<string>();
			
			List<string> datasource = test
				.Numbers
				.Select( x => x.ToString() )
				.ToList();


			for ( int i = 0; i < VALIDATE_WEIGHT * power; i++ )
			{
				Validate( test, datasource, context );
			}


			// 実行結果のチェック
			List<string> invalidate = new List<string>();
			bool validate = true;

			int min = int.MaxValue;
			int max = 0;
			foreach ( string data in datasource )
			{
				int n = context[data];

				if ( 0 == n )
				{
					validate = false;
					invalidate.Add( data );
				}

				min = Math.Min( min, n );
				max = Math.Max( max, n );

				Console.WriteLine( $"{data} : \t{n}" );
			}
			Console.WriteLine( $"最大出現回数：max = {max}" );
			Console.WriteLine( $"最小出現回数：min = {min}" );
			Console.WriteLine( $"　　　　　幅：{max - min}" );

			if ( !validate )
			{
				Assert.Fail( "出現回数0回の要素が発生している：", invalidate.ToArray() );
			}
		}
		private void Validate( 
				TestCase test, 
				List<string> datasource, 
				ContextMap<string> context )
		{
			Randomizer<string> randomizer = new Randomizer<string>( datasource, DateTime.Now.Millisecond );
			foreach ( string x in randomizer.Randomize( test.N ) )
			{
				context.Count( x );
			}
		}
	}
}

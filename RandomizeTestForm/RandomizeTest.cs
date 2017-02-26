using RandomizeUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeTestForm
{
	public static class RandomizeTest
	{
		#region Lines
		public static readonly string[] Lines;

		static RandomizeTest()
		{
			int no = 1;

			Lines =
@"
かばんちゃん
サーバル
カバ
トキ
かぴばら
すなねこ
ツチノコ
ハシビロコウ
アフリカオオコノハズク (博士)
ワシミミズク           (助手)
あらいさん
ふぇねっく
ＰＰＰ ロイヤルペンギン
ＰＰＰ コウテイペンギン
ＰＰＰ ジェンツーペンギン
ＰＰＰ イワトビペンギン
ＰＰＰ フンボルトペンギン
".Split( new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries )
			.AsEnumerable()
			.Select( x => no++.ToString( "000 " ) + x )
			.ToArray();
		}
		#endregion

		#region Test() +1
		public static void Test()
		{
			Test( x => Console.WriteLine( x ) );
		}

		public static void Test( Action<string> testaction )
		{
			var random = new Randomizer<string>( Lines );

			var testpattern = new[]{
				1, 3, 5, 10, 16
			};

			foreach ( int n in testpattern )
			{
				testaction( "■■■■抽出数：" + n.ToString() );

				foreach ( string line in random.Randomize( n ) )
				{
					testaction( "    " + line );
				}
			}
		}
		#endregion
	}
}

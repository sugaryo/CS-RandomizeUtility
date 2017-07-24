using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeUtilityTest.RandomizerTest
{
	/// <summary>
	/// <seealso cref="RandomizeUtility.Block"/> のテストケース（実行条件）クラス
	/// </summary>
	public class TestCase
	{
		/// <summary>
		/// ブロック分割の要素数
		/// </summary>
		public int S { get; private set; }
		/// <summary>
		/// ブロック分割の分割数
		/// </summary>
		public int N { get; private set; }

		/// <summary>
		/// 全要素のインデックス配列（ 0 ～ S - 1 ）
		/// </summary>
		public IEnumerable<int> Indexes
		{
			get { return Enumerable.Range( 0, this.S ); }
		}
		/// <summary>
		/// 全要素の番号配列（ 1 ～ S ）
		/// </summary>
		public IEnumerable<int> Numbers
		{
			get { return Enumerable.Range( 1, this.S ); }
		}


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="s">ブロック分割の要素数</param>
		/// <param name="n">ブロック分割の分割数</param>
		public TestCase(int s, int n)
		{
			this.S = s;
			this.N = n;
		}
	}
}

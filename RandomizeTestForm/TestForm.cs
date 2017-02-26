using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomizeTestForm
{
    public partial class TestForm : Form
    {
		private readonly StringBuilder sb = new StringBuilder();

        public TestForm()
        {
            InitializeComponent();
        }
		
        private void TestForm_Load( object sender, EventArgs e )
        {
			sb.Clear();

			foreach ( var line in RandomizeTest.Lines )
			{
				sb.AppendLine( line );
			}

			this.txtLeft.Text = sb.ToString();
		}

		private void btnTest_Click( object sender, EventArgs e )
        {
			try
			{
				sb.Clear();
				
				RandomizeTest.Test( 
					x =>
					{
						Console.WriteLine( x );
						sb.AppendLine( x );
					}, 
					this.rdoOrderOptionKeepOrigin.Checked 
						? RandomizeUtility.OrderOptions.KeepOrigin
						: RandomizeUtility.OrderOptions.Random 
				);


				this.txtOutput.Text = sb.ToString();
			}
			catch ( Exception ex )
			{
				this.txtOutput.Text = ex.StackTrace;
				MessageBox.Show( ex.Message );
			}
        }
		
    }
}

namespace RandomizeTestForm
{
    partial class TestForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.btnTest = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.txtLeft = new System.Windows.Forms.TextBox();
			this.split = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoOrderOptionKeepOrigin = new System.Windows.Forms.RadioButton();
			this.rdoOrderOptionRandom = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
			this.split.Panel1.SuspendLayout();
			this.split.Panel2.SuspendLayout();
			this.split.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnTest
			// 
			this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTest.Location = new System.Drawing.Point(15, 14);
			this.btnTest.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(931, 70);
			this.btnTest.TabIndex = 0;
			this.btnTest.Text = "TEST";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.Color.Black;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.ForeColor = System.Drawing.Color.LightCyan;
			this.txtOutput.Location = new System.Drawing.Point(0, 0);
			this.txtOutput.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(506, 316);
			this.txtOutput.TabIndex = 1;
			// 
			// txtLeft
			// 
			this.txtLeft.BackColor = System.Drawing.Color.Black;
			this.txtLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLeft.ForeColor = System.Drawing.Color.Pink;
			this.txtLeft.Location = new System.Drawing.Point(0, 0);
			this.txtLeft.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.txtLeft.Multiline = true;
			this.txtLeft.Name = "txtLeft";
			this.txtLeft.ReadOnly = true;
			this.txtLeft.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLeft.Size = new System.Drawing.Size(423, 316);
			this.txtLeft.TabIndex = 2;
			// 
			// split
			// 
			this.split.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.split.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.split.Location = new System.Drawing.Point(12, 162);
			this.split.Name = "split";
			// 
			// split.Panel1
			// 
			this.split.Panel1.Controls.Add(this.txtLeft);
			// 
			// split.Panel2
			// 
			this.split.Panel2.Controls.Add(this.txtOutput);
			this.split.Size = new System.Drawing.Size(937, 318);
			this.split.SplitterDistance = 425;
			this.split.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoOrderOptionRandom);
			this.groupBox1.Controls.Add(this.rdoOrderOptionKeepOrigin);
			this.groupBox1.Location = new System.Drawing.Point(13, 92);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(936, 64);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "並び順オプション";
			// 
			// rdoOrderOptionKeepOrigin
			// 
			this.rdoOrderOptionKeepOrigin.AutoSize = true;
			this.rdoOrderOptionKeepOrigin.Checked = true;
			this.rdoOrderOptionKeepOrigin.Location = new System.Drawing.Point(19, 27);
			this.rdoOrderOptionKeepOrigin.Name = "rdoOrderOptionKeepOrigin";
			this.rdoOrderOptionKeepOrigin.Size = new System.Drawing.Size(270, 25);
			this.rdoOrderOptionKeepOrigin.TabIndex = 0;
			this.rdoOrderOptionKeepOrigin.TabStop = true;
			this.rdoOrderOptionKeepOrigin.Text = "もとの並び順を維持する";
			this.rdoOrderOptionKeepOrigin.UseVisualStyleBackColor = true;
			// 
			// rdoOrderOptionRandom
			// 
			this.rdoOrderOptionRandom.AutoSize = true;
			this.rdoOrderOptionRandom.Location = new System.Drawing.Point(295, 27);
			this.rdoOrderOptionRandom.Name = "rdoOrderOptionRandom";
			this.rdoOrderOptionRandom.Size = new System.Drawing.Size(248, 25);
			this.rdoOrderOptionRandom.TabIndex = 1;
			this.rdoOrderOptionRandom.Text = "ランダムに並び替える";
			this.rdoOrderOptionRandom.UseVisualStyleBackColor = true;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(961, 492);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.split);
			this.Controls.Add(this.btnTest);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
			this.Name = "TestForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.TestForm_Load);
			this.split.Panel1.ResumeLayout(false);
			this.split.Panel1.PerformLayout();
			this.split.Panel2.ResumeLayout(false);
			this.split.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
			this.split.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TextBox txtLeft;
		private System.Windows.Forms.SplitContainer split;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdoOrderOptionRandom;
		private System.Windows.Forms.RadioButton rdoOrderOptionKeepOrigin;
	}
}


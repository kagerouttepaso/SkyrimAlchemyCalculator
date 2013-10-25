namespace SkyrimAlchemyCalculator {
	partial class Form1 {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.調合計算 = new System.Windows.Forms.Button();
			this.debugTextBox = new System.Windows.Forms.TextBox();
			this.checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// 調合計算
			// 
			this.調合計算.Dock = System.Windows.Forms.DockStyle.Fill;
			this.調合計算.Location = new System.Drawing.Point(153, 437);
			this.調合計算.Name = "調合計算";
			this.調合計算.Size = new System.Drawing.Size(487, 44);
			this.調合計算.TabIndex = 0;
			this.調合計算.Text = "button1";
			this.調合計算.UseVisualStyleBackColor = true;
			this.調合計算.Click += new System.EventHandler(this.button1_Click);
			// 
			// debugTextBox
			// 
			this.debugTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.debugTextBox.Location = new System.Drawing.Point(153, 3);
			this.debugTextBox.Multiline = true;
			this.debugTextBox.Name = "debugTextBox";
			this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.debugTextBox.Size = new System.Drawing.Size(487, 428);
			this.debugTextBox.TabIndex = 1;
			// 
			// checkedListBox
			// 
			this.checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkedListBox.FormattingEnabled = true;
			this.checkedListBox.Location = new System.Drawing.Point(3, 3);
			this.checkedListBox.Name = "checkedListBox";
			this.tableLayoutPanel1.SetRowSpan(this.checkedListBox, 2);
			this.checkedListBox.Size = new System.Drawing.Size(144, 478);
			this.checkedListBox.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.checkedListBox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.調合計算, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.debugTextBox, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 484);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(643, 484);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button 調合計算;
		private System.Windows.Forms.TextBox debugTextBox;
		private System.Windows.Forms.CheckedListBox checkedListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}


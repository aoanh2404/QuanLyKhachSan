namespace DesignForm.Forms
{
	partial class QLDichVu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLDichVu));
			this.panel2 = new System.Windows.Forms.Panel();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.cbLoaidv = new System.Windows.Forms.ComboBox();
			this.txtMadv = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTendv = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSoluong = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtGia = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dataGridView2);
			this.panel2.Controls.Add(this.cbLoaidv);
			this.panel2.Controls.Add(this.txtMadv);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.txtTendv);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.txtSoluong);
			this.panel2.Controls.Add(this.label14);
			this.panel2.Controls.Add(this.txtGia);
			this.panel2.Controls.Add(this.label16);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 10);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(938, 176);
			this.panel2.TabIndex = 0;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.AllowUserToResizeRows = false;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.EnableHeadersVisualStyles = false;
			this.dataGridView2.Location = new System.Drawing.Point(355, 9);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(578, 154);
			this.dataGridView2.TabIndex = 10;
			this.dataGridView2.TabStop = false;
			// 
			// cbLoaidv
			// 
			this.cbLoaidv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLoaidv.FormattingEnabled = true;
			this.cbLoaidv.Items.AddRange(new object[] {
            "Đồ uống",
            "Du lịch",
            "Khác",
            "Món ăn"});
			this.cbLoaidv.Location = new System.Drawing.Point(94, 9);
			this.cbLoaidv.Name = "cbLoaidv";
			this.cbLoaidv.Size = new System.Drawing.Size(121, 26);
			this.cbLoaidv.Sorted = true;
			this.cbLoaidv.TabIndex = 0;
			// 
			// txtMadv
			// 
			this.txtMadv.Location = new System.Drawing.Point(94, 43);
			this.txtMadv.Name = "txtMadv";
			this.txtMadv.Size = new System.Drawing.Size(235, 24);
			this.txtMadv.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(6, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Mã DV";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtTendv
			// 
			this.txtTendv.Location = new System.Drawing.Point(94, 75);
			this.txtTendv.Name = "txtTendv";
			this.txtTendv.Size = new System.Drawing.Size(235, 24);
			this.txtTendv.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(6, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "Loại DV";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Black;
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(6, 139);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 24);
			this.label9.TabIndex = 8;
			this.label9.Text = "Giá";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSoluong
			// 
			this.txtSoluong.Location = new System.Drawing.Point(94, 107);
			this.txtSoluong.Name = "txtSoluong";
			this.txtSoluong.Size = new System.Drawing.Size(235, 24);
			this.txtSoluong.TabIndex = 3;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Black;
			this.label14.ForeColor = System.Drawing.Color.White;
			this.label14.Location = new System.Drawing.Point(6, 107);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 24);
			this.label14.TabIndex = 6;
			this.label14.Text = "Số Lượng";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtGia
			// 
			this.txtGia.Location = new System.Drawing.Point(94, 139);
			this.txtGia.Name = "txtGia";
			this.txtGia.Size = new System.Drawing.Size(235, 24);
			this.txtGia.TabIndex = 4;
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Black;
			this.label16.ForeColor = System.Drawing.Color.White;
			this.label16.Location = new System.Drawing.Point(6, 75);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 24);
			this.label16.TabIndex = 4;
			this.label16.Text = "Tên DV";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BackColor = System.Drawing.SystemColors.Menu;
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.btnReset);
			this.panel5.Controls.Add(this.btnXoa);
			this.panel5.Controls.Add(this.btnSua);
			this.panel5.Controls.Add(this.btnThem);
			this.panel5.Location = new System.Drawing.Point(10, 187);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(938, 46);
			this.panel5.TabIndex = 1;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Location = new System.Drawing.Point(730, 9);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(88, 28);
			this.btnReset.TabIndex = 9;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnXoa
			// 
			this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnXoa.Location = new System.Drawing.Point(529, 8);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(88, 28);
			this.btnXoa.TabIndex = 8;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.UseVisualStyleBackColor = true;
			this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
			// 
			// btnSua
			// 
			this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSua.Location = new System.Drawing.Point(328, 8);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(88, 28);
			this.btnSua.TabIndex = 7;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
			// 
			// btnThem
			// 
			this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThem.Location = new System.Drawing.Point(127, 9);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 28);
			this.btnThem.TabIndex = 6;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.RightToLeft = true;
			// 
			// QLDichVu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(958, 240);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "QLDichVu";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý dịch vụ";
			this.Load += new System.EventHandler(this.QLDichVu_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtGia;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSoluong;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtTendv;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtMadv;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnXoa;
		private System.Windows.Forms.Button btnSua;
		private System.Windows.Forms.Button btnThem;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.ComboBox cbLoaidv;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.Button btnReset;
	}
}
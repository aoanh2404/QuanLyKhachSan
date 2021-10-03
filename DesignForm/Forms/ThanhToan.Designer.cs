namespace DesignForm.Forms
{
	partial class ThanhToan
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThanhToan));
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.dateNgaydi = new System.Windows.Forms.DateTimePicker();
			this.dateNgayden = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtGiaP = new System.Windows.Forms.TextBox();
			this.txtTong = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMaPhong = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMaKH = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtTenKH = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnThanhToan = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtMaP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLoaiP = new System.Windows.Forms.TextBox();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label2.Location = new System.Drawing.Point(11, 143);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Chi tiết đặt phòng";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.CadetBlue;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.txtLoaiP);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.dateNgaydi);
			this.panel3.Controls.Add(this.dateNgayden);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.txtGiaP);
			this.panel3.Controls.Add(this.txtTong);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtMaPhong);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Location = new System.Drawing.Point(11, 170);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(813, 93);
			this.panel3.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Black;
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(15, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 24);
			this.label6.TabIndex = 2;
			this.label6.Text = "Loại phòng";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dateNgaydi
			// 
			this.dateNgaydi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateNgaydi.CustomFormat = "yyyy/MM/dd HH:mm";
			this.dateNgaydi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateNgaydi.Location = new System.Drawing.Point(599, 33);
			this.dateNgaydi.MaxDate = new System.DateTime(2079, 12, 31, 0, 0, 0, 0);
			this.dateNgaydi.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dateNgaydi.Name = "dateNgaydi";
			this.dateNgaydi.Size = new System.Drawing.Size(149, 24);
			this.dateNgaydi.TabIndex = 9;
			// 
			// dateNgayden
			// 
			this.dateNgayden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateNgayden.CustomFormat = "yyyy/MM/dd HH:mm";
			this.dateNgayden.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateNgayden.Location = new System.Drawing.Point(599, 3);
			this.dateNgayden.MaxDate = new System.DateTime(2079, 12, 31, 0, 0, 0, 0);
			this.dateNgayden.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dateNgayden.Name = "dateNgayden";
			this.dateNgayden.Size = new System.Drawing.Size(149, 24);
			this.dateNgayden.TabIndex = 7;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.BackColor = System.Drawing.Color.Black;
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(511, 33);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 24);
			this.label12.TabIndex = 8;
			this.label12.Text = "Ngày đi";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.BackColor = System.Drawing.Color.Black;
			this.label10.ForeColor = System.Drawing.Color.White;
			this.label10.Location = new System.Drawing.Point(511, 3);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 24);
			this.label10.TabIndex = 6;
			this.label10.Text = "Ngày đến";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Black;
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(15, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "Giá";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtGiaP
			// 
			this.txtGiaP.Location = new System.Drawing.Point(103, 63);
			this.txtGiaP.Name = "txtGiaP";
			this.txtGiaP.Size = new System.Drawing.Size(189, 24);
			this.txtGiaP.TabIndex = 5;
			// 
			// txtTong
			// 
			this.txtTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTong.Location = new System.Drawing.Point(599, 63);
			this.txtTong.Name = "txtTong";
			this.txtTong.Size = new System.Drawing.Size(189, 24);
			this.txtTong.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.BackColor = System.Drawing.Color.Black;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(511, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Tổng tiền";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtMaPhong
			// 
			this.txtMaPhong.Location = new System.Drawing.Point(103, 3);
			this.txtMaPhong.Name = "txtMaPhong";
			this.txtMaPhong.Size = new System.Drawing.Size(190, 24);
			this.txtMaPhong.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Black;
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(15, 3);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 24);
			this.label7.TabIndex = 0;
			this.label7.Text = "Mã Phòng";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label1.Location = new System.Drawing.Point(9, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Thông tin khách hàng";
			// 
			// txtMaKH
			// 
			this.txtMaKH.Location = new System.Drawing.Point(103, 3);
			this.txtMaKH.Name = "txtMaKH";
			this.txtMaKH.Size = new System.Drawing.Size(190, 24);
			this.txtMaKH.TabIndex = 1;
			// 
			// label15
			// 
			this.label15.BackColor = System.Drawing.Color.Black;
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(15, 3);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(88, 24);
			this.label15.TabIndex = 0;
			this.label15.Text = "Mã KH";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtTenKH
			// 
			this.txtTenKH.Location = new System.Drawing.Point(103, 37);
			this.txtTenKH.Name = "txtTenKH";
			this.txtTenKH.Size = new System.Drawing.Size(189, 24);
			this.txtTenKH.TabIndex = 3;
			// 
			// label16
			// 
			this.label16.BackColor = System.Drawing.Color.Black;
			this.label16.ForeColor = System.Drawing.Color.White;
			this.label16.Location = new System.Drawing.Point(15, 37);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 24);
			this.label16.TabIndex = 2;
			this.label16.Text = "Tên KH";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new System.Drawing.Point(8, 309);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(814, 60);
			this.dataGridView1.TabIndex = 5;
			this.dataGridView1.TabStop = false;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.RightToLeft = true;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.btnThanhToan);
			this.panel2.Location = new System.Drawing.Point(11, 270);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(813, 35);
			this.panel2.TabIndex = 50;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.button1.Location = new System.Drawing.Point(492, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(102, 28);
			this.button1.TabIndex = 1;
			this.button1.Text = "Đặt Lại";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnThanhToan
			// 
			this.btnThanhToan.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.btnThanhToan.Location = new System.Drawing.Point(218, 4);
			this.btnThanhToan.Name = "btnThanhToan";
			this.btnThanhToan.Size = new System.Drawing.Size(102, 28);
			this.btnThanhToan.TabIndex = 0;
			this.btnThanhToan.Text = "Thanh toán";
			this.btnThanhToan.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.BackColor = System.Drawing.Color.CadetBlue;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.txtDiaChi);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.txtSDT);
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.txtMaKH);
			this.panel4.Controls.Add(this.label15);
			this.panel4.Controls.Add(this.txtTenKH);
			this.panel4.Controls.Add(this.label16);
			this.panel4.Location = new System.Drawing.Point(9, 69);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(813, 68);
			this.panel4.TabIndex = 2;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Location = new System.Drawing.Point(609, 37);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(189, 24);
			this.txtDiaChi.TabIndex = 7;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.Black;
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(521, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 24);
			this.label9.TabIndex = 6;
			this.label9.Text = "Địa chỉ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(609, 3);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(189, 24);
			this.txtSDT.TabIndex = 5;
			// 
			// label14
			// 
			this.label14.BackColor = System.Drawing.Color.Black;
			this.label14.ForeColor = System.Drawing.Color.White;
			this.label14.Location = new System.Drawing.Point(521, 3);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 24);
			this.label14.TabIndex = 4;
			this.label14.Text = "SĐT";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Red;
			this.panel1.Controls.Add(this.txtMaP);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(823, 34);
			this.panel1.TabIndex = 0;
			// 
			// txtMaP
			// 
			this.txtMaP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtMaP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtMaP.Location = new System.Drawing.Point(103, 5);
			this.txtMaP.Name = "txtMaP";
			this.txtMaP.Size = new System.Drawing.Size(111, 24);
			this.txtMaP.TabIndex = 1;
			this.txtMaP.Validated += new System.EventHandler(this.txtMaP_Validated);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(15, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 0;
			this.label4.Text = "Mã phòng";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtLoaiP
			// 
			this.txtLoaiP.Location = new System.Drawing.Point(103, 33);
			this.txtLoaiP.Name = "txtLoaiP";
			this.txtLoaiP.Size = new System.Drawing.Size(189, 24);
			this.txtLoaiP.TabIndex = 12;
			// 
			// ThanhToan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(833, 381);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel4);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ThanhToan";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thanh Toán";
			this.Load += new System.EventHandler(this.ThanhToan_Load);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtGiaP;
		private System.Windows.Forms.TextBox txtTong;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMaPhong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMaKH;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtTenKH;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtDiaChi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSDT;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnThanhToan;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtMaP;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker dateNgaydi;
		private System.Windows.Forms.DateTimePicker dateNgayden;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtLoaiP;
	}
}
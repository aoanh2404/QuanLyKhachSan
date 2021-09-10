namespace DesignForm
{
    partial class QuanLyNhanVien
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyNhanVien));
			this.txtID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHoTen = new System.Windows.Forms.TextBox();
			this.txtDiachi = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.rdNam = new System.Windows.Forms.RadioButton();
			this.rdnu = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.cbChucvu = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dateNamSinh = new System.Windows.Forms.DateTimePicker();
			this.btnXoa = new System.Windows.Forms.Button();
			this.btnSua = new System.Windows.Forms.Button();
			this.btnThem = new System.Windows.Forms.Button();
			this.txtCMND = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLuong = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(100, 9);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(104, 24);
			this.txtID.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "ID";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(12, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Họ tên";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHoTen
			// 
			this.txtHoTen.Location = new System.Drawing.Point(100, 63);
			this.txtHoTen.Name = "txtHoTen";
			this.txtHoTen.Size = new System.Drawing.Size(258, 24);
			this.txtHoTen.TabIndex = 5;
			// 
			// txtDiachi
			// 
			this.txtDiachi.Location = new System.Drawing.Point(100, 117);
			this.txtDiachi.Name = "txtDiachi";
			this.txtDiachi.Size = new System.Drawing.Size(472, 24);
			this.txtDiachi.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Black;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(12, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "Địa chỉ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(12, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Năm sinh";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(100, 144);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(121, 24);
			this.txtSDT.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Black;
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(12, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 24);
			this.label5.TabIndex = 12;
			this.label5.Text = "SĐT";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rdNam
			// 
			this.rdNam.AutoSize = true;
			this.rdNam.Location = new System.Drawing.Point(242, 90);
			this.rdNam.Name = "rdNam";
			this.rdNam.Size = new System.Drawing.Size(58, 22);
			this.rdNam.TabIndex = 8;
			this.rdNam.TabStop = true;
			this.rdNam.Text = "Nam";
			this.rdNam.UseVisualStyleBackColor = true;
			// 
			// rdnu
			// 
			this.rdnu.AutoSize = true;
			this.rdnu.Location = new System.Drawing.Point(323, 90);
			this.rdnu.Name = "rdnu";
			this.rdnu.Size = new System.Drawing.Size(45, 22);
			this.rdnu.TabIndex = 9;
			this.rdnu.TabStop = true;
			this.rdnu.Text = "Nữ";
			this.rdnu.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Black;
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(12, 171);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 26);
			this.label6.TabIndex = 14;
			this.label6.Text = "Chức vụ";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbChucvu
			// 
			this.cbChucvu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbChucvu.FormattingEnabled = true;
			this.cbChucvu.Items.AddRange(new object[] {
            "Bảo vệ",
            "Kỹ thuật viên",
            "Lễ tân",
            "Nhân viên",
            "Quản lý",
            "Tạp vụ"});
			this.cbChucvu.Location = new System.Drawing.Point(100, 171);
			this.cbChucvu.Name = "cbChucvu";
			this.cbChucvu.Size = new System.Drawing.Size(121, 26);
			this.cbChucvu.Sorted = true;
			this.cbChucvu.TabIndex = 15;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Brown;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EnableHeadersVisualStyles = false;
			this.dataGridView1.Location = new System.Drawing.Point(12, 200);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Aqua;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(823, 150);
			this.dataGridView1.TabIndex = 18;
			this.dataGridView1.TabStop = false;
			// 
			// dateNamSinh
			// 
			this.dateNamSinh.CustomFormat = "yyyy/MM/dd";
			this.dateNamSinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateNamSinh.Location = new System.Drawing.Point(100, 90);
			this.dateNamSinh.MaxDate = new System.DateTime(2079, 12, 31, 0, 0, 0, 0);
			this.dateNamSinh.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dateNamSinh.Name = "dateNamSinh";
			this.dateNamSinh.Size = new System.Drawing.Size(111, 24);
			this.dateNamSinh.TabIndex = 7;
			// 
			// btnXoa
			// 
			this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnXoa.Location = new System.Drawing.Point(569, 169);
			this.btnXoa.Name = "btnXoa";
			this.btnXoa.Size = new System.Drawing.Size(88, 28);
			this.btnXoa.TabIndex = 20;
			this.btnXoa.Text = "Xoá";
			this.btnXoa.UseVisualStyleBackColor = true;
			// 
			// btnSua
			// 
			this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSua.Location = new System.Drawing.Point(664, 169);
			this.btnSua.Name = "btnSua";
			this.btnSua.Size = new System.Drawing.Size(88, 28);
			this.btnSua.TabIndex = 21;
			this.btnSua.Text = "Sửa";
			this.btnSua.UseVisualStyleBackColor = true;
			// 
			// btnThem
			// 
			this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnThem.Location = new System.Drawing.Point(475, 169);
			this.btnThem.Name = "btnThem";
			this.btnThem.Size = new System.Drawing.Size(88, 28);
			this.btnThem.TabIndex = 19;
			this.btnThem.Text = "Thêm";
			this.btnThem.UseVisualStyleBackColor = true;
			// 
			// txtCMND
			// 
			this.txtCMND.Location = new System.Drawing.Point(100, 36);
			this.txtCMND.Name = "txtCMND";
			this.txtCMND.Size = new System.Drawing.Size(177, 24);
			this.txtCMND.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Black;
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(12, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 24);
			this.label7.TabIndex = 2;
			this.label7.Text = "CMND";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtLuong
			// 
			this.txtLuong.Location = new System.Drawing.Point(316, 171);
			this.txtLuong.Name = "txtLuong";
			this.txtLuong.Size = new System.Drawing.Size(121, 24);
			this.txtLuong.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Black;
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(228, 171);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 24);
			this.label8.TabIndex = 16;
			this.label8.Text = "Lương";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			this.errorProvider1.RightToLeft = true;
			// 
			// btnReset
			// 
			this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReset.Location = new System.Drawing.Point(665, 12);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(88, 28);
			this.btnReset.TabIndex = 19;
			this.btnReset.Text = "ReSet";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// QuanLyNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(848, 358);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtCMND);
			this.Controls.Add(this.txtHoTen);
			this.Controls.Add(this.dateNamSinh);
			this.Controls.Add(this.rdNam);
			this.Controls.Add(this.rdnu);
			this.Controls.Add(this.txtDiachi);
			this.Controls.Add(this.txtSDT);
			this.Controls.Add(this.cbChucvu);
			this.Controls.Add(this.txtLuong);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnXoa);
			this.Controls.Add(this.btnSua);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnThem);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "QuanLyNhanVien";
			this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản Lý Nhân Viên";
			this.Load += new System.EventHandler(this.QuanLyNhanVien_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiachi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.RadioButton rdnu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbChucvu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateNamSinh;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnReset;
    }
}
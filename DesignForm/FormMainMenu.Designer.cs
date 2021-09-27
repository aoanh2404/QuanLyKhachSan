namespace DesignForm
{
	partial class FormMainMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenu));
			this.panelMenu = new System.Windows.Forms.Panel();
			this.panelLogo = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.panelTitleBar = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.pnlDesktop = new System.Windows.Forms.Panel();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.panelMenu.SuspendLayout();
			this.panelLogo.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.panelTitleBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelMenu
			// 
			this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
			this.panelMenu.Controls.Add(this.button8);
			this.panelMenu.Controls.Add(this.button7);
			this.panelMenu.Controls.Add(this.button6);
			this.panelMenu.Controls.Add(this.button5);
			this.panelMenu.Controls.Add(this.button4);
			this.panelMenu.Controls.Add(this.button3);
			this.panelMenu.Controls.Add(this.button2);
			this.panelMenu.Controls.Add(this.button1);
			this.panelMenu.Controls.Add(this.panelLogo);
			this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelMenu.Location = new System.Drawing.Point(0, 0);
			this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Size = new System.Drawing.Size(220, 581);
			this.panelMenu.TabIndex = 0;
			// 
			// panelLogo
			// 
			this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
			this.panelLogo.Controls.Add(this.menuStrip1);
			this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLogo.Location = new System.Drawing.Point(0, 0);
			this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
			this.panelLogo.Name = "panelLogo";
			this.panelLogo.Size = new System.Drawing.Size(220, 80);
			this.panelLogo.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(220, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// panelTitleBar
			// 
			this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
			this.panelTitleBar.Controls.Add(this.lblTitle);
			this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
			this.panelTitleBar.Name = "panelTitleBar";
			this.panelTitleBar.Size = new System.Drawing.Size(864, 80);
			this.panelTitleBar.TabIndex = 1;
			// 
			// lblTitle
			// 
			this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblTitle.Font = new System.Drawing.Font("MS PMincho", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.LavenderBlush;
			this.lblTitle.Location = new System.Drawing.Point(229, 28);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(406, 24);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "HOME";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlDesktop
			// 
			this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDesktop.Location = new System.Drawing.Point(220, 80);
			this.pnlDesktop.Name = "pnlDesktop";
			this.pnlDesktop.Size = new System.Drawing.Size(864, 501);
			this.pnlDesktop.TabIndex = 2;
			this.pnlDesktop.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlDesktop_PreviewKeyDown);
			// 
			// button8
			// 
			this.button8.Dock = System.Windows.Forms.DockStyle.Top;
			this.button8.FlatAppearance.BorderSize = 0;
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button8.ForeColor = System.Drawing.Color.Gainsboro;
			this.button8.Image = global::DesignForm.Properties.Resources.user;
			this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button8.Location = new System.Drawing.Point(0, 500);
			this.button8.Margin = new System.Windows.Forms.Padding(4);
			this.button8.Name = "button8";
			this.button8.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button8.Size = new System.Drawing.Size(220, 60);
			this.button8.TabIndex = 7;
			this.button8.TabStop = false;
			this.button8.Text = "   Khách hàng";
			this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Visible = false;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button7
			// 
			this.button7.Dock = System.Windows.Forms.DockStyle.Top;
			this.button7.FlatAppearance.BorderSize = 0;
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button7.ForeColor = System.Drawing.Color.Gainsboro;
			this.button7.Image = global::DesignForm.Properties.Resources.food_tray;
			this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button7.Location = new System.Drawing.Point(0, 440);
			this.button7.Margin = new System.Windows.Forms.Padding(4);
			this.button7.Name = "button7";
			this.button7.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button7.Size = new System.Drawing.Size(220, 60);
			this.button7.TabIndex = 6;
			this.button7.TabStop = false;
			this.button7.Text = "   Quản lý dịch vụ";
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Visible = false;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Dock = System.Windows.Forms.DockStyle.Top;
			this.button6.FlatAppearance.BorderSize = 0;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.ForeColor = System.Drawing.Color.Gainsboro;
			this.button6.Image = global::DesignForm.Properties.Resources.maintenance;
			this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.Location = new System.Drawing.Point(0, 380);
			this.button6.Margin = new System.Windows.Forms.Padding(4);
			this.button6.Name = "button6";
			this.button6.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button6.Size = new System.Drawing.Size(220, 60);
			this.button6.TabIndex = 5;
			this.button6.TabStop = false;
			this.button6.Text = "   Thiết bị";
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Visible = false;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Dock = System.Windows.Forms.DockStyle.Top;
			this.button5.FlatAppearance.BorderSize = 0;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.ForeColor = System.Drawing.Color.Gainsboro;
			this.button5.Image = global::DesignForm.Properties.Resources.management;
			this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.Location = new System.Drawing.Point(0, 320);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button5.Size = new System.Drawing.Size(220, 60);
			this.button5.TabIndex = 4;
			this.button5.TabStop = false;
			this.button5.Text = "   User";
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Visible = false;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Dock = System.Windows.Forms.DockStyle.Top;
			this.button4.FlatAppearance.BorderSize = 0;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.Gainsboro;
			this.button4.Image = global::DesignForm.Properties.Resources.relationship;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new System.Drawing.Point(0, 260);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button4.Size = new System.Drawing.Size(220, 60);
			this.button4.TabIndex = 3;
			this.button4.TabStop = false;
			this.button4.Text = "  Nhân viên";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Visible = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Dock = System.Windows.Forms.DockStyle.Top;
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.Color.Gainsboro;
			this.button3.Image = global::DesignForm.Properties.Resources.hotelpay;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new System.Drawing.Point(0, 200);
			this.button3.Margin = new System.Windows.Forms.Padding(4);
			this.button3.Name = "button3";
			this.button3.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button3.Size = new System.Drawing.Size(220, 60);
			this.button3.TabIndex = 2;
			this.button3.TabStop = false;
			this.button3.Text = "  Thanh toán";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Dock = System.Windows.Forms.DockStyle.Top;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.Gainsboro;
			this.button2.Image = global::DesignForm.Properties.Resources.room_service;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(0, 140);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button2.Size = new System.Drawing.Size(220, 60);
			this.button2.TabIndex = 1;
			this.button2.TabStop = false;
			this.button2.Text = "  Dịch vụ";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Cursor = System.Windows.Forms.Cursors.Default;
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.button1.ForeColor = System.Drawing.Color.Gainsboro;
			this.button1.Image = global::DesignForm.Properties.Resources.room_1;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(0, 80);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
			this.button1.Size = new System.Drawing.Size(220, 60);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Text = "   Phòng";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem1.Image = global::DesignForm.Properties.Resources.iconLogout;
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(89, 20);
			this.toolStripMenuItem1.Text = "Đăng xuất";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.ForeColor = System.Drawing.Color.White;
			this.toolStripMenuItem2.Image = global::DesignForm.Properties.Resources.pass;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(106, 20);
			this.toolStripMenuItem2.Text = "Đổi mật khẩu";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// FormMainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 581);
			this.Controls.Add(this.pnlDesktop);
			this.Controls.Add(this.panelTitleBar);
			this.Controls.Add(this.panelMenu);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormMainMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hotel ABCDEF";
			this.Load += new System.EventHandler(this.FormMainMenu_Load);
			this.panelMenu.ResumeLayout(false);
			this.panelLogo.ResumeLayout(false);
			this.panelLogo.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelTitleBar.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelMenu;
		private System.Windows.Forms.Panel panelLogo;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panelTitleBar;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlDesktop;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button8;
	}
}


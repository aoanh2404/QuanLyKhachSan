using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignForm
{
    public partial class ChangePass : Form
    {
        private string strPassOld = string.Empty;
        private string strID = string.Empty;
        public int ischange
        { get; set; }

        public ChangePass(object[] param)
        {
            InitializeComponent();
            this.strID = param[0].ToString();
            this.strPassOld = param[1].ToString(); 
        } 

        private void ChangePass_Load(object sender, EventArgs e)
        {
			LoadThem();
			Event();
        }

		private void LoadThem()
		{
			if(ThemColor.PrimaryColor.Name.Equals("0"))
			{
				return;
			}

			foreach (Control btn in this.Controls)
			{
				if (btn.GetType() == typeof(Button))
				{
					Button btns = (Button)btn;
					btns.BackColor = ThemColor.PrimaryColor;
					btns.ForeColor = System.Drawing.Color.White;
					btns.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
				}
			}
		}

		#region EVENT
		private void Event()
        {
            this.btnUpdate.Click += BtnUpdate_Click;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(this.txtOldPass.Text))
                {
                    MessageBox.Show("Chưa nhập PassWord cũ!", "Thông báo");
                    this.txtOldPass.Focus();
                    return;
                }

                if (!this.txtOldPass.Text.Equals(this.strPassOld))
                {
                    MessageBox.Show("PassWord cu khong trung khop!", "Thông báo");
                    this.txtOldPass.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtNewPass.Text))
                {
                    MessageBox.Show("Chưa nhập PassWord moi!", "Thông báo");
                    this.txtNewPass.Focus();
                    return;
                }
                string strSQL = "UPDATE USERKS SET PASS = @PASS WHERE MANV = @IDUSER";
                SqlConnection conn = Database.GetDBConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("@PASS", this.txtNewPass.Text);
                cmd.Parameters.AddWithValue("@IDUSER", this.strID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update thanh Cong!", "Thông báo");
                ischange = 1;
                this.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}

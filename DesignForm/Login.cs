using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesignForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Event();
        }

        #region EVENT
        private void Event()
        {
            this.btnLogin.Click += BtnLogin_Click;
            this.FormClosing += Login_FormClosing;
            this.FormClosed += Login_FormClosed;
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.btnLogin.Click -= BtnLogin_Click;
                this.FormClosing -= Login_FormClosing;
                this.FormClosed -= Login_FormClosed;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtUserName.Text))
            {
                MessageBox.Show("Chưa nhập UserName!", "Thông báo");
                this.txtUserName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(this.txtPassWord.Text))
            {
                MessageBox.Show("Chưa nhập PassWord!", "Thông báo");
                this.txtPassWord.Focus();
                return;
            }

            string strSql = "SELECT UKS.MANV, UKS.USENAME, UKS.PASS, UKS.QUYENHAN, UKS.NGAYTAO, NV.NAME FROM USERKS UKS INNER JOIN NHANVIEN NV ON UKS.MANV = NV.MANV  WHERE USENAME = @USENAME COLLATE SQL_LATIN1_GENERAL_CP1_CS_AS AND PASS = @PASS COLLATE SQL_LATIN1_GENERAL_CP1_CS_AS";
            SqlConnection conn = Database.GetDBConnection();
            conn.Open();
            DataTable dtSource = new DataTable();
            SqlCommand sqlcmd = new SqlCommand(strSql, conn);
            sqlcmd.Parameters.AddWithValue("@USENAME",this.txtUserName.Text);
            sqlcmd.Parameters.AddWithValue("@PASS",this.txtPassWord.Text);
            dtSource.Load(sqlcmd.ExecuteReader());
            conn.Close();
            if(dtSource==null || dtSource.Rows.Count==0)
            {
                MessageBox.Show("UserName hoặc Password đã sai hoặc không tồn tại user!", "Thông báo");
                this.txtUserName.Focus();
                return;
            }

			FormMainMenu frm = new FormMainMenu(new object[] {dtSource.Rows[0]["NAME"].ToString(), dtSource.Rows[0]["QUYENHAN"].ToString(),
                dtSource.Rows[0]["PASS"].ToString(),dtSource.Rows[0]["MANV"].ToString()});
            frm.FormClosing += Menu_FormClosing;
            frm.Show();
            this.Visible = false;
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
            this.txtPassWord.Text = string.Empty;
        }
        #endregion
    }
}

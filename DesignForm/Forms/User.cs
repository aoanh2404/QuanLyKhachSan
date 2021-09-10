using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesignForm
{
	public partial class User : Form
	{
		public User()
		{
			InitializeComponent();
		}

		private void User_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			this.dataGridView1.KeyDown += DataGridView1_Key;
			this.dataGridView1.KeyUp += DataGridView1_Key;

			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Validated += ClearError_Validated;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).Validated += ClearError_Validated;
				}
			}
			SetDefaultMH();
		}

		private void LoadThem()
		{
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

		private void ClearError_Validated(object sender, EventArgs e)
		{
			try
			{
				this.errorProvider1.SetError((sender as Control), string.Empty);
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void LoadDataGrid()
		{
			string strSQL = "SELECT UKS.MANV, NV.NAME, USENAME, PASS,(CASE WHEN QUYENHAN = 0 THEN N'ADMIN' WHEN QUYENHAN = 1 THEN N'QUẢN LÝ' ELSE N'NHÂN VIÊN' END) AS QUYENHAN, " +
							 "NGAYTAO FROM USERKS UKS INNER JOIN NHANVIEN NV ON UKS.MANV = NV.MANV WHERE UKS.MANV != '2021000' ORDER BY UKS.MANV";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(dtdata);
		}

		private void btnTimID_Click(object sender, EventArgs e)
		{
			try
			{
				SearchUser frmSearch = new SearchUser();
				frmSearch.FormClosing += frmSearch_FormClosing;
				frmSearch.ShowDialog();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				DataRow drData = null;
				drData = (sender as SearchUser).drUserID;
				if (drData != null)
				{
					this.txtIDUser.Text = drData[0].ToString();
					this.txtHoten.Text = drData[1].ToString();
					this.txtUserName.Text = string.Empty;
					this.cbQuyenHan.SelectedIndex = -1;
				}

				ClearError();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if(this.txtIDUser.Text.Equals(string.Empty))
				{
					MessageBox.Show("Chưa nhập ID thông tin!");
					return;
				}

				if (!CheckERorr())
				{
					MessageBox.Show("Chưa nhập đủ thông tin!");
					return;
				}

				DataTable dtData = (this.dataGridView1.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MANV = '" + this.txtIDUser.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length > 0)
				{
					MessageBox.Show("Mã user đã tồn tại!");
					return;
				}

				DataRow[] dr2= dtData.Select("USENAME = '" + this.txtUserName.Text.ToString().Trim() + "'", string.Empty);

				if (dr2.Length > 0)
				{
					MessageBox.Show("Mã user đã tồn tại!");
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn thêm không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "INSERT INTO USERKS VALUES(@MANV, @USENAME, @PASS,@QUYENHAN,GETDATE())";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@MANV", this.txtIDUser.Text);
					cmd.Parameters.AddWithValue("@USENAME", this.txtUserName.Text);
					cmd.Parameters.AddWithValue("@PASS", "1111");
					cmd.Parameters.AddWithValue("@QUYENHAN", this.cbQuyenHan.SelectedIndex);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					MessageBox.Show("Thực hiện thành công!");
					SetDefaultMH();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private bool CheckERorr()
		{
			ArrayList ctrlEror = new ArrayList();

			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
				{
					ctrlEror.Add(ctrl);
				}
				else if ((ctrl is ComboBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
				{
					ctrlEror.Add(ctrl);
				}
			}

			if (ctrlEror.Count > 0)
			{
				for (int i = 0; i < ctrlEror.Count; i++)
				{
					this.errorProvider1.SetError((ctrlEror[i] as Control), "ERROR");
				}
				(ctrlEror[0] as Control).Focus();
				return false;
			}
			else
			{
				return true;
			}
		}

		private void ClearError()
		{
			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					this.errorProvider1.SetError((ctrl as Control), string.Empty);
				}

				if ((ctrl is ComboBox))
				{
					this.errorProvider1.SetError((ctrl as Control), string.Empty);
				}
			}
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (string.IsNullOrEmpty(this.txtIDUser.Text))
				{
					MessageBox.Show("Không có dữ liệu để xoá!");
					return;
				}
				
			   DataTable dtData = (this.dataGridView1.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MANV = '" + this.txtIDUser.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length == 0)
				{
					MessageBox.Show("Mã user không tồn tại!");
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xoá không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "DELETE FROM USERKS WHERE MANV = @MANV";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@MANV", this.txtIDUser.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					MessageBox.Show("Thực hiện thành công!");
					SetDefaultMH();
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			ClearError();

			if (this.txtIDUser.Text.Equals(string.Empty))
			{
				MessageBox.Show("Chưa nhập ID thông tin!");
				return;
			}

			DataTable dtData = (this.dataGridView1.DataSource as DataTable);

			DataRow[] dr = dtData.Select("MANV = '" + this.txtIDUser.Text.ToString().Trim() + "'", string.Empty);

			if (dr.Length == 0)
			{
				MessageBox.Show("Mã user không tồn tại!");
				return;
			}

			DataRow[] dr2 = dtData.Select("USENAME = '" + this.txtUserName.Text.ToString().Trim() + "'", string.Empty);

			if (dr2.Length > 0)
			{
				MessageBox.Show("Mã user đã tồn tại!");
				return;
			}

			if (!CheckERorr())
			{
				MessageBox.Show("Chưa nhập đủ thông tin!");
				return;
			}

			if (IsChangedMH())
			{
				MessageBox.Show("Không có dữ liệu thay đổi!");
				return;
			}

			DialogResult dlg = MessageBox.Show("Bạn có chắc muốn sữa không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dlg == DialogResult.Yes)
			{
				String strSql = "UPDATE USERKS SET USENAME = @USENAME, QUYENHAN = @QUYENHAN WHERE MANV = @MANV";
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSql, conn);
				cmd.Parameters.AddWithValue("@USENAME", this.txtUserName.Text);
				cmd.Parameters.AddWithValue("@QUYENHAN", this.cbQuyenHan.SelectedIndex);
				cmd.Parameters.AddWithValue("@MANV", this.txtIDUser.Text);
				cmd.ExecuteNonQuery();
				conn.Close();
				LoadDataGrid();
				MessageBox.Show("Thực hiện thành công!");
				SetDefaultMH();
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearError();

			DataTable dtData = (this.dataGridView1.DataSource as DataTable);

			DataRow[] dr = dtData.Select("MANV = '" + this.txtIDUser.Text.ToString().Trim() + "'", string.Empty);

			if (dr.Length == 0)
			{
				MessageBox.Show("Mã user không tồn tại!");
				return;
			}

			DialogResult dlg = MessageBox.Show("Bạn có chắc muốn sữa không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dlg == DialogResult.Yes)
			{
				String strSql = "UPDATE USERKS SET PASS = @PASS WHERE MANV = @MANV";
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSql, conn);
				cmd.Parameters.AddWithValue("@PASS", "1111");
				cmd.Parameters.AddWithValue("@MANV", this.txtIDUser.Text);
				cmd.ExecuteNonQuery();
				conn.Close();
				LoadDataGrid();
				MessageBox.Show("Thực hiện thành công!");
				SetDefaultMH();
			}
		}

		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["MANV"].HeaderText = "MÃ NV";
			this.dataGridView1.Columns["NAME"].HeaderText = "Họ tên";
			this.dataGridView1.Columns["USENAME"].HeaderText = "User name";
			this.dataGridView1.Columns["PASS"].HeaderText = "Pass word";
			this.dataGridView1.Columns["QUYENHAN"].HeaderText = "Quyền hạn";
			this.dataGridView1.Columns["NGAYTAO"].HeaderText = "Ngày tạo";
		}

		private void DataGridView1_Key(object sender, KeyEventArgs e)
		{
			try
			{
				ClearError();
				this.txtIDUser.Text = this.dataGridView1.CurrentRow.Cells["MANV"].Value.ToString();
				this.txtHoten.Text = this.dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
				this.txtUserName.Text = this.dataGridView1.CurrentRow.Cells["USENAME"].Value.ToString();
				this.cbQuyenHan.Text = this.dataGridView1.CurrentRow.Cells["QUYENHAN"].Value.ToString();
				SaveMH();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ClearError();
				this.txtIDUser.Text = this.dataGridView1.CurrentRow.Cells["MANV"].Value.ToString();
				this.txtHoten.Text = this.dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
				this.txtUserName.Text = this.dataGridView1.CurrentRow.Cells["USENAME"].Value.ToString();
				this.cbQuyenHan.Text = this.dataGridView1.CurrentRow.Cells["QUYENHAN"].Value.ToString();
				SaveMH();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void SaveMH()
		{
			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Tag = (ctrl as TextBox).Text;
				}
				else if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).Tag = (ctrl as ComboBox).SelectedIndex;
				}
			}
		}

		private bool IsChangedMH()
		{
			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					if (!Comparer.Equals((ctrl as TextBox).Tag, (ctrl as TextBox).Text))
					{
						return false;
					}
				}
				else if ((ctrl is ComboBox))
				{
					if (!Comparer.Equals((ctrl as ComboBox).Tag, (ctrl as ComboBox).SelectedIndex))
					{
						return false;
					}
				}

			}
			return true;
		}

		private void SetDefaultMH()
		{
			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}
				else if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).SelectedIndex = -1;
				}
			}
			SaveMH();
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignForm.Forms
{
	public partial class QLDichVu : Form
	{
		private DataTable dtSoucre = new DataTable();
		public QLDichVu()
		{
			InitializeComponent();
		}

		private void QLDichVu_Load(object sender, EventArgs e)
		{
			LoadDataGrid();
			LoadThem();
			this.dataGridView2.CellClick += DataGridView1_CellClick;
			this.dataGridView2.KeyDown += DataGridView1_Key;
			this.dataGridView2.KeyUp += DataGridView1_Key;
			foreach (Control ctrl in this.panel2.Controls)
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
			this.cbLoaidv.SelectedIndexChanged += CbLoaidv_SelectedIndexChanged;
			SetDefaultMH();
		}

		private void CbLoaidv_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DataRow[] dtData = new DataRow[] { };
				dtData = this.dtSoucre.Select("LOAIDV = '" + this.cbLoaidv.Text + "'");

				DataTable dt = new DataTable();
				dt = this.dtSoucre.Clone();

				foreach (DataRow dr in dtData)
				{
					dt.Rows.Add(dr.ItemArray);
				}

				SetDataGrid(dt);
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel5.Controls)
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

		private void DataGridView1_Key(object sender, KeyEventArgs e)
		{
			try
			{
				this.txtMadv.Text = this.dataGridView2.CurrentRow.Cells["MADV"].Value.ToString();
				this.txtTendv.Text = this.dataGridView2.CurrentRow.Cells["TENDV"].Value.ToString();
				this.txtSoluong.Text = this.dataGridView2.CurrentRow.Cells["SOLUONG"].Value.ToString();
				this.txtGia.Text = this.dataGridView2.CurrentRow.Cells["GIA1DONVI"].Value.ToString();
				this.cbLoaidv.Text = this.dataGridView2.CurrentRow.Cells["LOAIDV"].Value.ToString();
				this.txtMadv.Enabled = false;
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
				this.txtMadv.Text = this.dataGridView2.CurrentRow.Cells["MADV"].Value.ToString();
				this.txtTendv.Text = this.dataGridView2.CurrentRow.Cells["TENDV"].Value.ToString();
				this.txtSoluong.Text = this.dataGridView2.CurrentRow.Cells["SOLUONG"].Value.ToString();
				this.txtGia.Text = this.dataGridView2.CurrentRow.Cells["GIA1DONVI"].Value.ToString();
				this.cbLoaidv.Text = this.dataGridView2.CurrentRow.Cells["LOAIDV"].Value.ToString();
				this.txtMadv.Enabled = false;
				SaveMH();
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void LoadDataGrid()
		{
			string strSQL = "SELECT * FROM DICHVU";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			this.dtSoucre = dtdata;
		}

		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView2.DataSource = dtData;
			this.dataGridView2.Columns["MADV"].HeaderText = "Mã dịch vụ";
			this.dataGridView2.Columns["LOAIDV"].HeaderText = "Loại";
			this.dataGridView2.Columns["TENDV"].HeaderText = "Tên";
			this.dataGridView2.Columns["SOLUONG"].HeaderText = "Số lượng";
			this.dataGridView2.Columns["GIA1DONVI"].HeaderText = "Giá";
		}
		private bool CheckERorr()
		{
			ArrayList ctrlEror = new ArrayList();

			foreach (Control ctrl in this.panel2.Controls)
			{
				if ((ctrl is TextBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
				{
					ctrlEror.Add(ctrl);
				}

				if ((ctrl is ComboBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
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
			foreach (Control ctrl in this.panel2.Controls)
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

		private void SaveMH()
		{
			foreach (Control ctrl in this.panel2.Controls)
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
			foreach (Control ctrl in this.panel2.Controls)
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
			foreach (Control ctrl in this.panel2.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}
				else if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).SelectedIndex = 0;
				}
			}
			SaveMH();
			this.txtMadv.Enabled = true;
			this.txtMadv.Focus();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Chưa nhập đủ thông tin!");
					return;
				}

				DataTable dtData = (this.dataGridView2.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MADV = '" + this.txtMadv.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length > 0)
				{
					MessageBox.Show("Mã dịch vụ đã tồn tại!");
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn thêm không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "INSERT INTO DICHVU VALUES(@MADV, @LOAIDV, @TENDV,@SOLUONG,@GIA1DONVI)";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@MADV", this.txtMadv.Text);
					cmd.Parameters.AddWithValue("@LOAIDV", this.cbLoaidv.Text);
					cmd.Parameters.AddWithValue("@TENDV", this.txtTendv.Text);
					cmd.Parameters.AddWithValue("@SOLUONG", string.IsNullOrEmpty(this.txtSoluong.Text) ? "0" : this.txtSoluong.Text);
					cmd.Parameters.AddWithValue("@GIA1DONVI", string.IsNullOrEmpty(this.txtGia.Text) ? "0" : this.txtGia.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					SetDefaultMH();
					CbLoaidv_SelectedIndexChanged(null, null);
					MessageBox.Show("Thực hiện thành công!");
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

			DataTable dtData = (this.dataGridView2.DataSource as DataTable);

			DataRow[] dr = dtData.Select("MADV = '" + this.txtMadv.Text.ToString().Trim() + "'", string.Empty);

			if (dr.Length == 0)
			{
				MessageBox.Show("Mã dịch vụ không tồn tại!");
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
				String strSql = "UPDATE DICHVU SET LOAIDV = @LOAIDV, TENDV = @TENDV, SOLUONG = @SOLUONG, GIA1DONVI = @GIA1DONVI WHERE MADV = @MADV";
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSql, conn);
				cmd.Parameters.AddWithValue("@MADV", this.txtMadv.Text);
				cmd.Parameters.AddWithValue("@LOAIDV", this.cbLoaidv.Text);
				cmd.Parameters.AddWithValue("@TENDV", this.txtTendv.Text);
				cmd.Parameters.AddWithValue("@SOLUONG", this.txtSoluong.Text);
				cmd.Parameters.AddWithValue("@GIA1DONVI", this.txtGia.Text);
				cmd.ExecuteNonQuery();
				conn.Close();
				LoadDataGrid();
				SetDefaultMH();
				CbLoaidv_SelectedIndexChanged(null, null);
				MessageBox.Show("Thực hiện thành công!");
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (string.IsNullOrEmpty(this.txtMadv.Text))
				{
					MessageBox.Show("Không có dữ liệu để xoá!");
					return;
				}

				DataTable dtData = (this.dataGridView2.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MADV = '" + this.txtMadv.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length == 0)
				{
					MessageBox.Show("Mã dịch vụ không tồn tại!");
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn xoá không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "DELETE FROM DICHVU WHERE MADV = @MADV";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@MADV", this.txtMadv.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					SetDefaultMH();
					CbLoaidv_SelectedIndexChanged(null, null);
					MessageBox.Show("Thực hiện thành công!");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			ClearError();
			SetDefaultMH();
			CbLoaidv_SelectedIndexChanged(null, null);
		}
	}
}

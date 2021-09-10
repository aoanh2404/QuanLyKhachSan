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

namespace DesignForm.Forms
{
	public partial class ThietBi : Form
	{
		private DataTable dtDisTinct = new DataTable();

		private DataTable dtdata = new DataTable();

		public ThietBi()
		{
			InitializeComponent();
		}

		private void ThietBi_Load(object sender, EventArgs e)
		{
			this.KeyPreview = true;
			LoadThem();
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			this.dataGridView1.KeyDown += DataGridView1_Key;
			this.dataGridView1.KeyUp += DataGridView1_Key;
			LoadDataGrid();
			this.dtDisTinct = this.dtdata.DefaultView.ToTable(true, "TENTV");

			AutoCompleteStringCollection col = new AutoCompleteStringCollection();

			foreach (DataRow dr in this.dtDisTinct.Rows)
			{
				col.Add(dr[0].ToString());
			}

			this.txtTenTb.AutoCompleteCustomSource = col;
			this.txtTenTb.AutoCompleteMode = AutoCompleteMode.None;
			SetDefaultFocus();
		}
		private void DataGridView1_Key(object sender, KeyEventArgs e)
		{
			try
			{
				this.txtMaTb.Text = this.dataGridView1.CurrentRow.Cells["MATB"].Value.ToString();
				this.txtTenTb.Text = this.dataGridView1.CurrentRow.Cells["TENTV"].Value.ToString();
				this.txtMaP.Text = this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
				this.cbHienTrangTb.Text = this.dataGridView1.CurrentRow.Cells["HIENTRANG"].Value.ToString();
				this.dateNgayNhap.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NGAYNHAP"].Value.ToString());
				this.txtHangsx.Text = this.dataGridView1.CurrentRow.Cells["NHASX"].Value.ToString();
				this.txtGia.Text = this.dataGridView1.CurrentRow.Cells["GIA"].Value.ToString();
				if (!string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells["NGAYLAP"].Value.ToString()))
				{

					this.dateNgayLapTB.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NGAYLAP"].Value.ToString());
				}
				else
				{
					this.dateNgayLapTB.Value = DateTime.Now;
				}
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
				this.txtMaTb.Text = this.dataGridView1.CurrentRow.Cells["MATB"].Value.ToString();
				this.txtTenTb.Text = this.dataGridView1.CurrentRow.Cells["TENTV"].Value.ToString();
				this.txtMaP.Text = this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
				this.cbHienTrangTb.Text = this.dataGridView1.CurrentRow.Cells["HIENTRANG"].Value.ToString();
				this.dateNgayNhap.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NGAYNHAP"].Value.ToString());
				this.txtHangsx.Text = this.dataGridView1.CurrentRow.Cells["NHASX"].Value.ToString();
				this.txtGia.Text = this.dataGridView1.CurrentRow.Cells["GIA"].Value.ToString();
				if (!string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells["NGAYLAP"].Value.ToString()))
				{
					this.dateNgayLapTB.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NGAYLAP"].Value.ToString());
				}
				else
				{
					this.dateNgayLapTB.Value = DateTime.Now;

				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel2.Controls)
			{
				if (btn.GetType() == typeof(Button))
				{
					Button btns = (Button)btn;
					btns.BackColor = ThemColor.PrimaryColor;
					btns.ForeColor = System.Drawing.Color.White;
					btns.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
				}
			}

			this.btnReset.BackColor = ThemColor.PrimaryColor;
			this.btnReset.ForeColor = System.Drawing.Color.White;
			this.btnReset.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
		}

		private void LoadDataGrid()
		{
			StringBuilder sbSQL = new StringBuilder();

			sbSQL.Append("SELECT TB.MATB, TB.TENTV, QL.MAPHONG, (");
			sbSQL.Append("CASE WHEN TB.TINHTRANG =0 THEN N'Tốt' ELSE N'Hỏng' END) AS HIENTRANG, ");
			sbSQL.Append("QL.NGAYLAP, TB.NHASX, TB.GIA, TB.NGAYNHAP ");
			sbSQL.Append("FROM THIETBI TB LEFT JOIN QUANLITB QL ON TB.MATB = QL.MATB");

			this.dtdata = new DataTable();
			SqlConnection conn = new SqlConnection();
			conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(sbSQL.ToString(), conn);
			this.dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(this.dtdata);
		}

		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;

			this.dataGridView1.Columns["MATB"].HeaderText = "Mã thiết bị";
			this.dataGridView1.Columns["TENTV"].HeaderText = "Tên thiết bị";
			this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView1.Columns["HIENTRANG"].HeaderText = "Hiện trạng";
			this.dataGridView1.Columns["NGAYLAP"].HeaderText = "Ngày lắp";
			this.dataGridView1.Columns["NHASX"].HeaderText = "Nhà sản xuất";
			this.dataGridView1.Columns["GIA"].HeaderText = "Giá";
			this.dataGridView1.Columns["NGAYNHAP"].HeaderText = "Ngày nhập";

		}

		private void ClearMH()
		{
			foreach (Control ctrl in this.panel4.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).SelectedIndex = -1;
				}

				if (ctrl is DateTimePicker)
				{
					(ctrl as DateTimePicker).Value = DateTime.Now;
				}
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			try
			{
				this.panel4.Enabled = true;

				ClearMH();
				LoadDataGrid();
				this.dateNgayLapTB.Visible = true;
				this.txtMaP.Visible = true;
				this.lblMaP.Visible = true;
				this.lblNgayLapTb.Visible = true;
				SetDefaultFocus();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtMaTb_TextChanged(object sender, EventArgs e)
		{
			if (this.chkSearch.Checked && this.rdMatb.Checked)
			{
				if (this.txtMaTb.Text.Trim().Equals(string.Empty))
				{
					return;
				}

				DataTable dtGird = new DataTable();

				dtGird = this.dtdata.Clone();

				DataRow[] dr1 = new DataRow[] { };

				dr1 = this.dtdata.Select("MATB LIKE'" + this.txtMaTb.Text.Trim()+ "%'", string.Empty);

				foreach (DataRow dr in dr1)
				{
					dtGird.Rows.Add(dr.ItemArray);
				}

				SetDataGrid(dtGird);

				foreach (Control ctrl in this.panel4.Controls)
				{
					if ((ctrl is TextBox) && !ctrl.Equals(this.txtMaTb))
					{
						(ctrl as TextBox).Text = string.Empty;
					}

					if ((ctrl is ComboBox))
					{
						(ctrl as ComboBox).SelectedIndex = -1;
					}

					if (ctrl is DateTimePicker)
					{
						(ctrl as DateTimePicker).Value = DateTime.Now;
					}
				}
			}
		}

		private void txtTenTb_Validating(object sender, CancelEventArgs e)
		{
			if (this.chkSearch.Checked && this.rdTentb.Checked)
			{
				SetDataGrid(this.dtdata.Clone());

				DataTable dtGird = new DataTable();

				dtGird = this.dtdata.Clone();

				DataRow[] dr1 = new DataRow[] { };

				dr1 = this.dtdata.Select("TENTV LIKE'" + this.txtTenTb.Text.Trim() + "%'", string.Empty);

				foreach (DataRow dr in dr1)
				{
					dtGird.Rows.Add(dr.ItemArray);
				}

				SetDataGrid(dtGird);

				foreach (Control ctrl in this.panel4.Controls)
				{
					if ((ctrl is TextBox) && !ctrl.Equals(this.txtTenTb))
					{
						(ctrl as TextBox).Text = string.Empty;
					}

					if ((ctrl is ComboBox))
					{
						(ctrl as ComboBox).SelectedIndex = -1;
					}

					if (ctrl is DateTimePicker)
					{
						(ctrl as DateTimePicker).Value = DateTime.Now;
					}
				}
			}
		}

		private void SetDefaultFocus()
		{
			this.txtMaTb.Focus();
		}

		private void ThietBi_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.Handled = true;
				SendKeys.Send("{TAB}");
				e.SuppressKeyPress = true;
			}
		}

		private void btnCapnhat_Click(object sender, EventArgs e)
		{
			try
			{

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void chkSearch_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if(this.chkSearch.Checked)
				{
					this.panel1.Enabled = true;
					this.txtTenTb.AutoCompleteMode = AutoCompleteMode.Suggest;
				}
				else
				{
					this.panel1.Enabled = false;
					this.txtTenTb.AutoCompleteMode = AutoCompleteMode.None;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void rd_CheckedChanged(object sender, EventArgs e)
		{
			if(this.chkSearch.Checked && this.rdTentb.Checked)
			{
				this.txtTenTb.AutoCompleteMode = AutoCompleteMode.Suggest;
			}
			else
			{
				this.txtTenTb.AutoCompleteMode = AutoCompleteMode.None;
			}

			ClearMH();
			SetDataGrid(this.dtdata);
		}

		private void txtMaP_TextChanged(object sender, EventArgs e)
		{
			if (this.chkSearch.Checked && this.rdMaphong.Checked)
			{
				if (this.txtMaP.Text.Trim().Equals(string.Empty))
				{
					return;
				}

				DataTable dtGird = new DataTable();

				dtGird = this.dtdata.Clone();

				DataRow[] dr1 = new DataRow[] { };

				dr1 = this.dtdata.Select("MAPHONG LIKE'" + this.txtMaP.Text.Trim() + "%'", string.Empty);

				foreach (DataRow dr in dr1)
				{
					dtGird.Rows.Add(dr.ItemArray);
				}

				SetDataGrid(dtGird);

				foreach (Control ctrl in this.panel4.Controls)
				{
					if ((ctrl is TextBox) && !ctrl.Equals(this.txtMaP))
					{
						(ctrl as TextBox).Text = string.Empty;
					}

					if ((ctrl is ComboBox))
					{
						(ctrl as ComboBox).SelectedIndex = -1;
					}

					if (ctrl is DateTimePicker)
					{
						(ctrl as DateTimePicker).Value = DateTime.Now;
					}
				}
			}
		}
	}
}

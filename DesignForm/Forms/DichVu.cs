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
	public partial class DichVu : Form
	{
		private DataTable dtSoucre = new DataTable();
		public DichVu()
		{
			InitializeComponent();
		}

		private void DichVu_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
			LoadDataGridDV();
			this.comboBox1.SelectedIndex = 1;
			DataTable dtMAPHONG = new DataTable();
			string strSQL = "SELECT * FROM CTDATPHONG";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtMAPHONG.Load(cmd.ExecuteReader());
			conn.Close();

			AutoCompleteStringCollection col = new AutoCompleteStringCollection();

			foreach (DataRow dr in dtMAPHONG.Rows)
			{
				col.Add(dr[0].ToString());
			}

			this.txtMaPhong.AutoCompleteCustomSource = col;

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
			this.btnTra.BackColor = ThemColor.PrimaryColor;
			this.btnTra.ForeColor = System.Drawing.Color.White;
			this.btnTra.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
			this.label1.ForeColor = ThemColor.PrimaryColor;
		}

		private void LoadDataGrid()
		{
			string strSQL = "SELECT MADV, TENDV, LOAIDV, SOLUONG, GIA1DONVI FROM DICHVU";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(dtdata);
			this.dtSoucre = dtdata;
		}

		private void LoadDataGridDV()
		{
			string strSQL = "SELECT DVP.MADV ,(SELECT TENDV FROM DICHVU DV WHERE DV.MADV = DVP.MADV) AS TENDV, DVP.SOLUONG, DVP.NGAYSUDUNG, DVP.NGAYTRA, DVP.SOLUONG, DVP.GIA FROM DV_PHONG DVP WHERE MAPHONG = @MAPHONG";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaPhong.Text.Trim());
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGridDV(dtdata);
		}

		private void SetDataGridDV(DataTable dtData)
		{
			this.dtgSoucre.DataSource = dtData;
			this.dtgSoucre.Columns["MADV"].HeaderText = "Ma DV";
			this.dtgSoucre.Columns["TENDV"].HeaderText = "Tên DV";
			this.dtgSoucre.Columns["SOLUONG"].HeaderText = "Số lượng";
			this.dtgSoucre.Columns["NGAYSUDUNG"].HeaderText = "Ngay su dung";
			this.dtgSoucre.Columns["NGAYSUDUNG"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
			this.dtgSoucre.Columns["NGAYTRA"].HeaderText = "Ngay tra";
			this.dtgSoucre.Columns["NGAYTRA"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
			this.dtgSoucre.Columns["GIA"].HeaderText = "Gia";
			this.dtgSoucre.Columns["GIA"].DefaultCellStyle.Format = "###,##0";

		}
		private void SetDataGrid(DataTable dtData)
		{
			this.dtgDV.DataSource = dtData;
			this.dtgDV.Columns["MADV"].Visible = false ;
			this.dtgDV.Columns["TENDV"].HeaderText = "Tên";
			this.dtgDV.Columns["LOAIDV"].Visible = false;
			this.dtgDV.Columns["SOLUONG"].HeaderText = "Số lượng";
			this.dtgDV.Columns["GIA1DONVI"].HeaderText = "Giá";
			this.dtgDV.Columns["GIA1DONVI"].DefaultCellStyle.Format = "###,##0";
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DataRow[] dtData = new DataRow[] { };
				dtData = this.dtSoucre.Select("LOAIDV = '" + this.comboBox1.Text + "'");

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

		private void dtgDV_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ClearMH();
				this.txtTenDv.Text = this.dtgDV.CurrentRow.Cells["TENDV"].Value.ToString();
				this.txtGia.Text = Convert.ToInt32(this.dtgDV.CurrentRow.Cells["GIA1DONVI"].Value.ToString()).ToString("###,##0");
				this.txtTong.Text = "0";
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void dtgDV_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				ClearMH();
				this.txtTenDv.Text = this.dtgDV.CurrentRow.Cells["TENDV"].Value.ToString();
				this.txtGia.Text = Convert.ToInt32(this.dtgDV.CurrentRow.Cells["GIA1DONVI"].Value.ToString()).ToString("###,##0");
				this.txtTong.Text = "0";
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtSoluong_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(this.txtSoluong.Text.Trim()))
				{
					this.txtTong.Text = (Convert.ToInt32(this.txtSoluong.Text.Trim().Replace(",", string.Empty)) * Convert.ToInt32(this.txtGia.Text.Trim().Replace(",", string.Empty))).ToString("###,##0");
				}
				else
				{
					this.txtTong.Text = "0";
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
				{
					e.Handled = true;
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void ClearMH()
		{
			foreach (Control ctrl in this.panel2.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}

				//if ((ctrl is ComboBox))
				//{
				//	(ctrl as ComboBox).SelectedIndex = 0;
				//}

				if (ctrl is DateTimePicker)
				{
					(ctrl as DateTimePicker).Value = DateTime.Now;
				}
			}

		}

		private void btnThem_Click(object sender, EventArgs e)
		{ 
			try
			{
				String strSql = "INSERT INTO DV_PHONG VALUES (@MAPHONG,@MADV,@SOLUONG,@NGAYSUDUNG,@NGAYTRA,@GIA)";
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSql, conn);
				cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaPhong.Text.Trim());
				cmd.Parameters.AddWithValue("@MADV", this.dtgDV.CurrentRow.Cells["MADV"].Value.ToString());
				cmd.Parameters.AddWithValue("@SOLUONG", this.txtSoluong.Text);
				cmd.Parameters.AddWithValue("@NGAYSUDUNG", this.dateNgayThue.Value);
				cmd.Parameters.AddWithValue("@NGAYTRA", this.dateNgayThue.Value);
				cmd.Parameters.AddWithValue("@GIA", Convert.ToInt32(this.txtGia.Text.Replace(",",string.Empty)));
				cmd.ExecuteNonQuery();
				conn.Close();
				LoadDataGridDV();
				MessageBox.Show("Thực hiện thành công!");
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtMaPhong_TextChanged(object sender, EventArgs e)
		{
			LoadDataGridDV();
		}
	}
}

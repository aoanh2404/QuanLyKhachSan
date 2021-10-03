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
	public partial class KhachHang : Form
	{
		public KhachHang()
		{
			InitializeComponent();
		}

		private void KhachHang_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel1.Controls)
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

		private void LoadDataGrid()
		{
			string strSQL = "SELECT MAKH, TENKH, NAMSINH, SDT, DIACHI, (CASE WHEN GIOITINH = 0 THEN N'Nam' ELSE N'Nữ' END) AS GIOITINH FROM KHANHHANG";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(dtdata);
		}

		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["MAKH"].HeaderText = "Mã khách hàng";
			this.dataGridView1.Columns["SDT"].HeaderText = "SĐT";
			this.dataGridView1.Columns["TENKH"].HeaderText = "Tên khách hàng";
			this.dataGridView1.Columns["NAMSINH"].HeaderText = "Năm sinh";
			this.dataGridView1.Columns["GIOITINH"].HeaderText = "Giới tính";
			this.dataGridView1.Columns["DIACHI"].HeaderText = "Địa chỉ";
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.txtMaKH.Text = this.dataGridView1.CurrentRow.Cells["MAKH"].Value.ToString();
				this.txttenKh.Text = this.dataGridView1.CurrentRow.Cells["TENKH"].Value.ToString();
				this.txtDiachi.Text = this.dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
				this.txtNamSinh.Text = this.dataGridView1.CurrentRow.Cells["NAMSINH"].Value.ToString();
				this.txtSDT.Text = this.dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
				if(this.dataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nam"))
				{
					this.rdNam.Checked = true;
				}
				else
				{
					this.rdnu.Checked = true;
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{

		}
	}
}

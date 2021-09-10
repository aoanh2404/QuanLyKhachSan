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
	public partial class PhongKS : Form
	{
		public PhongKS()
		{
			InitializeComponent();
		}

		private void PhongKS_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
		}

		private void LoadThem()
		{
			foreach (Control btn in this.tabpDatPhong.Controls)
			{
				if (btn.GetType() == typeof(Button))
				{
					Button btns = (Button)btn;
					btns.BackColor = ThemColor.PrimaryColor;
					btns.ForeColor = System.Drawing.Color.White;
					btns.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
				}
			}

			foreach (Control btn in this.panel5.Controls)
			{
				if (btn.GetType() == typeof(Button))
				{
					Button btns = (Button)btn;
					btns.BackColor = ThemColor.PrimaryColor;
					btns.ForeColor = System.Drawing.Color.White;
					btns.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
				}
				this.label1.ForeColor = ThemColor.SecondaryColor;
				this.label11.ForeColor = ThemColor.PrimaryColor;
			}
		}

		private void LoadDataGrid()
		{
			string strSQL = "SELECT MAPHONG, LOAIPHONG, GIAPHONG, (CASE WHEN TRANGTHAI = 0 THEN N'Trống' WHEN TRANGTHAI = 1 THEN N'Đã đặt' ELSE N'Đã thuê' END) AS TRANGTHAI FROM PHONG";
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
			this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView1.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
			this.dataGridView1.Columns["GIAPHONG"].HeaderText = "Giá phòng";
			this.dataGridView1.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
		}
		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox10_TextChanged(object sender, EventArgs e)
		{

		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}

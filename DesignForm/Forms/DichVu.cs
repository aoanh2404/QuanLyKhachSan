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
		public DichVu()
		{
			InitializeComponent();
		}

		private void DichVu_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
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
			string strSQL = "SELECT TENDV, SOLUONG,  GIA1DONVI FROM DICHVU";
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
			this.dataGridView1.Columns["TENDV"].HeaderText = "Tên";
			this.dataGridView1.Columns["SOLUONG"].HeaderText = "Số lượng";
			this.dataGridView1.Columns["GIA1DONVI"].HeaderText = "Giá";
		}
	}
}

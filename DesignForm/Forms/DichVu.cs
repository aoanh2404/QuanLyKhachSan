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
			string strSQL = "SELECT TENDV, LOAIDV, SOLUONG, GIA1DONVI FROM DICHVU";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(dtdata);
			this.dtSoucre = dtdata;
		}


		private void SetDataGrid(DataTable dtData)
		{
			this.dtgDV.DataSource = dtData;
			this.dtgDV.Columns["TENDV"].HeaderText = "Tên";
			this.dtgDV.Columns["LOAIDV"].Visible = false;
			this.dtgDV.Columns["SOLUONG"].HeaderText = "Số lượng";
			this.dtgDV.Columns["GIA1DONVI"].HeaderText = "Giá";
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
	}
}

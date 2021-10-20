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
	public partial class ChangePhong : Form
	{
		private DataTable dtDisTinct = new DataTable();
		private DataTable dtdata = new DataTable();

		public string strMAP { get; set; }

		public ChangePhong()
		{
			InitializeComponent();
		}

		private void ChangePhong_Load(object sender, EventArgs e)
		{
			LoadData();
			this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
		}


		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (dataGridView1.RowCount == 0)
				{
					return;
				}

				strMAP = this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
				this.Close();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void LoadData()
		{
			string strSQL = "SELECT MAPHONG, LOAIPHONG, GIAPHONG FROM PHONG WHERE TRANGTHAI = 0";
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			this.dtdata.Load(cmd.ExecuteReader());
			conn.Close();

			this.dtDisTinct = this.dtdata.DefaultView.ToTable(true, "LOAIPHONG");
			this.cbLoaiPhong.DataSource = dtDisTinct;
			this.cbLoaiPhong.DisplayMember = "LOAIPHONG";

			DataRow[] dr = null;
			dr = this.dtdata.Select("LOAIPHONG = '" + this.cbLoaiPhong.Text + "'");

			DataTable dtGrid = new DataTable();
			dtGrid = this.dtdata.Clone();
			if (dr != null)
			{
				foreach (DataRow drG in dr)
				{
					dtGrid.Rows.Add(drG.ItemArray);
				}
			}

			SetDataGrid(dtGrid);
		}

		private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRow[] dr = this.dtdata.Select("LOAIPHONG = '" + (sender as Control).Text + "'");

			DataTable dtGrid = new DataTable();
			dtGrid = this.dtdata.Clone();
			if (dr != null)
			{
				foreach (DataRow drG in dr)
				{
					dtGrid.Rows.Add(drG.ItemArray);
				}
			}

			SetDataGrid(dtGrid);
		}


		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView1.Columns["GIAPHONG"].HeaderText = "Giá phòng";
			this.dataGridView1.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
			this.dataGridView1.Columns["LOAIPHONG"].Visible = false;
		}
	}
}

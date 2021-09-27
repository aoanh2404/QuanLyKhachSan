using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesignForm
{
	public partial class SearchUser : Form
	{
		public DataRow drUserID { get; set; }

		public SearchUser()
		{
			InitializeComponent();
		}

		private void SearchUser_Load(object sender, EventArgs e)
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

				drUserID = ((DataTable)this.dataGridView1.DataSource).Rows[e.RowIndex];
				this.Close();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void LoadData()
		{
			string strSQL = "SELECT NV.MANV, NV.NAME FROM NHANVIEN NV WHERE MANV NOT IN(SELECT USK.MANV FROM USERKS USK)";
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
			this.dataGridView1.Columns["MANV"].HeaderText = "MÃ NV";
			this.dataGridView1.Columns["NAME"].HeaderText = "Họ tên";
		}
	}
}

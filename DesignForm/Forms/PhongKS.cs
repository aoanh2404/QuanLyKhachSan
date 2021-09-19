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
		private DataTable dtDisTinct = new DataTable();
		private DataTable dtdata = new DataTable();
		public PhongKS()
		{
			InitializeComponent();
		}

		private void PhongKS_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGridPhong();
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

		private void LoadDataGridPhong()
		{
			string strSQL = "SELECT MAPHONG, LOAIPHONG, GIAPHONG, (CASE WHEN TRANGTHAI = 0 THEN N'Trống' WHEN TRANGTHAI = 1 THEN N'Đã đặt' ELSE N'Đã thuê' END) AS TRANGTHAI FROM PHONG";
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			this.dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			this.dtDisTinct = this.dtdata.DefaultView.ToTable(true, "LOAIPHONG");
			this.cbLoaiPhong.DataSource = dtDisTinct;
			this.cbLoaiPhong.DisplayMember = "LOAIPHONG";

			DataRow[] dr = this.dtdata.Select("LOAIPHONG = '" + this.cbLoaiPhong.Text + "'");

			DataTable dtGrid = new DataTable();
			dtGrid = this.dtdata.Clone();
			if (dr != null)
			{
				foreach (DataRow drG in dr)
				{
					dtGrid.Rows.Add(drG.ItemArray);
				}
			}

			SetDataGridPhong(dtGrid);

		}

		private void LoadDataGridDatPhong()
		{
			string strSQL = "SELECT * FROM DATPHONG";
			DataTable dtPhongDat = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtPhongDat.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGridDatPhong(dtPhongDat);
		}

		private void SetDataGridPhong(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView1.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
			this.dataGridView1.Columns["GIAPHONG"].HeaderText = "Giá phòng";
			this.dataGridView1.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
		}

		private void SetDataGridDatPhong(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["SDT"].HeaderText = "SĐT";
			this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView1.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
			this.dataGridView1.Columns["TENKH"].HeaderText = "Tên khách hàng";
			this.dataGridView1.Columns["NGAYDEN"].HeaderText = "Ngày đến";
			this.dataGridView1.Columns["THOIGIANDEN"].HeaderText = "Giờ đến";
			this.dataGridView1.Columns["NGAYDI"].HeaderText = "Ngày đi";
		}


		private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRow[] dr = this.dtdata.Select("LOAIPHONG = '" + this.cbLoaiPhong.Text + "'");

			DataTable dtGrid = new DataTable();
			dtGrid = this.dtdata.Clone();
			if (dr != null)
			{
				foreach (DataRow drG in dr)
				{
					dtGrid.Rows.Add(drG.ItemArray);
				}
			}

			SetDataGridPhong(dtGrid);
			this.txtMaPhongD.Text = string.Empty;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.txtMaPhongD.Text= this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void dataGridView1_Key(object sender, KeyEventArgs e)
		{
			try
			{
				this.txtMaPhongD.Text = this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void btnDatPhong_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn thêm không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "INSERT INTO DATPHONG VALUES(@SDT, @MAPHONG, @LOAIPHONG, @TENKH, @NGAYDEN, @THOIGIANDEN, @NGAYDI)";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@SDT", this.txtSdtDat.Text.Trim());
					cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaPhongD.Text.Trim());
					cmd.Parameters.AddWithValue("@LOAIPHONG", this.cbLoaiPhong.Text);
					cmd.Parameters.AddWithValue("@TENKH", this.txtHoTenDat.Text);
					cmd.Parameters.AddWithValue("@NGAYDEN", this.dateNgaydenDat.Value);
					cmd.Parameters.AddWithValue("@THOIGIANDEN", this.dateGioDat.Value);
					cmd.Parameters.AddWithValue("@NGAYDI", this.dateNgayDiDat.Value);
					cmd.ExecuteNonQuery();
					conn.Close();
					MessageBox.Show("Thực hiện thành công!");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

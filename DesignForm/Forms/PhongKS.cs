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
			LoadDataGridDatPhong();
			this.dtDisTinct = this.dtdata.DefaultView.ToTable(true, "LOAIPHONG");
			this.cbLoaiPhong.DataSource = dtDisTinct;
			this.cbLoaiPhong.DisplayMember = "LOAIPHONG";
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
			this.dtdata = new DataTable();
			string strSQL = "SELECT MAPHONG, LOAIPHONG, GIAPHONG, (CASE WHEN TRANGTHAI = 0 THEN N'Trống' WHEN TRANGTHAI = 1 THEN N'Đã đặt' ELSE N'Đang thuê' END) AS TRANGTHAI FROM PHONG";
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			this.dtdata.Load(cmd.ExecuteReader());
			conn.Close();

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
			string strSQL = "SELECT SDT, TENKH, MAPHONG, LOAIPHONG, NGAYDEN, THOIGIANDEN, NGAYDI FROM DATPHONG";
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
			this.dataGridView3.DataSource = dtData;
			this.dataGridView3.Columns["SDT"].HeaderText = "SĐT";
			this.dataGridView3.Columns["TENKH"].HeaderText = "Tên khách hàng";
			this.dataGridView3.Columns["MAPHONG"].HeaderText = "Mã phòng";
			this.dataGridView3.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
			this.dataGridView3.Columns["NGAYDEN"].HeaderText = "Ngày đến";
			this.dataGridView3.Columns["THOIGIANDEN"].HeaderText = "Giờ đến";
			this.dataGridView3.Columns["NGAYDI"].HeaderText = "Ngày đi";
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
				this.txtMaPhongD.Text = this.dataGridView1.CurrentRow.Cells["MAPHONG"].Value.ToString();
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
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Chưa nhập đủ thông tin!");
					return;
				}

				DataTable dtData = (this.dataGridView3.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MAPHONG = '" + this.txtMaPhongD.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length > 0)
				{
					MessageBox.Show("Đã được đặt mời chọn phòng khác!");
					return;
				}


				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn đặt không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "INSERT INTO DATPHONG VALUES(@SDT, @MAPHONG, @LOAIPHONG, @TENKH, @NGAYDEN, @THOIGIANDEN, @NGAYDI); UPDATE PHONG SET TRANGTHAI = 1 WHERE MAPHONG = @MAPHONG";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					SqlTransaction transaction;
					transaction = conn.BeginTransaction("SampleTransaction");
					cmd.Connection = conn;
					cmd.Transaction = transaction;
					cmd.Parameters.AddWithValue("@SDT", this.txtSdtDat.Text.Trim());
					cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaPhongD.Text.Trim());
					cmd.Parameters.AddWithValue("@LOAIPHONG", this.cbLoaiPhong.Text);
					cmd.Parameters.AddWithValue("@TENKH", this.txtHoTenDat.Text);
					cmd.Parameters.AddWithValue("@NGAYDEN", this.dateNgaydenDat.Value.ToShortDateString());
					cmd.Parameters.AddWithValue("@THOIGIANDEN", this.dateGioDat.Value.ToShortTimeString());
					cmd.Parameters.AddWithValue("@NGAYDI", this.dateNgayDiDat.Value.ToLongTimeString());
					try
					{
						cmd.ExecuteNonQuery();
						transaction.Commit();
						conn.Close();
						LoadDataGridDatPhong();
						LoadDataGridPhong();
						MessageBox.Show("Thực hiện thành công!");
						ClearMH();
					}
					catch (Exception ex)
					{
						Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
						Console.WriteLine("  Message: {0}", ex.Message);

						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
							Console.WriteLine("  Message: {0}", ex2.Message);
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (this.dataGridView3.RowCount == 0)
				{
					return;
				}

				this.txtSdtDat.Text = this.dataGridView3.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtHoTenDat.Text = this.dataGridView3.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDEN"].Value.ToString());
				this.dateGioDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["THOIGIANDEN"].Value.ToString());
				this.dateNgayDiDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString());
				this.cbLoaiPhong.Text = this.dataGridView3.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMaPhongD.Text = this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString();

			}
			catch (Exception)
			{

				throw;
			}
		}

		private void dataGridView3_Key(object sender, KeyEventArgs e)
		{
			try
			{
				if (this.dataGridView3.RowCount == 0)
				{
					return;
				}
				this.txtSdtDat.Text = this.dataGridView3.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtHoTenDat.Text = this.dataGridView3.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDEN"].Value.ToString());
				this.dateGioDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["THOIGIANDEN"].Value.ToString());
				this.dateNgayDiDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString());
				this.cbLoaiPhong.Text = this.dataGridView3.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMaPhongD.Text = this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString();

			}
			catch (Exception)
			{

				throw;
			}
		}

		private void ClearMH()
		{
			foreach (Control ctrl in this.panel11.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).SelectedIndex = 0;
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
				ClearMH();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void SaveMH()
		{
			foreach (Control ctrl in this.panel11.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Tag = (ctrl as TextBox).Text;
				}

				if ((ctrl is DateTimePicker))
				{
					(ctrl as DateTimePicker).Tag = (ctrl as DateTimePicker).Value;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).Tag = (ctrl as ComboBox).SelectedIndex;
				}
			}
		}

		private bool IsChangedMH()
		{
			foreach (Control ctrl in this.panel11.Controls)
			{
				if ((ctrl is TextBox))
				{
					if (!Comparer.Equals((ctrl as TextBox).Tag, (ctrl as TextBox).Text))
					{
						return false;
					}
				}

				if ((ctrl is DateTimePicker))
				{
					if (!Comparer.Equals((ctrl as DateTimePicker).Tag, (ctrl as DateTimePicker).Value))
					{
						return false;
					}
				}

				if ((ctrl is ComboBox))
				{
					if (!Comparer.Equals((ctrl as ComboBox).Tag, (ctrl as ComboBox).SelectedIndex))
					{
						return false;
					}
				}
			}

			return true;
		}

		private bool CheckERorr()
		{
			ArrayList ctrlEror = new ArrayList();

			foreach (Control ctrl in this.panel11.Controls)
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
			foreach (Control ctrl in this.panel4.Controls)
			{
				if ((ctrl is TextBox))
				{
					this.errorProvider1.SetError((ctrl as Control), string.Empty);
				}

				if ((ctrl is DateTimePicker))
				{
					this.errorProvider1.SetError((ctrl as Control), string.Empty);
				}

				if ((ctrl is ComboBox))
				{
					this.errorProvider1.SetError((ctrl as Control), string.Empty);
				}
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();
				if (string.IsNullOrEmpty(this.txtSdtDat.Text.Trim())
					|| string.IsNullOrEmpty(this.txtMaPhongD.Text.Trim())
					|| string.IsNullOrEmpty(this.txtHoTenDat.Text.Trim()))
				{
					MessageBox.Show("Không đủ điều kiện dữ liệu để xoá, điều kiện gồm:\n Số điện thoại\n Tên khách hàng\n Mã phòng đã đặt", "Thông báo");
					return;

				}
				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn huỷ đặt phòng không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "DELETE DATPHONG WHERE SDT = @SDT AND MAPHONG = @MAPHONG AND TENKH = @TENKH; UPDATE PHONG SET TRANGTHAI = 0 WHERE MAPHONG = @MAPHONG";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					SqlTransaction transaction;
					transaction = conn.BeginTransaction("SampleTransaction");
					cmd.Connection = conn;
					cmd.Transaction = transaction;
					cmd.Parameters.AddWithValue("@SDT", this.txtSdtDat.Text.Trim());
					cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaPhongD.Text.Trim());
					cmd.Parameters.AddWithValue("@TENKH", this.txtHoTenDat.Text);
					try
					{
						cmd.ExecuteNonQuery();
						transaction.Commit();
						conn.Close();
						LoadDataGridDatPhong();
						LoadDataGridPhong();
						MessageBox.Show("Thực hiện thành công!");
						ClearMH();
					}
					catch (Exception ex)
					{
						Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
						Console.WriteLine("  Message: {0}", ex.Message);

						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
							Console.WriteLine("  Message: {0}", ex2.Message);
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

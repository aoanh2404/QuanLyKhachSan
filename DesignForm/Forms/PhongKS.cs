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
		private DataTable dtCBN = new DataTable();
		private string strSDTold = string.Empty;
		private bool isCheckKH = false;
		private DataTable dtSoucre = new DataTable();

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
			this.dtCBN = this.dtdata.DefaultView.ToTable(true, "LOAIPHONG");

			this.dateNgayDiDat.Checked = false;
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel6.Controls)
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

		#region TABDATPHONG
		private void LoadDataGridPhong()
		{
			this.dtdata = new DataTable();
			try
			{
				string strSQL = "SELECT MAPHONG, LOAIPHONG, GIAPHONG, (CASE WHEN TRANGTHAI = 0 THEN N'Trống' WHEN TRANGTHAI = 1 THEN N'Đã đặt' ELSE N'Đang thuê' END) AS TRANGTHAI FROM PHONG";
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSQL, conn);
				this.dtdata.Load(cmd.ExecuteReader());
				conn.Close();

				DataRow[] dr = null;
				if (this.tabPhong.SelectedTab == this.tabpDatPhong)
				{
					dr = this.dtdata.Select("LOAIPHONG = '" + this.cbLoaiPhong.Text + "'");
				}
				else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
				{
					dr = this.dtdata.Select("LOAIPHONG = '" + this.cbLoaiPN.Text + "'");
				}

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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void LoadDataGridDatPhong()
		{
			try
			{
				string strSQL = "SELECT SDT, TENKH, MAPHONG, LOAIPHONG, NGAYDEN, THOIGIANDEN, NGAYDI FROM DATPHONG";
				DataTable dtPhongDat = new DataTable();
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSQL, conn);
				dtPhongDat.Load(cmd.ExecuteReader());
				this.dtSoucre = dtPhongDat;
				conn.Close();
				SetDataGridDatPhong(dtPhongDat);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SetDataGridPhong(DataTable dtData)
		{
			if (this.tabPhong.SelectedTab == this.tabpDatPhong)
			{
				this.dataGridView1.DataSource = dtData;
				this.dataGridView1.Columns["MAPHONG"].HeaderText = "Mã phòng";
				this.dataGridView1.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
				this.dataGridView1.Columns["GIAPHONG"].HeaderText = "Giá phòng";
				this.dataGridView1.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
			}
			else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
			{
				this.dataGridView4.DataSource = dtData;
				this.dataGridView4.Columns["MAPHONG"].HeaderText = "Mã phòng";
				this.dataGridView4.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
				this.dataGridView4.Columns["LOAIPHONG"].Visible = false;
				this.dataGridView4.Columns["GIAPHONG"].HeaderText = "Giá phòng";
				this.dataGridView4.Columns["TRANGTHAI"].HeaderText = "Trạng thái";
			}
		}

		private void SetDataGridDatPhong(DataTable dtData)
		{
			if (this.tabPhong.SelectedTab == this.tabpDatPhong)
			{
				this.dataGridView3.DataSource = dtData;
				this.dataGridView3.Columns["SDT"].HeaderText = "SĐT";
				this.dataGridView3.Columns["TENKH"].HeaderText = "Tên khách hàng";
				this.dataGridView3.Columns["MAPHONG"].HeaderText = "Mã phòng";
				this.dataGridView3.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
				this.dataGridView3.Columns["NGAYDEN"].HeaderText = "Ngày đến";
				this.dataGridView3.Columns["THOIGIANDEN"].HeaderText = "Giờ đến";
				this.dataGridView3.Columns["NGAYDI"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
				this.dataGridView3.Columns["NGAYDI"].HeaderText = "Ngày đi";
			}
			else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
			{
				this.dataGridView2.DataSource = dtData;
				this.dataGridView2.Columns["SDT"].HeaderText = "SĐT";
				this.dataGridView2.Columns["TENKH"].HeaderText = "Tên khách hàng";
				this.dataGridView2.Columns["MAPHONG"].HeaderText = "Mã phòng";
				this.dataGridView2.Columns["LOAIPHONG"].HeaderText = "Loại phòng";
				this.dataGridView2.Columns["NGAYDEN"].HeaderText = "Ngày đến";
				this.dataGridView2.Columns["THOIGIANDEN"].HeaderText = "Giờ đến";
				this.dataGridView2.Columns["NGAYDI"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";
				this.dataGridView2.Columns["NGAYDI"].HeaderText = "Ngày đi";
			}
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

			SetDataGridPhong(dtGrid);
			this.txtMaPhongD.Text = string.Empty;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ClearError();
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
				ClearError();
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
					MessageBox.Show("Bạn chưa điền đầy đủ thông tin cần thiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				DataTable dtData = (this.dataGridView1.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MAPHONG = '" + this.txtMaPhongD.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length > 0 && !dr[0]["TRANGTHAI"].ToString().Equals("Trống"))
				{
					MessageBox.Show(" Phòng đã được đặt mời chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}


				DialogResult dlg = MessageBox.Show("Bạn muốn thực hiện đặt phòng " + this.txtMaPhongD.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
					cmd.Parameters.AddWithValue("@NGAYDI", this.dateNgayDiDat.Checked == true ? this.dateNgayDiDat.Value.ToString() : (object)DBNull.Value);
					try
					{
						cmd.ExecuteNonQuery();
						transaction.Commit();
						conn.Close();
						LoadDataGridDatPhong();
						LoadDataGridPhong();
						MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearMH();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							MessageBox.Show(ex2.Message);
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
				ClearError();

				if (this.dataGridView3.RowCount == 0)
				{
					return;
				}

				this.txtSdtDat.Text = this.dataGridView3.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtHoTenDat.Text = this.dataGridView3.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDEN"].Value.ToString());
				this.dateGioDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["THOIGIANDEN"].Value.ToString());

				if (!string.IsNullOrEmpty(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString()))
				{
					this.dateNgayDiDat.Checked = true;
					this.dateNgayDiDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString());
				}
				else
				{
					this.dateNgayDiDat.Value = DateTime.Now;
					this.dateNgayDiDat.Checked = false;
				}

				this.cbLoaiPhong.Text = this.dataGridView3.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMaPhongD.Text = this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString();

				string searchValue = this.txtMaPhongD.Text;
				int rowIndex = -1;

				dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				try
				{
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{
						if (row.Cells[0].Value.ToString().Equals(searchValue))
						{
							rowIndex = row.Index;
							dataGridView1.Rows[row.Index].Selected = true;
							break;
						}
					}
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
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
				ClearError();
				if (this.dataGridView3.RowCount == 0)
				{
					return;
				}
				this.txtSdtDat.Text = this.dataGridView3.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtHoTenDat.Text = this.dataGridView3.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDEN"].Value.ToString());
				this.dateGioDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["THOIGIANDEN"].Value.ToString());
				if (!string.IsNullOrEmpty(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString()))
				{
					this.dateNgayDiDat.Checked = true;
					this.dateNgayDiDat.Value = Convert.ToDateTime(this.dataGridView3.CurrentRow.Cells["NGAYDI"].Value.ToString());
				}
				else
				{
					this.dateNgayDiDat.Value = DateTime.Now;
					this.dateNgayDiDat.Checked = false;
				}
				this.cbLoaiPhong.Text = this.dataGridView3.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMaPhongD.Text = this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString();

				string searchValue = this.txtMaPhongD.Text;
				int rowIndex = -1;

				dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				try
				{
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{
						if (row.Cells[0].Value.ToString().Equals(searchValue))
						{
							rowIndex = row.Index;
							dataGridView1.Rows[row.Index].Selected = true;
							break;
						}
					}
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
			}
			catch (Exception)
			{

				throw;
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
					MessageBox.Show("Không đủ điều kiện dữ liệu để xoá, điều kiện gồm:\n Số điện thoại\n Tên khách hàng\n Mã phòng đã đặt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
						MessageBox.Show("Hủy đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearMH();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							MessageBox.Show(ex2.Message);
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnSuaD_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Bạn chưa điền đây đủ thông tin cần thiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				DataTable dtData = (this.dataGridView3.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MAPHONG = '" + this.txtMaPhongD.Text.ToString().Trim() + "'", string.Empty);

				if (!this.txtMaPhongD.Text.Trim().Equals(this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString()) && dr.Length > 0)
				{
					MessageBox.Show("Phòng đã được đặt mời chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}


				DialogResult dlg = MessageBox.Show("Bạn muốn thay đổi thông tin đặt phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					StringBuilder sbsSQL = new StringBuilder();
					sbsSQL.Append("UPDATE DATPHONG SET MAPHONG = @MAPHONG, LOAIPHONG = @LOAIPHONG, TENKH = @TENKH, NGAYDEN = @NGAYDEN, THOIGIANDEN = @THOIGIANDEN, NGAYDI = @NGAYDI WHERE SDT = @SDT;");

					if (!this.txtMaPhongD.Text.ToString().Equals(this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString()))
					{
						sbsSQL.Append("UPDATE PHONG SET TRANGTHAI = 0 WHERE MAPHONG = @MAPHONGTAG;");
						sbsSQL.Append("UPDATE PHONG SET TRANGTHAI = 1 WHERE MAPHONG = @MAPHONG;");
					}

					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(sbsSQL.ToString(), conn);
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
					cmd.Parameters.AddWithValue("@NGAYDI", this.dateNgayDiDat.Checked == true ? this.dateNgayDiDat.Value.ToString() : (object)DBNull.Value);
					cmd.Parameters.AddWithValue("@MAPHONGTAG", this.dataGridView3.CurrentRow.Cells["MAPHONG"].Value.ToString());
					try
					{
						cmd.ExecuteNonQuery();
						transaction.Commit();
						conn.Close();
						LoadDataGridDatPhong();
						LoadDataGridPhong();
						MessageBox.Show("Thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearMH();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							MessageBox.Show(ex2.Message);
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();
				ClearMH();
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		private void ClearMH()
		{
			if (this.tabPhong.SelectedTab == this.tabpDatPhong)
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

				this.dateNgayDiDat.Checked = false;
			}
			else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
			{
				foreach (Control ctrl in this.panel2.Controls)
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

				this.rdNam.Checked = true;
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

			if (this.tabPhong.SelectedTab == this.tabpDatPhong)
			{
				foreach (Control ctrl in this.panel11.Controls)
				{
					if ((ctrl is TextBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
					{
						ctrlEror.Add(ctrl);
					}

					if ((ctrl is DateTimePicker))
					{
						if (this.dateNgayDiDat.Value.Day - (this.dateNgaydenDat.Value.Day) < 0)
						{
							ctrlEror.Add(ctrl);
						}
					}

					if ((ctrl is ComboBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
					{
						ctrlEror.Add(ctrl);
					}
				}
			}
			else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
			{
				foreach (Control ctrl in this.panel2.Controls)
				{
					if ((ctrl is TextBox) && !ctrl.Equals(this.txtSDTN) && string.IsNullOrEmpty(ctrl.Text.Trim()))
					{
						ctrlEror.Add(ctrl);
					}

					if ((ctrl is DateTimePicker))
					{
						if (this.dateNgayDiDat.Value.Day - (this.dateNgaydenDat.Value.Day) < 0)
						{
							ctrlEror.Add(ctrl);
						}
					}

					if ((ctrl is ComboBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
					{
						ctrlEror.Add(ctrl);
					}
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
			if (this.tabPhong.SelectedTab == this.tabpDatPhong)
			{
				foreach (Control ctrl in this.panel11.Controls)
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
			else if (this.tabPhong.SelectedTab == this.tabpNhanPhong)
			{
				foreach (Control ctrl in this.panel2.Controls)
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
		}

		private void tabPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cbLoaiPN.DataSource = this.dtCBN;
			this.cbLoaiPN.DisplayMember = "LOAIPHONG";

			LoadDataGridDatPhong();
			LoadDataGridPhong();
		}

		private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			ClearError();
			if (this.dataGridView2.RowCount == 0)
			{
				return;
			}
			try
			{
				this.txtSDTN.Text = this.dataGridView2.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtTenKH.Text = this.dataGridView2.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenN.Value = Convert.ToDateTime(this.dataGridView2.CurrentRow.Cells["NGAYDEN"].Value.ToString());

				if (!string.IsNullOrEmpty(this.dataGridView2.CurrentRow.Cells["NGAYDI"].Value.ToString()))
				{
					this.dateNgaydiN.Checked = true;
					this.dateNgaydiN.Value = Convert.ToDateTime(this.dataGridView2.CurrentRow.Cells["NGAYDI"].Value.ToString());
				}
				else
				{
					this.dateNgaydiN.Value = DateTime.Now;
					this.dateNgaydiN.Checked = false;
				}

				this.cbLoaiPN.Text = this.dataGridView2.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMAPN.Text = this.dataGridView2.CurrentRow.Cells["MAPHONG"].Value.ToString();
				DataRow[] dr = this.dtdata.Select("MAPHONG = '" + this.txtMAPN.Text + "'");
				if (dr != null)
				{
					this.txtGiaPN.Text = dr[0]["GIAPHONG"].ToString();
				}

				this.strSDTold = this.txtSDTN.Text.Trim();

				string searchValue = this.txtMAPN.Text;
				int rowIndex = -1;

				dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				try
				{
					foreach (DataGridViewRow row in dataGridView4.Rows)
					{
						if (row.Cells[0].Value.ToString().Equals(searchValue))
						{
							rowIndex = row.Index;
							dataGridView4.Rows[row.Index].Selected = true;
							break;
						}
					}
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void dataGridView2_Key(object sender, KeyEventArgs e)
		{
			ClearError();
			if (this.dataGridView2.RowCount == 0)
			{
				return;
			}
			try
			{
				this.txtSDTN.Text = this.dataGridView2.CurrentRow.Cells["SDT"].Value.ToString();
				this.txtTenKH.Text = this.dataGridView2.CurrentRow.Cells["TENKH"].Value.ToString();
				this.dateNgaydenN.Value = Convert.ToDateTime(this.dataGridView2.CurrentRow.Cells["NGAYDEN"].Value.ToString());

				if (!string.IsNullOrEmpty(this.dataGridView2.CurrentRow.Cells["NGAYDI"].Value.ToString()))
				{
					this.dateNgaydiN.Checked = true;
					this.dateNgaydiN.Value = Convert.ToDateTime(this.dataGridView2.CurrentRow.Cells["NGAYDI"].Value.ToString());
				}
				else
				{
					this.dateNgaydiN.Value = DateTime.Now;
					this.dateNgaydiN.Checked = false;
				}
				this.cbLoaiPN.Text = this.dataGridView2.CurrentRow.Cells["LOAIPHONG"].Value.ToString();
				this.txtMAPN.Text = this.dataGridView2.CurrentRow.Cells["MAPHONG"].Value.ToString();
				DataRow[] dr = this.dtdata.Select("MAPHONG = '" + this.txtMAPN.Text + "'");
				if (dr != null)
				{
					this.txtGiaPN.Text = dr[0]["GIAPHONG"].ToString();
				}

				this.strSDTold = this.txtSDTN.Text.Trim();

				string searchValue = this.txtMAPN.Text;
				int rowIndex = -1;

				dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				try
				{
					foreach (DataGridViewRow row in dataGridView4.Rows)
					{
						if (row.Cells[0].Value.ToString().Equals(searchValue))
						{
							rowIndex = row.Index;
							dataGridView4.Rows[row.Index].Selected = true;
							break;
						}
					}
				}
				catch (Exception exc)
				{
					MessageBox.Show(exc.Message);
				}

			}
			catch (Exception)
			{

				throw;
			}

		}

		private void btnNhanP_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Bạn chưa điền đầy đủ thông tin cần thiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				DataTable dtN = (this.dataGridView4.DataSource as DataTable);

				DataRow[] drn = dtN.Select("MAPHONG = '" + this.txtMAPN.Text.ToString().Trim() + "'", string.Empty);

				if (drn.Length > 0 && drn[0]["TRANGTHAI"].ToString().Equals("Đang thuê"))
				{
					MessageBox.Show(" Phòng đã được thuê mời chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				else if (drn.Length > 0 && drn[0]["TRANGTHAI"].ToString().Equals("Đã đặt"))
				{
					MessageBox.Show(" Phòng đã được đặt mời chọn phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn muốn thực hiện nhận phòng " + this.txtMaPhongD.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					StringBuilder sbSQL = new StringBuilder();
					SqlConnection conn = Database.GetDBConnection();

					DataTable dtData = (this.dataGridView2.DataSource as DataTable);

					DataRow[] dr = dtData.Select("MAPHONG = '" + this.txtMAPN.Text.ToString().Trim() + "'", string.Empty);

					if (dr.Length > 0)
					{
						sbSQL.Append("DELETE DATPHONG WHERE MAPHONG = @MAPHONG; ");
					}

					sbSQL.Append("UPDATE PHONG SET TRANGTHAI = 2 WHERE MAPHONG = @MAPHONG; ");

					if (!this.isCheckKH)
					{
						sbSQL.Append("INSERT INTO KHANHHANG VALUES(@MAKH, @SDT, @TENKH, @NAMSINH, @GIOITINH, @DIACHI); ");
					}
					else
					{
						if (!string.IsNullOrEmpty(this.txtSDTN.Text.Trim())
							&& !string.IsNullOrEmpty(this.strSDTold)
							&& !this.txtSDTN.Text.Trim().Equals(this.strSDTold))
						{
							DialogResult dlgsdt = MessageBox.Show("Khách hàng có sự thay đổi về số điện thoại.\nCó muốn cập nhật lại không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

							if (dlgsdt == DialogResult.Yes)
							{
								sbSQL.Append("UPDATE KHANHHANG SET SDT = @SDT WHERE MAKH = @MAKH; ");
							}
						}
						else if (!string.IsNullOrEmpty(this.txtSDTN.Text.Trim())
							&& string.IsNullOrEmpty(this.strSDTold))
						{
							DialogResult dlgsdt1 = MessageBox.Show("Khách hàng có sự thay đổi về số điện thoại.\nCó muốn cập nhật lại không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

							if (dlgsdt1 == DialogResult.Yes)
							{
								sbSQL.Append("UPDATE KHANHHANG SET SDT = @SDT WHERE MAKH = @MAKH; ");
							}
						}
						else
						{
							//nothing
						}
					}

					sbSQL.Append("INSERT INTO CTDATPHONG VALUES(@MAPHONG, @MAKH, @NGAYDEN, @THOIGIANDEN, @NGAYDI)");

					SqlCommand cmd = new SqlCommand(sbSQL.ToString(), conn);
					conn.Open();
					SqlTransaction transaction;
					transaction = conn.BeginTransaction("SampleTransaction");
					cmd.Connection = conn;
					cmd.Transaction = transaction;

					cmd.Parameters.AddWithValue("@MAKH", this.txtMAKH.Text.Trim());
					cmd.Parameters.AddWithValue("@MAPHONG", this.txtMAPN.Text.Trim());
					cmd.Parameters.AddWithValue("@NGAYDEN", this.dateNgaydenN.Value.ToShortDateString());
					cmd.Parameters.AddWithValue("@THOIGIANDEN", Convert.ToDateTime(DateTime.Now).ToString("HH:mm"));
					cmd.Parameters.AddWithValue("@NGAYDI", this.dateNgaydiN.Checked == true ? this.dateNgaydiN.Value.ToString() : (object)DBNull.Value);
					cmd.Parameters.AddWithValue("@SDT", this.txtSDTN.Text.Trim());
					cmd.Parameters.AddWithValue("@TENKH", this.txtTenKH.Text);
					cmd.Parameters.AddWithValue("@NAMSINH", this.txtNamsinh.Text);
					cmd.Parameters.AddWithValue("@GIOITINH", this.rdNam.Checked == true ? 0 : 1);
					cmd.Parameters.AddWithValue("@DIACHI", this.txtDiaChi.Text.Trim());

					try
					{
						cmd.ExecuteNonQuery();
						transaction.Commit();
						conn.Close();
						LoadDataGridDatPhong();
						LoadDataGridPhong();
						MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ClearMH();
						this.strSDTold = string.Empty;
						this.isCheckKH = false;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						try
						{
							transaction.Rollback();
						}
						catch (Exception ex2)
						{
							MessageBox.Show(ex2.Message);
						}
					}
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtSDTN_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.txtSDTN.Focused)
				{
					DataTable dtGird = new DataTable();

					dtGird = this.dtSoucre.Clone();

					DataRow[] dr1 = new DataRow[] { };

					dr1 = this.dtSoucre.Select("SDT LIKE'" + this.txtSDTN.Text.Trim() + "%'", string.Empty);

					foreach (DataRow dr in dr1)
					{
						dtGird.Rows.Add(dr.ItemArray);
					}

					SetDataGridDatPhong(dtGird);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtMAKH_Validating(object sender, CancelEventArgs e)
		{
			try
			{
				string strSQL = "SELECT MAKH, SDT, TENKH, NAMSINH, GIOITINH, DIACHI FROM KHANHHANG WHERE MAKH = @MAKH";
				DataTable dtKH = new DataTable();
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(strSQL, conn);
				cmd.Parameters.AddWithValue("@MAKH", this.txtMAKH.Text.Trim());
				dtKH.Load(cmd.ExecuteReader());
				conn.Close();

				if (dtKH != null && dtKH.Rows.Count > 0)
				{
					this.isCheckKH = true;

					this.txtTenKH.Text = dtKH.Rows[0]["TENKH"].ToString();
					this.txtNamsinh.Text = dtKH.Rows[0]["NAMSINH"].ToString();

					if (dtKH.Rows[0]["NAMSINH"].ToString().Equals("0"))
					{
						this.rdNam.Checked = true;
					}
					else
					{
						this.rdnu.Checked = true;
					}

					this.txtDiaChi.Text = dtKH.Rows[0]["DIACHI"].ToString();
					this.strSDTold = dtKH.Rows[0]["SDT"].ToString();
				}
				else
				{
					this.isCheckKH = false;
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void btnResetN_Click(object sender, EventArgs e)
		{
			ClearError();
			ClearMH();
			LoadDataGridDatPhong();
		}

		private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			ClearError();
			this.txtMAPN.Text = this.dataGridView4.CurrentRow.Cells["MAPHONG"].Value.ToString();
			DataRow[] dr = this.dtdata.Select("MAPHONG = '" + this.txtMAPN.Text + "'");
			if (dr != null)
			{
				this.txtGiaPN.Text = dr[0]["GIAPHONG"].ToString();
			}
		}

		private void dataGridView4_KeyDown(object sender, KeyEventArgs e)
		{
			ClearError();
			this.txtMAPN.Text = this.dataGridView4.CurrentRow.Cells["MAPHONG"].Value.ToString();
			DataRow[] dr = this.dtdata.Select("MAPHONG = '" + this.txtMAPN.Text + "'");
			if (dr != null)
			{
				this.txtGiaPN.Text = dr[0]["GIAPHONG"].ToString();
			}
		}
	}
}
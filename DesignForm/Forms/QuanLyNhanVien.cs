using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesignForm
{
	public partial class QuanLyNhanVien : Form
	{
		public QuanLyNhanVien()
		{
			InitializeComponent();
		}

		private void QuanLyNhanVien_Load(object sender, EventArgs e)
		{
			LoadThem();
			LoadDataGrid();
			EVENT();
			SetDefaultMH();
		}

		private void EVENT()
		{
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			this.dataGridView1.KeyDown += DataGridView1_Key;
			this.dataGridView1.KeyUp += DataGridView1_Key;
			this.btnThem.Click += BtnThem_Click;
			this.btnReset.Click += BtnReset_Click;
			this.btnXoa.Click += BtnXoa_Click;
			this.btnSua.Click += BtnSua_Click;
			this.txtSDT.KeyPress += txtLuong_TxtSDT_KeyPress;
			this.txtLuong.KeyPress += txtLuong_TxtSDT_KeyPress;
			this.txtHoTen.KeyPress += TxtHoTen_KeyPress;

			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Validated += QuanLyNhanVien_Validated;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).Validated += QuanLyNhanVien_Validated;
				}

				if (ctrl is DateTimePicker)
				{
					(ctrl as DateTimePicker).Validated += QuanLyNhanVien_Validated;
				}
			}
		}

		private void TxtHoTen_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{

			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtLuong_TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
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

		private void BtnSua_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Chưa nhập đủ thông tin hoặc đã nhập sai!");
					return;
				}

				if (IsChangedMH())
				{
					MessageBox.Show("Không có dữ liệu thay đổi!");
					return;
				}


				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn sữa không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "UPDATE NHANVIEN SET CMND = @CMND, NAME = @NAME, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, DIACHI = @DIACHI,SDT = @SDT,CHUCVU = @CHUCVU,LUONGCB = @LUONGCB WHERE MANV = @Mannv";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@Mannv", this.txtID.Text);
					cmd.Parameters.AddWithValue("@CMND", this.txtCMND.Text);
					cmd.Parameters.AddWithValue("@NAME", this.txtHoTen.Text);
					cmd.Parameters.AddWithValue("@NAMSINH", this.dateNamSinh.Value.ToShortDateString());
					cmd.Parameters.AddWithValue("@GIOITINH", this.rdNam.Checked == true ? 0 : 1);
					cmd.Parameters.AddWithValue("@DIACHI", this.txtDiachi.Text);
					cmd.Parameters.AddWithValue("@SDT", this.txtSDT.Text);
					cmd.Parameters.AddWithValue("@CHUCVU", this.cbChucvu.Text);
					cmd.Parameters.AddWithValue("@LUONGCB", this.txtLuong.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					MessageBox.Show("Thực hiện thành công!");
					SetDefaultMH();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void BtnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.txtID.Enabled)
				{
					MessageBox.Show("Không có dữ liệu để xoá!", "Thông báo");
					return;
				}

				DialogResult dlg = new DialogResult();

				if (!IsChangedMH())
				{
					dlg = MessageBox.Show("Có dữ liệu thay đổi bạn có chắc muốn xoá không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
				else
				{
					dlg = MessageBox.Show("Bạn có chắc muốn xoá không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}


				if (dlg == DialogResult.Yes)
				{
					String strSql = "DELETE FROM NHANVIEN WHERE MANV = @MANV";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@MANV", this.txtID.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					MessageBox.Show("Thực hiện thành công!");
					SetDefaultMH();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void QuanLyNhanVien_Validated(object sender, EventArgs e)
		{
			try
			{
				this.errorProvider1.SetError((sender as Control), string.Empty);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void BtnReset_Click(object sender, EventArgs e)
		{
			try
			{
				SetDefaultMH();
				ClearError();
				this.txtID.Enabled = true;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void BtnThem_Click(object sender, EventArgs e)
		{
			try
			{
				ClearError();

				if (!CheckERorr())
				{
					MessageBox.Show("Chưa nhập đủ thông tin!");
					return;
				}

				DataTable dtData = (this.dataGridView1.DataSource as DataTable);

				DataRow[] dr = dtData.Select("MANV = '" + this.txtID.Text.ToString().Trim() + "'", string.Empty);

				if (dr.Length > 0)
				{
					MessageBox.Show("Mã đã tồn tại!");
					return;
				}

				DialogResult dlg = MessageBox.Show("Bạn có chắc muốn thêm không!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (dlg == DialogResult.Yes)
				{
					String strSql = "INSERT INTO NHANVIEN VALUES(@Mannv, @CMND, @NAME,@NAMSINH,@GIOITINH,@DIACHI,@SDT,@CHUCVU,@LUONGCB)";
					SqlConnection conn = Database.GetDBConnection();
					conn.Open();
					SqlCommand cmd = new SqlCommand(strSql, conn);
					cmd.Parameters.AddWithValue("@Mannv", this.txtID.Text);
					cmd.Parameters.AddWithValue("@CMND", this.txtCMND.Text);
					cmd.Parameters.AddWithValue("@NAME", this.txtHoTen.Text);
					cmd.Parameters.AddWithValue("@NAMSINH", this.dateNamSinh.Value.ToShortDateString());
					cmd.Parameters.AddWithValue("@GIOITINH", this.rdNam.Checked == true ? 0 : 1);
					cmd.Parameters.AddWithValue("@DIACHI", this.txtDiachi.Text);
					cmd.Parameters.AddWithValue("@SDT", this.txtSDT.Text);
					cmd.Parameters.AddWithValue("@CHUCVU", this.cbChucvu.Text);
					cmd.Parameters.AddWithValue("@LUONGCB", this.txtLuong.Text);
					cmd.ExecuteNonQuery();
					conn.Close();
					LoadDataGrid();
					MessageBox.Show("Thực hiện thành công!");
					SetDefaultMH();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void DataGridView1_Key(object sender, KeyEventArgs e)
		{
			try
			{
				ClearError();
				this.txtID.Text = this.dataGridView1.CurrentRow.Cells["MANV"].Value.ToString();
				this.txtCMND.Text = this.dataGridView1.CurrentRow.Cells["CMND"].Value.ToString();
				this.txtHoTen.Text = this.dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
				this.dateNamSinh.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NAMSINH"].Value.ToString());
				if (this.dataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nam"))
				{
					this.rdNam.Checked = true;
				}
				else
				{
					this.rdnu.Checked = true;
				}

				this.txtDiachi.Text = this.dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
				this.txtSDT.Text = this.dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
				this.cbChucvu.Text = this.dataGridView1.CurrentRow.Cells["CHUCVU"].Value.ToString();
				this.txtLuong.Text = this.dataGridView1.CurrentRow.Cells["LUONGCB"].Value.ToString();
				this.txtID.Enabled = false;
				SaveMH();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ClearError();
				this.txtID.Text = this.dataGridView1.CurrentRow.Cells["MANV"].Value.ToString();
				this.txtCMND.Text = this.dataGridView1.CurrentRow.Cells["CMND"].Value.ToString();
				this.txtHoTen.Text = this.dataGridView1.CurrentRow.Cells["NAME"].Value.ToString();
				this.dateNamSinh.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["NAMSINH"].Value.ToString());
				if (this.dataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nam"))
				{
					this.rdNam.Checked = true;
				}
				else
				{
					this.rdnu.Checked = true;
				}

				this.txtDiachi.Text = this.dataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
				this.txtSDT.Text = this.dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
				this.cbChucvu.Text = this.dataGridView1.CurrentRow.Cells["CHUCVU"].Value.ToString();
				this.txtLuong.Text = this.dataGridView1.CurrentRow.Cells["LUONGCB"].Value.ToString();

				this.txtID.Enabled = false;
				SaveMH();
			}
			catch (Exception)
			{
				throw;
			}
		}

		#region Method

		private void LoadThem()
		{
			foreach (Control btn in this.Controls)
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
			string strSQL = "SELECT MANV, CMND, NAME, NAMSINH, (CASE WHEN GIOITINH = 0 THEN N'Nam' ELSE N'Nữ' END) AS GIOITINH , " +
				"DIACHI, SDT, CHUCVU, LUONGCB FROM NHANVIEN WHERE MANV != '2021000' ORDER BY MANV";
			DataTable dtdata = new DataTable();
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtdata.Load(cmd.ExecuteReader());
			conn.Close();
			SetDataGrid(dtdata);
		}

		private bool CheckERorr()
		{
			ArrayList ctrlEror = new ArrayList();

			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox) && string.IsNullOrEmpty(ctrl.Text.Trim()))
				{
					ctrlEror.Add(ctrl);
				}

				if ((ctrl is DateTimePicker) && (DateTime.Now.Year - this.dateNamSinh.Value.Year) < 18)
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
			foreach (Control ctrl in this.Controls)
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

		private void SetDefaultMH()
		{
			foreach (Control ctrl in this.Controls)
			{
				if ((ctrl is TextBox))
				{
					(ctrl as TextBox).Text = string.Empty;
				}

				if ((ctrl is ComboBox))
				{
					(ctrl as ComboBox).SelectedIndex = -1;
				}

				if (ctrl is DateTimePicker)
				{
					(ctrl as DateTimePicker).Value = DateTime.Now;
				}
			}
			this.rdNam.Checked = true;
			this.txtID.Focus();
			SaveMH();
		}

		private void SetDataGrid(DataTable dtData)
		{
			this.dataGridView1.DataSource = dtData;
			this.dataGridView1.Columns["MANV"].HeaderText = "MÃ NV";
			this.dataGridView1.Columns["CMND"].HeaderText = "Số CMND";
			this.dataGridView1.Columns["NAME"].HeaderText = "Họ tên";
			this.dataGridView1.Columns["NAMSINH"].HeaderText = "Năm sinh";
			this.dataGridView1.Columns["GIOITINH"].HeaderText = "Giới tính";
			this.dataGridView1.Columns["DIACHI"].HeaderText = "Địa chỉ";
			this.dataGridView1.Columns["SDT"].HeaderText = "Số ĐT";
			this.dataGridView1.Columns["CHUCVU"].HeaderText = "Chức vụ";
			this.dataGridView1.Columns["LUONGCB"].HeaderText = "Lương CB";
		}

		private void SaveMH()
		{
			foreach (Control ctrl in this.Controls)
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

				if ((ctrl is RadioButton))
				{
					(ctrl as RadioButton).Tag = (ctrl as RadioButton).Checked;
				}
			}
		}

		private bool IsChangedMH()
		{
			foreach (Control ctrl in this.Controls)
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

				if ((ctrl is RadioButton))
				{
					if (!Comparer.Equals((ctrl as RadioButton).Tag, (ctrl as RadioButton).Checked))
					{
						return false;
					}
				}
			}

			return true;
		}
		#endregion
	}
}

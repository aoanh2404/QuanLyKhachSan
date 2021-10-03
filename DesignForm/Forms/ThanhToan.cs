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
	public partial class ThanhToan : Form
	{
		public ThanhToan()
		{
			InitializeComponent();
		}

		private void ThanhToan_Load(object sender, EventArgs e)
		{
			LoadThem();

			DataTable dtMAPHONG = new DataTable();
			string strSQL = "SELECT * FROM CTDATPHONG";
			SqlConnection conn = Database.GetDBConnection();
			conn.Open();
			SqlCommand cmd = new SqlCommand(strSQL, conn);
			dtMAPHONG.Load(cmd.ExecuteReader());
			conn.Close();

			AutoCompleteStringCollection col = new AutoCompleteStringCollection();

			foreach (DataRow dr in dtMAPHONG.Rows)
			{
				col.Add(dr[0].ToString());
			}

			this.txtMaP.AutoCompleteCustomSource = col;
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel2.Controls)
			{
				if (btn.GetType() == typeof(Button))
				{
					Button btns = (Button)btn;
					btns.BackColor = ThemColor.PrimaryColor;
					btns.ForeColor = System.Drawing.Color.White;
					btns.FlatAppearance.BorderColor = ThemColor.SecondaryColor;
				}
			}

			this.label1.ForeColor = ThemColor.SecondaryColor;
			this.label2.ForeColor = ThemColor.PrimaryColor;
		}

		private void txtMaP_Validated(object sender, EventArgs e)
		{
			try
			{
				StringBuilder sbSQL = new StringBuilder();
				sbSQL.Append("SELECT CT.MAPHONG, CT.MAKH, KH.TENKH, KH.SDT, KH.DIACHI, ");
				sbSQL.Append("P.LOAIPHONG, P.GIAPHONG, CT.NGAYDEN, CT.THOIGIANDEN  ");
				sbSQL.Append("FROM CTDATPHONG CT INNER JOIN KHANHHANG KH ON CT.MAKH = KH.MAKH ");
				sbSQL.Append("INNER JOIN PHONG P ON P.MAPHONG = CT.MAPHONG WHERE CT.MAPHONG = @MAPHONG");

				DataTable dtData = new DataTable();
				SqlConnection conn = Database.GetDBConnection();
				conn.Open();
				SqlCommand cmd = new SqlCommand(sbSQL.ToString(), conn);
				cmd.Parameters.AddWithValue("@MAPHONG", this.txtMaP.Text.Trim());
				dtData.Load(cmd.ExecuteReader());
				conn.Close();

				if (dtData != null && dtData.Rows.Count > 0)
				{
					this.txtMaKH.Text = dtData.Rows[0]["MAKH"].ToString();
					this.txtTenKH.Text = dtData.Rows[0]["TENKH"].ToString();
					this.txtSDT.Text = dtData.Rows[0]["SDT"].ToString();
					this.txtDiaChi.Text = dtData.Rows[0]["DIACHI"].ToString();
					this.txtMaPhong.Text = dtData.Rows[0]["MAPHONG"].ToString();
					this.txtLoaiP.Text = dtData.Rows[0]["LOAIPHONG"].ToString();
					this.txtGiaP.Text = dtData.Rows[0]["GIAPHONG"].ToString();
					this.dateNgayden.Value = Convert.ToDateTime(Convert.ToDateTime(dtData.Rows[0]["NGAYDEN"].ToString()).ToShortDateString() + " " + dtData.Rows[0]["THOIGIANDEN"].ToString());

				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

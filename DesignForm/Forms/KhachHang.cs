using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignForm.Forms
{
	public partial class KhachHang : Form
	{
		public KhachHang()
		{
			InitializeComponent();
		}

		private void KhachHang_Load(object sender, EventArgs e)
		{
			LoadThem();
		}

		private void LoadThem()
		{
			foreach (Control btn in this.panel1.Controls)
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
	}
}

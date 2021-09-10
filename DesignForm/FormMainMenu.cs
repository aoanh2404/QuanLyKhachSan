using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignForm
{
	public partial class FormMainMenu : Form
	{
		private Button currenButton;
		private Random random;
		private int tempIndex;
		private Form activeForm;
		private string strUserName = string.Empty;
		private string strQuyenHan = string.Empty;
		private string strPassold = string.Empty;
		private string strIDUSER = string.Empty;
		public FormMainMenu(object[] fPara)
		{
			InitializeComponent();
			this.random = new Random();
			this.strUserName = fPara[0].ToString();
			this.strQuyenHan = fPara[1].ToString();
			this.strPassold = fPara[2].ToString();
			this.strIDUSER = fPara[3].ToString();
		}
		private void FormMainMenu_Load(object sender, EventArgs e)
		{
			try
			{
				if (this.strQuyenHan.ToString().Equals("0"))
				{
					this.button7.Visible = true;
					this.button6.Visible = true;
					this.button5.Visible = true;
					this.button4.Visible = true;
				}

				if (this.strQuyenHan.ToString().Equals("1"))
				{
					this.button7.Visible = true;
					this.button6.Visible = true;
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

		private Color SelectThemeColor()
		{
			int index = this.random.Next(ThemColor.ColorList.Count);
			while (tempIndex == index)
			{
				index = random.Next(ThemColor.ColorList.Count);
			}
			this.tempIndex = index;
			string color = ThemColor.ColorList[index];
			return ColorTranslator.FromHtml(color);
		}

		private void OpenChildForm(Form childForm, object btnSender)
		{
			if (activeForm != null)
			{
				activeForm.Close();
			}
			Activatebutton(btnSender);
			activeForm = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			this.pnlDesktop.Controls.Add(childForm);
			childForm.BringToFront();
			childForm.Show();
			this.lblTitle.Text = childForm.Text;
			this.ActiveControl = childForm;
		}

		private void Activatebutton(object btnSender)
		{
			if (btnSender != null)
			{
				if (this.currenButton != (Button)btnSender)
				{
					DisableButton();
					Color Ccolor = SelectThemeColor();
					this.currenButton = (Button)btnSender;
					this.currenButton.BackColor = Ccolor;
					this.currenButton.ForeColor = Color.White;
					this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
					this.panelTitleBar.BackColor = Ccolor;
					this.panelLogo.BackColor = ThemColor.ChangeColorBrightness(Ccolor, -0.3);
					this.menuStrip1.BackColor = ThemColor.ChangeColorBrightness(Ccolor, -0.3);
					ThemColor.PrimaryColor = Ccolor;
					ThemColor.SecondaryColor = ThemColor.ChangeColorBrightness(Ccolor, -0.3);
				}
			}
		}

		private void DisableButton()
		{
			foreach (Control prevButton in panelMenu.Controls)
			{
				if (prevButton.GetType() == typeof(Button))
				{
					prevButton.BackColor = Color.FromArgb(51, 51, 76);
					prevButton.ForeColor = Color.Gainsboro;
					prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Forms.PhongKS(), sender);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Forms.DichVu(), sender);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Forms.ThanhToan(), sender);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OpenChildForm(new QuanLyNhanVien(), sender);
		}
	
		private void button5_Click(object sender, EventArgs e)
		{
			OpenChildForm(new User(), sender);
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			try
			{
				this.Visible = false;
				ChangePass frm = new ChangePass(new object[] { this.strIDUSER, this.strPassold });
				frm.FormClosing += FrmChangepass_FormClosing;
				frm.Show();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void FrmChangepass_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.Visible = true;
				int ischange = (sender as ChangePass).ischange;
				if (ischange == 1)
				{
					this.Close();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				this.Close();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Forms.ThietBi(), sender);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Forms.QLDichVu(), sender);
		}

		private void pnlDesktop_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode.ToString().Equals(""))
			{

			}
		}
	}
}

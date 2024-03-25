using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	String<name the image type>
	 * Returns:
	 *		String Array<File Number, Row, Col>
	// Call and receive implementation
	IconPicker pIconSelector = new IconPicker(pMain, this, "ItemBtn");

	if (pIconSelector.ShowDialog() != DialogResult.OK)
		return;

	string[] strArray = pIconSelector.ReturnValues;
	/****************************************/
	public partial class IconPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private double dX, dY, dIconSize;
		private string strBtnType;
		public string[] ReturnValues = new string[] { "0", "0", "0" };
		private System.Windows.Forms.ToolTip pToolTip;

		public IconPicker(Main mainForm, Form ParentForm, String strBtnType)
		{
			InitializeComponent();

			//this.MouseMove += IconPicker_MouseMove;
			foreach (Control control in Controls)
				control.MouseMove += IconPicker_MouseMove;

			pMain = mainForm;
			pParentForm = ParentForm;
			this.strBtnType = strBtnType;
		}

		private void IconPicker_Load(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			cbFileSelector.Items.Clear();

			cbFileSelector.BeginUpdate();

			if (Directory.Exists(strBtnType))
			{
				try
				{
					string[] strArrayFilePaths = Directory.GetFiles(strBtnType, "*.png");

					strArrayFilePaths = strArrayFilePaths.OrderBy(f => ExtractNumberFromFileName(f)).ToArray();

					foreach (string strFilePath in strArrayFilePaths)
						cbFileSelector.Items.Add(Path.GetFileNameWithoutExtension(strFilePath));
				}
				catch (Exception ex)
				{
					pMain.Logger($"Icon Picker > {ex.Message}");
				}
			}
			else
			{
				pMain.Logger("Icon Picker > Folder: " + strBtnType + " not exist.", Color.Red);
			}

			cbFileSelector.EndUpdate();

			cbFileSelector.SelectedIndex = 0;

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(pbImageViewer, "Can press Ctrl when do Left Click for instant Pick and Close");
		}

		private void IconPicker_MouseMove(object sender, MouseEventArgs e)
		{
			dX = Math.Floor(((e.X) / dIconSize));
			dY = Math.Floor(((e.Y) / dIconSize));

			lbLocation.Text = "Row: " + dY + " Col: " + dX;
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Close();
		}

		private int ExtractNumberFromFileName(string fileName)
		{
			string strNumber = Path.GetFileNameWithoutExtension(fileName);

			strNumber = new string(strNumber.Where(char.IsDigit).ToArray());

			if (int.TryParse(strNumber, out int result))
				return result;
			else
				return int.MaxValue;
		}

		private void cbFileSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFileSelector.SelectedItem != null)
			{
				pbIcon.Image = null;
				btnSelect.Enabled = false;

				string strSelectedFile = cbFileSelector.SelectedItem.ToString();

				ReturnValues[0] = strSelectedFile.Replace(strBtnType, "");

				string strPathCompose = strBtnType + "\\" + strSelectedFile + ".png";

				Image pImage = Image.FromFile(strPathCompose);
				if (pImage != null)
				{
					if (pImage.Width == 512 && pImage.Height == 512)
					{
						dIconSize = 32.0;
						pbImageViewer.SizeMode = PictureBoxSizeMode.Normal;
					}
					else
					{
						dIconSize = 16.0;
						pbImageViewer.SizeMode = PictureBoxSizeMode.StretchImage;
					}

					pbImageViewer.Image = pImage;
				}
				else
				{
					pMain.Logger("Icon Picker > Something went wrong while try load: (" + strPathCompose + ").", Color.Red);
				}
			}
		}

		private void pbImageViewer_Click(object sender, EventArgs e)
		{
			ReturnValues[1] = dY.ToString();
			ReturnValues[2] = dX.ToString();

			btnSelect.Enabled = true;

			Image pIcon = pMain.GetIcon(strBtnType, ReturnValues[0], Convert.ToInt32(ReturnValues[1]), Convert.ToInt32(ReturnValues[2]));
			if (pIcon != null)
				pbIcon.Image = pIcon;

			if (Control.ModifierKeys == Keys.Control)   // NOTE: Thats avoid everything
			{
				DialogResult = DialogResult.OK;

				Close();
			}
		}
	}
}

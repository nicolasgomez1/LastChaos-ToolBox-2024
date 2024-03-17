using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Form<Parent Form to center the Window>
	 *	String<Prompt to show>
	 * Returns:
	 *		String<Text entered by user>
	// Call and receive implementation
	MessageBox_Input pInput = new MessageBox_Input(this, "Please enter a value:");

	if (pInput.ShowDialog() != DialogResult.OK)
		 return;

	string strOutput = pInput.strOutput;
	/****************************************/
	public partial class MessageBox_Input : Form
	{
		private Form pParentForm;
		private System.Windows.Forms.ToolTip pToolTip;
		public string strOutput = "";

		public MessageBox_Input(Form pParentForm, string strCaption)
		{
			InitializeComponent();

			this.FormClosing += MessageBox_Input_FormClosing;

			rtbMessage.Text = strCaption;

			this.Width = Math.Max(TextRenderer.MeasureText(strCaption, rtbMessage.Font).Width + 40, 300);

			this.pParentForm = pParentForm;
		}

		private async void MessageBox_Input_Load(object sender, EventArgs e) {
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			tbInput.Text = "";

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(tbInput, "Press enter to close this window");
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			strOutput = tbInput.Text.ToString();

			Close();
		}

		private void MessageBox_Input_FormClosing(object sender, FormClosingEventArgs e)
		{
			pToolTip.Dispose();

			pToolTip = null;
		}

		private void tbInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnOk_Click(sender, e);
		}
	}
}

using System.Windows.Forms;
using System;
using System.Drawing;

namespace LastChaos_ToolBox_2024
{
	/*
	// For call new Instance
	ProgressDialog pProgressDialog = new ProgressDialog(this, "Loading Data, Please Wait...");

	// For Update text from existing Instance
	pProgressDialog.UpdateText("Spoon");

	// For close Instance
	pProgressDialog.Close();
	/****************************************/
	public class ProgressDialog
	{
		private Form pDialogForm;
		private Label pLabel;

		public ProgressDialog(Form pParentForm, string strMsg)
		{
			pDialogForm = new Form();
			pDialogForm.FormBorderStyle = FormBorderStyle.None;
			pDialogForm.StartPosition = FormStartPosition.Manual;
			pDialogForm.ControlBox = false;
			pDialogForm.Size = new Size(200, 70);
			pDialogForm.TopMost = true;
			pDialogForm.BackColor = Color.FromArgb(60, 56, 54);
			pDialogForm.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - pDialogForm.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - pDialogForm.Height) / 2);

			var panel = new Panel();
			panel.Dock = DockStyle.Fill;
			panel.BorderStyle = BorderStyle.FixedSingle;

			pLabel = new Label();
			pLabel.Text = strMsg;
			pLabel.Dock = DockStyle.Fill;
			pLabel.TextAlign = ContentAlignment.MiddleCenter;
			pLabel.ForeColor = Color.FromArgb(208, 203, 148);
			pLabel.Font = new Font(pLabel.Font.FontFamily, 12);

			panel.Controls.Add(pLabel);
			pDialogForm.Controls.Add(panel);

			pDialogForm.Show();

			ResizeForm();
		}

		private void ResizeForm() { pDialogForm.Size = new Size((int)pLabel.CreateGraphics().MeasureString(pLabel.Text, pLabel.Font).Width + 2 * 10, pDialogForm.Height); }

		public void UpdateText(string strText)
		{
			pLabel.Invoke((MethodInvoker)delegate
			{
				pLabel.Text = strText;

				ResizeForm();
			});
		}

		public void Close()
		{
			if (pDialogForm != null && !pDialogForm.IsDisposed)
				pDialogForm.Invoke((MethodInvoker)delegate { pDialogForm.Close(); });
		}
	}
}

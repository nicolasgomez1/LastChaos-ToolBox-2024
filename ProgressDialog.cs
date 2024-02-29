using System.Windows.Forms;
using System;
using System.Drawing;

namespace LastChaos_ToolBox_2024
{
	public class ProgressDialog : IDisposable
	{
		private Form pDialogForm;

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

            var label = new Label();
            label.Text = strMsg;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.ForeColor = Color.FromArgb(208, 203, 148);
            label.Font = new Font(label.Font.FontFamily, 12);

            panel.Controls.Add(label);
            pDialogForm.Controls.Add(panel);

            pDialogForm.Show();
        }

        public void Close()
		{
			if (pDialogForm != null && !pDialogForm.IsDisposed)
			{
                pDialogForm.Invoke((MethodInvoker)delegate
                {
                    pDialogForm.Close();
                });
			}
		}

		public void Dispose()
		{
			Close();
		}
    }
}
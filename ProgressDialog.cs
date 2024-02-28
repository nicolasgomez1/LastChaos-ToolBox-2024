using System.Windows.Forms;
using System;
using System.Drawing;

namespace LastChaos_ToolBox_2024
{
	public class ProgressDialog : IDisposable
	{
		private Form dialogForm;

        public ProgressDialog(string strMsg)
        {
            dialogForm = new Form();
            dialogForm.FormBorderStyle = FormBorderStyle.None;
            dialogForm.StartPosition = FormStartPosition.CenterScreen;
            dialogForm.ControlBox = false;
            dialogForm.Size = new Size(200, 70);
            dialogForm.TopMost = true;
            dialogForm.BackColor = Color.FromArgb(60, 56, 54);

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
            dialogForm.Controls.Add(panel);

            dialogForm.Show();
        }

        public void Close()
		{
			if (dialogForm != null && !dialogForm.IsDisposed)
			{
				dialogForm.Invoke((MethodInvoker)delegate
				{
					dialogForm.Close();
				});
			}
		}

		public void Dispose()
		{
			Close();
		}
    }
}
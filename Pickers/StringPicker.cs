using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	Int<String ID>
	 *	Boolean<Enable/Disable "Remove String" Button>
	 * Returns:
	 *		Array<Int<String ID>, String<String>>
	// Call and receive implementation
	StringPicker pStringSelector = new StringPicker(pMain, this, 1);

	if (pStringSelector.ShowDialog() != DialogResult.OK)
		return;

	int iStringID = Convert.ToInt32(pStringSelector.ReturnValues[0]);
	string strString = pStringSelector.ReturnValues[1].ToString();
	/****************************************/
	public partial class StringPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		private bool bUserAction = false;
		public object[] ReturnValues = new object[2];

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		public StringPicker(Main mainForm, Form ParentForm, int nStringID, bool bRemoveStringEnable = true)
		{
			InitializeComponent();

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues[0] = nStringID;

			btnRemoveString.Enabled = bRemoveStringEnable;
		}

		private async void StringPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			if (pMain.pStringTable == null)
			{
				pMain.pStringTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, a_string_{pMain.pSettings.WorkLocale} FROM {pMain.pSettings.DBData}.t_string ORDER BY a_index;");
				});
			}

			if (pMain.pStringTable != null)
			{
				bUserAction = false;

				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nActualStringID = Convert.ToInt32(ReturnValues[0]);

				foreach (DataRow pRow in pMain.pStringTable.Rows)
				{
					int nStringID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nStringID,
						Text = pRow["a_index"] + " - " + pRow["a_string_" + pMain.pSettings.WorkLocale].ToString()
					});

					if (nStringID == nActualStringID)
						MainList.SelectedIndex = MainList.Items.Count - 1;
				}

				if (MainList.SelectedIndex == -1)
					MainList.SelectedIndex = 0;

				MainList.EndUpdate();

				bUserAction = true;
			}
		}

		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				void Search()
				{
					string strStringToSearch = tbSearch.Text;

					for (int i = 0; i < MainList.Items.Count; i++)
					{
						if (MainList.GetItemText(MainList.Items[i]).IndexOf(strStringToSearch, StringComparison.OrdinalIgnoreCase) != -1 && i > nSearchPosition)
						{
							MainList.SetSelected(i, true);

							nSearchPosition = i;

							return;
						}
					}

					for (int i = 0; i <= nSearchPosition; i++)
					{
						if (MainList.GetItemText(MainList.Items[i]).IndexOf(strStringToSearch, StringComparison.OrdinalIgnoreCase) != -1)
						{
							MainList.SetSelected(i, true);

							nSearchPosition = i;

							return;
						}
					}
				}

				int nSelected = MainList.SelectedIndex;

				if (nSelected != -1)
				{
					if (nSelected < nSearchPosition)
						nSearchPosition = nSelected;

					Search();
				}

				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void MainList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;

				if (pSelectedItem != null)
				{
					DialogResult = DialogResult.OK;

					ReturnValues[0] = pSelectedItem.ID;
					ReturnValues[1] = pSelectedItem.Text.Split(new string[] { " - " }, StringSplitOptions.None)[1].Trim();

					Close();
				}
			}
		}

		private void btnRemoveString_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues = new object[] { -1, "" };

			Close();
		}
	}
}

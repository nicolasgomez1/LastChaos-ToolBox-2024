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
	 *	Int <Actual Rare Option ID>
	 * Returns:
	 *		Int<Rare Option ID>
	// Call and receive implementation
	RareOptionPicker pRareOptionSelector = new RareOptionPicker(pMain, this, 512);

	if (pRareOptionSelector.ShowDialog() != DialogResult.OK)
		return;

	int iRareOptionID = pRareOptionSelector.ReturnValues;
	/****************************************/
	public partial class RareOptionPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		private bool bUserAction = false;
		public int ReturnValues = -1;

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		public RareOptionPicker(Main mainForm, Form ParentForm, int iActualRareOptionID)
		{
			InitializeComponent();

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues = iActualRareOptionID;
		}

		private async void RareOptionPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string> { "a_prefix_" + pMain.pSettings.WorkLocale };

			if (pMain.pRareOptionTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (var column in listQueryCompose.ToList())
				{
					if (!pMain.pRareOptionTable.Columns.Contains(column))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(column);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pRareOptionTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_rareoption ORDER BY a_index;");
				});
			}

			if (pMain.pRareOptionTable != null)
			{
				bUserAction = false;

				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nOriginalRareOptionID = ReturnValues;

				foreach (DataRow pRow in pMain.pRareOptionTable.Rows)
				{
					int nItemID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nItemID,
						Text = pRow["a_index"] + " - " + pRow["a_prefix_" + pMain.pSettings.WorkLocale].ToString()
					});

					if (nItemID == nOriginalRareOptionID)
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

					ReturnValues = pSelectedItem.ID;

					Close();
				}
			}
		}

		private void btnRemoveRareOption_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues = -1;

			Close();
		}
	}
}

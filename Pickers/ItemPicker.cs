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
	 *	Int <Actual Item ID>
	 * Returns:
	 *		Int<Item ID>
	// Call and receive implementation
	ItemPicker pItemSelector = new ItemPicker(pMain, this, 19);

	if (pItemSelector.ShowDialog() != DialogResult.OK)
		return;

	int iItemID = pItemSelector.ReturnValues;
	/****************************************/
	public partial class ItemPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		public int ReturnValues = -1;

		public ItemPicker(Main mainForm, Form ParentForm, int iActualItemID)
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues = iActualItemID;
		}

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		private async void ItemPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

            bool bRequestNeeded = false;
            List<string> listQueryCompose = new List<string> {
				"a_texture_id", "a_texture_row", "a_texture_col", "a_name_" + pMain.pSettings.WorkLocale, "a_descr_" + pMain.pSettings.WorkLocale
			};

            if (pMain.pItemTable == null)
            {
                bRequestNeeded = true;
            }
            else
            {
                foreach (var column in listQueryCompose.ToList())
                {
                    if (!pMain.pItemTable.Columns.Contains(column))
                        bRequestNeeded = true;
                    else
                        listQueryCompose.Remove(column);
                }
            }

            if (bRequestNeeded)
            {
                pMain.pItemTable = await Task.Run(() =>
                {
                    return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
                });
            }

            if (pMain.pItemTable != null)
			{
				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nOriginalItemID = ReturnValues;

				foreach (DataRow pRow in pMain.pItemTable.Rows)
				{
					int nItemID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nItemID,
						Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.WorkLocale].ToString()
					});

					if (nItemID == nOriginalItemID)
						MainList.SelectedIndex = MainList.Items.Count - 1;
				}

				if (MainList.SelectedIndex == -1)
					MainList.SelectedIndex = 0;

				MainList.EndUpdate();
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
			ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;

			if (pSelectedItem != null)
			{
				btnSelect.Enabled = false;

				int nItemID = pSelectedItem.ID;

				DataRow pRowItem = pMain.pItemTable.Select("a_index = " + nItemID).FirstOrDefault();

				Image pIcon = pMain.GetIcon("ItemBtn", pRowItem["a_texture_id"].ToString(), Convert.ToInt32(pRowItem["a_texture_row"]), Convert.ToInt32(pRowItem["a_texture_col"]));
				if (pIcon != null)
					pbIcon.Image = pIcon;

				tbDescription.Text = pRowItem["a_descr_" + pMain.pSettings.WorkLocale].ToString();

				pRowItem = null;

				btnSelect.Enabled = true;
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;

			if (pSelectedItem != null)
			{
				DialogResult = DialogResult.OK;

				ReturnValues = pSelectedItem.ID;

				Close();
			}
		}

		private void btnRemoveSkill_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues = -1;

			Close();
		}
	}
}

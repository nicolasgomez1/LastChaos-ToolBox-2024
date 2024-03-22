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
	 *	Int<Zone ID>
	 * Returns:
	 *		Array<Int<Zone ID>, String<Zone Name>>
	// Call and receive implementation
	ZonePicker pZoneSelector = new ZonePicker(pMain, this, 1);

	if (pZoneSelector.ShowDialog() != DialogResult.OK)
		return;

	int iZoneID = Convert.ToInt32(pZoneSelector.ReturnValues[0]);
	string strZoneName = pZoneSelector.ReturnValues[1].ToString();
	/****************************************/
	public partial class ZonePicker : Form
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

		public ZonePicker(Main mainForm, Form ParentForm, int nStringID, bool bRemoveStringEnable = true)
		{
			InitializeComponent();

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues[0] = nStringID;
		}

		private async void ZonePicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string> { "a_name" };

			if (pMain.pZoneTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (string strColumnName in listQueryCompose.ToList())
				{
					if (!pMain.pZoneTable.Columns.Contains(strColumnName))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(strColumnName);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pZoneTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_zone_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_zonedata ORDER BY a_zone_index;");
				});
			}

			listQueryCompose = null;

			if (pMain.pZoneTable != null)
			{
				bUserAction = false;

				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nActualStringID = Convert.ToInt32(ReturnValues[0]);

				foreach (DataRow pRow in pMain.pZoneTable.Rows)
				{
					int nStringID = Convert.ToInt32(pRow["a_zone_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nStringID,
						Text = pRow["a_zone_index"] + " - " + pRow["a_name"].ToString()
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

		private void tbSearch_TextChanged(object sender, EventArgs e) { nSearchPosition = 0; }
	}
}

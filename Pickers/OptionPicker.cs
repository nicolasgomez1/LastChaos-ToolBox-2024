using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Definitions;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	Int <Actual Option ID>
	 * Returns:
	 *		Int Array<Option Type, Option Level>
	// Call and receive implementation
	OptionPicker pOptionSelector = new OptionPicker(pMain, this, { 512, 1 });

	if (pOptionSelector.ShowDialog() != DialogResult.OK)
		return;

	int iOptionID = pOptionSelector.ReturnValues[0];
	int iOptionLevel = pOptionSelector.ReturnValues[1];
	/****************************************/
	public partial class OptionPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		private DataRow pRowOption;
		private string[] strArrayLevel;
		public int[] ReturnValues = { -1, 0 };

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		public OptionPicker(Main mainForm, Form ParentForm, int[] nArray)
		{
			InitializeComponent();

			this.FormClosing += OptionPicker_FormClosing;

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues = nArray;
		}

		private void OptionPicker_FormClosing(object sender, FormClosingEventArgs e) { pRowOption = null; }

		public void AddInfo(string strText, bool bHead = false)
		{
			rtbInformation.BeginInvoke((MethodInvoker)delegate
			{
				int nStartPos = rtbInformation.TextLength;
				rtbInformation.AppendText(strText.ToString() + Environment.NewLine);
				int nEndPos = rtbInformation.TextLength;

				rtbInformation.Select(nStartPos, nEndPos - nStartPos);
				rtbInformation.SelectionColor = bHead ? Color.FromArgb(100, 100, 100) : Color.FromArgb(208, 203, 148);
				rtbInformation.SelectionLength = 0;

				rtbInformation.ScrollToCaret();
			});
		}

		private async void OptionPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string> {
				"a_type", "a_level", "a_prob", "a_weapon_type", "a_wear_type", "a_accessory_type", "a_name_" + pMain.pSettings.WorkLocale
			};

			if (pMain.pOptionTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (var column in listQueryCompose.ToList())
				{
					if (!pMain.pOptionTable.Columns.Contains(column))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(column);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pOptionTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_option ORDER BY a_index;");
				});
			}

			listQueryCompose = null;

			if (pMain.pOptionTable != null)
			{
				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nOriginalOptionID = ReturnValues[0];

				foreach (DataRow pRow in pMain.pOptionTable.Rows)
				{
					int nItemID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nItemID,
						Text = pRow["a_type"] + " - " + pRow["a_name_" + pMain.pSettings.WorkLocale].ToString()
					});

					if (nItemID == nOriginalOptionID)
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
				rtbInformation.Clear();

				cbLevelSelector.Items.Clear();
				cbLevelSelector.Enabled = false;

				btnSelect.Enabled = false;

				int nItemID = pSelectedItem.ID;

				pRowOption = pMain.pOptionTable.Select("a_index = " + nItemID).FirstOrDefault();

				AddInfo("Type: ", true);

				AddInfo(Defs.OptionTypes[Convert.ToInt32(pRowOption["a_type"])]);

				AddInfo("Weapon Types: ", true);

				// NOTE: I'm not sure of all this >>
				int nFlag = Convert.ToInt32(pRowOption["a_weapon_type"]);

				if (nFlag != 0)
				{
					int i = 0;
					foreach (string strSubType in Defs.ItemTypesNSubTypes["Weapon"])
					{
						if ((nFlag & 1L << i) != 0)
							AddInfo(strSubType);

						i++;
					}
				}
				else
				{
					AddInfo("0");
				}

				AddInfo("Wear Types: ", true);

				nFlag = Convert.ToInt32(pRowOption["a_wear_type"]);

				if (nFlag != 0)
				{
					int i = 0;
					foreach (string strSubType in Defs.ItemTypesNSubTypes["Armor"])
					{
						if ((nFlag & 1L << i) != 0)
							AddInfo(strSubType);

						i++;
					}
				}
				else
				{
					AddInfo("0");
				}

				AddInfo("Accesory Types: ", true);

				nFlag = Convert.ToInt32(pRowOption["a_accessory_type"]);

				if (nFlag != 0)
				{
					int i = 0;
					foreach (string strSubType in Defs.ItemTypesNSubTypes["Accesory"])
					{
						if ((nFlag & 1L << i) != 0)
							AddInfo(strSubType);

						i++;
					}
				}
				else
				{
					AddInfo("0");
				}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				{
					string strLevel = pRowOption["a_level"].ToString();
					if (strLevel.IndexOf(' ') >= 0)
						strLevel = strLevel.TrimStart();

					strArrayLevel = strLevel.Split(' ');

					string strProb = pRowOption["a_prob"].ToString();
					if (strProb.IndexOf(' ') >= 0)
						strProb = strProb.TrimStart();

					string[] strArrayProb = strProb.Split(' ');

					int i = 0;
					foreach (string strLevelB in strArrayLevel)
					{
						if (i < strArrayProb.Length)
						{
							cbLevelSelector.Items.Add("[" + (i + 1) + "] Lvl: " + strLevelB + " Prob: " + strArrayProb[i]);

							if (Convert.ToInt32(strLevelB) == ReturnValues[1])
								MainList.SelectedIndex = MainList.Items.Count - 1;
						}
						else
						{
							pMain.Logger("option Picker > Option: " + nItemID + " Error: a_prob mismatched with a_level.", Color.Red);
						}

						i++;
					}

					if (cbLevelSelector.SelectedIndex == -1)
						cbLevelSelector.SelectedIndex = 1;
				}

				cbLevelSelector.Enabled = true;
				btnSelect.Enabled = true;
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;
			int nSelectedOptionLevel = cbLevelSelector.SelectedIndex;

			if (pSelectedItem != null && nSelectedOptionLevel != -1)
			{
				cbLevelSelector.Enabled = false;

				cbLevelSelector.Items.Clear();

				cbLevelSelector.BeginUpdate();

				DialogResult = DialogResult.OK;

				ReturnValues[0] = Convert.ToInt32(pRowOption["a_type"]);
				ReturnValues[1] = Convert.ToInt32(strArrayLevel[nSelectedOptionLevel]);

				Close();
			}
		}

		private void btnRemoveOption_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues[0] = -1;
			ReturnValues[1] = 0;

			Close();
		}

		private void tbSearch_TextChanged(object sender, EventArgs e) { nSearchPosition = 0; }
	}
}

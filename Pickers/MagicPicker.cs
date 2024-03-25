using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Definitions;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	Int <Actual Magic ID>
	 * Returns:
	 *		Int Array<Magic Type, Magic Level>
	// Call and receive implementation
	MagicPicker pMagicSelector = new MagicPicker(pMain, this, new int[] { 0, 1 });

	if (pMagicSelector.ShowDialog() != DialogResult.OK)
		return;

	int iMagicType = pMagicSelector.ReturnValues[0];
	int iMagicLevel = pMagicSelector.ReturnValues[1];
	/****************************************/
	public partial class MagicPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		//private DataRow pRowOption;
		private string[] strArrayLevel;
		public int[] ReturnValues = { -1, 0 };

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		public MagicPicker(Main mainForm, Form ParentForm, int[] nArray)
		{
			InitializeComponent();

			this.FormClosing += MagicPicker_FormClosing;

			pMain = mainForm;
			pParentForm = ParentForm;
			ReturnValues = nArray;
		}

		private void MagicPicker_FormClosing(object sender, FormClosingEventArgs e) { /*pRowMagic = null;*/ }

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

		private async void MagicPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string> {
				"a_name", "a_maxlevel", "a_type", "a_subtype", "a_damagetype", "a_hittype", "a_attribute", "a_psp", "a_ptp", "a_hsp", "a_htp", "a_togle"
			};

			if (pMain.pMagicTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (var column in listQueryCompose.ToList())
				{
					if (!pMain.pMagicTable.Columns.Contains(column))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(column);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pMagicTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_magic ORDER BY a_index;");
				});

				bRequestNeeded = false;
				listQueryCompose.Clear();

				listQueryCompose = new List<string> { "a_level", "a_power", "a_hitrate" };

				if (pMain.pMagicLevelTable == null)
				{
					bRequestNeeded = true;
				}
				else
				{
					foreach (var column in listQueryCompose.ToList())
					{
						if (!pMain.pMagicLevelTable.Columns.Contains(column))
							bRequestNeeded = true;
						else
							listQueryCompose.Remove(column);
					}
				}

				if (bRequestNeeded)
				{
					pMain.pMagicLevelTable = await Task.Run(() =>
					{
						return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_magiclevel ORDER BY a_level");
					});
				}
			}

			listQueryCompose = null;

			if (pMain.pMagicTable != null && pMain.pMagicLevelTable != null)
			{
				MainList.Items.Clear();

				MainList.BeginUpdate();

				int nOriginalSkillID = Convert.ToInt32(ReturnValues[0]);

				foreach (DataRow pRow in pMain.pMagicTable.Rows)
				{
					int nSkillID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nSkillID,
						Text = pRow["a_index"] + " - " + pRow["a_name"].ToString()
					});

					if (nSkillID == nOriginalSkillID)
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
				/*
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
				}*/

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

				//ReturnValues[0] = Convert.ToInt32(pRowOption["a_type"]);	// TODO
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

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

	int nMagicType = pMagicSelector.ReturnValues[0];
	int nMagicLevel = pMagicSelector.ReturnValues[1];
	/****************************************/
	public partial class MagicPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		private DataRow pRowMagic;
		private List<DataRow> listMagicLevels;
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

		private void MagicPicker_FormClosing(object sender, FormClosingEventArgs e) {
			pRowMagic = null;

			listMagicLevels.Clear();
			listMagicLevels = null;
		}

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

				foreach (DataRow pRow in pMain.pMagicTable.Rows)
				{
					int nSkillID = Convert.ToInt32(pRow["a_index"]);

					MainList.Items.Add(new ListBoxItem
					{
						ID = nSkillID,
						Text = pRow["a_index"] + " - " + pRow["a_name"].ToString()
					});

					if (nSkillID == Convert.ToInt32(ReturnValues[0]))
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

				pRowMagic = pMain.pMagicTable.Select("a_index = " + nItemID).FirstOrDefault();

				AddInfo("Type:", true);

				var varType = Defs.MagicTypes.ElementAtOrDefault(Convert.ToInt32(pRowMagic["a_type"]));
				if (varType.Value == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_type out of range.", Color.Red);
					return;
				}
				
				AddInfo(varType.Key);

				AddInfo("Sub Type:", true);

				if (varType.Value.Count < Convert.ToInt32(pRowMagic["a_subtype"]))
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_subtype out of range.", Color.Red);
					return;
				}

				AddInfo(varType.Value[Convert.ToInt32(pRowMagic["a_subtype"])]);

				AddInfo("Damage Type:", true);

				string strDamageType = Defs.MagicDamageTypes[Convert.ToInt32(pRowMagic["a_damagetype"])];
				if (strDamageType == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_damagetype out of range.", Color.Red);
					return;
				}

				AddInfo(strDamageType);

				AddInfo("Hit Type:", true);

				string strHitType = Defs.MagicHitTypes[Convert.ToInt32(pRowMagic["a_hittype"])];
				if (strHitType == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_hittype out of range.", Color.Red);
					return;
				}

				AddInfo(strHitType);

				AddInfo("Attribute:", true);
				AddInfo(pRowMagic["a_attribute"].ToString());

				AddInfo("Self Power Parameter:", true);

				string strParam = Defs.MagicParamTypes[Convert.ToInt32(pRowMagic["a_psp"])];
				if (strParam == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_psp out of range.", Color.Red);
					return;
				}

				AddInfo(strParam);

				AddInfo("Target Power Parameter:", true);

				strParam = Defs.MagicParamTypes[Convert.ToInt32(pRowMagic["a_ptp"])];
				if (strParam == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_ptp out of range.", Color.Red);
					return;
				}

				AddInfo(strParam);

				AddInfo("Self Hit Rate:", true);

				strParam = Defs.MagicParamTypes[Convert.ToInt32(pRowMagic["a_hsp"])];
				if (strParam == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_hsp out of range.", Color.Red);
					return;
				}

				AddInfo(strParam);

				AddInfo("Target Hit Rate:", true);

				strParam = Defs.MagicParamTypes[Convert.ToInt32(pRowMagic["a_htp"])];
				if (strParam == null)
				{
					pMain.Logger("Magic Picker > Magic: " + nItemID + " Error: a_htp out of range.", Color.Red);
					return;
				}

				AddInfo(strParam);

				AddInfo("Toggle:", true);

				string strToggle = "False";

				if (pRowMagic["a_togle"].ToString() == "1")
					strToggle = "True";

				AddInfo(strToggle);

				listMagicLevels = pMain.pMagicLevelTable.AsEnumerable().Where(row => row.RowState != DataRowState.Deleted && row.Field<int>("a_index") == nItemID).ToList();

				foreach (var pRowMagicLevel in listMagicLevels)
				{
					int nLevel = Convert.ToInt32(pRowMagicLevel["a_level"]);

					cbLevelSelector.Items.Add("Lvl: " + nLevel + " Power: " + pRowMagicLevel["a_power"] + " Hit Rate: " + pRowMagicLevel["a_hitrate"]);

					if (nLevel == ReturnValues[1])
						cbLevelSelector.SelectedIndex = cbLevelSelector.Items.Count - 1;
				}

				if (cbLevelSelector.SelectedIndex == -1)
					cbLevelSelector.SelectedIndex = 0;

				cbLevelSelector.Enabled = true;
				btnSelect.Enabled = true;
			}
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;
			int nSelectedMagicLevel = cbLevelSelector.SelectedIndex;

			if (pSelectedItem != null && nSelectedMagicLevel != -1)
			{
				DialogResult = DialogResult.OK;

				ReturnValues[0] = Convert.ToInt32(pRowMagic["a_index"]);
				ReturnValues[1] = Convert.ToInt32(listMagicLevels[nSelectedMagicLevel]["a_level"]);

				Close();
			}
		}

		private void btnRemoveMagic_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues[0] = -1;
			ReturnValues[1] = 0;

			Close();
		}

		private void tbSearch_TextChanged(object sender, EventArgs e) { nSearchPosition = 0; }
	}
}

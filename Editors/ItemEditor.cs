//#define NEED_SECOND_SKILL_TO_CRAFT	// NOTE: These values are required by the server, but are not actually used
#define ALLOWED_ZONE_SYSTEM	// NOTE: Custom system made by NicolasG, disable that to use normal a_zone_flag

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Definitions;

namespace LastChaos_ToolBox_2024.Editors
{
	public partial class ItemEditor : Form
	{
		private Main pMain;
		private bool bUserAction = false;
		private bool bUnsavedChanges = false;
		private ListBoxItem pLastSelected;
		private System.Windows.Forms.ToolTip pToolTip;
		private DataRow pTempRow;
		private int nSearchPosition = 0;
		private string[] strArrayZones;
		private Dictionary<Control, ToolTip> pToolTips = new Dictionary<Control, ToolTip>();
		private RenderDialog pRenderDialog;

		public ItemEditor(Main mainForm)
		{
			this.FormClosing += ItemEditor_FormClosing;

			InitializeComponent();

#if NEED_SECOND_SKILL_TO_CRAFT
			label44.Visible = true;

			btnSkill2RequiredID.Visible = true;

			label43.Visible = true;

			tbSkill2RequiredLevel.Visible = true;
#endif

#if ALLOWED_ZONE_SYSTEM
			btnAllowedZoneFlag.Visible = true;
#else
			lAllowedZone.Text = "Zone Flag";

			tbAllowedZoneFlag.Visible = true;
#endif

			pMain = mainForm;
		}

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		private async Task LoadItemDataAsync()
		{
			bool bRequestNeeded = false;

			// NOTE: Here you must define the columns that you want to request from the database.
			HashSet<string> listQueryCompose = new HashSet<string>
			{
				"a_enable", "a_texture_id", "a_texture_row", "a_texture_col", "a_file_smc", "a_weight", "a_price", "a_level", "a_level2", "a_durability", "a_fame",
				"a_max_use", "a_grade", "a_type_idx", "a_subtype_idx", "a_wearing", "a_rvr_value", "a_rvr_grade", "a_effect_name", "a_attack_effect_name",
				"a_damage_effect_name", "a_castle_war", "a_job_flag", "a_zone_flag", "a_flag", "a_origin_variation1", "a_origin_variation2", "a_origin_variation3",
				"a_origin_variation4", "a_origin_variation5", "a_origin_variation6", "a_set_0", "a_set_1", "a_set_2", "a_set_3", "a_set_4", "a_num_0", "a_num_1",
				"a_num_2", "a_num_3", "a_num_4", "a_need_sskill", "a_need_sskill_level",
#if NEED_SECOND_SKILL_TO_CRAFT
				"a_need_sskill2", "a_need_sskill_level2"
#endif
			};

			// NOTE: If columns related to locale are required, they must be defined here.
			for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
			{
				string strNation = pMain.pSettings.NationSupported[i].ToLower();

				listQueryCompose.Add("a_name_" + strNation);
				listQueryCompose.Add("a_descr_" + strNation);
			}

			if (pMain.pItemTable == null)	// NOTE: If the global table is empty, directly indicate that a query must be executed requesting all previously defined columns
			{
				bRequestNeeded = true;
			}
            else    // NOTE: If the global table is not empty, check if any of the columns to request are already present. To remove it from the query and not request redundant information.
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
                    // WARNING NOTE: Possible problem: I don't know how this will work when do query with multiple locales that are not compatible with a single charset are requested.
                    return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
				});
			}
		}

		private async Task LoadZoneDataAsync()
		{
			bool bRequestNeeded = false;

			HashSet<string> listQueryCompose = new HashSet<string> { "a_name" };

			if (pMain.pZoneTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (var column in listQueryCompose.ToList())
				{
					if (!pMain.pZoneTable.Columns.Contains(column))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(column);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pZoneTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_zone_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_zonedata ORDER BY a_zone_index;");
				});
			}
		}

		private async Task LoadSkillDataAsync()
		{
			bool bRequestNeeded = false;

			HashSet<string> listQueryCompose = new HashSet<string> {
				"a_name_" + pMain.pSettings.WorkLocale, "a_client_description_" + pMain.pSettings.WorkLocale, "a_client_icon_texid", "a_client_icon_row", "a_client_icon_col"
			};

			
			if (pMain.pSkillTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (var column in listQueryCompose.ToList())
				{
					if (!pMain.pZoneTable.Columns.Contains(column))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(column);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pSkillTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_skill ORDER BY a_index;");
				});

				// Populate pSkillLevelTable

				// Reset vals
				bRequestNeeded = false;
				listQueryCompose.Clear();

				listQueryCompose = new HashSet<string> { "a_level", "a_dummypower" };

				if (pMain.pSkillLevelTable == null)
				{
					bRequestNeeded = true;
				}
				else
				{
					foreach (var column in listQueryCompose.ToList())
					{
						if (!pMain.pSkillLevelTable.Columns.Contains(column))
							bRequestNeeded = true;
						else
							listQueryCompose.Remove(column);
					}
				}

				if (bRequestNeeded)
				{
					pMain.pSkillLevelTable = await Task.Run(() =>
					{
						return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_skilllevel ORDER BY a_level");
					});
				}
			}
		}

		private async void ItemEditor_LoadAsync(object sender, EventArgs e)
		{
			ProgressDialog pProgressDialog = new ProgressDialog(this, "Loading Data, Please Wait...");

			foreach (Control control in this.Controls)
			{
				if (control is Label)
					((Label)control).TabStop = false;
			}

			cbNationSelector.Items.Clear();

			cbNationSelector.BeginUpdate();

			for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
			{
				string strNation = pMain.pSettings.NationSupported[i];

				cbNationSelector.Items.Add(pMain.pSettings.NationSupported[i]);

				if (pMain.pSettings.NationSupported[i].ToLower() == pMain.pSettings.WorkLocale)
					cbNationSelector.SelectedIndex = i;
			}

			cbNationSelector.EndUpdate();
			/****************************************/
			cbCastleType.Items.Clear();

			cbCastleType.BeginUpdate();

			foreach (string strCastleType in Defs.ItemCastleTypes)
				cbCastleType.Items.Add(strCastleType);

			cbCastleType.EndUpdate();
			/****************************************/
			cbTypeSelector.Items.Clear();

			cbTypeSelector.BeginUpdate();

			foreach (string strType in Defs.ItemTypesNSubTypes.Keys)
				cbTypeSelector.Items.Add(strType);

			cbTypeSelector.EndUpdate();
			/****************************************/
			cbWearingPositionSelector.Items.Clear();

			cbWearingPositionSelector.BeginUpdate();

			foreach (string strWearingPos in Defs.ItemWearingPositions)
				cbWearingPositionSelector.Items.Add(strWearingPos);

			cbWearingPositionSelector.EndUpdate();
			/****************************************/
			cbRvRValueSelector.Items.Clear();

			cbRvRValueSelector.BeginUpdate();

			foreach (string strSyndicateType in Defs.SyndicateTypesNGrades.Keys)
				cbRvRValueSelector.Items.Add(strSyndicateType);

			cbRvRValueSelector.EndUpdate();
			/****************************************/
#if DEBUG
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
#endif
			await Task.WhenAll( // NOTE: Here information is requested from the mysql server asynchronously, thus reducing waiting times to the minimum possible.
                LoadItemDataAsync(),    // Populate pItemTable
				LoadZoneDataAsync(),    // Populate pZoneTable
				LoadSkillDataAsync()    // Populate pSkillTable & pSkillLevelTable
			);
#if DEBUG
			stopwatch.Stop();
			pMain.PrintLog($"Data load took: {stopwatch.ElapsedMilliseconds} ms", Color.CornflowerBlue);
#endif
			/****************************************/
			if (pMain.pItemTable != null)
			{
				MainList.Items.Clear();

				MainList.BeginUpdate();

				foreach (DataRow pRow in pMain.pItemTable.Rows)
				{
					MainList.Items.Add(new ListBoxItem
					{
						ID = Convert.ToInt32(pRow["a_index"]),
						Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.WorkLocale].ToString()
					});
				}

				MainList.SelectedIndex = 0;

				MainList.EndUpdate();
			}
			/****************************************/
			if (pMain.pZoneTable != null)
			{
				int nTotalZones = pMain.pZoneTable.Rows.Count;
				strArrayZones = new string[nTotalZones];

				for (int i = 0; i < nTotalZones; i++)
					strArrayZones[i] = pMain.pZoneTable.Rows[i]["a_name"].ToString();
			}
			/****************************************/
			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnReload, "Reload Items, Zones Skill & Skills Levels Data from Database");
			pToolTips[btnReload] = pToolTip;    // For Dispose
			/****************************************/
			btnReload.Enabled = true;
			btnAddNew.Enabled = true;

			pProgressDialog.Close();
		}

		private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)  // NOTE: Here is an example of the unsaved data warning messages in case you want to close the form.
        {
			void Clear()
			{
				foreach (var toolTip in pToolTips.Values)
					toolTip.Dispose();

				if (pRenderDialog != null)
					pRenderDialog.Close();

				pTempRow = null;
			}

			if (bUnsavedChanges)
			{
				DialogResult pDialogReturn = MessageBox.Show("You have unsaved changes. Do you want to discard them and exit?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.No)
					e.Cancel = true;
				else
					Clear();
			}
			else
			{
				Clear();
			}
		}

		private void LoadItemData(int nItemID)
		{
			bUserAction = false;

			// Clear Selections & Others
			cbTypeSelector.SelectedIndex = -1;
			cbSubTypeSelector.SelectedIndex = -1;
			cbWearingPositionSelector.SelectedIndex = -1;

			foreach (var toolTip in pToolTips.Values)
				toolTip.Dispose();
			/****************************************/
			// Replicate struct in temp row
			pTempRow = pMain.pItemTable.NewRow();
			// Copy data from main table to temp one
			pTempRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = " + nItemID)[0].ItemArray.Clone();

			// Load data to UI
			// General
			tbID.Text = nItemID.ToString();
			/****************************************/
			if (pTempRow["a_enable"].ToString() == "1")
				cbEnable.Checked = true;
			else
				cbEnable.Checked = false;
			/****************************************/
			string strTexID = pTempRow["a_texture_id"].ToString();
			string strTexRow = pTempRow["a_texture_row"].ToString();
			string strTexCol = pTempRow["a_texture_col"].ToString();

			Image pIcon = pMain.GetIcon("ItemBtn", strTexID, Convert.ToInt32(strTexRow), Convert.ToInt32(strTexCol));
			if (pIcon != null)
			{
				pbIcon.Image = pIcon;

				pToolTip = new ToolTip();
				pToolTip.SetToolTip(pbIcon, "FILE: " + strTexID + " ROW: " + strTexRow + " COL: " + strTexCol);
				pToolTips[pbIcon] = pToolTip;
			}
			/****************************************/
			string strSMCPath = pTempRow["a_file_smc"].ToString();

			tbSMC.Text = strSMCPath.Replace("Data\\", "");

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(tbSMC, "Double Click to edit");
			pToolTips[tbSMC] = pToolTip;
			/****************************************/
			int nWearingPosition = Convert.ToInt32(pTempRow["a_wearing"]);

			if (pMain.pSettings.ShowRenderDialog[this.Name] == "true")
			{
				if (pRenderDialog == null || pRenderDialog.IsDisposed)
					pRenderDialog = new RenderDialog(pMain);

				if (!pRenderDialog.Visible)
					pRenderDialog.Show();

				pRenderDialog.SetModel(pMain.pSettings.ClientPath + "\\" + strSMCPath, "small", nWearingPosition);
			}
			/****************************************/
			tbMaxStack.Text = pTempRow["a_weight"].ToString();

			tbPrice.Text = pTempRow["a_price"].ToString();

			tbMinLevel.Text = pTempRow["a_level"].ToString();

			tbMaxLevel.Text = pTempRow["a_level2"].ToString();

			tbDurability.Text = pTempRow["a_durability"].ToString();

			tbFame.Text = pTempRow["a_fame"].ToString();

			tbMaxUse.Text = pTempRow["a_max_use"].ToString();
			/****************************************/
			tbGrade.Text = pTempRow["a_grade"].ToString();

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(tbGrade, "¿Rare Rate?");
			pToolTips[tbGrade] = pToolTip;  // For Dispose
			/****************************************/
			string strNation = cbNationSelector.SelectedItem.ToString().ToLower();

			tbName.Text = pTempRow["a_name_" + strNation].ToString();
			tbDescription.Text = pTempRow["a_descr_" + strNation].ToString();
			/****************************************/
			int nCastleType = Convert.ToInt32(pTempRow["a_castle_war"]);

			if (nCastleType < 0 || nCastleType > Defs.ItemCastleTypes.Length)
				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_castle_war out of range", Color.Red);
			else
				cbCastleType.SelectedIndex = nCastleType;
			/****************************************/
			if (nWearingPosition < -1 || nWearingPosition > Defs.ItemWearingPositions.Length)
			{
				cbWearingPositionSelector.Enabled = false;
				cbWearingPositionSelector.Text = "";

				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_wearing out of range", Color.Red);
			}
			else
			{
				if (nWearingPosition == -1)
					nWearingPosition = 0;
				else
					nWearingPosition++;

				cbWearingPositionSelector.Enabled = true;
				cbWearingPositionSelector.SelectedIndex = nWearingPosition;
			}
			/****************************************/
			btnClassFlag.Text = pTempRow["a_job_flag"].ToString();

			string strTooltip = "";
			long nFlag = Convert.ToInt32(pTempRow["a_job_flag"]);

			for (int i = 0; i < Defs.ItemClass.Length; i++)
			{
				if ((nFlag & 1L << i) != 0)
					strTooltip += Defs.ItemClass[i] + "\n";
			}

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnClassFlag, strTooltip);
			pToolTips[btnClassFlag] = pToolTip;
			/****************************************/
			string strFlag = pTempRow["a_zone_flag"].ToString();

#if ALLOWED_ZONE_SYSTEM
			btnAllowedZoneFlag.Text = strFlag;

			strTooltip = "";
			nFlag = long.Parse(strFlag);

			for (int i = 0; i < pMain.pZoneTable.Rows.Count; i++)
			{
				if ((nFlag & 1L << i) != 0)
					strTooltip += pMain.pZoneTable.Rows[i]["a_name"] + "\n";
			}

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnAllowedZoneFlag, strTooltip);
			pToolTips[btnAllowedZoneFlag] = pToolTip;
#else
			tbAllowedZoneFlag.Text = strFlag;
#endif
			/****************************************/
			strFlag = pTempRow["a_flag"].ToString();

			btnItemFlag.Text = strFlag;

			strTooltip = "";
			nFlag = long.Parse(strFlag);

			for (int i = 0; i < Defs.ItemFlag.Length; i++)
			{
				if ((nFlag & 1L << i) != 0)
					strTooltip += Defs.ItemFlag[i] + "\n";
			}

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnItemFlag, strTooltip);
			pToolTips[btnItemFlag] = pToolTip;
			/****************************************/
			int nType = Convert.ToInt32(pTempRow["a_type_idx"]);

			if (nType < 0 || nType > Defs.ItemTypesNSubTypes.Keys.Count)
			{
				cbTypeSelector.Items.Clear();
				cbTypeSelector.Enabled = false;
				cbTypeSelector.Text = "";

				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_type_idx out of range", Color.Red);
			}
			else
			{
				cbTypeSelector.SelectedIndex = nType;

				int nSubType = Convert.ToInt32(pTempRow["a_subtype_idx"]);

				if (nSubType < 0 || nSubType > Defs.ItemTypesNSubTypes[Defs.ItemTypesNSubTypes.Keys.ElementAt(nType)].Count)
				{
					cbSubTypeSelector.Items.Clear();
					cbSubTypeSelector.Enabled = false;
					cbSubTypeSelector.Text = "";

					pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_subtype_idx out of range", Color.Red);
				}
				else
				{
					cbSubTypeSelector.SelectedIndex = nSubType;
				}
			}
			/****************************************/
			int nRvRValue = Convert.ToInt32(pTempRow["a_rvr_value"]);
			if (nRvRValue > Defs.SyndicateTypesNGrades.Keys.Count)
			{
				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_rvr_value out of range", Color.Red);
			}
			else
			{
				cbRvRValueSelector.SelectedIndex = nRvRValue;

				if (nRvRValue == 0)
				{
					cbRvRGradeSelector.Items.Clear();
					cbRvRGradeSelector.Enabled = false;
					cbRvRGradeSelector.Text = "";
				}
				else
				{
					cbRvRGradeSelector.SelectedIndex = Convert.ToInt32(pTempRow["a_rvr_grade"]);
				}
			}
			/****************************************/
			tbEffectNormal.Text = pTempRow["a_effect_name"].ToString();
			tbEffectAttack.Text = pTempRow["a_attack_effect_name"].ToString();
			tbEffectDamage.Text = pTempRow["a_damage_effect_name"].ToString();
			/****************************************/
			for (int i = 1; i <= 6; i++)
			{
				Control[] cTextBox = this.Controls.Find("tbVariation" + i, true);
				if (cTextBox.Length > 0)
					((TextBox)cTextBox[0]).Text = pTempRow["a_origin_variation" + i].ToString();
			}
			/****************************************/
			for (int i = 0; i <= 4; i++)
			{
				Control[] cTextBox = this.Controls.Find("tbSet" + i, true);
				if (cTextBox.Length > 0)
					((TextBox)cTextBox[0]).Text = pTempRow["a_set_" + i].ToString();
			}
			/****************************************/
			for (int i = 0; i <= 4; i++)
			{
				Control[] cTextBox = this.Controls.Find("tbOption" + i, true);
				if (cTextBox.Length > 0)
					((TextBox)cTextBox[0]).Text = pTempRow["a_num_" + i].ToString();
			}

			// Crafting
			int iSkillNeededID = Convert.ToInt32(pTempRow["a_need_sskill"]);
			string strSkillName = iSkillNeededID.ToString();
			DataRow pSkillData = pMain.pSkillTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("a_indeX") == iSkillNeededID);

			if (iSkillNeededID != -1)
				strSkillName = iSkillNeededID + " - " + pSkillData["a_name_" + pMain.pSettings.WorkLocale];

			btnSkill1RequiredID.Text = strSkillName;
			tbSkill1RequiredLevel.Text = pTempRow["a_need_sskill_level"].ToString();

#if NEED_SECOND_SKILL_TO_CRAFT
			iSkillNeededID = Convert.ToInt32(pTempRow["a_need_sskill2"]);
			strSkillName = iSkillNeededID.ToString();
			pSkillData = pMain.pSkillTable.AsEnumerable().FirstOrDefault(row => row.Field<int>("a_indeX") == iSkillNeededID);

			if (iSkillNeededID != -1)
				strSkillName = iSkillNeededID + " - " + pSkillData["a_name_" + pMain.pSettings.WorkLocale];

			btnSkill2RequiredID.Text = strSkillName;
			tbSkill2RequiredLevel.Text = pTempRow["a_need_sskill_level2"].ToString();
#endif

			pSkillData = null;
			/****************************************/
			// TODO: agregar más gilada
			/****************************************/
			bUserAction = true;

			btnUpdate.Enabled = true;

			btnCopy.Enabled = true;
			btnDelete.Enabled = true;
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
				int nItemID = pSelectedItem.ID;

				if (bUnsavedChanges)
				{
					DialogResult pDialogReturn = MessageBox.Show("There are unsaved changes. If you proceed, your changes will be discarded.\nDo you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

					if (pDialogReturn == DialogResult.Yes)
					{
						bUnsavedChanges = false;

						LoadItemData(nItemID);
					}
					else
					{
						MainList.SelectedIndexChanged -= MainList_SelectedIndexChanged;
						MainList.SelectedItem = pLastSelected;
						MainList.SelectedIndexChanged += MainList_SelectedIndexChanged;
					}
				}
				else
				{
					LoadItemData(nItemID);
				}

				pLastSelected = pSelectedItem;
			}
		}

		private void btnReload_Click(object sender, EventArgs e)    // NOTE: Here is an example on how to manage the reloading of information from global tables
        {
			nSearchPosition = 0;

			pMain.pItemTable.Dispose();
			pMain.pItemTable = null;

			pMain.pZoneTable.Dispose();
			pMain.pItemTable = null;

			pMain.pSkillTable.Dispose();
			pMain.pSkillTable = null;

			pMain.pSkillLevelTable.Dispose();
			pMain.pSkillLevelTable = null;

			btnCopy.Enabled = false;
			btnDelete.Enabled = false;

			btnUpdate.Enabled = false;

			ItemEditor_LoadAsync(sender, e);
		}

		private void btnAddNew_Click(object sender, EventArgs e)
		{
			/*bool bReturn = pMain.QueryUpdateInsert("utf8", "INSERT INTO lc_data_nov.t_clientversion (a_min, a_max) VALUES('0', '9199')");

		   if (bReturn)
			   pMain.PrintLog("suc");
		   else
			   pMain.PrintLog("failed");
			/////
			DataTable pData = pMain.QuerySelect("utf8", "SELECT * FROM lc_data_nov.t_clientversion;");

			if (pData != null)
			{
				foreach (DataRow row in pData.Rows)
				{
					foreach (DataColumn col in pData.Columns)
						Console.Write(col.ColumnName + " " +row[col] + "\t");

					Console.WriteLine();
				}
			}*/
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			// TODO:
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// TODO:
		}

		private void cbEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				string strEnable = "0";

				if (cbEnable.Checked)
					strEnable = "1";

				pTempRow["a_enable"] = strEnable;

				bUnsavedChanges = true;
			}
		}

		private void pbIcon_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				IconPicker pIconSelector = new IconPicker(pMain, this, "ItemBtn");

				if (pIconSelector.ShowDialog() != DialogResult.OK)
					return;

				string[] strArray = pIconSelector.ReturnValues;

				Image pIcon = pMain.GetIcon("ItemBtn", strArray[0], Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
				if (pIcon != null)
				{
					pTempRow["a_texture_id"] = strArray[0];
					pTempRow["a_texture_row"] = strArray[1];
					pTempRow["a_texture_col"] = strArray[2];

					pbIcon.Image = pIcon;

					pToolTips[pbIcon].SetToolTip(pbIcon, "FILE: " + strArray[0] + " ROW: " + strArray[1] + " COL: " + strArray[2]);

					bUnsavedChanges = true;
				}
			}
		}

		private void tbSMC_DoubleClick(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				OpenFileDialog pFileDialog = new OpenFileDialog();

				pFileDialog.Title = "Item Editor";
				pFileDialog.Filter = "SMC Files|*.smc";
				pFileDialog.InitialDirectory = pMain.pSettings.ClientPath + "\\Data";

				if (pFileDialog.ShowDialog() == DialogResult.OK)
				{
					tbSMC.Text = pFileDialog.FileName.Replace(pMain.pSettings.ClientPath + "\\", "");

					pTempRow["a_file_smc"] = tbSMC.Text;

					bUnsavedChanges = true;
				}
			}
		}

		private void tbMaxStack_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_weight"] = tbMaxStack.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbPrice_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_price"] = tbPrice.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMinLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_level"] = tbMinLevel.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMaxLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_level2"] = tbMaxLevel.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbDurability_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_durability"] = tbDurability.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbFame_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_fame"] = tbFame.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMaxUse_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_max_use"] = tbMaxUse.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbGrade_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_grade"] = tbGrade.Text;

				bUnsavedChanges = true;
			}
		}

		private void cbNationSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				bUserAction = false;

				string strNation = cbNationSelector.SelectedItem.ToString().ToLower();

				tbName.Text = pTempRow["a_name_" + strNation].ToString();

				tbDescription.Text = pTempRow["a_descr_" + strNation].ToString();

				bUserAction = true;
			}
		}

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_name_" + cbNationSelector.SelectedItem.ToString().ToLower()] = tbName.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbDescription_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_descr_" + cbNationSelector.SelectedItem.ToString().ToLower()] = tbDescription.Text;

				bUnsavedChanges = true;
			}
		}

		private void cbCastleType_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nType = cbTypeSelector.SelectedIndex;

			if (nType != -1)
			{
				if (bUserAction)
				{
					pTempRow["a_castle_war"] = nType;

					bUnsavedChanges = true;
				}
			}
		}

		private void btnClassFlag_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				FlagPicker pFlagSelector = new FlagPicker(pMain, this, Defs.ItemClass, Convert.ToInt32(btnClassFlag.Text.ToString()));

				if (pFlagSelector.ShowDialog() != DialogResult.OK)
					return;

				string strFlag = pFlagSelector.ReturnValues.ToString();

				btnClassFlag.Text = strFlag;

				string strTooltip = "";
				long nFlag = Convert.ToInt32(strFlag);

				for (int i = 0; i < Defs.ItemClass.Length; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip += Defs.ItemClass[i] + "\n";
				}

				pToolTips[btnClassFlag].SetToolTip(btnClassFlag, strTooltip);

				pTempRow["a_job_flag"] = strFlag;

				bUnsavedChanges = true;
			}
		}

		private void btnAllowedZoneFlag_Click(object sender, EventArgs e)
		{
#if ALLOWED_ZONE_SYSTEM
			if (bUserAction)
			{
				FlagPicker pFlagSelector = new FlagPicker(pMain, this, strArrayZones, long.Parse(btnAllowedZoneFlag.Text.ToString()));

				if (pFlagSelector.ShowDialog() != DialogResult.OK)
					return;

				string strFlag = pFlagSelector.ReturnValues.ToString();

				btnAllowedZoneFlag.Text = strFlag;

				string strTooltip = "";
				long nFlag = long.Parse(strFlag);

				for (int i = 0; i < pMain.pZoneTable.Rows.Count; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip += pMain.pZoneTable.Rows[i]["a_name"] + "\n";
				}

				pToolTips[btnAllowedZoneFlag].SetToolTip(btnAllowedZoneFlag, strTooltip);

				pTempRow["a_zone_flag"] = strFlag;

				bUnsavedChanges = true;
			}
#endif
		}

		private void tbAllowedZoneFlag_TextChanged(object sender, EventArgs e)
		{
#if !ALLOWED_ZONE_SYSTEM
			if (bUserAction)
			{
				pTempRow["a_zone_flag"] = tbAllowedZoneFlag.Text;

				bUnsavedChanges = true;
			}
#endif
		}

		private void btnItemFlag_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				FlagPicker pFlagSelector = new FlagPicker(pMain, this, Defs.ItemFlag, long.Parse(btnItemFlag.Text.ToString()));

				if (pFlagSelector.ShowDialog() != DialogResult.OK)
					return;

				string strFlag = pFlagSelector.ReturnValues.ToString();

				btnItemFlag.Text = strFlag;

				string strTooltip = "";
				long nFlag = long.Parse(strFlag);

				for (int i = 0; i < Defs.ItemFlag.Length; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip += Defs.ItemFlag[i] + "\n";
				}

				pToolTips[btnItemFlag].SetToolTip(btnItemFlag, strTooltip);

				pTempRow["a_flag"] = strFlag;

				bUnsavedChanges = true;
			}
		}

		private void cbTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nType = cbTypeSelector.SelectedIndex;

			if (nType != -1)
			{
				cbSubTypeSelector.Enabled = false;

				cbSubTypeSelector.Items.Clear();

				cbSubTypeSelector.BeginUpdate();

				foreach (string strSubType in Defs.ItemTypesNSubTypes[Defs.ItemTypesNSubTypes.Keys.ElementAt(nType)])
					cbSubTypeSelector.Items.Add(strSubType);

				cbSubTypeSelector.EndUpdate();

				cbSubTypeSelector.Enabled = true;

				if (bUserAction)
				{
					pTempRow["a_type_idx"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void cbSubTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction && cbTypeSelector.SelectedIndex != -1)
			{
				pTempRow["a_subtype_idx"] = cbSubTypeSelector.SelectedIndex.ToString();

				bUnsavedChanges = true;
			}
		}

		private void cbWearingPositionSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction && cbWearingPositionSelector.SelectedIndex != -1)
			{
				pTempRow["a_wearing"] = cbWearingPositionSelector.SelectedIndex.ToString();

				bUnsavedChanges = true;
			}
		}

		private void cbRvRValueSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nType = cbRvRValueSelector.SelectedIndex;

			if (nType > 0)
			{
				cbRvRGradeSelector.Enabled = false;

				cbRvRGradeSelector.Items.Clear();

				cbRvRGradeSelector.BeginUpdate();

				foreach (string strGrade in Defs.SyndicateTypesNGrades[Defs.SyndicateTypesNGrades.Keys.ElementAt(nType)])
					cbRvRGradeSelector.Items.Add(strGrade);

				cbRvRGradeSelector.EndUpdate();

				cbRvRGradeSelector.Enabled = true;
			}

			if (bUserAction)
			{
				pTempRow["a_rvr_value"] = nType.ToString();

				bUnsavedChanges = true;
			}
		}

		private void cbRvRGradeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction && cbRvRGradeSelector.SelectedIndex != -1)
			{
				pTempRow["a_rvr_grade"] = cbRvRGradeSelector.SelectedIndex.ToString();

				bUnsavedChanges = true;
			}
		}

		private void tbEffectNormal_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_effect_name"] = tbEffectNormal.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbEffectAttack_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_attack_effect_name"] = tbEffectAttack.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbEffectDamage_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_damage_effect_name"] = tbEffectDamage.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation1_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation1"] = tbVariation1.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation2_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation2"] = tbVariation2.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation3_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation3"] = tbVariation3.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation4_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation4"] = tbVariation4.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation5_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation5"] = tbVariation5.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation6_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_origin_variation6"] = tbVariation6.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet0_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_set_0"] = tbSet0.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet1_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_set_1"] = tbSet1.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet2_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_set_2"] = tbSet2.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet3_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_set_3"] = tbSet3.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet4_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_set_4"] = tbSet4.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption0_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_num_0"] = tbOption0.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption1_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_num_1"] = tbOption1.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption2_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_num_2"] = tbOption2.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption3_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_num_3"] = tbOption3.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption4_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_num_4"] = tbOption4.Text;

				bUnsavedChanges = true;
			}
		}

		private void btnSkill1RequiredID_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				string strIDColumn = "a_need_sskill";
				string strLevelColumn = "a_need_sskill_level";

				SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { Convert.ToInt32(pTempRow[strIDColumn]), pTempRow[strLevelColumn].ToString() });

				if (pSkillSelector.ShowDialog() != DialogResult.OK)
					return;

				int iSkillNeededID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
				string strSkillLevelNeeded = pSkillSelector.ReturnValues[1].ToString();
				string strSkillName = iSkillNeededID.ToString();

				if (iSkillNeededID != -1)
					strSkillName = iSkillNeededID + " - " + pMain.pSkillTable.Rows[iSkillNeededID]["a_name_" + pMain.pSettings.WorkLocale];

				btnSkill1RequiredID.Text = strSkillName;
				tbSkill1RequiredLevel.Text = strSkillLevelNeeded;

				pTempRow[strIDColumn] = iSkillNeededID.ToString();
				pTempRow[strLevelColumn] = strSkillLevelNeeded;

				bUnsavedChanges = true;
			}
		}

		private void tbSkill1RequiredLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_need_sskill_level"] = tbSkill1RequiredLevel.Text;

				bUnsavedChanges = true;
			}
		}

		private void btnSkill2RequiredID_Click(object sender, EventArgs e)
		{
#if NEED_SECOND_SKILL_TO_CRAFT
			if (bUserAction)
			{
				string strIDColumn = "a_need_sskill";
				string strLevelColumn = "a_need_sskill_level";

				SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { Convert.ToInt32(pTempRow[strIDColumn]), pTempRow[strLevelColumn].ToString() });

				if (pSkillSelector.ShowDialog() != DialogResult.OK)
					return;

				int iSkillNeededID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
				string strSkillLevelNeeded = pSkillSelector.ReturnValues[1].ToString();
				string strSkillName = iSkillNeededID.ToString();

				if (iSkillNeededID != -1)
					strSkillName = iSkillNeededID + " - " + pMain.pSkillTable.Rows[iSkillNeededID]["a_name_" + pMain.pSettings.WorkLocale];

				btnSkill2RequiredID.Text = strSkillName;
				tbSkill2RequiredLevel.Text = strSkillLevelNeeded;

				pTempRow[strIDColumn] = iSkillNeededID.ToString();
				pTempRow[strLevelColumn] = strSkillLevelNeeded;

				bUnsavedChanges = true;
			}
#endif
		}

		private void tbSkill2RequiredLevel_TextChanged(object sender, EventArgs e)
		{
#if NEED_SECOND_SKILL_TO_CRAFT
			if (bUserAction)
			{
				pTempRow["a_need_sskill_level2"] = tbSkill2RequiredLevel.Text;

				bUnsavedChanges = true;
			}
#endif
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			DataRow[] pRow = pMain.pItemTable.Select("a_index = " + Convert.ToInt32(tbID.Text));

			int nRowIndex = pMain.pItemTable.Rows.IndexOf(pRow[0]);

			foreach (DataColumn column in pTempRow.Table.Columns)
			{
				string strColumnName = column.ColumnName;
				object objColumnValue = pTempRow[column];

				// TODO: Compose query to update values in db server

				// NOTE: Esto puede ser útil más adelante. Verifica si la columna existe en la tabla principal.
				/*if (!pMain.pItemTable.Columns.Contains("column_name"))
					pMain.pItemTable.Columns.Add("column_name", column.DataType);*/
				// TODO: Add check, if query fails?
				pMain.pItemTable.Rows[nRowIndex][strColumnName] = objColumnValue;
			}
		}
	}
}
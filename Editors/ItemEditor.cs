//#define NEED_SECOND_SKILL_TO_CRAFT	// NOTE: These values are required by the server, but are not actually used
#define ALLOWED_ZONE_SYSTEM // NOTE: Custom system made by NicolasG, disable that to use normal a_zone_flag

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Definitions;
using IniParser;
using IniParser.Model;

namespace LastChaos_ToolBox_2024.Editors
{
	public partial class ItemEditor : Form
	{
		private Main pMain;
		private RenderDialog pRenderDialog;
		private bool bUserAction = false;
		private bool bUnsavedChanges = false;
		private bool bFortuneLoaded = false;
		private int nSearchPosition = 0;
		private ListBoxItem pLastSelected;
		private DataRow pTempItemRow;
		private DataRow pTempFortuneHeadRow;
		private DataRow[] pTempFortuneDataRows;
		private string[] strArrayZones;
		private System.Windows.Forms.ToolTip pToolTip;
		private Dictionary<Control, ToolTip> pToolTips = new Dictionary<Control, ToolTip>();

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

			gbFortune.MouseEnter += gbFortune_MouseEnter;
			/****************************************/
			gridFortune.TopLeftHeaderCell.Value = "N°";

			DataGridViewButtonColumn cSkill = new DataGridViewButtonColumn();
			cSkill.Name = "skill";
			cSkill.HeaderText = "Skill";
			gridFortune.Columns.Add(cSkill);

			DataGridViewComboBoxColumn cSkillLevel = new DataGridViewComboBoxColumn();
			cSkillLevel.Name = "level";
			cSkillLevel.HeaderText = "Skill Level";
			gridFortune.Columns.Add(cSkillLevel);

			gridFortune.Columns.Add("prob", "Probability");

			DataGridViewButtonColumn cString = new DataGridViewButtonColumn();
			cString.Name = "string";
			cString.HeaderText = "String ID";
			gridFortune.Columns.Add(cString);

			gridFortune.AdvancedRowHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
			gridFortune.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 30, 31);
			gridFortune.RowHeadersDefaultCellStyle.SelectionForeColor = gridFortune.RowHeadersDefaultCellStyle.ForeColor = Color.FromArgb(208, 203, 148);
			gridFortune.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 56, 54);

			gridFortune.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
			gridFortune.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 30, 31);
			gridFortune.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(208, 203, 148);
			gridFortune.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			gridFortune.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
			gridFortune.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
			gridFortune.DefaultCellStyle.ForeColor = Color.FromArgb(208, 203, 148);
			gridFortune.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			gridFortune.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			/****************************************/
			cbRenderDialog.Checked = bool.Parse(pMain.pSettings.ShowRenderDialog[this.Name]);
			cbAutoLoadFortuneData.Checked = bool.Parse(pMain.pSettings.ItemEditorAutoShowFortune);
		}

		private void cbRenderDialog_CheckedChanged(object sender, EventArgs e)
		{
			string strState = "false";

			if (cbRenderDialog.Checked)
				strState = "true";

			pMain.pSettings.ShowRenderDialog[this.Name] = strState;

			FileIniDataParser pParser = new FileIniDataParser();
			IniData pData = pParser.ReadFile(pMain.pSettings.SettingsFile);

			pData["RenderDialog"]["ItemEditor"] = strState;

			pParser.WriteFile(pMain.pSettings.SettingsFile, pData);
		}

		private void cbAutoLoadFortuneData_CheckedChanged(object sender, EventArgs e)
		{
			string strState = "false";

			if (cbAutoLoadFortuneData.Checked)
				strState = "true";

			pMain.pSettings.ItemEditorAutoShowFortune = strState;

			FileIniDataParser pParser = new FileIniDataParser();
			IniData pData = pParser.ReadFile(pMain.pSettings.SettingsFile);

			pData["Settings"]["ItemEditorAutoLoadFortune"] = strState;

			pParser.WriteFile(pMain.pSettings.SettingsFile, pData);
		}

		private void MakepItemFortuneHeadTableStructure()
		{
			pMain.pItemFortuneHeadTable = new DataTable();

			pMain.pItemFortuneHeadTable.Columns.Add("a_item_idx", typeof(int));     // int
			pMain.pItemFortuneHeadTable.Columns.Add("a_prob_type", typeof(byte));   // tinyint unsigned
			pMain.pItemFortuneHeadTable.Columns.Add("a_enable", typeof(byte));      // tinyint unsigned
		}

		private void MakepItemFortuneDataTableStructure()
		{
			pMain.pItemFortuneDataTable = new DataTable();

			pMain.pItemFortuneDataTable.Columns.Add("a_item_idx", typeof(int));         // int
			pMain.pItemFortuneDataTable.Columns.Add("a_skill_index", typeof(int));      // int
			pMain.pItemFortuneDataTable.Columns.Add("a_skill_level", typeof(sbyte));    // tinyint
			pMain.pItemFortuneDataTable.Columns.Add("a_string_index", typeof(int));     // int
			pMain.pItemFortuneDataTable.Columns.Add("a_prob", typeof(int));             // int
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
			List<string> listQueryCompose = new List<string>
			{
				"a_enable", "a_texture_id", "a_texture_row", "a_texture_col", "a_file_smc", "a_weight", "a_price", "a_level", "a_level2", "a_durability", "a_fame",
				"a_max_use", "a_grade", "a_type_idx", "a_subtype_idx", "a_wearing", "a_rvr_value", "a_rvr_grade", "a_effect_name", "a_attack_effect_name",
				"a_damage_effect_name", "a_castle_war", "a_job_flag", "a_zone_flag", "a_flag", "a_origin_variation1", "a_origin_variation2", "a_origin_variation3",
				"a_origin_variation4", "a_origin_variation5", "a_origin_variation6", "a_set_0", "a_set_1", "a_set_2", "a_set_3", "a_set_4", "a_num_0", "a_num_1",
				"a_num_2", "a_num_3", "a_num_4", "a_need_sskill", "a_need_sskill_level",
#if NEED_SECOND_SKILL_TO_CRAFT
				"a_need_sskill2", "a_need_sskill_level2",
#endif
				"a_need_item0", "a_need_item_count0", "a_need_item1", "a_need_item_count1", "a_need_item2", "a_need_item_count2", "a_need_item3", "a_need_item_count3",
				"a_need_item4", "a_need_item_count4", "a_need_item5", "a_need_item_count5", "a_need_item6", "a_need_item_count6", "a_need_item7", "a_need_item_count7",
				"a_need_item8", "a_need_item_count8", "a_need_item9", "a_need_item_count9", "a_rare_index_0", "a_rare_prob_0", "a_rare_index_1", "a_rare_prob_1",
				"a_rare_index_2", "a_rare_prob_2", "a_rare_index_3", "a_rare_prob_3", "a_rare_index_4", "a_rare_prob_4", "a_rare_index_5", "a_rare_prob_5",
				"a_rare_index_6", "a_rare_prob_6", "a_rare_index_7", "a_rare_prob_7", "a_rare_index_8", "a_rare_prob_8", "a_rare_index_9", "a_rare_prob_9"
			};

			// NOTE: If columns related to locale are required, they must be defined here.
			for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
			{
				string strNation = pMain.pSettings.NationSupported[i].ToLower();

				listQueryCompose.Add("a_name_" + strNation);
				listQueryCompose.Add("a_descr_" + strNation);
			}

			if (pMain.pItemTable == null)   // NOTE: If the global table is empty, directly indicate that a query must be executed requesting all previously defined columns
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
					// NOTE: As you can see, regardless of the columns to request, it is always necessary to request the reference column, in this case a_index.
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
				});
			}
		}

		private async Task LoadZoneDataAsync()
		{
			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string> { "a_name" };

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

			List<string> listQueryCompose = new List<string> {
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
					if (!pMain.pSkillTable.Columns.Contains(column))
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
			}

			// Reset vals & Populate pSkillLevelTable
			bRequestNeeded = false;
			listQueryCompose.Clear();

			listQueryCompose = new List<string> { "a_level", "a_dummypower" };

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

		private async Task LoadRareOptionDataAsync()
		{
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
		}

		private void LoadFortuneData()
		{
#if DEBUG
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
#endif
			int nItemID = Convert.ToInt32(pTempItemRow["a_index"]);

			bool bRequestNeeded = pMain.pItemFortuneHeadTable == null || pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID).FirstOrDefault() == null;
			if (bRequestNeeded)
			{
				var pHeadResult = pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_item_idx, a_prob_type, a_enable FROM {pMain.pSettings.DBData}.t_fortune_head WHERE a_item_idx = " + nItemID);

				if (pHeadResult != null && pHeadResult.Rows.Count > 0)
				{
					pMain.pItemFortuneHeadTable = pHeadResult;
					/****************************************/
					bRequestNeeded = pMain.pItemFortuneDataTable == null || pMain.pItemFortuneDataTable.Select("a_item_idx = " + nItemID).Length <= 0;
					if (bRequestNeeded)
					{
						var pDataResult = pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_item_idx, a_skill_index, a_skill_level, a_string_index, a_prob FROM {pMain.pSettings.DBData}.t_fortune_data WHERE a_item_idx = " + nItemID + " ORDER BY a_string_index;"); // NOTE: I don't know what column use to sort

						if (pDataResult != null && pDataResult.Rows.Count > 0)
							pMain.pItemFortuneDataTable = pDataResult;
					}
				}
			}
#if DEBUG
			stopwatch.Stop();
			pMain.Logger($"Check and Fortune Head & Data load took: {stopwatch.ElapsedMilliseconds} ms.");
#endif
		}

		private void SetFortuneData()
		{
			if (bFortuneLoaded)
				return;

			bFortuneLoaded = true;

			rtFortuneWarning.Visible = false;

			gridFortune.Rows.Clear();

			int nItemID = Convert.ToInt32(pTempItemRow["a_index"]);

			if (pMain.pItemFortuneHeadTable != null && pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID).Length > 0)
			{
				pTempFortuneHeadRow = pMain.pItemFortuneHeadTable.NewRow();
				pTempFortuneHeadRow.ItemArray = (object[])pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID)[0].ItemArray.Clone();
			}

			if (pTempFortuneHeadRow != null)
			{
				cbFortuneEnable.Visible = true;
				lProbType.Visible = true;
				cbFortuneProbType.Visible = true;
				gridFortune.Enabled = true;

				if (pTempFortuneHeadRow["a_enable"].ToString() == "1")
					cbFortuneEnable.Checked = true;
				else
					cbFortuneEnable.Checked = false;

				cbFortuneProbType.SelectedIndex = Convert.ToInt32(pTempFortuneHeadRow["a_prob_type"]);
				/****************************************/
				if (pMain.pItemFortuneDataTable != null)
				{
					pTempFortuneDataRows = pMain.pItemFortuneDataTable.AsEnumerable().Where(row => row.RowState != DataRowState.Deleted && row.Field<int>("a_item_idx") == nItemID).ToArray();

					if (pTempFortuneDataRows.Length > 0)
					{
						int i = 0;
						foreach (DataRow pFortuneRow in pTempFortuneDataRows)
						{
							int iFortuneSkillID = Convert.ToInt32(pFortuneRow["a_skill_index"]);
							int iFortuneSkillLevel = Convert.ToInt32(pFortuneRow["a_skill_level"]);
							string strSkillID = iFortuneSkillID.ToString();

							DataRow pSkillRow = pMain.pSkillTable.Select("a_index = " + strSkillID).FirstOrDefault();
							if (pSkillRow != null)
							{
								gridFortune.Rows.Insert(i);

								gridFortune.Rows[i].HeaderCell.Value = (i + 1).ToString();

								gridFortune.Rows[i].Cells["skill"].Value = strSkillID + " - " + pSkillRow["a_name_" + pMain.pSettings.WorkLocale];
								gridFortune.Rows[i].Cells["skill"].Tag = iFortuneSkillID;
								gridFortune.Rows[i].Cells["skill"].ToolTipText = pSkillRow["a_client_description_" + pMain.pSettings.WorkLocale].ToString();

								using (DataGridViewComboBoxCell cSkillLevel = (DataGridViewComboBoxCell)gridFortune.Rows[i].Cells["level"])
								{
									List<DataRow> listSkillLevels = pMain.pSkillLevelTable.AsEnumerable().Where(row => row.Field<int>("a_index") == iFortuneSkillID).ToList();

									foreach (var pRowSkillLevel in listSkillLevels)
									{
										int iSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

										cSkillLevel.Items.Add("Level: " + iSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

										if (iFortuneSkillLevel == iSkillLevel)
											cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
									}
								}

								gridFortune.Rows[i].Cells["level"].Tag = iFortuneSkillLevel;

								gridFortune.Rows[i].Cells["prob"].Value = pFortuneRow["a_prob"].ToString();

								gridFortune.Rows[i].Cells["string"].Value = pFortuneRow["a_string_index"].ToString();
							}

							pSkillRow = null;

							i++;
						}
					}
					else
					{
						pMain.Logger("Item Editor > Item: " + nItemID + " Warning: This item have a entry in a_fortune_head, but not in a_fortune_data.", Color.Yellow);
					}
				}
			}
			else
			{
				if (pMain.pSettings.ItemEditorAutoShowFortune == "false")
					rtFortuneWarning.Visible = false;

				btnAddFortune.Visible = true;
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
			/****************************************/
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
			cbGrade.Items.Clear();

			cbGrade.BeginUpdate();

			foreach (string strAPetType in Defs.APetTypes)
				cbGrade.Items.Add(strAPetType);

			cbGrade.EndUpdate();
			/****************************************/
			cbCastleType.Items.Clear();

			cbCastleType.BeginUpdate();

			foreach (string strCastleType in Defs.ItemCastleTypes)
				cbCastleType.Items.Add(strCastleType);

			cbCastleType.EndUpdate();
			/****************************************/
			cbWearingPositionSelector.Items.Clear();

			cbWearingPositionSelector.BeginUpdate();

			foreach (string strWearingPos in Defs.ItemWearingPositions)
				cbWearingPositionSelector.Items.Add(strWearingPos);

			cbWearingPositionSelector.EndUpdate();
			/****************************************/
			cbTypeSelector.Items.Clear();

			cbTypeSelector.BeginUpdate();

			foreach (string strType in Defs.ItemTypesNSubTypes.Keys)
				cbTypeSelector.Items.Add(strType);

			cbTypeSelector.EndUpdate();
			/****************************************/
			cbRvRValueSelector.Items.Clear();

			cbRvRValueSelector.BeginUpdate();

			foreach (string strSyndicateType in Defs.SyndicateTypesNGrades.Keys)
				cbRvRValueSelector.Items.Add(strSyndicateType);

			cbRvRValueSelector.EndUpdate();
			/****************************************/
			cbFortuneEnable.Visible = false;
			lProbType.Visible = false;
			cbFortuneProbType.Visible = false;
			btnAddFortune.Visible = false;
			gridFortune.Enabled = false;

			cbFortuneProbType.Items.Clear();

			cbFortuneProbType.BeginUpdate();

			foreach (string strProbType in Defs.FortuneItemProbTypes)
				cbFortuneProbType.Items.Add(strProbType);

			cbFortuneProbType.EndUpdate();
#if DEBUG
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
#endif
			await Task.WhenAll( // NOTE: Here information is requested from the mysql server asynchronously, thus reducing waiting times to the minimum possible.
				LoadItemDataAsync(),    // Populate pItemTable
				LoadZoneDataAsync(),    // Populate pZoneTable
				LoadSkillDataAsync(),    // Populate pSkillTable & pSkillLevelTable
				LoadRareOptionDataAsync()   // Populate pRateoptionTable
			);
#if DEBUG
			stopwatch.Stop();
			pMain.Logger($"Items, Zones, Skill & Skills Level Data load took: {stopwatch.ElapsedMilliseconds} ms.");
#endif
			/****************************************/
			if (pMain.pItemTable != null && pMain.pZoneTable != null && pMain.pSkillTable != null && pMain.pSkillLevelTable != null && pMain.pRareOptionTable != null)
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
				/****************************************/
				cbSet0.Items.Clear();

				cbSet0.BeginUpdate();

				for (int i = 0; i < nTotalZones; i++)
					cbSet0.Items.Add(pMain.pZoneTable.Rows[i]["a_name"].ToString());

				cbSet0.EndUpdate();
			}
			/****************************************/
			pToolTip = new ToolTip();

			pToolTip.SetToolTip(btnReload, "Reload Items, Zones, Skills, Rare Options & Fortune Data from Database");
			pToolTip.SetToolTip(cbAutoLoadFortuneData, "When this is checked The Fortune Data are requested to server (If are not stored yet) automatically when select and Item from List.");

			pToolTips[cbAutoLoadFortuneData] = pToolTip;    // For Dispose
			/****************************************/
			MainList.Enabled = true;

			btnReload.Enabled = true;
			btnAddNew.Enabled = true;

			pProgressDialog.Close();

			MainList.Focus();
		}

		private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)  // NOTE: Here is an example of the unsaved data warning messages in case want to close the form.
		{
			void Clear()
			{
				foreach (var toolTip in pToolTips.Values)
					toolTip.Dispose();

				pToolTips = null;

				if (pRenderDialog != null)
				{
					pRenderDialog.Close();
					pRenderDialog = null;
				}

				// TODO: Add here all used tables, arrays, etc
				pTempItemRow = null;
				pTempFortuneHeadRow = null;
				pTempFortuneDataRows = null;

				strArrayZones = null;
			}

			if (bUnsavedChanges)
			{
				DialogResult pDialogReturn = MessageBox.Show("You have unsaved changes. Do you want to discard them and exit?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

			// Reset Controls
			cbTypeSelector.SelectedIndex = -1;
			cbSubTypeSelector.SelectedIndex = -1;
			cbWearingPositionSelector.SelectedIndex = -1;

			bFortuneLoaded = false;
			cbFortuneEnable.Visible = false;
			lProbType.Visible = false;
			cbFortuneProbType.Visible = false;
			btnAddFortune.Visible = false;
			gridFortune.Enabled = false;

			pTempFortuneHeadRow = null;
			pTempFortuneDataRows = null;

			foreach (var toolTip in pToolTips.Values)
				toolTip.Dispose();
			/****************************************/
			pTempItemRow = pMain.pItemTable.NewRow();   // Replicate struct in temp row val
			pTempItemRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = " + nItemID)[0].ItemArray.Clone();    // Copy data from main table to temp one

			// General
			tbID.Text = nItemID.ToString();
			/****************************************/
			if (pTempItemRow["a_enable"].ToString() == "1")
				cbEnable.Checked = true;
			else
				cbEnable.Checked = false;
			/****************************************/
			string strTexID = pTempItemRow["a_texture_id"].ToString();
			string strTexRow = pTempItemRow["a_texture_row"].ToString();
			string strTexCol = pTempItemRow["a_texture_col"].ToString();

			Image pIcon = pMain.GetIcon("ItemBtn", strTexID, Convert.ToInt32(strTexRow), Convert.ToInt32(strTexCol));
			if (pIcon != null)
			{
				pbIcon.Image = pIcon;

				pToolTip = new ToolTip();
				pToolTip.SetToolTip(pbIcon, "FILE: " + strTexID + " ROW: " + strTexRow + " COL: " + strTexCol);
				pToolTips[pbIcon] = pToolTip;
			}
			/****************************************/
			string strSMCPath = pTempItemRow["a_file_smc"].ToString();

			tbSMC.Text = strSMCPath.Replace("Data\\", "");

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(tbSMC, "Double Click to edit");
			pToolTips[tbSMC] = pToolTip;
			/****************************************/
			int nWearingPosition = Convert.ToInt32(pTempItemRow["a_wearing"]);

			if (pMain.pSettings.ShowRenderDialog[this.Name] == "true")
			{
				if (pRenderDialog == null || pRenderDialog.IsDisposed)
					pRenderDialog = new RenderDialog(pMain);

				if (!pRenderDialog.Visible)
					pRenderDialog.Show();

				if (!File.Exists(pMain.pSettings.ClientPath + "\\" + strSMCPath))
					pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_file_smc path not exist or empty.", Color.Red);
				else
					pRenderDialog.SetModel(pMain.pSettings.ClientPath + "\\" + strSMCPath, "small", nWearingPosition);
			}
			/****************************************/
			tbMaxStack.Text = pTempItemRow["a_weight"].ToString();

			tbPrice.Text = pTempItemRow["a_price"].ToString();

			tbMinLevel.Text = pTempItemRow["a_level"].ToString();

			tbMaxLevel.Text = pTempItemRow["a_level2"].ToString();

			tbDurability.Text = pTempItemRow["a_durability"].ToString();

			tbFame.Text = pTempItemRow["a_fame"].ToString();

			tbMaxUse.Text = pTempItemRow["a_max_use"].ToString();
			/****************************************/
			int nAPetType = Convert.ToInt32(pTempItemRow["a_grade"]);

			if (nAPetType < 0 || nAPetType > Defs.ItemCastleTypes.Length)
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_grade out of range.", Color.Red);
			else
				cbGrade.SelectedIndex = nAPetType;
			/****************************************/
			string strNation = cbNationSelector.SelectedItem.ToString().ToLower();

			tbName.Text = pTempItemRow["a_name_" + strNation].ToString();
			tbDescription.Text = pTempItemRow["a_descr_" + strNation].ToString();
			/****************************************/
			int nCastleType = Convert.ToInt32(pTempItemRow["a_castle_war"]);

			if (nCastleType < 0 || nCastleType > Defs.ItemCastleTypes.Length)
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_castle_war out of range.", Color.Red);
			else
				cbCastleType.SelectedIndex = nCastleType;
			/****************************************/
			if (nWearingPosition < -1 || nWearingPosition > Defs.ItemWearingPositions.Length)
			{
				cbWearingPositionSelector.Enabled = false;
				cbWearingPositionSelector.Text = "";

				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_wearing out of range.", Color.Red);
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
			btnClassFlag.Text = pTempItemRow["a_job_flag"].ToString();

			StringBuilder strTooltip = new StringBuilder();

			long nJobFlag = Convert.ToInt32(pTempItemRow["a_job_flag"]);

			for (int i = 0; i < Defs.ItemClass.Length; i++)
			{
				if ((nJobFlag & 1L << i) != 0)
					strTooltip.Append(Defs.ItemClass[i] + "\n");
			}

			if (nJobFlag != 0 && strTooltip.Length <= 0)
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_job_flag out of range.", Color.Red);

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnClassFlag, strTooltip.ToString());
			pToolTips[btnClassFlag] = pToolTip;
			/****************************************/
			string strZoneFlag = pTempItemRow["a_zone_flag"].ToString();

#if ALLOWED_ZONE_SYSTEM
			btnAllowedZoneFlag.Text = strZoneFlag;

			strTooltip = new StringBuilder();
			long nZoneFlag = long.Parse(strZoneFlag);

			for (int i = 0; i < pMain.pZoneTable.Rows.Count; i++)
			{
				if ((nZoneFlag & 1L << i) != 0)
					strTooltip.Append(pMain.pZoneTable.Rows[i]["a_name"] + "\n");
			}

			if (nZoneFlag != 0 && strTooltip.Length <= 0)
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_zone_flag out of range.", Color.Red);

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnAllowedZoneFlag, strTooltip.ToString());
			pToolTips[btnAllowedZoneFlag] = pToolTip;
#else
			tbAllowedZoneFlag.Text = strFlag;
#endif
			/****************************************/
			string strItemFlag = pTempItemRow["a_flag"].ToString();

			btnItemFlag.Text = strItemFlag;

			strTooltip = new StringBuilder();
			long nItemFlag = long.Parse(strItemFlag);

			for (int i = 0; i < Defs.ItemFlag.Length; i++)
			{
				if ((nItemFlag & 1L << i) != 0)
					strTooltip.Append(Defs.ItemFlag[i] + "\n");
			}

			if (nItemFlag != 0 && strTooltip.Length <= 0)
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_flag out of range.", Color.Red);

			// TODO: Add check for conflicts in flag config

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(btnItemFlag, strTooltip.ToString());
			pToolTips[btnItemFlag] = pToolTip;
			/****************************************/
			int nType = Convert.ToInt32(pTempItemRow["a_type_idx"]);

			if (nType < 0 || nType > Defs.ItemTypesNSubTypes.Keys.Count)
			{
				cbTypeSelector.Enabled = false;
				cbTypeSelector.Text = "";

				cbSubTypeSelector.Items.Clear();
				cbSubTypeSelector.Enabled = false;
				cbSubTypeSelector.Text = "";

				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_type_idx out of range.", Color.Red);
			}
			else
			{
				cbTypeSelector.Enabled = true;
				cbTypeSelector.SelectedIndex = nType;

				int nSubType = Convert.ToInt32(pTempItemRow["a_subtype_idx"]);

				if (nSubType < 0 || nSubType > Defs.ItemTypesNSubTypes[Defs.ItemTypesNSubTypes.Keys.ElementAt(nType)].Count)
				{
					cbSubTypeSelector.Items.Clear();
					cbSubTypeSelector.Enabled = false;
					cbSubTypeSelector.Text = "";

					pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_subtype_idx out of range.", Color.Red);
				}
				else
				{
					cbSubTypeSelector.SelectedIndex = nSubType;
				}
			}
			/****************************************/
			int nRvRValue = Convert.ToInt32(pTempItemRow["a_rvr_value"]);
			if (nRvRValue > Defs.SyndicateTypesNGrades.Keys.Count)
			{
				pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_rvr_value out of range.", Color.Red);
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
					cbRvRGradeSelector.SelectedIndex = Convert.ToInt32(pTempItemRow["a_rvr_grade"]);
				}
			}
			/****************************************/
			tbEffectNormal.Text = pTempItemRow["a_effect_name"].ToString();
			tbEffectAttack.Text = pTempItemRow["a_attack_effect_name"].ToString();
			tbEffectDamage.Text = pTempItemRow["a_damage_effect_name"].ToString();
			/****************************************/
			for (int i = 1; i <= 6; i++)
				((TextBox)this.Controls.Find("tbVariation" + i, true)[0]).Text = pTempItemRow["a_origin_variation" + i].ToString();
			/****************************************/
			DataRow pItemTableRow;

			if ((nItemFlag & 1L << 22 /*ITEM_FLAG_QUEST*/) != 0)
			{
				gbSetData.Visible = false;
				gbQuestData.Visible = true;

				if (strArrayZones != null)
				{
					int nZoneID = Convert.ToInt32(pTempItemRow["a_set_0"]);

					if (nZoneID <= strArrayZones.Length)
						cbSet0.SelectedIndex = nZoneID;
					else
						pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_set_0 out of range.", Color.Red);
				}

				for (int i = 1; i <= 4; i++)
					((TextBox)this.Controls.Find("tbSet" + i, true)[0]).Text = pTempItemRow["a_set_" + i].ToString();
			}
			else
			{
				gbQuestData.Visible = false;
				gbSetData.Visible = true;

				for (int i = 0; i <= 4; i++)
				{
					int nSetItemID = Convert.ToInt32(pTempItemRow["a_set_" + i]);
					string strItemID = nSetItemID.ToString();

					if (nSetItemID != 0)
					{
						pItemTableRow = pMain.pItemTable.Select("a_index = " + nSetItemID).FirstOrDefault();

						if (pItemTableRow != null)
							strItemID += " - " + pItemTableRow["a_name_" + pMain.pSettings.WorkLocale];
						else
							pMain.Logger("Item Editor > Item: " + nSetItemID + " Error: a_set_" + i + " not exist.", Color.Red);

						pItemTableRow = null;
					}

					((Button)this.Controls.Find("btnSet" + i, true)[0]).Text = strItemID;
				}
			}
			/****************************************/
			for (int i = 0; i <= 4; i++)
				((TextBox)this.Controls.Find("tbOption" + i, true)[0]).Text = pTempItemRow["a_num_" + i].ToString();

			// Crafting
			int iSkillNeededID = Convert.ToInt32(pTempItemRow["a_need_sskill"]);
			string strSkillName = iSkillNeededID.ToString();

			if (iSkillNeededID != -1)
			{
				DataRow pSkillData = pMain.pSkillTable.Select("a_index = " + iSkillNeededID).FirstOrDefault();

				if (pSkillData != null)
					strSkillName += " - " + pSkillData["a_name_" + pMain.pSettings.WorkLocale];
				else
					pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_need_sskill " + iSkillNeededID + " not exist.", Color.Red);

				pSkillData = null;
			}

			btnSkill1RequiredID.Text = strSkillName;
			tbSkill1RequiredLevel.Text = pTempItemRow["a_need_sskill_level"].ToString();

#if NEED_SECOND_SKILL_TO_CRAFT
			iSkillNeededID = Convert.ToInt32(pTempRow["a_need_sskill2"]);
			strSkillName = iSkillNeededID.ToString();
			pSkillData = pMain.pSkillTable.Select("a_index = " + iSkillNeededID).FirstOrDefault();

			if (iSkillNeededID != -1)
			{
				DataRow pSkillData = pMain.pSkillTable.Select("a_index = " + iSkillNeededID).FirstOrDefault();

				if (pSkillData != null)
					strSkillName += " - " + pSkillData["a_name_" + pMain.pSettings.WorkLocale];
				else
					pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_need_sskill2 " + iSkillNeededID + " not exist.", Color.Red);

				pSkillData = null;
			}

			btnSkill2RequiredID.Text = strSkillName;
			tbSkill2RequiredLevel.Text = pTempRow["a_need_sskill_level2"].ToString();
#endif
			/****************************************/
			for (int i = 0; i <= 9; i++)
			{
				int nRequiredItemID = Convert.ToInt32(pTempItemRow["a_need_item" + i]);
				string strRequiredItemID = nRequiredItemID.ToString();

				if (nRequiredItemID != -1)
				{
					pItemTableRow = pMain.pItemTable.Select("a_index = " + nRequiredItemID).FirstOrDefault();

					if (pItemTableRow != null)
						strRequiredItemID += " - " + pItemTableRow["a_name_" + pMain.pSettings.WorkLocale];
					else
						pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_need_item" + i + " not exist.", Color.Red);

					pItemTableRow = null;
				}

				((Button)this.Controls.Find("btnItem" + i + "Required", true)[0]).Text = strRequiredItemID;

				((TextBox)this.Controls.Find("tbItem" + i + "RequiredAmount", true)[0]).Text = pTempItemRow["a_need_item_count" + i].ToString();
			}

			// Rare
			DataRow pRareOptionTableRow;

			for (int i = 0; i <= 9; i++)
			{
				int nRareOptionID = Convert.ToInt32(pTempItemRow["a_rare_index_" + i]);
				string strRateOptionID = nRareOptionID.ToString();
				int nRateOptionProb = Convert.ToInt32(pTempItemRow["a_rare_prob_" + i]);

				if (nRareOptionID != -1)
				{
					pRareOptionTableRow = pMain.pRareOptionTable.Select("a_index = " + nRareOptionID).FirstOrDefault();

					if (pRareOptionTableRow != null)
						strRateOptionID += " - " + pRareOptionTableRow["a_prefix_" + pMain.pSettings.WorkLocale];
					else
						pMain.Logger("Item Editor > Item: " + nItemID + " Error: a_rare_index_" + i + " not exist.", Color.Red);
				}

				((Button)this.Controls.Find("btnRareIndex" + i, true)[0]).Text = strRateOptionID;

				((TextBox)this.Controls.Find("tbRareProb" + i, true)[0]).Text = nRateOptionProb.ToString();

				((Label)this.Controls.Find("lRareProb" + i + "Percentage", true)[0]).Text = ((nRateOptionProb * 100.0f) / 10000.0f) + "%";
			}

			pRareOptionTableRow = null;

			// Fortune
			if (pMain.pSettings.ItemEditorAutoShowFortune == "true")
			{
				LoadFortuneData();

				SetFortuneData();
			}
			else
			{
				rtFortuneWarning.Visible = true;

				gridFortune.Rows.Clear();
			}

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
					DialogResult pDialogReturn = MessageBox.Show("There are unsaved changes. If you proceed, your changes will be discarded.\nDo you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
			DialogResult pDialogReturn = MessageBox.Show("There are unsaved changes. If you proceed, your changes will be discarded.\nDo you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (pDialogReturn == DialogResult.Yes)
			{
				bUnsavedChanges = false;

				MainList.Enabled = false;
				btnReload.Enabled = false;

				nSearchPosition = 0;

				// TODO: Add dispose to all global tables used by this tool
				pMain.pItemTable.Dispose();
				pMain.pItemTable = null;

				pMain.pZoneTable.Dispose();
				pMain.pZoneTable = null;

				pMain.pSkillTable.Dispose();
				pMain.pSkillTable = null;

				pMain.pSkillLevelTable.Dispose();
				pMain.pSkillLevelTable = null;

				pMain.pRareOptionTable.Dispose();
				pMain.pRareOptionTable = null;

				if (pMain.pItemFortuneHeadTable != null)
				{
					pMain.pItemFortuneHeadTable.Dispose();
					pMain.pItemFortuneHeadTable = null;
				}

				if (pMain.pItemFortuneDataTable != null)
				{
					pMain.pItemFortuneDataTable.Dispose();
					pMain.pItemFortuneDataTable = null;
				}

				btnUpdate.Enabled = false;

				btnAddNew.Enabled = false;
				btnCopy.Enabled = false;
				btnDelete.Enabled = false;

				ItemEditor_LoadAsync(sender, e);
			}
		}

		private void btnAddNew_Click(object sender, EventArgs e)
		{
			// TODO:
			/*bool bReturn = pMain.QueryUpdateInsert(pMain.pSettings.DBCharset, "INSERT INTO lc_data_nov.t_clientversion (a_min, a_max) VALUES('0', '9199')");

		   if (bReturn)
			   pMain.PrintLog("suc");
		   else
			   pMain.PrintLog("failed");
			/////
			DataTable pData = pMain.QuerySelect(pMain.pSettings.DBCharset, "SELECT * FROM lc_data_nov.t_clientversion;");

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

			// TODO: Cuando termine es código y el de btnAddNew, hacer una branch ChangeUIOnFlag para en algún momento retomar la idea de modificar la ui dependiendo de la flag.
			// TODO: En mis otras herramientas usaba una columna temporal indicando que el item era justamente, temporal, se aplicaba esa flag a items copiados o nuevos, pero aquí lo que podría hacer es: un check cuando se selecciona un elemento de MainList, y verificar si int nItemID = Convert.ToInt32(pTempItemRow["a_index"]); existe en pItemTable.
			/*
			 DataRow pRow = pMain.pItemFortuneDataTable.NewRow();
					
					pRow["a_item_idx"] = pTempItemRow["a_index"];
					pRow["a_skill_index"] = row.Cells["skill"].Tag;
					pRow["a_skill_level"] = row.Cells["level"].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None)[0].Replace("Level: ", "").Trim(); // DUDE LOOK THAT SHIT HAHA, NOTE: in theory, the element index is equivalent to level, but i'm not trust so, by go in this way have not room to errors.	//row.Cells["level"].Tag;
					pRow["a_string_index"] = row.Cells["string"].Value;
					pRow["a_prob"] = row.Cells["prob"].Value;

					pTempFortuneDataRows[i] = pRow;
			 */
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			bool bSuccess = true;
			int nItemID = Convert.ToInt32(pTempItemRow["a_index"]);

			DataRow pItemTableRow = pMain.pItemTable.Select("a_index = " + nItemID).FirstOrDefault();
			if (pItemTableRow != null)
			{
				StringBuilder strbuilderQuery = new StringBuilder();

				strbuilderQuery.Append("BEGIN;\n");

				strbuilderQuery.Append("DELETE FROM " + pMain.pSettings.DBData + ".t_fortune_head WHERE a_item_idx = " + nItemID + ";\n");

				strbuilderQuery.Append("DELETE FROM " + pMain.pSettings.DBData + ".t_fortune_data WHERE a_item_idx = " + nItemID + ";\n");

				strbuilderQuery.Append("DELETE FROM " + pMain.pSettings.DBData + ".t_item WHERE a_index = " + nItemID + ";\n");

				string strQuery = strbuilderQuery.Append("COMMIT;\n").ToString();

				if (!(bSuccess = pMain.QueryUpdateInsert(pMain.pSettings.DBCharset, strQuery)))
				{
					string strError = "Item Editor > Item: " + nItemID + " Something got wrong while trying to execute the MySQL Transaction. Changes not applied.";

					pMain.Logger(strError, Color.Red);

					MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			pItemTableRow = null;

			if (bSuccess)
			{
				try
				{
					DataRow pRow;

					if (pMain.pItemFortuneHeadTable != null)
					{
						pRow = pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID).FirstOrDefault();

						if (pRow != null)
							pMain.pItemFortuneHeadTable.Rows.Remove(pRow);
					}

					if (pMain.pItemFortuneDataTable != null)
					{
						DataRow[] pRows = pMain.pItemFortuneDataTable.Select("a_item_idx = " + nItemID);

						if (pRows.Length > 0)
						{
							foreach (DataRow pDataRow in pRows)
								pMain.pItemFortuneDataTable.Rows.Remove(pDataRow);
						}

						pRows = null;
					}

					pRow = pMain.pItemTable.Select("a_index = " + nItemID).FirstOrDefault();

					if (pRow != null)
						pMain.pItemTable.Rows.Remove(pRow);

					pRow = null;
				}
				catch (Exception ex)
				{
					string strError = "Item Editor > Item: " + nItemID + " Changes applied in DataBase, but something got wrong while transferring temp item data to main tables. Please restart the application (" + ex.Message + ").";

					pMain.Logger(strError, Color.Red);

					MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					MessageBox.Show("Item Deleted successfully!", "Item Editor", MessageBoxButtons.OK);

					int nPrevObjectID = MainList.SelectedIndex <= 0 ? 0 : MainList.SelectedIndex - 1;

					MainList.Items.Remove(MainList.SelectedItem);

					MainList.SelectedIndex = nPrevObjectID;

					bUnsavedChanges = false;
				}
			}
		}

		private void cbEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				string strEnable = "0";

				if (cbEnable.Checked)
					strEnable = "1";

				pTempItemRow["a_enable"] = strEnable;

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
					pTempItemRow["a_texture_id"] = strArray[0];
					pTempItemRow["a_texture_row"] = strArray[1];
					pTempItemRow["a_texture_col"] = strArray[2];

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

					pTempItemRow["a_file_smc"] = tbSMC.Text;

					bUnsavedChanges = true;
				}
			}
		}

		private void tbMaxStack_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_weight"] = tbMaxStack.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbPrice_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_price"] = tbPrice.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMinLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_level"] = tbMinLevel.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMaxLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_level2"] = tbMaxLevel.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbDurability_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_durability"] = tbDurability.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbFame_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_fame"] = tbFame.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbMaxUse_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_max_use"] = tbMaxUse.Text;

				bUnsavedChanges = true;
			}
		}

		private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbGrade.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_grade"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void cbNationSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				bUserAction = false;

				string strNation = cbNationSelector.SelectedItem.ToString().ToLower();

				tbName.Text = pTempItemRow["a_name_" + strNation].ToString();

				tbDescription.Text = pTempItemRow["a_descr_" + strNation].ToString();

				bUserAction = true;
			}
		}

		private void tbName_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_name_" + cbNationSelector.SelectedItem.ToString().ToLower()] = tbName.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbDescription_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_descr_" + cbNationSelector.SelectedItem.ToString().ToLower()] = tbDescription.Text;

				bUnsavedChanges = true;
			}
		}

		private void cbCastleType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbTypeSelector.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_castle_war"] = nType;

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

				StringBuilder strTooltip = new StringBuilder();
				long nFlag = Convert.ToInt32(strFlag);

				for (int i = 0; i < Defs.ItemClass.Length; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip.Append(Defs.ItemClass[i] + "\n");
				}

				pToolTips[btnClassFlag].SetToolTip(btnClassFlag, strTooltip.ToString());

				pTempItemRow["a_job_flag"] = strFlag;

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

				StringBuilder strTooltip = new StringBuilder();
				long nFlag = long.Parse(strFlag);

				for (int i = 0; i < pMain.pZoneTable.Rows.Count; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip.Append(pMain.pZoneTable.Rows[i]["a_name"] + "\n");

				}

				pToolTips[btnAllowedZoneFlag].SetToolTip(btnAllowedZoneFlag, strTooltip.ToString());

				pTempItemRow["a_zone_flag"] = strFlag;

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

				long lFlag = pFlagSelector.ReturnValues;
				string strFlag = lFlag.ToString();

				btnItemFlag.Text = strFlag;

				StringBuilder strTooltip = new StringBuilder();
				long nFlag = long.Parse(strFlag);

				for (int i = 0; i < Defs.ItemFlag.Length; i++)
				{
					if ((nFlag & 1L << i) != 0)
						strTooltip.Append(Defs.ItemFlag[i] + "\n");
				}

				// TODO: Add check for conflicts in flag config

				if ((lFlag & 1L << 22 /*ITEM_FLAG_QUEST*/) != 0)
				{
					gbSetData.Visible = false;
					gbQuestData.Visible = true;

					if (strArrayZones != null)
					{
						int nZoneID = Convert.ToInt32(pTempItemRow["a_set_0"]);

						if (nZoneID <= strArrayZones.Length)
							cbSet0.SelectedIndex = nZoneID;
						else
							pMain.Logger("Item Editor > Item: " + pTempItemRow["a_index"].ToString() + " Error: a_set_0 out of range.", Color.Red);
					}

					for (int i = 1; i <= 4; i++)
						((TextBox)this.Controls.Find("tbSet" + i, true)[0]).Text = pTempItemRow["a_set_" + i].ToString();
				}
				else
				{
					gbQuestData.Visible = false;
					gbSetData.Visible = true;

					DataRow pItemTableRow;

					for (int i = 0; i <= 4; i++)
					{
						int nSetItemID = Convert.ToInt32(pTempItemRow["a_set_" + i]);
						string strItemID = nSetItemID.ToString();

						if (nSetItemID != 0)
						{
							pItemTableRow = pMain.pItemTable.Select("a_index = " + nSetItemID).FirstOrDefault();

							if (pItemTableRow != null)
								strItemID += " - " + pItemTableRow["a_name_" + pMain.pSettings.WorkLocale];
							else
								pMain.Logger("Item Editor > Item: " + nSetItemID + " Error: a_set_" + i + " not exist.", Color.Red);

							pItemTableRow = null;
						}

						((Button)this.Controls.Find("btnSet" + i, true)[0]).Text = strItemID;
					}
				}

				pToolTips[btnItemFlag].SetToolTip(btnItemFlag, strTooltip.ToString());

				pTempItemRow["a_flag"] = strFlag;

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
					pTempItemRow["a_type_idx"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void cbSubTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbSubTypeSelector.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_subtype_idx"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void cbWearingPositionSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbWearingPositionSelector.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_wearing"] = nType.ToString();

					bUnsavedChanges = true;
				}
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
				pTempItemRow["a_rvr_value"] = nType.ToString();

				bUnsavedChanges = true;
			}
		}

		private void cbRvRGradeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbRvRGradeSelector.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_rvr_grade"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void tbEffectNormal_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_effect_name"] = tbEffectNormal.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbEffectAttack_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_attack_effect_name"] = tbEffectAttack.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbEffectDamage_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_damage_effect_name"] = tbEffectDamage.Text;

				bUnsavedChanges = true;
			}
		}
		/****************************************/
		private void ChangeVariationAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				pTempItemRow["a_origin_variation" + nNumber] = cTextBox.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbVariation1_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 1); }
		private void tbVariation2_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 2); }
		private void tbVariation3_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 3); }
		private void tbVariation4_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 4); }
		private void tbVariation5_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 5); }
		private void tbVariation6_TextChanged(object sender, EventArgs e) { ChangeVariationAction((TextBox)sender, 6); }
		/****************************************/
		private void cbQuestZoneID_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (bUserAction)
			{
				int nType = cbSet0.SelectedIndex;

				if (nType != -1)
				{
					pTempItemRow["a_set_0"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void btnSetAction(int nNumber)
		{
			// TODO: Here have to do something depending on flag selected.
		}

		private void btnSet0_Click(object sender, EventArgs e) { btnSetAction(0); }
		private void btnSet1_Click(object sender, EventArgs e) { btnSetAction(1); }
		private void btnSet2_Click(object sender, EventArgs e) { btnSetAction(2); }
		private void btnSet3_Click(object sender, EventArgs e) { btnSetAction(3); }
		private void btnSet4_Click(object sender, EventArgs e) { btnSetAction(4); }
		/****************************************/
		private void ChangeSetAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				pTempItemRow["a_set_" + nNumber] = cTextBox.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet1_TextChanged(object sender, EventArgs e) { ChangeSetAction((TextBox)sender, 1); }
		private void tbSet2_TextChanged(object sender, EventArgs e) { ChangeSetAction((TextBox)sender, 2); }
		private void tbSet3_TextChanged(object sender, EventArgs e) { ChangeSetAction((TextBox)sender, 3); }
		private void tbSet4_TextChanged(object sender, EventArgs e) { ChangeSetAction((TextBox)sender, 4); }
		/****************************************/
		private void ChangeOptionAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				pTempItemRow["a_num_" + nNumber] = cTextBox.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbOption0_TextChanged(object sender, EventArgs e) { ChangeOptionAction((TextBox)sender, 0); }
		private void tbOption1_TextChanged(object sender, EventArgs e) { ChangeOptionAction((TextBox)sender, 1); }
		private void tbOption2_TextChanged(object sender, EventArgs e) { ChangeOptionAction((TextBox)sender, 2); }
		private void tbOption3_TextChanged(object sender, EventArgs e) { ChangeOptionAction((TextBox)sender, 3); }
		private void tbOption4_TextChanged(object sender, EventArgs e) { ChangeOptionAction((TextBox)sender, 4); }
		/****************************************/
		private void btnSkill1RequiredID_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				string strIDColumn = "a_need_sskill";
				string strLevelColumn = "a_need_sskill_level";

				SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { Convert.ToInt32(pTempItemRow[strIDColumn]), pTempItemRow[strLevelColumn].ToString() });

				if (pSkillSelector.ShowDialog() != DialogResult.OK)
					return;

				int iSkillNeededID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
				string strSkillLevelNeeded = pSkillSelector.ReturnValues[1].ToString();
				string strSkillName = iSkillNeededID.ToString();

				if (iSkillNeededID != -1)
					strSkillName += " - " + pSkillSelector.ReturnValues[2];

				btnSkill1RequiredID.Text = strSkillName;

				tbSkill1RequiredLevel.Text = strSkillLevelNeeded;

				pTempItemRow[strIDColumn] = iSkillNeededID.ToString();
				pTempItemRow[strLevelColumn] = strSkillLevelNeeded;

				bUnsavedChanges = true;
			}
		}

		private void tbSkill1RequiredLevel_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempItemRow["a_need_sskill_level"] = tbSkill1RequiredLevel.Text;

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
					strSkillName += " - " + pSkillSelector.ReturnValues[2];

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
		/****************************************/
		private void ChangeItemRequiredAction(int nNumber)
		{
			if (bUserAction)
			{
				string strItemIDColumn = "a_need_item" + nNumber;

				ItemPicker pItemSelector = new ItemPicker(pMain, this, Convert.ToInt32(pTempItemRow[strItemIDColumn]));

				if (pItemSelector.ShowDialog() != DialogResult.OK)
					return;

				int iItemNeededID = pItemSelector.ReturnValues;
				string strItemName = iItemNeededID.ToString();

				if (iItemNeededID != -1)
				{
					DataRow pItemTableRow = pMain.pItemTable.Select("a_index = " + iItemNeededID).FirstOrDefault();

					strItemName += " - " + pItemTableRow["a_name_" + pMain.pSettings.WorkLocale];

					pItemTableRow = null;
				}

				((Button)this.Controls.Find("btnItem" + nNumber + "Required", true)[0]).Text = strItemName;

				((TextBox)this.Controls.Find("tbItem" + nNumber + "RequiredAmount", true)[0]).Focus();

				pTempItemRow[strItemIDColumn] = iItemNeededID.ToString();

				bUnsavedChanges = true;
			}
		}

		private void btnItem0Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(0); }
		private void btnItem1Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(1); }
		private void btnItem2Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(2); }
		private void btnItem3Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(3); }
		private void btnItem4Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(4); }
		private void btnItem5Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(5); }
		private void btnItem6Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(6); }
		private void btnItem7Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(7); }
		private void btnItem8Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(8); }
		private void btnItem9Required_Click(object sender, EventArgs e) { ChangeItemRequiredAction(9); }
		/****************************************/
		private void ChangeItemRequiredAmountAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				pTempItemRow["a_need_item_count" + nNumber] = cTextBox.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbItem0RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 0); }
		private void tbItem1RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 1); }
		private void tbItem2RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 2); }
		private void tbItem3RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 3); }
		private void tbItem4RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 4); }
		private void tbItem5RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 5); }
		private void tbItem6RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 6); }
		private void tbItem7RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 7); }
		private void tbItem8RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 8); }
		private void tbItem9RequiredAmount_TextChanged(object sender, EventArgs e) { ChangeItemRequiredAmountAction((TextBox)sender, 9); }
		/****************************************/
		private void ChangeRareOptionAction(int nNumber)
		{
			if (bUserAction)
			{
				string strRareOptionIDColumn = "a_rare_index_" + nNumber;

				ItemPicker pItemSelector = new ItemPicker(pMain, this, Convert.ToInt32(pTempItemRow[strRareOptionIDColumn]));

				RareOptionPicker pRareOptionSelector = new RareOptionPicker(pMain, this, 512);

				if (pRareOptionSelector.ShowDialog() != DialogResult.OK)
					return;

				int iRareOptionID = pRareOptionSelector.ReturnValues;
				string strRareOptionName = iRareOptionID.ToString();

				if (iRareOptionID != -1)
				{
					DataRow pRareOptionTableRow = pMain.pRareOptionTable.Select("a_index = " + iRareOptionID).FirstOrDefault();

					strRareOptionName += " - " + pRareOptionTableRow["a_prefix_" + pMain.pSettings.WorkLocale];

					pRareOptionTableRow = null;
				}

				((Button)this.Controls.Find("btnRareIndex" + nNumber, true)[0]).Text = strRareOptionName;

				((TextBox)this.Controls.Find("tbRareProb" + nNumber, true)[0]).Focus();

				pTempItemRow[strRareOptionIDColumn] = iRareOptionID.ToString();

				bUnsavedChanges = true;
			}
		}

		private void btnRareIndex0_Click(object sender, EventArgs e) { ChangeRareOptionAction(0); }
		private void btnRareIndex1_Click(object sender, EventArgs e) { ChangeRareOptionAction(1); }
		private void btnRareIndex2_Click(object sender, EventArgs e) { ChangeRareOptionAction(2); }
		private void btnRareIndex3_Click(object sender, EventArgs e) { ChangeRareOptionAction(3); }
		private void btnRareIndex4_Click(object sender, EventArgs e) { ChangeRareOptionAction(4); }
		private void btnRareIndex5_Click(object sender, EventArgs e) { ChangeRareOptionAction(5); }
		private void btnRareIndex6_Click(object sender, EventArgs e) { ChangeRareOptionAction(6); }
		private void btnRareIndex7_Click(object sender, EventArgs e) { ChangeRareOptionAction(7); }
		private void btnRareIndex8_Click(object sender, EventArgs e) { ChangeRareOptionAction(8); }
		private void btnRareIndex9_Click(object sender, EventArgs e) { ChangeRareOptionAction(9); }
		/****************************************/
		private void ChangeRareProbAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				string strProb = cTextBox.Text;

				((Label)this.Controls.Find("lRareProb" + nNumber + "Percentage", true)[0]).Text = ((Convert.ToInt32(strProb) * 100.0f) / 10000.0f) + "%";

				pTempItemRow["a_rare_prob_" + nNumber] = strProb;

				bUnsavedChanges = true;
			}
		}

		private void tbRareProb0_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 0); }
		private void tbRareProb1_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 1); }
		private void tbRareProb2_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 2); }
		private void tbRareProb3_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 3); }
		private void tbRareProb4_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 4); }
		private void tbRareProb5_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 5); }
		private void tbRareProb6_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 6); }
		private void tbRareProb7_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 7); }
		private void tbRareProb8_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 8); }
		private void tbRareProb9_TextChanged(object sender, EventArgs e) { ChangeRareProbAction((TextBox)sender, 9); }
		/****************************************/
		private void gbFortune_MouseEnter(object sender, EventArgs e)
		{
			if (bUserAction && pMain.pSettings.ItemEditorAutoShowFortune == "false")
			{
				if (pMain.pItemTable != null)
				{
					bUserAction = false;

					LoadFortuneData();

					SetFortuneData();

					bUserAction = true;
				}
			}
		}

		private void btnAddFortune_Click(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				try
				{
					if (pMain.pItemFortuneHeadTable == null)    // NOTE: This condition theoretically should not be met, but just in case
						MakepItemFortuneHeadTableStructure();

					pTempFortuneHeadRow = pMain.pItemFortuneHeadTable.NewRow();

					pTempFortuneHeadRow["a_item_idx"] = pTempItemRow["a_index"];
					pTempFortuneHeadRow["a_prob_type"] = 0;
					pTempFortuneHeadRow["a_enable"] = 1;
				}
				finally
				{
					btnAddFortune.Visible = false;

					cbFortuneEnable.Visible = true;
					cbFortuneEnable.Checked = true;

					lProbType.Visible = true;

					cbFortuneProbType.Visible = true;
					cbFortuneProbType.SelectedIndex = 0;

					gridFortune.Enabled = true;

					bUnsavedChanges = true;
				}
			}
		}

		private void cbFortuneEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				string strEnable = "0";

				if (cbFortuneEnable.Checked)
					strEnable = "1";

				pTempFortuneHeadRow["a_enable"] = strEnable;

				bUnsavedChanges = true;
			}
		}

		private void cbIFortuneProbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				int nType = cbFortuneProbType.SelectedIndex;

				if (nType != -1)
				{
					pTempFortuneHeadRow["a_prob_type"] = nType.ToString();

					bUnsavedChanges = true;
				}
			}
		}

		private void gridFortune_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (bUserAction)
			{
				if (e.Button == MouseButtons.Left && e.ColumnIndex == 0 && e.RowIndex >= 0) // Skill Selector
				{
					int nSkillID = Convert.ToInt32(((DataGridViewButtonCell)gridFortune.Rows[e.RowIndex].Cells["skill"]).Tag);
					string strSkillLevel = gridFortune.Rows[e.RowIndex].Cells["level"].Tag.ToString();

					SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { nSkillID, strSkillLevel }, false);

					if (pSkillSelector.ShowDialog() != DialogResult.OK)
						return;

					nSkillID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
					int iSelectedSkillLevel = Convert.ToInt32(pSkillSelector.ReturnValues[1]);
					strSkillLevel = pSkillSelector.ReturnValues[1].ToString();

					gridFortune.Rows[e.RowIndex].Cells["skill"].Value = nSkillID + " - " + pSkillSelector.ReturnValues[2];
					gridFortune.Rows[e.RowIndex].Cells["skill"].Tag = nSkillID;
					gridFortune.Rows[e.RowIndex].Cells["skill"].ToolTipText = pSkillSelector.ReturnValues[3].ToString();

					using (DataGridViewComboBoxCell cSkillLevel = (DataGridViewComboBoxCell)gridFortune.Rows[e.RowIndex].Cells["level"])
					{
						List<DataRow> listSkillLevels = pMain.pSkillLevelTable.AsEnumerable().Where(row => row.Field<int>("a_index") == nSkillID).ToList();

						foreach (var pRowSkillLevel in listSkillLevels)
						{
							int iSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

							cSkillLevel.Items.Add("Level: " + iSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

							if (iSelectedSkillLevel == iSkillLevel)
								cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
						}
					}

					gridFortune.Rows[e.RowIndex].Cells["level"].Tag = iSelectedSkillLevel;

					bUnsavedChanges = true;
				}
				else if (e.Button == MouseButtons.Left && e.ColumnIndex == 3 && e.RowIndex >= 0) // String Selector
				{
					StringPicker pStringSelector = new StringPicker(pMain, this, 1, false);

					if (pStringSelector.ShowDialog() != DialogResult.OK)
						return;

					gridFortune.Rows[e.RowIndex].Cells["string"].Value = pStringSelector.ReturnValues[0];
					gridFortune.Rows[e.RowIndex].Cells["string"].ToolTipText = pStringSelector.ReturnValues[1].ToString();

					bUnsavedChanges = true;
				}
				else if (e.Button == MouseButtons.Right && e.ColumnIndex == -1) // Header Column
				{
					ContextMenuStrip ContextMenu = new ContextMenuStrip();

					ToolStripMenuItem addItem = new ToolStripMenuItem("Add New");
					addItem.Click += (menuItemSender, menuItemEventArgs) =>
					{
						int nDefaultSkillID = 1708;
						int nDefaultSkillLevel = 1;
						int nDefaultStringID = 5870;
						int nDefaultProb = 0;

						try
						{
							if (pTempFortuneDataRows == null)
								pTempFortuneDataRows = new DataRow[1];

							int nPosition = pTempFortuneDataRows.Length - 1;

							if (pMain.pItemFortuneDataTable == null)
								MakepItemFortuneDataTableStructure();

							pTempFortuneDataRows[nPosition] = pMain.pItemFortuneDataTable.NewRow();

							pTempFortuneDataRows[nPosition]["a_item_idx"] = pTempItemRow["a_index"];
							pTempFortuneDataRows[nPosition]["a_skill_index"] = nDefaultSkillID;
							pTempFortuneDataRows[nPosition]["a_skill_level"] = nDefaultSkillLevel;
							pTempFortuneDataRows[nPosition]["a_string_index"] = nDefaultStringID;
							pTempFortuneDataRows[nPosition]["a_prob"] = nDefaultProb;
						}
						finally
						{
							DataRow pSkillRow = pMain.pSkillTable.Select("a_index = " + nDefaultSkillID).FirstOrDefault();
							if (pSkillRow != null)
							{
								int i = gridFortune.Rows.Count;

								gridFortune.Rows.Insert(i);

								gridFortune.Rows[i].HeaderCell.Value = (i + 1).ToString();

								gridFortune.Rows[i].Cells["skill"].Value = nDefaultSkillID + " - " + pSkillRow["a_name_" + pMain.pSettings.WorkLocale];
								gridFortune.Rows[i].Cells["skill"].Tag = nDefaultSkillID;
								gridFortune.Rows[i].Cells["skill"].ToolTipText = pSkillRow["a_client_description_" + pMain.pSettings.WorkLocale].ToString();

								using (DataGridViewComboBoxCell cSkillLevel = (DataGridViewComboBoxCell)gridFortune.Rows[i].Cells["level"])
								{
									List<DataRow> listSkillLevels = pMain.pSkillLevelTable.AsEnumerable().Where(row => row.Field<int>("a_index") == nDefaultSkillID).ToList();

									foreach (var pRowSkillLevel in listSkillLevels)
									{
										int iFortuneSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

										cSkillLevel.Items.Add("Level: " + iFortuneSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

										if (nDefaultSkillLevel == iFortuneSkillLevel)
											cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
									}
								}

								gridFortune.Rows[i].Cells["level"].Tag = nDefaultSkillLevel;

								gridFortune.Rows[i].Cells["prob"].Value = nDefaultProb;

								gridFortune.Rows[i].Cells["string"].Value = nDefaultStringID;
							}

							pSkillRow = null;

							bUnsavedChanges = true;
						}
					};

					ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete");
					deleteItem.Enabled = e.RowIndex >= 0;
					deleteItem.Click += (menuItemSender, menuItemEventArgs) =>
					{
						int nRow = e.RowIndex;

						if (nRow >= 0)
						{
							try
							{
								int nSkillID = Convert.ToInt32(((DataGridViewButtonCell)gridFortune.Rows[nRow].Cells["skill"]).Tag);

								DataRow pFortuneLastSkillRow = pTempFortuneDataRows.Cast<DataRow>().Where(row => row.RowState != DataRowState.Deleted && row["a_skill_index"].ToString() == nSkillID.ToString()).LastOrDefault();
								if (pFortuneLastSkillRow != null)
									pTempFortuneDataRows.ElementAt(Array.IndexOf(pTempFortuneDataRows, pFortuneLastSkillRow)).Delete();

								pFortuneLastSkillRow = null;
							}
							finally
							{
								gridFortune.Rows.RemoveAt(nRow);

								int i = 1;
								foreach (DataGridViewRow row in gridFortune.Rows)
								{
									row.HeaderCell.Value = i.ToString();

									i++;
								}

								bUnsavedChanges = true;
							}
						}
					};

					ContextMenu.Items.AddRange(new ToolStripItem[] { addItem, deleteItem });

					ContextMenu.Show(Cursor.Position);
				}
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
#if DEBUG
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
#endif
			int nItemID = Convert.ToInt32(pTempItemRow["a_index"]);
			StringBuilder strbuilderQuery = new StringBuilder();

			// Init transaction.
			strbuilderQuery.Append("BEGIN;\n"); //strbuilderQuery.Append("BEGIN TRANSACTION;\n");

			if (gridFortune.Rows.Count == 0)
			{
				// Request for Fortune Data.
				if (pTempFortuneHeadRow == null || pTempFortuneDataRows == null)
				{
					LoadFortuneData();

					SetFortuneData();   // NOTE: I need call that to populate pTempFortuneHeadRow & pTempFortuneDataRows, but it do some redraws and can make the UI looks laggy... anyway is not too important.
				}
			}
			else
			{
				// First clear and set size of DataRow Array
				pTempFortuneDataRows = new DataRow[gridFortune.Rows.Count];

				// Check if Global Table is not null. If is, set the structure, cos i need use to after.
				if (pMain.pItemFortuneDataTable == null)
					MakepItemFortuneDataTableStructure();

				int i = 0;
				foreach (DataGridViewRow row in gridFortune.Rows)
				{
					DataRow pRow = pMain.pItemFortuneDataTable.NewRow();
					
					pRow["a_item_idx"] = pTempItemRow["a_index"];
					pRow["a_skill_index"] = row.Cells["skill"].Tag;
					pRow["a_skill_level"] = row.Cells["level"].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.None)[0].Replace("Level: ", "").Trim(); // DUDE LOOK THAT SHIT HAHA, NOTE: in theory, the element index is equivalent to level, but i'm not trust so, by go in this way have not room to errors.	//row.Cells["level"].Tag;
					pRow["a_string_index"] = row.Cells["string"].Value;
					pRow["a_prob"] = row.Cells["prob"].Value;

					pTempFortuneDataRows[i] = pRow;

					i++;
				}
			}

			if (pTempFortuneHeadRow != null)
			{
				// Delete all rows in t_fortune_head related to nItemID.
				strbuilderQuery.Append("DELETE FROM " + pMain.pSettings.DBData + ".t_fortune_head WHERE a_item_idx = " + nItemID + ";\n");

				// Compose t_fortune_head INSERT Query.
				StringBuilder strColumnsNames = new StringBuilder();
				StringBuilder strColumnsValues = new StringBuilder();

				foreach (DataColumn pColumn in pTempFortuneHeadRow.Table.Columns)
				{
					strColumnsNames.Append(pColumn.ColumnName + ", ");

					strColumnsValues.Append((object)pTempFortuneHeadRow[pColumn] + ", ");
				}

				strColumnsNames.Length -= 2;
				strColumnsValues.Length -= 2;

				strbuilderQuery.Append("INSERT INTO " + pMain.pSettings.DBData + ".t_fortune_head (" + strColumnsNames + ") VALUES (" + strColumnsValues + ");\n");

				if (pTempFortuneDataRows != null)
				{
					// Delete all rows in t_fortune_data related to nItemID.
					strbuilderQuery.Append("DELETE FROM " + pMain.pSettings.DBData + ".t_fortune_data WHERE a_item_idx = " + nItemID + ";\n");

					// Compose t_fortune_data INSERT Query.
					strColumnsNames = new StringBuilder();
					strColumnsValues = new StringBuilder();

					foreach (DataRow pRow in pTempFortuneDataRows)
					{
						strColumnsValues.Append("(");

						foreach (DataColumn pColumn in pRow.Table.Columns)
						{
							string strColumnName = pColumn.ColumnName;

							if (!strColumnsNames.ToString().Contains(strColumnName))
								strColumnsNames.Append(strColumnName + ", ");

							strColumnsValues.Append((object)pRow[pColumn] + ", ");
						}

						strColumnsValues.Length -= 2;

						strColumnsValues.Append("), ");
					}

					strColumnsNames.Length -= 2;
					strColumnsValues.Length -= 2;

					strbuilderQuery.Append("INSERT INTO " + pMain.pSettings.DBData + ".t_fortune_data (" + strColumnsNames + ") VALUES " + strColumnsValues + ";\n");
				}

				strColumnsNames = null;
				strColumnsValues = null;
			}

			// Check if item exist in Global Table, if exist, do a UPDATE. If not, do a INSERT.
			DataRow pItemTableRow = pMain.pItemTable.Select("a_index = " + nItemID).FirstOrDefault();
			if (pItemTableRow != null)  // UPDATE
			{
				// Compose UPDATE Query.
				strbuilderQuery.Append("UPDATE " + pMain.pSettings.DBData + ".t_item SET");

				foreach (DataColumn pColumn in pTempItemRow.Table.Columns)
					strbuilderQuery.Append(" " + pColumn.ColumnName + " = '" + pMain.EscapeChars(pTempItemRow[pColumn].ToString()) + "',");

				strbuilderQuery.Length -= 1;

				strbuilderQuery.Append(" WHERE a_index = " + nItemID + ";\n");
			}
			else    // INSERT
			{
				// Compose INSERT Query.
				StringBuilder strColumnsNames = new StringBuilder();
				StringBuilder strColumnsValues = new StringBuilder();

				foreach (DataColumn pColumn in pTempItemRow.Table.Columns)
				{
					strColumnsNames.Append(pColumn.ColumnName + ", ");

					strColumnsValues.Append("'" + pMain.EscapeChars(pTempItemRow[pColumn].ToString()) + "', ");
				}

				strColumnsNames.Length -= 2;
				strColumnsValues.Length -= 2;

				strbuilderQuery.Append("INSERT INTO " + pMain.pSettings.DBData + ".t_item (" + strColumnsNames + ") VALUES (" + strColumnsValues + ");\n");

				strColumnsNames = null;
				strColumnsValues = null;
			}

			if (pMain.QueryUpdateInsert(pMain.pSettings.DBCharset, strbuilderQuery.Append("COMMIT;\n").ToString()))
			{
				try
				{
					// Transfer from pTempFortuneHead To pMain.pItemFortuneHeadTable.
					if (pTempFortuneHeadRow != null)
					{
						if (pMain.pItemFortuneHeadTable != null)    // If Global Table is not null.
						{
							DataRow pItemFortuneHeadTableRow = pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID).FirstOrDefault();

							if (pItemFortuneHeadTableRow != null)   // Row exist in Global Table.
							{
								pItemFortuneHeadTableRow.ItemArray = (object[])pTempFortuneHeadRow.ItemArray.Clone();
							}
							else    // Row not exist in Global Table.
							{
								pItemFortuneHeadTableRow = pMain.pItemFortuneHeadTable.NewRow();
								pItemFortuneHeadTableRow.ItemArray = (object[])pTempFortuneHeadRow.ItemArray.Clone();
								pMain.pItemFortuneHeadTable.Rows.Add(pItemFortuneHeadTableRow);
							}

							pItemFortuneHeadTableRow = null;
						}
						else    // If Global Table is null.
						{
							MakepItemFortuneHeadTableStructure();

							DataRow pItemFortuneHeadTableRow = pMain.pItemFortuneHeadTable.NewRow();
							pItemFortuneHeadTableRow.ItemArray = (object[])pTempFortuneHeadRow.ItemArray.Clone();
							pMain.pItemFortuneHeadTable.Rows.Add(pItemFortuneHeadTableRow);

							pItemFortuneHeadTableRow = null;
						}
					}

					// Transfer from pTempFortuneData To pMain.pItemFortuneDataTable.
					if (pTempFortuneDataRows != null && pTempFortuneDataRows.Length > 0)
					{
						if (pMain.pItemFortuneDataTable != null)    // If Global Table is not null.
						{
							DataRow[] pItemFortuneDataTableRows = pMain.pItemFortuneDataTable.Select("a_item_idx = " + nItemID);

							if (pItemFortuneDataTableRows.Length > 0)   // Rows exist in Global Table.
							{
								for (int i = 0; i < pItemFortuneDataTableRows.Length && i < pTempFortuneDataRows.Length; i++)
									pItemFortuneDataTableRows[i].ItemArray = (object[])pTempFortuneDataRows[i].ItemArray.Clone();
							}
							else    // Rows not exist in Global Table.
							{
								foreach (DataRow pTempFortuneDataRow in pTempFortuneDataRows)
								{
									DataRow newDataRow = pMain.pItemFortuneDataTable.NewRow();
									newDataRow.ItemArray = (object[])pTempFortuneDataRow.ItemArray.Clone();
									pMain.pItemFortuneDataTable.Rows.Add(newDataRow);
								}
							}

							pItemFortuneDataTableRows = null;
						}
						else    // If Global Table is null.
						{
							MakepItemFortuneDataTableStructure();

							foreach (DataRow pTempFortuneDataRow in pTempFortuneDataRows)
							{
								DataRow newDataRow = pMain.pItemFortuneDataTable.NewRow();
								newDataRow.ItemArray = (object[])pTempFortuneDataRow.ItemArray.Clone();
								pMain.pItemFortuneDataTable.Rows.Add(newDataRow);
							}
						}
					}

					// Transfer from pTempItemRow To pMain.pItemTable.
					if (pItemTableRow != null)  // Row exist in Global Table, update it.
					{
						pItemTableRow.ItemArray = (object[])pTempItemRow.ItemArray.Clone();
					}
					else // Row not exist in Global Table, insert it.
					{
						pItemTableRow = pMain.pItemTable.NewRow();
						pItemTableRow.ItemArray = (object[])pTempItemRow.ItemArray.Clone();
						pMain.pItemTable.Rows.Add(pItemTableRow);
					}
				}
				catch (Exception ex)
				{
					string strError = "Item Editor > Item: " + nItemID + " Changes applied in DataBase, but something got wrong while transferring temp item data to main tables. Please restart the application (" + ex.Message + ").";

					pMain.Logger(strError, Color.Red);

					MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					MessageBox.Show("Changes applied successfully!", "Item Editor", MessageBoxButtons.OK);

					pItemTableRow = null;

					bUnsavedChanges = false;
				}
			}
			else
			{
				string strError = "Item Editor > Item: " + nItemID + " Something got wrong while trying to execute the MySQL Transaction. Changes not applied.";

				pMain.Logger(strError, Color.Red);

				MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			strbuilderQuery = null;
#if DEBUG
			stopwatch.Stop();
			pMain.Logger($"Compose query, run it, and transfer Data from Temp to Global took: {stopwatch.ElapsedMilliseconds}.{stopwatch.ElapsedTicks} MS.TICKS");
#endif
		}
	}
}

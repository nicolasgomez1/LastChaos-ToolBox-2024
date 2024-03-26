//#define ENABLE_SECOND_SKILL_TO_CRAFT	// NOTE: These values are required by the server, but are not actually used
#define ALLOWED_ZONE_SYSTEM // NOTE: Custom system made by NicolasG, disable that to use normal a_zone_flag

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
		private ToolTip pToolTip;
		private Dictionary<Control, ToolTip> pToolTips = new Dictionary<Control, ToolTip>();
		ContextMenuStrip cmFortune;
		ContextMenuStrip cmCommonInput;

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }
			public override string ToString() { return Text; }
		}

		public ItemEditor(Main mainForm)
		{
			InitializeComponent();

			this.FormClosing += ItemEditor_FormClosing;

#if ENABLE_SECOND_SKILL_TO_CRAFT
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

			gridFortune.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(166, 166, 166);

			gridFortune.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Inset;
			/****************************************/
			cbRenderDialog.Checked = bool.Parse(pMain.pSettings.ShowRenderDialog[this.Name]);

			cbAutoLoadFortuneData.Checked = bool.Parse(pMain.pSettings.ItemEditorAutoShowFortune);
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			Control cControl = (sender as ContextMenuStrip)?.SourceControl;
			// TODO: NOTE: Some pickers return 0, others -1, I don't know how the update or insert action will behave, it could fail completely.
			if (cControl != null)
			{
				string strControlName = cControl.Name;
				int nActualValue = Convert.ToInt32(cControl.Text);

				ToolStripMenuItem menuItemPicker = new ToolStripMenuItem("Item Picker");
				menuItemPicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					ItemPicker pItemSelector = new ItemPicker(pMain, this, nActualValue);

					if (pItemSelector.ShowDialog() != DialogResult.OK)
						return;
#pragma warning disable
					cControl.Text = pItemSelector.ReturnValues.ToString();
#pragma warning restore
				};

				ToolStripMenuItem menuZonePicker = new ToolStripMenuItem("Zone Picker");
				menuZonePicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					ZonePicker pZoneSelector = new ZonePicker(pMain, this, nActualValue);

					if (pZoneSelector.ShowDialog() != DialogResult.OK)
						return;

					cControl.Text = pZoneSelector.ReturnValues[0].ToString();
				};

				ToolStripMenuItem menuSkillPicker = new ToolStripMenuItem("Skill Picker");
				menuSkillPicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					int nSkillLevel = 0;
					TextBox tbSecondInputObject = null;

					if (strControlName.Length >= 11 && strControlName.Substring(0, 11) == "tbRareIndex")
					{
						tbSecondInputObject = ((TextBox)this.Controls.Find("tbRareProb" + strControlName[strControlName.Length - 1], true)[0]);
						nSkillLevel = Convert.ToInt32(tbSecondInputObject.Text);
					}

					if (strControlName.Length >= 9 && strControlName == "tbOption0")
					{
						tbSecondInputObject = ((TextBox)this.Controls.Find("tbOption1", true)[0]);
						nSkillLevel = Convert.ToInt32(tbSecondInputObject.Text);
					}

					SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { nActualValue, nSkillLevel }, false);

					if (pSkillSelector.ShowDialog() != DialogResult.OK)
						return;

					cControl.Text = pSkillSelector.ReturnValues[0].ToString();

					if (tbSecondInputObject != null)
						tbSecondInputObject.Text = pSkillSelector.ReturnValues[1].ToString();
				};

				ToolStripMenuItem menuRarePicker = new ToolStripMenuItem("Rare Option Picker");
				menuRarePicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					RareOptionPicker pRareOptionSelector = new RareOptionPicker(pMain, this, nActualValue);

					if (pRareOptionSelector.ShowDialog() != DialogResult.OK)
						return;
#pragma warning disable
					cControl.Text = pRareOptionSelector.ReturnValues.ToString();
#pragma warning restore
				};

				ToolStripMenuItem menuOptionPicker = new ToolStripMenuItem("Option Picker");
				menuOptionPicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					int nOptionLevel = 0;
					TextBox tbSecondInputObject = null;

					if (strControlName.Length >= 11 && strControlName.Substring(0, 11) == "tbRareIndex")
					{
						tbSecondInputObject = ((TextBox)this.Controls.Find("tbRareProb" + strControlName[strControlName.Length - 1], true)[0]);
						nOptionLevel = Convert.ToInt32(tbSecondInputObject.Text);
					}

					OptionPicker pOptionSelector = new OptionPicker(pMain, this, new int[] { nActualValue, nOptionLevel });

					if (pOptionSelector.ShowDialog() != DialogResult.OK)
						return;

					cControl.Text = pOptionSelector.ReturnValues[0].ToString();

					if (tbSecondInputObject != null)
						tbSecondInputObject.Text = pOptionSelector.ReturnValues[1].ToString();
				};

				ToolStripMenuItem menuMagicPicker = new ToolStripMenuItem("Magic Picker");
				menuMagicPicker.Click += (menuItemSender, menuItemEventArgs) =>
				{
					int nMagicLevel = 0;
					TextBox tbSecondInputObject = null;

					if (strControlName.Length >= 11 && strControlName.Substring(0, 11) == "tbRareIndex")
					{
						tbSecondInputObject = ((TextBox)this.Controls.Find("tbRareProb" + strControlName[strControlName.Length - 1], true)[0]);
						nMagicLevel = Convert.ToInt32(tbSecondInputObject.Text);
					}

					if (strControlName.Length >= 6 && strControlName == "tbSet0")
					{
						tbSecondInputObject = ((TextBox)this.Controls.Find("tbSet1", true)[0]);
						nMagicLevel = Convert.ToInt32(tbSecondInputObject.Text);
					}

					MagicPicker pMagicSelector = new MagicPicker(pMain, this, new int[] { nActualValue, nMagicLevel });

					if (pMagicSelector.ShowDialog() != DialogResult.OK)
						return;

					cControl.Text = pMagicSelector.ReturnValues[0].ToString();

					if (tbSecondInputObject != null)
						tbSecondInputObject.Text = pMagicSelector.ReturnValues[1].ToString();
				};

				cmCommonInput = new ContextMenuStrip();
				cmCommonInput.Items.AddRange(new ToolStripItem[] { menuItemPicker, menuZonePicker, menuSkillPicker, menuOptionPicker, menuRarePicker, menuMagicPicker });
				cmCommonInput.Show(Cursor.Position);
			}
		}

		private (bool bProceed, bool bDeleteActual) CheckUnsavedChanges()
		{
			bool bProceed = true;
			bool bDeleteActual = false;

			if (bUnsavedChanges)
			{
				if (pMain.pItemTable.Select("a_index = " + pTempItemRow["a_index"]).FirstOrDefault() != null)   // the current selected item, it is not temporary.
				{
					DialogResult pDialogReturn = MessageBox.Show("There are unsaved changes. If you proceed, your changes will be discarded.\nDo you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (pDialogReturn != DialogResult.Yes)
						bProceed = false;
				}
				else    // the current selected item is temporary.
				{
					DialogResult pDialogReturn = MessageBox.Show("The current Item is temporary, if you don't press Update. Do you want to continue and lose all the information regarding it?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					if (pDialogReturn != DialogResult.Yes)
						bProceed = false;
					else if (pDialogReturn == DialogResult.Yes)
						bDeleteActual = true;
				}
			}

			return (bProceed, bDeleteActual);
		}

		private void SetSetDataTexts()
		{
			int nType = cbTypeSelector.SelectedIndex;
			string[] strArrayTexts = { "0", "1", "2", "3", "4" };

			if (nType == 2 /*ITYPE_ONCE*/ && ((Convert.ToInt64(pTempItemRow["a_flag"]) & (1 << 22 /*ITEM_FLAG_QUEST*/)) != 0))
			{
				strArrayTexts[0] = "Zone ID";
				strArrayTexts[1] = "Position X";
				strArrayTexts[2] = "Position X";
				strArrayTexts[3] = "Quest Range";
			}

			for (int i = 0; i < strArrayTexts.Length; i++)
				((Label)this.Controls.Find("lSet" + i, true)[0]).Text = strArrayTexts[i];

			strArrayTexts = null;
		}

		private void SetOptionDataTexts()
		{
			int nType = cbTypeSelector.SelectedIndex;
			int nSubType = cbSubTypeSelector.SelectedIndex;
			string[] strArrayTexts = { "0", "1", "2", "3", "4" };

			if (nType == 0 /*ITYPE_WEAPON*/)
			{
				strArrayTexts[0] = "Physical Attack";
				strArrayTexts[1] = "Magic Attack";
				strArrayTexts[2] = "Attack Speed";
			}
			else if (nType == 1 /*ITYPE_WEAR*/)
			{
				strArrayTexts[0] = "Physical Defense";
				strArrayTexts[1] = "Magic Defense";

				if (nSubType == 6 /*IWEAR_BACKWING*/)
					strArrayTexts[2] = "Fly Speed";
				else
					strArrayTexts[2] = "???";	// NOTE: Some items have values here

				if (nSubType == 7 /*IWEAR_SUIT*/ || ((Convert.ToInt64(pTempItemRow["a_flag"]) & (1 << 26 /*ITEM_FLAG_COSTUME2*/)) != 0))
					strArrayTexts[4] = "Duration Time";
			}

			for (int i = 0; i < strArrayTexts.Length; i++)
				((Label)this.Controls.Find("lOption" + i, true)[0]).Text = strArrayTexts[i];

			strArrayTexts = null;
		}

		private void AddItemToList(int nItemID, string strItemName, bool bIsTemp)
		{
			MainList.Items.Add(new ListBoxItem
			{
				ID = nItemID,
				Text = nItemID + " - " + strItemName
			});

			if (bIsTemp)
			{
				LoadItemData(nItemID, false);

				MainList.SelectedIndexChanged -= MainList_SelectedIndexChanged;
				MainList.SelectedIndex = MainList.Items.Count - 1;
				MainList.SelectedIndexChanged += MainList_SelectedIndexChanged;

				pLastSelected = (ListBoxItem)MainList.SelectedItem;

				bUnsavedChanges = true;
			}
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

			var columnsToAdd = new List<DataColumn>
			{
				new DataColumn("a_item_idx", typeof(int)),		// int
				new DataColumn("a_prob_type", typeof(byte)),	// tinyint unsigned
				new DataColumn("a_enable", typeof(byte))		// tinyint unsigned
			};

			pMain.pItemFortuneHeadTable.Columns.AddRange(columnsToAdd.ToArray());
		}

		private void MakepItemFortuneDataTableStructure()
		{
			pMain.pItemFortuneDataTable = new DataTable();

			var columnsToAdd = new List<DataColumn>
			{
				new DataColumn("a_item_idx", typeof(int)),         // int
				new DataColumn("a_skill_index", typeof(int)),      // int
				new DataColumn("a_skill_level", typeof(sbyte)),    // tinyint
				new DataColumn("a_string_index", typeof(int)),     // int
				new DataColumn("a_prob", typeof(int))              // int
			};

			pMain.pItemFortuneDataTable.Columns.AddRange(columnsToAdd.ToArray());
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
#if ENABLE_SECOND_SKILL_TO_CRAFT
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

				listQueryCompose.AddRange(new List<string>
				{
					"a_name_" + strNation,
					"a_descr_" + strNation
				});
			}

			if (pMain.pItemTable == null)   // NOTE: If the global table is empty, directly indicate that a query must be executed requesting all previously defined columns.
			{
				bRequestNeeded = true;
			}
			else    // NOTE: If the global table is not empty, check if any of the columns to request are already present. To remove it from the query and not request redundant information.
			{
				foreach (string strColumnName in listQueryCompose.ToList())
				{
					if (!pMain.pItemTable.Columns.Contains(strColumnName))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(strColumnName);
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

			listQueryCompose = null;
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
		}

		private async Task LoadSkillDataAsync()
		{
			bool bRequestNeeded = false;

			List<string> listQueryCompose = new List<string>
			{
				"a_name_" + pMain.pSettings.WorkLocale, "a_client_description_" + pMain.pSettings.WorkLocale, "a_client_icon_texid", "a_client_icon_row", "a_client_icon_col"
			};

			if (pMain.pSkillTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (string strColumnName in listQueryCompose.ToList())
				{
					if (!pMain.pSkillTable.Columns.Contains(strColumnName))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(strColumnName);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pSkillTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_skill ORDER BY a_index;");
				});
			}

			// Reset vals & Populate pSkillLevelTable.
			bRequestNeeded = false;
			listQueryCompose.Clear();

			listQueryCompose = new List<string> { "a_level", "a_dummypower" };

			if (pMain.pSkillLevelTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				foreach (string strColumnName in listQueryCompose.ToList())
				{
					if (!pMain.pSkillLevelTable.Columns.Contains(strColumnName))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(strColumnName);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pSkillLevelTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_skilllevel ORDER BY a_level");
				});
			}

			listQueryCompose = null;
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
				foreach (string strColumnName in listQueryCompose.ToList())
				{
					if (!pMain.pRareOptionTable.Columns.Contains(strColumnName))
						bRequestNeeded = true;
					else
						listQueryCompose.Remove(strColumnName);
				}
			}

			if (bRequestNeeded)
			{
				pMain.pRareOptionTable = await Task.Run(() =>
				{
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_rareoption ORDER BY a_index;");
				});
			}

			listQueryCompose = null;
		}

		private void LoadFortuneData(int nItemID)
		{
#if DEBUG
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
#endif
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

		private void SetFortuneData(int nItemID)
		{
			if (bFortuneLoaded)
				return;

			bFortuneLoaded = true;

			rtFortuneWarning.Visible = false;

			gridFortune.Rows.Clear();

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

									foreach (DataRow pRowSkillLevel in listSkillLevels)
									{
										int iSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

										cSkillLevel.Items.Add("Level: " + iSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

										if (iFortuneSkillLevel == iSkillLevel)
											cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
									}

									listSkillLevels = null;
								}

								gridFortune.Rows[i].Cells["level"].Tag = iFortuneSkillLevel;

								gridFortune.Rows[i].Cells["prob"].Value = pFortuneRow["a_prob"].ToString();

								gridFortune.Rows[i].Cells["string_id"].Value = pFortuneRow["a_string_index"].ToString();
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
				LoadItemDataAsync(),    // Populate pItemTable.
				LoadZoneDataAsync(),    // Populate pZoneTable.
				LoadSkillDataAsync(),   // Populate pSkillTable & pSkillLevelTable.
				LoadRareOptionDataAsync()   // Populate pRateoptionTable.
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
					AddItemToList(Convert.ToInt32(pRow["a_index"]), pRow["a_name_" + pMain.pSettings.WorkLocale].ToString(), false);

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

			pToolTip.SetToolTip(btnReload, "Reload Items, Zones, Skills, Rare Options & Fortune Data from Database");
			pToolTip.SetToolTip(cbAutoLoadFortuneData, "When this is checked The Fortune Data are requested to server (If are not stored yet) automatically when select and Item from List.");

			pToolTips[cbAutoLoadFortuneData] = pToolTip;    // For Dispose.
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

				pTempItemRow = null;
				pTempFortuneHeadRow = null;
				pTempFortuneDataRows = null;

				strArrayZones = null;

				if (cmFortune != null)
				{
					cmFortune.Dispose();
					cmFortune = null;
				}

				if (cmCommonInput != null)
				{
					cmCommonInput.Dispose();
					cmCommonInput = null;
				}
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

		private void LoadItemData(int nItemID, bool bLoadFrompItemTable)
		{
			bUserAction = false;

			// Reset Controls.
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
			if (bLoadFrompItemTable)
			{
				pTempItemRow = pMain.pItemTable.NewRow();   // Replicate struct in temp row val.
				pTempItemRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = " + nItemID)[0].ItemArray.Clone();    // Copy data from main table to temp one.
			}

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
			tbAllowedZoneFlag.Text = strZoneFlag;
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
			SetSetDataTexts();

			for (int i = 0; i <= 4; i++)
				((TextBox)this.Controls.Find("tbSet" + i, true)[0]).Text = pTempItemRow["a_set_" + i].ToString();
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

#if ENABLE_SECOND_SKILL_TO_CRAFT
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
			DataRow pItemTableRow;

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
				}

				((Button)this.Controls.Find("btnItem" + i + "Required", true)[0]).Text = strRequiredItemID;

				((TextBox)this.Controls.Find("tbItem" + i + "RequiredAmount", true)[0]).Text = pTempItemRow["a_need_item_count" + i].ToString();
			}

			pItemTableRow = null;

			// Rare
			for (int i = 0; i <= 9; i++)
			{
				int nRateOptionProb = Convert.ToInt32(pTempItemRow["a_rare_prob_" + i]);

				((TextBox)this.Controls.Find("tbRareIndex" + i, true)[0]).Text = pTempItemRow["a_rare_index_" + i].ToString();

				((TextBox)this.Controls.Find("tbRareProb" + i, true)[0]).Text = nRateOptionProb.ToString();

				((Label)this.Controls.Find("lRareProb" + i + "Percentage", true)[0]).Text = ((nRateOptionProb * 100.0f) / 10000.0f) + "%";
			}

			// Fortune
			if (pMain.pSettings.ItemEditorAutoShowFortune == "true")
			{
				LoadFortuneData(nItemID);

				SetFortuneData(nItemID);
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

		private void tbSearch_TextChanged(object sender, EventArgs e) { nSearchPosition = 0; }

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
				var (bProceed, bDeleteActual) = CheckUnsavedChanges();

				if (bProceed)
				{
					if (bDeleteActual)
					{
						int nPrevObjectID = MainList.SelectedIndex <= 0 ? 0 : MainList.SelectedIndex - 1;

						MainList.Items.RemoveAt(MainList.Items.Count - 1);

						object nSelected = MainList.Items[nPrevObjectID];

						LoadItemData(((ListBoxItem)nSelected).ID, true);

						MainList.SelectedIndexChanged -= MainList_SelectedIndexChanged;
						MainList.SelectedItem = nSelected;
						MainList.SelectedIndexChanged += MainList_SelectedIndexChanged;

						bUnsavedChanges = false;
					}
					else
					{
						bUnsavedChanges = false;

						LoadItemData(pSelectedItem.ID, true);
					}
				}
				else
				{
					MainList.SelectedIndexChanged -= MainList_SelectedIndexChanged;
					MainList.SelectedItem = pLastSelected;
					MainList.SelectedIndexChanged += MainList_SelectedIndexChanged;
				}

				pLastSelected = pSelectedItem;
			}
		}

		private void btnReload_Click(object sender, EventArgs e)    // NOTE: Here is an example on how to manage the reloading of information from global tables.
		{
			void Reload()
			{
				MainList.Enabled = false;
				btnReload.Enabled = false;

				nSearchPosition = 0;

				// TODO: Add dispose to all global tables used by this tool.
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

			var (bProceed, bDeleteActual) = CheckUnsavedChanges();

			if (bProceed)
			{
				bUnsavedChanges = false;

				Reload();
			}
		}

		private int AskForIndex()
		{
			DialogResult pDialogReturn = MessageBox.Show("The database was queried for the highest a_index value, but failed. You will have to enter a value yourself, do you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

			if (pDialogReturn == DialogResult.Yes)
			{
				MessageBox_Input pInput = new MessageBox_Input(this, "Please enter a Item ID:");

				if (pInput.ShowDialog() != DialogResult.OK)
				{
					pDialogReturn = MessageBox.Show("Do you want to cancel?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (pDialogReturn == DialogResult.Yes)
						return -1;
					else
						return AskForIndex();
				}
				else
				{
					return Convert.ToInt32(pInput.strOutput);
				}
			}

			return -1;
		}

		private void btnAddNew_Click(object sender, EventArgs e)
		{
			var (bProceed, bDeleteActual) = CheckUnsavedChanges();

			if (bProceed)
			{
				int nItemID = 9999;
				DataRow pRow;

				List<string> listUIntColumns = new List<string> { "a_durability" };  // Here add all unsigned int columns.

				List<string> listIntColumns = new List<string>	// Here add all int columns.
				{
					"a_index",
					"a_enable",
					"a_weight",
					"a_price",
					"a_level",
					"a_level2",
					"a_fame",
					"a_max_use",
					"a_grade",
					"a_type_idx",
					"a_subtype_idx",
					"a_job_flag",
#if !ALLOWED_ZONE_SYSTEM
					"a_zone_flag",
#endif
					"a_set_0",
					"a_set_1",
					"a_set_2",
					"a_set_3",
					"a_set_4",
					"a_num_0",
					"a_num_1",
					"a_num_2",
					"a_num_3",
					"a_num_4",
					"a_need_sskill",
#if ENABLE_SECOND_SKILL_TO_CRAFT
					"a_need_sskill2",
#endif
					"a_need_item0",
					"a_need_item1",
					"a_need_item2",
					"a_need_item3",
					"a_need_item4",
					"a_need_item5",
					"a_need_item6",
					"a_need_item7",
					"a_need_item8",
					"a_need_item9",
					"a_rare_index_0", "a_rare_prob_0",
					"a_rare_index_1", "a_rare_prob_1",
					"a_rare_index_2", "a_rare_prob_2",
					"a_rare_index_3", "a_rare_prob_3",
					"a_rare_index_4", "a_rare_prob_4",
					"a_rare_index_5", "a_rare_prob_5",
					"a_rare_index_6", "a_rare_prob_6",
					"a_rare_index_7", "a_rare_prob_7",
					"a_rare_index_8", "a_rare_prob_8",
					"a_rare_index_9", "a_rare_prob_9"
				};

				List<string> listUTinyIntColumns = new List<string>  // Here add all unsigned tinyint columns.
				{
					"a_origin_variation1",
					"a_origin_variation2",
					"a_origin_variation3",
					"a_origin_variation4",
					"a_origin_variation5",
					"a_origin_variation6",
					"a_rvr_value",
					"a_rvr_grade",
					"a_castle_war"
				};

				List<string> listTinyIntColumns = new List<string>	// Here add all tinyint columns.
				{
					"a_texture_id",
					"a_texture_row",
					"a_texture_col",
					"a_wearing",
					"a_need_sskill_level",
#if ENABLE_SECOND_SKILL_TO_CRAFT
					"a_need_sskill_level2"
#endif
				};

				List<string> listVarcharColumns = new List<string>	// Here add all varchar columns.
				{
					"a_file_smc",
					"a_effect_name",
					"a_attack_effect_name",
					"a_damage_effect_name"
				};

				int i = 0;
				for (i = 0; i < pMain.pSettings.NationSupported.Length; i++)
				{
					string strNation = pMain.pSettings.NationSupported[i].ToLower();

					listVarcharColumns.AddRange(new List<string>
					{
						"a_name_" + strNation,
						"a_descr_" + strNation
					});
				}

				List<string> listBigIntColumns = new List<string>	// Here add all bigint columns.
				{
#if ALLOWED_ZONE_SYSTEM
					"a_zone_flag",
#endif
					"a_flag"
				};

				List<string> listSmallIntColumns = new List<string>	// Here add all smallint columns.
				{
					"a_need_item_count0",
					"a_need_item_count1",
					"a_need_item_count2",
					"a_need_item_count3",
					"a_need_item_count4",
					"a_need_item_count5",
					"a_need_item_count6",
					"a_need_item_count7",
					"a_need_item_count8",
					"a_need_item_count9"
				};

				if (pMain.pItemTable == null)   // If is null, create new DataTable and set schema (column name & datatype).
				{
					DataTable pItemTableStruct = new DataTable();

					foreach (string strColumnName in listUIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(uint));

					foreach (string strColumnName in listIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(int));

					foreach (string strColumnName in listUTinyIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(byte));

					foreach (string strColumnName in listTinyIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(sbyte));

					foreach (string strColumnName in listVarcharColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(string));

					foreach (string strColumnName in listBigIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(long));

					foreach (string strColumnName in listSmallIntColumns)
						pItemTableStruct.Columns.Add(strColumnName, typeof(short));

					pRow = pItemTableStruct.NewRow();

					pItemTableStruct.Dispose();
					pItemTableStruct = null;

					DataTable QueryReturn = pMain.QuerySelect(pMain.pSettings.DBCharset, "SELECT a_index FROM " + pMain.pSettings.DBData + ".t_item ORDER BY a_index DESC LIMIT 1");
					if (QueryReturn != null && QueryReturn.Rows.Count > 0)
					{
						nItemID = Convert.ToInt32(QueryReturn.Rows[0]["a_index"]);
					}
					else
					{
						if ((nItemID = AskForIndex()) == -1)    // I don't test it...
							return;
					}

					QueryReturn = null;
				}
				else
				{
					nItemID = Convert.ToInt32(pMain.pItemTable.Select().LastOrDefault()["a_index"]) + 1;

					pRow = pMain.pItemTable.NewRow();
				}

				List<object> listDefaultValue = new List<object>
				{
					0,  // a_durability
					0,	// a_index
					0,	// a_enable
					0,	// a_weight
					0,	// a_price
					0,	// a_level
					0,	// a_level2
					-1,	// a_fame
					-1,	// a_max_use
					0,	// a_grade
					0,	// a_type_idx
					0,	// a_subtype_idx
					0,	// a_job_flag
#if !ALLOWED_ZONE_SYSTEM
					0,	// a_zone_flag
#endif
					0,	// a_set_0
					0,	// a_set_1
					0,	// a_set_2
					0,	// a_set_3
					0,	// a_set_4
					0,	// a_num_0
					0,	// a_num_1
					0,	// a_num_2
					0,	// a_num_3
					0,	// a_num_4
					-1,	// a_need_sskill
#if ENABLE_SECOND_SKILL_TO_CRAFT
					-1,	// a_need_sskill2
#endif
					-1,	// a_need_item0
					-1,	// a_need_item1
					-1,	// a_need_item2
					-1,	// a_need_item3
					-1,	// a_need_item4
					-1,	// a_need_item5
					-1,	// a_need_item6
					-1,	// a_need_item7
					-1,	// a_need_item8
					-1,	// a_need_item9
					-1,	// a_rare_index_0
					0,	// a_rare_prob_0
					-1,	// a_rare_index_1
					0,	// a_rare_prob_1
					-1,	// a_rare_index_2
					0,	// a_rare_prob_2
					-1,	// a_rare_index_3
					0,	// a_rare_prob_3
					-1,	// a_rare_index_4
					0,	// a_rare_prob_4
					-1,	// a_rare_index_5
					0,	// a_rare_prob_5
					-1,	// a_rare_index_6
					0,	// a_rare_prob_6
					-1,	// a_rare_index_7
					0,	// a_rare_prob_7
					-1,	// a_rare_index_8
					0,	// a_rare_prob_8
					-1,	// a_rare_index_9
					0,	// a_rare_prob_9
					0,	// a_origin_variation1
					0,	// a_origin_variation2
					0,	// a_origin_variation3
					0,	// a_origin_variation4
					0,	// a_origin_variation5
					0,	// a_origin_variation6
					0,	// a_rvr_value
					0,	// a_rvr_grade
					0,	// a_castle_war
					0,	// a_texture_id
					1,	// a_texture_row
					1,	// a_texture_col
					-1,	// a_wearing
					0,  // a_need_sskill_level
#if ENABLE_SECOND_SKILL_TO_CRAFT
					0,	// a_need_sskill_level2
#endif
					"Item\\Common\\ITEM_treasure02.smc",	// a_file_smc
					"",	// a_effect_name
					"",	// a_attack_effect_name
					"", // a_damage_effect_name
				};

				for (i = 0; i < pMain.pSettings.NationSupported.Length; i++)
				{
					string strNation = pMain.pSettings.NationSupported[i].ToLower();

					listDefaultValue.AddRange(new List<string>
					{
						"New Item",
						"Created with NicolasG LastChaos ToolBox 2024"
					});
				}

				listDefaultValue.AddRange(new List<object>
				{
#if ALLOWED_ZONE_SYSTEM
					0,  // a_zone_flag
#endif
					0,  // a_flag
					0,  // a_need_item_count0
					0,  // a_need_item_count1
					0,  // a_need_item_count2
					0,  // a_need_item_count3
					0,  // a_need_item_count4
					0,  // a_need_item_count5
					0,  // a_need_item_count6
					0,  // a_need_item_count7
					0,  // a_need_item_count8
					0   // a_need_item_count9
				});

				i = 0;
				foreach (string strColumnName in listUIntColumns.Concat(listIntColumns).Concat(listUTinyIntColumns).Concat(listTinyIntColumns).Concat(listVarcharColumns).Concat(listBigIntColumns).Concat(listSmallIntColumns))
				{
					pRow[strColumnName] = listDefaultValue[i];

					i++;
				}

				pRow["a_index"] = nItemID;

				try
				{
					pTempItemRow = pRow;
				}
				catch (Exception ex)
				{
					string strError = "Item Editor > Item: " + nItemID + " Something got wrong. Please restart the application (" + ex.Message + ").";

					pMain.Logger(strError, Color.Red);

					MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					if (bDeleteActual)
						MainList.Items.RemoveAt(MainList.SelectedIndex);

					AddItemToList(nItemID, "New Item", true);
				}

				listUIntColumns = null;
				listIntColumns = null;
				listUTinyIntColumns = null;
				listTinyIntColumns = null;
				listVarcharColumns = null;
				listBigIntColumns = null;
				listSmallIntColumns = null;
				listDefaultValue = null;
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			var (bProceed, bDeleteActual) = CheckUnsavedChanges();

			if (bDeleteActual)
			{
				DialogResult pDialogReturn = MessageBox.Show("You cannot copy this Item. Because it's temporary.", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
				return;
			}

			if (bProceed)
			{
				int nItemIDToCopy = Convert.ToInt32(pTempItemRow["a_index"]);
				int nNewItemID = Convert.ToInt32(pMain.pItemTable.Select().LastOrDefault()["a_index"]) + 1;

				pTempItemRow = pMain.pItemTable.NewRow();
				pTempItemRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = " + nItemIDToCopy)[0].ItemArray.Clone();

				pTempItemRow["a_index"] = nNewItemID;

				for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
				{
					string strNation = pMain.pSettings.NationSupported[i].ToLower();

					pTempItemRow["a_name_" + strNation] = pTempItemRow["a_name_" + strNation] + " Copy";
				}

				AddItemToList(nNewItemID, pTempItemRow["a_name_" + pMain.pSettings.WorkLocale].ToString(), true);

				if (pTempFortuneHeadRow == null || pTempFortuneDataRows == null)
				{
					LoadFortuneData(nItemIDToCopy);

					SetFortuneData(nItemIDToCopy);

					if (pTempFortuneHeadRow != null)
						pTempFortuneHeadRow["a_item_idx"] = nNewItemID;

					if (pTempFortuneDataRows != null)
					{
						foreach (DataRow pRow in pTempFortuneDataRows)
							pRow["a_item_idx"] = nNewItemID;
					}
				}
			}
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

			if (bSuccess)
			{
				try
				{
					if (pMain.pItemFortuneHeadTable != null)
					{
						DataRow pRow = pMain.pItemFortuneHeadTable.Select("a_item_idx = " + nItemID).FirstOrDefault();

						if (pRow != null)
							pMain.pItemFortuneHeadTable.Rows.Remove(pRow);

						pRow = null;
					}

					if (pMain.pItemFortuneDataTable != null)
					{
						DataRow[] pRows = pMain.pItemFortuneDataTable.Select("a_item_idx = " + nItemID);

						if (pRows.Length > 0)
						{
							foreach (DataRow pRow in pRows)
								pMain.pItemFortuneDataTable.Rows.Remove(pRow);
						}

						pRows = null;
					}

					if (pItemTableRow != null)
						pMain.pItemTable.Rows.Remove(pItemTableRow);
				}
				catch (Exception ex)
				{
					string strError = "Item Editor > Item: " + nItemID + " Changes applied in DataBase, but something got wrong while transferring temp item data to main tables. Please restart the application (" + ex.Message + ").";

					pMain.Logger(strError, Color.Red);

					MessageBox.Show(strError, "Item Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				finally
				{
					int nPrevObjectID = MainList.SelectedIndex <= 0 ? 0 : MainList.SelectedIndex - 1;

					MainList.Items.Remove(MainList.SelectedItem);

					MessageBox.Show("Item Deleted successfully!", "Item Editor", MessageBoxButtons.OK);

					MainList.SelectedIndex = nPrevObjectID;

					bUnsavedChanges = false;
				}
			}

			pItemTableRow = null;
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
#pragma warning disable
				string strFlag = pFlagSelector.ReturnValues.ToString();
#pragma warning restore
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
#pragma warning disable
				string strFlag = pFlagSelector.ReturnValues.ToString();
#pragma warning restore
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
				pTempItemRow["a_zone_flag"] = tbAllowedZoneFlag.Text;

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

				pToolTips[btnItemFlag].SetToolTip(btnItemFlag, strTooltip.ToString());

				pTempItemRow["a_flag"] = strFlag;

				bUnsavedChanges = true;
			}

			SetSetDataTexts();
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
				
				SetOptionDataTexts();
				
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

			SetOptionDataTexts();
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
		private void ChangeSetAction(TextBox cTextBox, int nNumber)
		{
			if (bUserAction)
			{
				pTempItemRow["a_set_" + nNumber] = cTextBox.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbSet0_TextChanged(object sender, EventArgs e) { ChangeSetAction((TextBox)sender, 0); }
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

				int nSkillNeededID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
				string strSkillLevelNeeded = pSkillSelector.ReturnValues[1].ToString();
				string strSkillName = nSkillNeededID.ToString();

				if (nSkillNeededID != -1)
					strSkillName += " - " + pSkillSelector.ReturnValues[2];

				btnSkill1RequiredID.Text = strSkillName;

				tbSkill1RequiredLevel.Text = strSkillLevelNeeded;

				pTempItemRow[strIDColumn] = nSkillNeededID.ToString();
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
#if ENABLE_SECOND_SKILL_TO_CRAFT
			if (bUserAction)
			{
				string strIDColumn = "a_need_sskill";
				string strLevelColumn = "a_need_sskill_level";

				SkillPicker pSkillSelector = new SkillPicker(pMain, this, new object[] { Convert.ToInt32(pTempRow[strIDColumn]), pTempRow[strLevelColumn].ToString() });

				if (pSkillSelector.ShowDialog() != DialogResult.OK)
					return;

				int nSkillNeededID = Convert.ToInt32(pSkillSelector.ReturnValues[0]);
				string strSkillLevelNeeded = pSkillSelector.ReturnValues[1].ToString();
				string strSkillName = nSkillNeededID.ToString();

				if (nSkillNeededID != -1)
					strSkillName += " - " + pSkillSelector.ReturnValues[2];

				btnSkill2RequiredID.Text = strSkillName;
				tbSkill2RequiredLevel.Text = strSkillLevelNeeded;

				pTempRow[strIDColumn] = nSkillNeededID.ToString();
				pTempRow[strLevelColumn] = strSkillLevelNeeded;

				bUnsavedChanges = true;
			}
#endif
		}

		private void tbSkill2RequiredLevel_TextChanged(object sender, EventArgs e)
		{
#if ENABLE_SECOND_SKILL_TO_CRAFT
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

				int nItemNeededID = pItemSelector.ReturnValues;
				string strItemName = nItemNeededID.ToString();

				if (nItemNeededID != -1)
				{
					DataRow pItemTableRow = pMain.pItemTable.Select("a_index = " + nItemNeededID).FirstOrDefault();

					strItemName += " - " + pItemTableRow["a_name_" + pMain.pSettings.WorkLocale];

					pItemTableRow = null;
				}

				((Button)this.Controls.Find("btnItem" + nNumber + "Required", true)[0]).Text = strItemName;

				((TextBox)this.Controls.Find("tbItem" + nNumber + "RequiredAmount", true)[0]).Focus();

				pTempItemRow[strItemIDColumn] = nItemNeededID.ToString();

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
				pTempItemRow["a_rare_index_" + nNumber] = ((TextBox)this.Controls.Find("tbRareIndex" + nNumber, true)[0]).Text.ToString();

				bUnsavedChanges = true;
			}
		}

		private void tbRareIndex0_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(0); }
		private void tbRareIndex1_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(1); }
		private void tbRareIndex2_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(2); }
		private void tbRareIndex3_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(3); }
		private void tbRareIndex4_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(4); }
		private void tbRareIndex5_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(5); }
		private void tbRareIndex6_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(6); }
		private void tbRareIndex7_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(7); }
		private void tbRareIndex8_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(8); }
		private void tbRareIndex9_TextChanged(object sender, EventArgs e) { ChangeRareOptionAction(9); }

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

					int nItemID = Convert.ToInt32(pTempItemRow["a_index"]);

					LoadFortuneData(nItemID);

					SetFortuneData(nItemID);

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
					int nSelectedSkillLevel = Convert.ToInt32(pSkillSelector.ReturnValues[1]);
					strSkillLevel = pSkillSelector.ReturnValues[1].ToString();

					gridFortune.Rows[e.RowIndex].Cells["skill"].Value = nSkillID + " - " + pSkillSelector.ReturnValues[2];
					gridFortune.Rows[e.RowIndex].Cells["skill"].Tag = nSkillID;
					gridFortune.Rows[e.RowIndex].Cells["skill"].ToolTipText = pSkillSelector.ReturnValues[3].ToString();

					using (DataGridViewComboBoxCell cSkillLevel = (DataGridViewComboBoxCell)gridFortune.Rows[e.RowIndex].Cells["level"])
					{
						List<DataRow> listSkillLevels = pMain.pSkillLevelTable.AsEnumerable().Where(row => row.Field<int>("a_index") == nSkillID).ToList();

						foreach (DataRow pRowSkillLevel in listSkillLevels)
						{
							int iSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

							cSkillLevel.Items.Add("Level: " + iSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

							if (nSelectedSkillLevel == iSkillLevel)
								cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
						}

						listSkillLevels = null;
					}

					gridFortune.Rows[e.RowIndex].Cells["level"].Tag = nSelectedSkillLevel;

					bUnsavedChanges = true;
				}
				else if (e.Button == MouseButtons.Left && e.ColumnIndex == 3 && e.RowIndex >= 0)    // String Selector
				{
					StringPicker pStringSelector = new StringPicker(pMain, this, 1, false);

					if (pStringSelector.ShowDialog() != DialogResult.OK)
						return;

					gridFortune.Rows[e.RowIndex].Cells["string_id"].Value = pStringSelector.ReturnValues[0];
					gridFortune.Rows[e.RowIndex].Cells["string_id"].ToolTipText = pStringSelector.ReturnValues[1].ToString();

					bUnsavedChanges = true;
				}
				else if (e.Button == MouseButtons.Right && e.ColumnIndex == -1) // Header Column
				{
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

									foreach (DataRow pRowSkillLevel in listSkillLevels)
									{
										int iFortuneSkillLevel = Convert.ToInt32(pRowSkillLevel["a_level"]);

										cSkillLevel.Items.Add("Level: " + iFortuneSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

										if (nDefaultSkillLevel == iFortuneSkillLevel)
											cSkillLevel.Value = cSkillLevel.Items[cSkillLevel.Items.Count - 1];
									}
								}

								gridFortune.Rows[i].Cells["level"].Tag = nDefaultSkillLevel;

								gridFortune.Rows[i].Cells["prob"].Value = nDefaultProb;

								gridFortune.Rows[i].Cells["string_id"].Value = nDefaultStringID;
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

					cmFortune = new ContextMenuStrip();
					cmFortune.Items.AddRange(new ToolStripItem[] { addItem, deleteItem });
					cmFortune.Show(Cursor.Position);
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
			strbuilderQuery.Append("BEGIN;\n");

			if (gridFortune.Rows.Count == 0)
			{
				// Request for Fortune Data.
				if (pTempFortuneHeadRow == null || pTempFortuneDataRows == null)
				{
					LoadFortuneData(nItemID);

					SetFortuneData(nItemID);   // NOTE: I need call that to populate pTempFortuneHeadRow & pTempFortuneDataRows, but it do some redraws and can make the UI looks laggy... anyway is not too important.
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
					pRow["a_string_index"] = row.Cells["string_id"].Value;
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
								foreach (DataRow pRow in pTempFortuneDataRows)
								{
									DataRow newDataRow = pMain.pItemFortuneDataTable.NewRow();
									newDataRow.ItemArray = (object[])pRow.ItemArray.Clone();
									pMain.pItemFortuneDataTable.Rows.Add(newDataRow);
								}
							}

							pItemFortuneDataTableRows = null;
						}
						else    // If Global Table is null.
						{
							MakepItemFortuneDataTableStructure();

							foreach (DataRow pRow in pTempFortuneDataRows)
							{
								DataRow newDataRow = pMain.pItemFortuneDataTable.NewRow();
								newDataRow.ItemArray = (object[])pRow.ItemArray.Clone();
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
					int nSelectedIndex = MainList.SelectedIndex;
					ListBoxItem pSelectedItem = (ListBoxItem)MainList.Items[nSelectedIndex];
					pSelectedItem.ID = nItemID;
					pSelectedItem.Text = nItemID + " - " + tbName.Text.ToString();

					MainList.SelectedIndexChanged -= MainList_SelectedIndexChanged;
					MainList.Items[nSelectedIndex] = pSelectedItem;
					MainList.SelectedIndexChanged += MainList_SelectedIndexChanged;

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
			pMain.Logger($"Compose query, run it and transfer Data from Temp to Global took: {stopwatch.ElapsedMilliseconds} ms or {stopwatch.ElapsedTicks} ticks");
#endif
		}
	}
}

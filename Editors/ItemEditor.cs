using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Definitions;	// NOTE: This contains all hardcoded definitions.

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
		private int nSearchPosition = 1;

		public ItemEditor(Main mainForm)
		{
			this.FormClosing += ItemEditor_FormClosing;

			InitializeComponent();

			pMain = mainForm;
		}

		public class ListBoxItem
		{
			public int ID { get; set; }
			public string Text { get; set; }

			public override string ToString()
			{
				return Text;
			}
		}

		private async void ItemEditor_Load(object sender, EventArgs e)
		{
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

				if (pMain.pSettings.NationSupported[i].ToLower() == pMain.pSettings.DefaultEditNation)
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
			ProgressDialog progressDialog = new ProgressDialog(this, "Loading Items Data, Please Wait...");
			/****************************************/
			/* NOTE: Esto se tendría que replicar en cada herramienta que se cree de ahora en más.
			 * Definir todas las columnas necesarias para el funcionamiento de la herramienta en cuestión.
			 * Posteriormente verificar si la tabla pMain.pItemTable está vacía. Si es así directamente ejecutar la Query.
			 * De lo contrario inteligentemente verificar que columnas requeridas no están presentes en pMain.pItemTable para posteriormente obtenerlas y cargarlas.
			 */
			bool bRequestNeeded = false;

			// Aquí se definen las columnas generales que son requeridas por la Herramienta en cuestión.
			List<string> listQueryCompose = new List<string>
			{
				"a_enable", "a_texture_id", "a_texture_row", "a_texture_col", "a_file_smc", "a_weight", "a_price", "a_level", "a_level2", "a_durability",
				"a_fame", "a_max_use", "a_type_idx", "a_subtype_idx", "a_wearing", "a_quest_trigger_ids", "a_quest_trigger_count", "a_rvr_value",
				"a_rvr_grade", "a_effect_name", "a_attack_effect_name", "a_damage_effect_name", "a_castle_war", "a_job_flag", "a_zone_flag"
            };

			// Esto sirve para solicitar únicamente las columnas asociadas a los idiomas definidos en General -> NationSupported.
			for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
			{
				string strNation = pMain.pSettings.NationSupported[i].ToLower();

				listQueryCompose.Add("a_name_" + strNation);
				listQueryCompose.Add("a_descr_" + strNation);
			}

			// Aquí se verificará si la Tabla global requerida por la Herramienta está vacía. Si es así se ejecutará la petición directamente.
			if (pMain.pItemTable == null)
			{
				bRequestNeeded = true;
			}
			else
			{
				for (int i = listQueryCompose.Count - 1; i >= 0; i--)
				{
					if (!pMain.pItemTable.Columns.Contains(listQueryCompose[i]))
						bRequestNeeded = true;
					else
						listQueryCompose.RemoveAt(i);
				}
			}

			// Aquí se definirán las columnas que son necesarias para identificar las filas. Éstas columnas serán solicitadas en la petición sin importar si están presentes en la Tabla global.
			listQueryCompose.Add("a_index");
			
			// Request to t_item data if needed
			if (bRequestNeeded)
			{
				pMain.pItemTable = await Task.Run(() =>
				{
					// TODO: Acá tengo 2 opciones, o hago 2 peticiones, una con utf8 y otra para los textos en distintos idiomas.
					// NOTE: Posible problema, se podrían hacer peticiones con algunas variaciones en el orden o rangos, no sé como se comportaría si sistema en dicho caso.
					return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
				});
			}
            /****************************************/
            progressDialog.UpdateText("Loading Zones Data, Please Wait...");

            // Reset vals and load t_zonedata data if needed
            bRequestNeeded = false;
            listQueryCompose.Clear();

            // Aquí se definen las columnas requeridas para ésta Herramienta.
            listQueryCompose = new List<string>
            {
                "a_name"
            };

            // Aquí se verificará si la Tabla global requerida por la Herramienta está vacía. Si es así se ejecutará la petición directamente.
            if (pMain.pZoneTable == null)
            {
                bRequestNeeded = true;
            }
            else
            {
                for (int i = listQueryCompose.Count - 1; i >= 0; i--)
                {
                    if (!pMain.pItemTable.Columns.Contains(listQueryCompose[i]))
                        bRequestNeeded = true;
                    else
                        listQueryCompose.RemoveAt(i);
                }
            }

            // Aquí se definirán las columnas que son necesarias para identificar las filas. Éstas columnas serán solicitadas en la petición sin importar si están presentes en la Tabla global.
            listQueryCompose.Add("a_zone_index");

            // Request to t_zonedata if needed
            if (bRequestNeeded)
            {
                pMain.pZoneTable = await Task.Run(() =>
                {
                    return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_zonedata ORDER BY a_zone_index;");
                });
            }
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
						Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.DefaultEditNation].ToString()
					});
				}

				MainList.SelectedIndex = 0;

				MainList.EndUpdate();
			}

			progressDialog.Close();

            pToolTip = new ToolTip();
            pToolTip.SetToolTip(btnReload, "Reload Items Data from Database");

			btnReload.Enabled = true;
            btnAddNew.Enabled = true;
        }

		private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (bUnsavedChanges)
			{
				DialogResult pDialogReturn = MessageBox.Show("You have unapplied changes. Are you sure you want to exit?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.No)
					e.Cancel = true;
			}
		}

		void LoadItemData(int nItemID)
		{
			bUserAction = false;

			// Clear Selections
			cbTypeSelector.SelectedIndex = -1;
			cbSubTypeSelector.SelectedIndex = -1;
			cbWearingPositionSelector.SelectedIndex = -1;

			// Replicate struct in temp row
			pTempRow = pMain.pItemTable.NewRow();
			// Copy data from main table to temp one
			pTempRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = " + nItemID)[0].ItemArray.Clone();

			// Load data to UI
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
			}
			/****************************************/
			tbSMC.Text = pTempRow["a_file_smc"].ToString();

			pToolTip = new ToolTip();
			pToolTip.SetToolTip(tbSMC, "Double Click to edit");
			/****************************************/
			tbMaxStack.Text = pTempRow["a_weight"].ToString();
			tbPrice.Text = pTempRow["a_price"].ToString();
			tbMinLevel.Text = pTempRow["a_level"].ToString();
			tbMaxLevel.Text = pTempRow["a_level2"].ToString();
			tbDurability.Text = pTempRow["a_durability"].ToString();
			tbFame.Text = pTempRow["a_fame"].ToString();
			tbMaxUse.Text = pTempRow["a_max_use"].ToString();
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
            btnClassFlag.Text = pTempRow["a_job_flag"].ToString();

            btnAllowedZoneFlag.Text = pTempRow["a_zone_flag"].ToString();
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
            int nWearingPosition = Convert.ToInt32(pTempRow["a_wearing"]);

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
            tbQuestTriggerID.Text = pTempRow["a_quest_trigger_ids"].ToString();
			tbQuestTriggerCount.Text = pTempRow["a_quest_trigger_count"].ToString();

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
            // TODO: Seguir agregando mierdas

            bUserAction = true;
			
			btnUpdate.Enabled = true;

            BtnCopy.Enabled = true;
            btnDelete.Enabled = true;
        }

		private void ChangePanel(Panel pPanel)
		{
			if (pPanel == GeneralPanel)
			{
				CraftingPanel.Visible = false;
				OthersPanel.Visible = false;
				GeneralPanel.Visible = true;
			}
			else if (pPanel == CraftingPanel)
			{
				GeneralPanel.Visible = false;
				OthersPanel.Visible = false;
				CraftingPanel.Visible = true;
			}
			else if (pPanel == OthersPanel)
			{
				GeneralPanel.Visible = false;
				CraftingPanel.Visible = false;
				OthersPanel.Visible = true;
			}
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{
			string strStringToSearch = tbSearch.Text;

			for (int i = 0; i < MainList.Items.Count; i++)
			{
				if (MainList.GetItemText(MainList.Items[i]).IndexOf(strStringToSearch, StringComparison.OrdinalIgnoreCase) != -1)
				{
					MainList.SetSelected(nSearchPosition, true);

					nSearchPosition = i;

					break;
				}
			}
		}

		private void tbSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				void Search()
				{
					bool bFoundLast = false;
					string strStringToSearch = tbSearch.Text;

					for (int i = 0; i < MainList.Items.Count; i++)
					{
						if (MainList.GetItemText(MainList.Items[i]).IndexOf(strStringToSearch, StringComparison.OrdinalIgnoreCase) != -1 && i > nSearchPosition)
						{
							MainList.SetSelected(i, true);

							nSearchPosition = i;

							bFoundLast = true;

							break;
						}
					}

					if (!bFoundLast)
						nSearchPosition = 1;
				}

				int nSelected = MainList.SelectedIndex;

				if (nSelected != -1)
				{
					if (nSelected < nSearchPosition)
						nSearchPosition = nSelected;

					Search();
				}
				else
				{
					nSearchPosition = 1;

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
					DialogResult pDialogReturn = MessageBox.Show("There are unapplied changes, Do you want to discard them?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

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

		private void btnReload_Click(object sender, EventArgs e)
		{
			nSearchPosition = 1;

			pMain.pItemTable.Dispose();
			pMain.pItemTable = null;

			btnUpdate.Enabled = false;

			ItemEditor_Load(sender, e);
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

		private void BtnCopy_Click(object sender, EventArgs e)
		{
			// TODO:
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// TODO:
		}

		private void btnGeneral_Click(object sender, EventArgs e) { ChangePanel(GeneralPanel); }
		private void btnCrafting_Click(object sender, EventArgs e) { ChangePanel(CraftingPanel); }
		private void btnOthers_Click(object sender, EventArgs e) { ChangePanel(OthersPanel); }

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
				/* Args:
				 *	Main<Pointer to Main Form>
				 *	String<name the image type>
				 *	Returns:
				 *		String<array of 3 elements>
				 */
				IconPicker pIconSelector = new IconPicker(pMain, "ItemBtn");

				if (pIconSelector.ShowDialog() != DialogResult.OK)
					return;

				string[] strArray = pIconSelector.ReturnValues;
				/****************************************/
				Image pIcon = pMain.GetIcon("ItemBtn", strArray[0], Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
				if (pIcon != null)
				{
					pTempRow["a_texture_id"] = strArray[0];
					pTempRow["a_texture_row"] = strArray[1];
					pTempRow["a_texture_col"] = strArray[2];

					pbIcon.Image = pIcon;

					pToolTip = new ToolTip();
					pToolTip.SetToolTip(pbIcon, "FILE: " + strArray[0] + " ROW: " + strArray[1] + " COL: " + strArray[2]);

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
                /* Args:
				 *	Main<Pointer to Main Form>
				 *	String array with flag names<Flags Array>
				 *	Int<Flag>
				 *	Returns:
				 *		Int<composed Flag>
				 */
                FlagPicker pFlagSelector = new FlagPicker(pMain, Defs.ItemClass, Convert.ToInt32(btnClassFlag.Text.ToString()));

                if (pFlagSelector.ShowDialog() != DialogResult.OK)
                    return;

                string strFlag = pFlagSelector.ReturnValues.ToString();
                /****************************************/
                btnClassFlag.Text = strFlag;

                pTempRow["a_job_flag"] = strFlag;

                bUnsavedChanges = true;
            }
        }

        private void btnAllowedZoneFlag_Click(object sender, EventArgs e)
        {
            if (bUserAction)
            {
                /* Args:
				 *	Main<Pointer to Main Form>
				 *	String array with flag names<Flags Array>
				 *	Int<Flag>
				 *	Returns:
				 *		Int<composed Flag>
				 */
                FlagPicker pFlagSelector = new FlagPicker(pMain, Defs.ItemClass, Convert.ToInt32(btnAllowedZoneFlag.Text.ToString()));

                if (pFlagSelector.ShowDialog() != DialogResult.OK)
                    return;

                string strFlag = pFlagSelector.ReturnValues.ToString();
                /****************************************/
                btnAllowedZoneFlag.Text = strFlag;

                pTempRow["a_zone_flag"] = strFlag;

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

		private void tbQuestTriggerID_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_quest_trigger_ids"] = tbQuestTriggerID.Text;

				bUnsavedChanges = true;
			}
		}

		private void tbQuestTriggerCount_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_quest_trigger_count"] = tbQuestTriggerCount.Text;

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
				pTempRow["a_effect_name"] = tbEffectNormal.ToString();

				bUnsavedChanges = true;
			}
		}

		private void tbEffectAttack_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_attack_effect_name"] = tbEffectAttack.ToString();

				bUnsavedChanges = true;
			}
		}

		private void tbEffectDamage_TextChanged(object sender, EventArgs e)
		{
			if (bUserAction)
			{
				pTempRow["a_damage_effect_name"] = tbEffectDamage.ToString();

				bUnsavedChanges = true;
			}
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

				pMain.pItemTable.Rows[nRowIndex][strColumnName] = objColumnValue;
			}
		}
    }
}

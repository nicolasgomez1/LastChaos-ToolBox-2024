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
			cbTypeSelector.Items.Clear();

			cbTypeSelector.BeginUpdate();

			foreach (string strType in Defs.ItemTypesNSubTypes.Keys)
				cbTypeSelector.Items.Add(strType);

			cbTypeSelector.EndUpdate();
			/****************************************/

			/****************************************/
			cbWearingPositionSelector.Items.Clear();

			cbWearingPositionSelector.BeginUpdate();

			foreach (string strWearingPos in Defs.ItemWearingPositions)
				cbWearingPositionSelector.Items.Add(strWearingPos);

			cbWearingPositionSelector.EndUpdate();
			/****************************************/

			/****************************************/
			cbRvRValueSelector.Items.Clear();

			cbRvRValueSelector.BeginUpdate();

			foreach (string strSyndicateType in Defs.SyndicateTypesNGrades.Keys)
				cbRvRValueSelector.Items.Add(strSyndicateType);

			cbRvRValueSelector.EndUpdate();
			/****************************************/

			ProgressDialog progressDialog = new ProgressDialog(this, "Please Wait...");

            /****************************************/
            /* NOTE: Esto se tendría que replicar en cada herramienta que se cree de ahora en más.
             * Definir todas las columnas necesarias para el funcionamiento de la herramienta en cuestión.
             * Posteriormente verificar si la tabla pMain.pItemTable está vacía. Si es así directamente ejecutar la Query.
             * De lo contrario inteligentemente verificar que columnas requeridas no están presentes en pMain.pItemTable para posteriormente obtenerlas y cargarlas.
             */
            bool bRequestNeeded = false;
			List<string> listQueryCompose = new List<string>
			{
				"a_index", "a_enable", "a_texture_id", "a_texture_row", "a_texture_col", "a_file_smc", "a_weight", "a_price", "a_level", "a_level2", "a_durability",
				"a_fame", "a_max_use", "a_type_idx", "a_subtype_idx", "a_wearing", "a_quest_trigger_ids", "a_quest_trigger_count", "a_rvr_value", "a_rvr_grade"
			};

			for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
			{
				string strNation = pMain.pSettings.NationSupported[i].ToLower();

				listQueryCompose.Add("a_name_" + strNation);
				listQueryCompose.Add("a_descr_" + strNation);
			}

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

			if (bRequestNeeded)
			{
				pMain.pItemTable = await Task.Run(() =>
				{
					return pMain.QuerySelect("utf8", $"SELECT {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
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
						Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.DefaultEditNation].ToString(),
					});
				}

				MainList.SelectedIndex = 0;

				MainList.EndUpdate();
			}

			progressDialog.Close();
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

			if (pTempRow["a_enable"].ToString() == "1")
				cbEnable.Checked = true;
			else
				cbEnable.Checked = false;

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

			string strNation = cbNationSelector.SelectedItem.ToString().ToLower();

			tbName.Text = pTempRow["a_name_" + strNation].ToString();

			tbDescription.Text = pTempRow["a_descr_" + strNation].ToString();

			int nType = Convert.ToInt32(pTempRow["a_type_idx"]);

			if (nType < 0 || nType > Defs.ItemTypesNSubTypes.Keys.Count)
			{
				cbTypeSelector.Items.Clear();
				cbTypeSelector.Enabled = false;
				cbTypeSelector.Text = "";

				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_type_idx out of range");
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

					pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_subtype_idx out of range");
				}
				else
				{
					cbSubTypeSelector.SelectedIndex = nSubType;
				}
			}

			int nWearinPosition = Convert.ToInt32(pTempRow["a_wearing"]);

			if (nWearinPosition < -1 || nWearinPosition > Defs.ItemWearingPositions.Length)
			{
				cbWearingPositionSelector.Items.Clear();
				cbWearingPositionSelector.Enabled = false;
				cbWearingPositionSelector.Text = "";

				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_wearing out of range");
			}
			else
			{
				if (nWearinPosition == -1)
					nWearinPosition = 0;
				else
					nWearinPosition++;

				cbWearingPositionSelector.SelectedIndex = nWearinPosition;
			}

			tbQuestTriggerID.Text = pTempRow["a_quest_trigger_ids"].ToString();

			tbQuestTriggerCount.Text = pTempRow["a_quest_trigger_count"].ToString();

			int nRvRValue = Convert.ToInt32(pTempRow["a_rvr_value"]);
			if (nRvRValue > Defs.SyndicateTypesNGrades.Keys.Count)
			{
				pMain.PrintLog("Item Editor > Item: " + nItemID + " Error: a_rvr_value out of range");
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

			bUserAction = true;
			btnUpdate.Enabled = true;
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
			IconPicker pIconSelector = new IconPicker(pMain, "ItemBtn");

			if (pIconSelector.ShowDialog() != DialogResult.OK)
				return;

			string[] strArray = pIconSelector.ReturnValues;

			Image pIcon = pMain.GetIcon("ItemBtn", strArray[0], Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
			if (pIcon != null)
			{
				if (bUserAction)
					bUnsavedChanges = true;

				pTempRow["a_texture_id"] = strArray[0];
				pTempRow["a_texture_row"] = strArray[1];
				pTempRow["a_texture_col"] = strArray[2];

				pbIcon.Image = pIcon;

				pToolTip = new ToolTip();
				pToolTip.SetToolTip(pbIcon, "FILE: " + strArray[0] + " ROW: " + strArray[1] + " COL: " + strArray[2]);
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

		private void cbTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			int nType = cbTypeSelector.SelectedIndex;

			if (nType != -1)
			{
				pMain.PrintLog("cbTypeSelector_SelectedIndexChanged: " + nType);

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

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			DataRow[] pRow = pMain.pItemTable.Select("a_index = " + Convert.ToInt32(tbID.Text));

			int nRowIndex = pMain.pItemTable.Rows.IndexOf(pRow[0]);

			foreach (DataColumn column in pTempRow.Table.Columns)
			{
				string strColumnName = column.ColumnName;
				object objColumnValue = pTempRow[column];

                // TODO: Compose query to update values in db server

                // NOTE: Esto puede ser étil más adelante. Verifica si la columna existe en la tabla principal
                /*if (!pMain.pItemTable.Columns.Contains("column_name"))
					pMain.pItemTable.Columns.Add("column_name", column.DataType);*/

                pMain.pItemTable.Rows[nRowIndex][strColumnName] = objColumnValue;
			}
		}
	}
}

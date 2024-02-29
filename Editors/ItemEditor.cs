using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024.Editors
{
	public partial class ItemEditor : Form
	{
		private Main pMain;
        private bool bUserAction = false;
        private bool bUnsavedChanges = false;
        private ListBoxItem pLastSelected;
        private System.Windows.Forms.ToolTip pToolTip;
        
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

            var progressDialog = new ProgressDialog("Please Wait...", this);

			if (pMain.pItemTable == null)
			{
				pMain.pItemTable = await Task.Run(() =>
				{
					// a_index, a_name_{pMain.pSettings.DefaultEditNation}
					return pMain.QuerySelect("utf8", $"SELECT * FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
				});
			}

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
					}); ;
				}

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

        private void ChangePanel(Panel pPanel)
		{
			if (pPanel == GeneralPanel)
			{
				CraftingPanel.Visible = false;
				GeneralPanel.Visible = true;
            }

            if (pPanel == CraftingPanel)
            {
                GeneralPanel.Visible = false;
                CraftingPanel.Visible = true;
            }
        }

		private void MainList_SelectedIndexChanged(object sender, EventArgs e)
		{
            ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;
            
            void LoadItemData() {
                if (pSelectedItem != null)
                {
					bUserAction = false;

                    // TODO: Load data from table to UI
                    int nItemID = pSelectedItem.ID;

					DataRow pRow = pMain.pItemTable.Select("a_index = " + nItemID)[0];

                    tbID.Text = nItemID.ToString();

                    if (pRow["a_enable"].ToString() == "1")
                        cbEnable.Checked = true;
                    else
                        cbEnable.Checked = false;

                    string strTexID = pRow["a_texture_id"].ToString();
                    string strTexRow = pRow["a_texture_row"].ToString();
                    string strTexCol = pRow["a_texture_col"].ToString();

                    Image pIcon = pMain.GetIcon("ItemBtn", strTexID, Convert.ToInt32(strTexRow), Convert.ToInt32(strTexCol));
                    if (pIcon != null)
                    {
                        pbIcon.Image = pIcon;

                        pToolTip = new ToolTip();
                        pToolTip.SetToolTip(pbIcon, "FILE: " + strTexID + " ROW: " + strTexRow + " COL: " + strTexCol);
                    }

                    // NOTE: Finally set update button enable and enable user action check
                    bUserAction = true;
                    btnUpdate.Enabled = true;
                }
            }

            if (bUnsavedChanges)
            {
                DialogResult pDialogReturn = MessageBox.Show("There are unapplied changes, Do you want to discard them?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (pDialogReturn == DialogResult.Yes)
                {
					bUnsavedChanges = false;

                    LoadItemData();
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
				LoadItemData();
            }

            pLastSelected = pSelectedItem;
        }

		private void Insert_Click(object sender, EventArgs e)
		{
			pMain.pItemTable.Dispose();
			pMain.pItemTable = null;

			ItemEditor_Load(sender, e);
		}
		
		private void Update_Click(object sender, EventArgs e)
		{
            /*bool bReturn = pMain.QueryUpdateInsert("utf8", "INSERT INTO lc_data_nov.t_clientversion (a_min, a_max) VALUES('0', '9199')");

		   if (bReturn)
			   pMain.PrintLog("suc");
		   else
			   pMain.PrintLog("failed");
            -------
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

        private void btnGeneral_Click(object sender, EventArgs e) { ChangePanel(GeneralPanel); }
        private void btnCrafting_Click(object sender, EventArgs e) { ChangePanel(CraftingPanel); }
       
        private void tbID_TextChanged(object sender, EventArgs e) { if (bUserAction) bUnsavedChanges = true; }
        private void cbEnable_CheckedChanged(object sender, EventArgs e) { if (bUserAction) bUnsavedChanges = true; }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            IconPicker pIconSelector = new IconPicker(pMain, "ItemBtn");

            if (pIconSelector.ShowDialog() != DialogResult.OK)
                return;

            string[] strArray = pIconSelector.ReturnValues;

            Image pIcon = pMain.GetIcon("ItemBtn", strArray[0], Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
            if (pIcon != null)
            {
                pbIcon.Image = pIcon;

                pToolTip = new ToolTip();
                pToolTip.SetToolTip(pbIcon, "FILE: " + strArray[0] + " ROW: " + strArray[1] + " COL: " + strArray[2
                    ]);
            }
        }
    }
}

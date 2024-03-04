﻿using Definitions;
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
using static LastChaos_ToolBox_2024.Editors.ItemEditor;

namespace LastChaos_ToolBox_2024
{
    /* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	Int array with default Skill ID and Level to select<Skill data Array>
	 * Returns:
	 *		Array<Int<Skill ID>, String<Skill Level>>
	// Call and receive implementation
	SkillPicker pSkillSelector = new SkillPicker(pMain, this, new int[] { Convert.ToInt32(pTempRow[strIDColumn]), Convert.ToInt32(pTempRow[strLevelColumn]) });

    if (pSkillSelector.ShowDialog() != DialogResult.OK)
		return;

	int[] iArray = pSkillSelector.ReturnValues;
    /****************************************/
    public partial class SkillPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
        private int nSearchPosition = 0;
        public object[] ReturnValues = new object[2];

        public SkillPicker(Main mainForm, Form ParentForm, object[] iArray)
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

            pMain = mainForm;
            pParentForm = ParentForm;
            ReturnValues = iArray;
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

        private async void SkillPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

            if (pMain.pSkillTable != null && pMain.pSkillLevelTable != null)
			{
                MainList.Items.Clear();

                MainList.BeginUpdate();

                int nOriginalSkillID = Convert.ToInt32(ReturnValues[0]);

                foreach (DataRow pRow in pMain.pSkillTable.Rows)
                {
                    int nSkillID = Convert.ToInt32(pRow["a_index"]);

                    MainList.Items.Add(new ListBoxItem
                    {
                        ID = nSkillID,
                        Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.WorkLocale].ToString()
                    });

                    if (nSkillID == nOriginalSkillID)
                        MainList.SelectedIndex = MainList.Items.Count - 1;
                }

                //MainList.SelectedIndex = 0;

                MainList.EndUpdate();
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("There are unsaved changes. If you proceed, your changes will be discarded.\nDo you want to continue?", "Item Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                cbLevelSelector.Enabled = false;
                btnSelect.Enabled = false;

                cbLevelSelector.Items.Clear();

                cbLevelSelector.BeginUpdate();

                int nItemID = pSelectedItem.ID;

                DataRow pRowSkill = pMain.pSkillTable.Select("a_index = " + nItemID).FirstOrDefault();

                Image pIcon = pMain.GetIcon("SkillBtn", pRowSkill["a_client_icon_texid"].ToString(), Convert.ToInt32(pRowSkill["a_client_icon_row"]), Convert.ToInt32(pRowSkill["a_client_icon_col"]));
                if (pIcon != null)
                    pbIcon.Image = pIcon;

                tbDescription.Text = pRowSkill["a_client_description_" + pMain.pSettings.WorkLocale].ToString();

                string strOriginalSkillLevel = ReturnValues[1].ToString();
                List<DataRow> pRowsSkillLevel = pMain.pSkillLevelTable.AsEnumerable().Where(row => row.Field<int>("a_index") == nItemID).ToList();

                foreach (var pRowSkillLevel in pRowsSkillLevel)
                {
                    string strSkillLevel = pRowSkillLevel["a_level"].ToString();
                    
                    cbLevelSelector.Items.Add("Level: " + strSkillLevel + " - Power: " + pRowSkillLevel["a_dummypower"].ToString());

                    if (strOriginalSkillLevel == strSkillLevel)
                        cbLevelSelector.SelectedIndex = cbLevelSelector.Items.Count - 1;
                }

                if (cbLevelSelector.SelectedIndex == -1)
                    cbLevelSelector.SelectedIndex = 0;

                cbLevelSelector.EndUpdate();

                cbLevelSelector.Enabled = true;
                btnSelect.Enabled = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;
            int nSelectedSkillLevel = cbLevelSelector.SelectedIndex;

            if (pSelectedItem != null && nSelectedSkillLevel != -1)
            {
                cbLevelSelector.Enabled = false;

                cbLevelSelector.Items.Clear();

                cbLevelSelector.BeginUpdate();

                DialogResult = DialogResult.OK;

                ReturnValues = new object[] { pSelectedItem.ID, (nSelectedSkillLevel + 1).ToString() };

                Close();
            }
        }

        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            ReturnValues = new object[] { -1, "0" };

            Close();
        }
    }
}
using Definitions;
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
	 *		Int<Array of 2 elements>
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
        private bool bUserAction = false;
        private int nSearchPosition = 0;
		public int[] ReturnValues = { 0, 0 };

		public SkillPicker(Main mainForm, Form ParentForm, int[] iArray)
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

        private async void FlagPicker_LoadAsync(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

            bUserAction = false;

            if (pMain.pSkillTable != null && pMain.pSkillLevelTable != null)
			{
                MainList.Items.Clear();

                MainList.BeginUpdate();

                foreach (DataRow pRow in pMain.pSkillTable.Rows)
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

            bUserAction = true;
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
            if (bUserAction)
            {
                ListBoxItem pSelectedItem = (ListBoxItem)MainList.SelectedItem;

                if (pSelectedItem != null)
                {
                    int nItemID = pSelectedItem.ID;
                    // TODO: All code related to skill & skill level selection. Also adds a icon and description aside of the main list
                }
            }
        }

        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            ReturnValues = new[] { -1, 0 };

            Close();
        }
    }
}

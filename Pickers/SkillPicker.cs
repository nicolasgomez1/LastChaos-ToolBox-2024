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

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 *	Int array with skill ID and Level<Skill data Array>
	 * Returns:
	 *		Int<Array of 2 elements>
	 */
	/*FlagPicker pFlagSelector = new FlagPicker(pMain, this, Defs.ItemClass, Convert.ToInt32(btnFlag.Text.ToString()));

	if (pFlagSelector.ShowDialog() != DialogResult.OK)
		 return;

	string strFlag = pFlagSelector.ReturnValues.ToString();*/
	/****************************************/
	public partial class SkillPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int[] iArray;
		public int[] ReturnValues = { 0, 0 };

		public SkillPicker(Main mainForm, Form ParentForm, int[] iArray)
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			pMain = mainForm;
            pParentForm = ParentForm;
            this.iArray = iArray;
		}

		private void FlagPicker_Load(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);
		}

		private void tbSearch_TextChanged(object sender, EventArgs e)
		{

		}

        private void MainList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemoveSkill_Click(object sender, EventArgs e)
        {

        }
    }
}

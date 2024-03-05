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
	 *	String array with flag names<Flags Array>
	 *	Long<Flag>
	 * Returns:
	 *		Longs<composed Flag>
	// Call and receive implementation
	FlagPicker pFlagSelector = new FlagPicker(pMain, this, Defs.ItemClass, Convert.ToInt32(btnFlag.Text.ToString()));

	if (pFlagSelector.ShowDialog() != DialogResult.OK)
		 return;

	string strFlag = pFlagSelector.ReturnValues.ToString();
	/****************************************/
	public partial class FlagPicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private string[] strArrayFlag;
		public long ReturnValues = 0;

		public FlagPicker(Main mainForm, Form ParentForm, string[] strArray, long nFlag)
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			pMain = mainForm;
			pParentForm = ParentForm;
			this.strArrayFlag = strArray;
            ReturnValues = nFlag;
		}

		private void FlagPicker_Load(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			clbFlagList.Items.Clear();

			clbFlagList.BeginUpdate();

			for (int i = 0; i < strArrayFlag.Length; i++)
			{
				clbFlagList.Items.Add(i + " - " + strArrayFlag[i]);

				clbFlagList.SetItemChecked(i, (ReturnValues & 1L << i) > 0);
			}

			clbFlagList.EndUpdate();

			tbFlag.Text = ReturnValues.ToString();
		}

		private void btnCheckAll_Click(object sender, EventArgs e)
		{
			long nFlag = 0;

			for (int i = 0; i < clbFlagList.Items.Count; ++i)
			{
				clbFlagList.SetItemChecked(i, true);
				nFlag += 1L << i;
			}

			tbFlag.Text = nFlag.ToString();

			ReturnValues = nFlag;
		}

		private void btnUnCheckAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < clbFlagList.Items.Count; ++i)
				clbFlagList.SetItemChecked(i, false);

			tbFlag.Text = "0";

			ReturnValues = 0;
		}

		private void clbFlagList_SelectedIndexChanged(object sender, EventArgs e)
		{
			long nFlag = 0;

			for (int i = 0; i < clbFlagList.Items.Count; ++i)
			{
				if (clbFlagList.GetItemChecked(i))
					nFlag += 1L << i;
			}

			tbFlag.Text = nFlag.ToString();

			ReturnValues = nFlag;

			clbFlagList.ClearSelected();
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Close();
		}
	}
}

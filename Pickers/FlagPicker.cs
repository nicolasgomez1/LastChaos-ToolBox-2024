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
	public partial class FlagPicker : Form
	{
		private Main pMain;
		private string[] pStrArrayFlag;
		private int pNFlag;
		public int ReturnValues = 0;

		public FlagPicker(Main mainForm, string[] strArray, int nFlag)
		{
			InitializeComponent();

			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			pMain = mainForm;
			pStrArrayFlag = strArray;
			ReturnValues = pNFlag = nFlag;
		}

		private void FlagPicker_Load(object sender, EventArgs e)
		{
			btnUnCheckAll.Enabled = false;

			clbFlagList.Items.Clear();

			clbFlagList.BeginUpdate();

			for (int i = 0; i < pStrArrayFlag.Length; i++)
			{
				clbFlagList.Items.Add(i + " - " + pStrArrayFlag[i]);

				clbFlagList.SetItemChecked(i, (pNFlag & 1 << i) > 0);
			}

			clbFlagList.EndUpdate();

			btnUnCheckAll.Enabled = true;

			tbFlag.Text = pNFlag.ToString();
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
			int nFlag = 0;

			for (int i = 0; i < clbFlagList.Items.Count; ++i)
			{
				if (clbFlagList.GetItemChecked(i))
					nFlag += 1 << i;
			}

			tbFlag.Text = nFlag.ToString();

			ReturnValues = nFlag;

			clbFlagList.ClearSelected();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			Close();
		}
	}
}

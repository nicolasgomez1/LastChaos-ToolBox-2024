using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Definitions;

namespace LastChaos_ToolBox_2024
{
	/* Args:
	 *	Main<Pointer to Main Form>
	 *	Form<Parent Form to center the Window>
	 * Returns:
	 *		Array<Int<Zone ID>, String<Zone Name>>
	// Call and receive implementation
	GenericTypePicker pGenericTypeSelector = new GenericTypePicker(pMain, this);

	if (pGenericTypeSelector.ShowDialog() != DialogResult.OK)
		return;

	int nType = Convert.ToInt32(pGenericTypeSelector.ReturnValues[0]);
	/****************************************/
	public partial class GenericTypePicker : Form
	{
		private Form pParentForm;
		private Main pMain;
		private int nSearchPosition = 0;
		private List<(string, string[])> listTypesLists;
		public int ReturnValues = -1;

		public GenericTypePicker(Main mainForm, Form ParentForm)
		{
			InitializeComponent();

			pMain = mainForm;
			pParentForm = ParentForm;
		}

		private void GenericTypePicker_Load(object sender, EventArgs e)
		{
			this.Location = new Point((int)pParentForm.Location.X + (pParentForm.Width - this.Width) / 2, (int)pParentForm.Location.Y + (pParentForm.Height - this.Height) / 2);

			listTypesLists = new List<(string, string[])>
			{
				("IETC Types", Defs.IETCTypes)
			};

			foreach (var List in listTypesLists)
				cbTypesListSelector.Items.Add(List.Item1);
		}

		private void cbTypesListSelector_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (var List in listTypesLists[cbTypesListSelector.SelectedIndex].Item2)
			{
				MainList.Items.Add(List);
			}
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

		private void MainList_DoubleClick(object sender, EventArgs e)
		{
			int nIndex = MainList.SelectedIndex;
			if (nIndex != -1)
			{
				DialogResult = DialogResult.OK;

				ReturnValues = nIndex;

				Close();
			}
		}

		private void btnRemoveZone_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;

			ReturnValues = -1;

			Close();
		}

		private void tbSearch_TextChanged(object sender, EventArgs e) { nSearchPosition = 0; }
	}
}

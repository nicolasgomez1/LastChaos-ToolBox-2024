using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024.Editors
{
	public partial class ItemEditor : Form
	{
		private Main pMain;

		public ItemEditor(Main mainForm)
		{
			InitializeComponent();

			pMain = mainForm;
		}

		private async void ItemEditor_Load(object sender, EventArgs e)
		{
            var progressDialog = new ProgressDialog("Please Wait...");

            // Load t_item to memory
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
				// TODO: Clean ListBox
				MainList.Items.Clear();

				// TODO: Stop ListBox Update
				MainList.BeginUpdate();

				// TODO: Fill ListBox with items names and ids
				foreach (DataRow pRow in pMain.pItemTable.Rows)
				{
                    MainList.Items.Add(new ListBoxItem
                    {
                        ID = Convert.ToInt32(pRow["a_index"]),
                        Text = pRow["a_index"] + " - " + pRow["a_name_" + pMain.pSettings.DefaultEditNation].ToString()
                    });

                    /*foreach (DataColumn col in pMain.pItemTable.Columns)
					{
						Console.Write(col.ColumnName + " " + row[col] + "\t");
					}*/
                }

				// TODO: Finally StartListBox Update again
				MainList.EndUpdate();
			}

            progressDialog.Close();
        }

		private void Insert_Click(object sender, EventArgs e)
		{
			pMain.pItemTable = null;
			ItemEditor_Load(sender, e);
		}
		
		private void Update_Click(object sender, EventArgs e)
		{
			/*bool bReturn = pMain.QueryUpdateInsert("utf8", "INSERT INTO lc_data_nov.t_clientversion (a_min, a_max) VALUES('0', '9199')");

		   if (bReturn)
			   pMain.PrintLog("suc");
		   else
			   pMain.PrintLog("failed");*/

			DataTable pData = pMain.QuerySelect("utf8", "SELECT * FROM lc_data_nov.t_clientversion;");

			if (pData != null)
			{
				foreach (DataRow row in pData.Rows)
				{
					foreach (DataColumn col in pData.Columns)
					{
						Console.Write(col.ColumnName + " " +row[col] + "\t");
					}

					Console.WriteLine();
				}
			}
		}

		private void MainList_SelectedIndexChanged(object sender, EventArgs e)
		{

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
    }
}

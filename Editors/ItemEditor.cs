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

		private void ItemEditor_Load(object sender, EventArgs e)
		{
			// TODO: preload all item data 
		}

		private void Insert_Click(object sender, EventArgs e)
		{
			bool bReturn = pMain.QueryUpdateInsert("utf8", "INSERT INTO lc_data_nov.t_clientversion (a_min, a_max) VALUES('0', '9199')");

			if (bReturn)
				pMain.PrintLog("suc");
			else
				pMain.PrintLog("failed");
		}

		private void Update_Click(object sender, EventArgs e)
		{
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
	}
}

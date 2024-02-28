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
        private Main pMainForm;

        public ItemEditor(Main mainForm)
        {
            InitializeComponent();
            pMainForm = mainForm;
        }

        /*private void Reload_Click(object sender, EventArgs e)
        {
            Main.PrintLog($"{pMainForm.pSettings.DBHost}");
        }*/

        private void ItemEditor_Load(object sender, EventArgs e)
        {

        }
    }
}

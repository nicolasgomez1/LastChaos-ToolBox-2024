using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SlimDX.Direct3D9;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Net.NetworkInformation;
using System.IO;
using System.Configuration;

// Editors
using LastChaos_ToolBox_2024.Editors;

namespace LastChaos_ToolBox_2024
{
    public partial class Main : Form
    {
        public Settings pSettings { get; } = new Settings();
        public MySqlConnection mysqlConn;

        public Main()
        {
            InitializeComponent();

            Assembly pAssembly = Assembly.GetAssembly(typeof(Main));
            this.Text = $"{pAssembly.GetName().Name} Build: {pAssembly.GetName().Version.Revision}";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ConnectToDatabase();
        }

        private void ReloadSettings_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void Reconnect_Click(object sender, EventArgs e)
        {
            if (mysqlConn.State == ConnectionState.Open)
            {
                PrintLog("MySQL > Closing existing connection.");
                mysqlConn.Close();
            }

            ConnectToDatabase();
        }

        private void ItemEditor_Click(object sender, EventArgs e)
        {
            ItemEditor pItemEditor = new ItemEditor(this);
            pItemEditor.Show();
        }

        private string GetValueFromLine(string strString)
        {
            string[] strArray = strString.Split('=');

            if (strArray.Length >= 2)
            {
                return strArray[1].Trim();
            }
            else
            {
                PrintLog("Settings file is corrupted or wrong formed.");

                return "";
            }
        }

        public static void PrintLog(string strMsg)
        {
            StackFrame stackFrame = new StackFrame(1, true);

            string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{Path.GetFileName(stackFrame.GetFileName())} : {stackFrame.GetFileLineNumber()} : {stackFrame.GetMethod().Name}] > {strMsg}";

            using (StreamWriter sw = File.AppendText("Logs.log"))
            {
                sw.WriteLine(strLog);
            }

            Debug.WriteLine(strLog);
        }

        public class Settings {
            public string SettingsFile = "Settings.ini";

            public string DBHost = "";
            public string DBUsername = "";
            public string DBPassword = ""; 
            public string DBAuth = ""; 
            public string DBData = "";
            public string DBUser = "";
            public string DBCharset = "utf8";

            public string DefaultEditNation = "USA";
        }

        void LoadSettings()
        {
            PrintLog("Starting settings load...");

            if (File.Exists(pSettings.SettingsFile))
            {
                string[] strArray = File.ReadAllLines(pSettings.SettingsFile);

                // Database Settings
                pSettings.DBHost = GetValueFromLine(strArray[0]);
                pSettings.DBUsername = GetValueFromLine(strArray[1]);
                pSettings.DBPassword = GetValueFromLine(strArray[2]);
                pSettings.DBAuth = GetValueFromLine(strArray[3]);
                pSettings.DBData = GetValueFromLine(strArray[4]);
                pSettings.DBUser = GetValueFromLine(strArray[5]);
                pSettings.DBCharset = GetValueFromLine(strArray[6]);

                // Others Settings
                pSettings.DefaultEditNation = GetValueFromLine(strArray[7]);

                PrintLog("Settings load finished.");
            }
            else
            {
                PrintLog($"{pSettings.SettingsFile} not exist.");
            }
        }

        void ConnectToDatabase()
        {
            try
            {
                mysqlConn = new MySqlConnection($"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET={pSettings.DBCharset}");

                mysqlConn.Open();

                PrintLog("MySQL > Connected successfully.");
            }
            catch (Exception ex)
            {
                PrintLog($"MySQL > {ex.Message}");

                DialogResult result = MessageBox.Show($"{ex.Message}\n\nWould you like to retry the connection?", "MySQL > It was not possible to connect to your Database Server.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    ConnectToDatabase();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}

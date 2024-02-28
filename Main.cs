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
using System.Data.SqlClient;

namespace LastChaos_ToolBox_2024
{
    public partial class Main : Form
    {
        public Settings pSettings { get; } = new Settings();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
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

                try
                {
                    MySqlConnection mysqlConn = new MySqlConnection($"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET={pSettings.DBCharset}");
                    mysqlConn.Open();

                    PrintLog("MySQL > Connected successfully.");
                }
                catch (Exception ex)
                {
                    PrintLog($"MySQL > {ex.Message}");
                }
            }
            else
            {
                PrintLog($"{pSettings.SettingsFile} not exist.");
            }
        }

        private void Reconnect_Click(object sender, EventArgs e)
        {

        }
        private void ItemEditor_Click(object sender, EventArgs e)
        {
            PrintLog($"TEST:{pSettings.DBHost}");

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
    }
}

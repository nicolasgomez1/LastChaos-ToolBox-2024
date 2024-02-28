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
using LastChaos_ToolBox_2024.Editors;

namespace LastChaos_ToolBox_2024
{
    public partial class Main : Form
    {
        //private static Settings pSettings { get; } = new Settings();
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

                pSettings.DBHost = GetValueFromLine(strArray[0]);
                pSettings.DBUsername = GetValueFromLine(strArray[1]);
                pSettings.DBPassword = GetValueFromLine(strArray[2]);
                pSettings.DBAuth = GetValueFromLine(strArray[3]);
                pSettings.DBData = GetValueFromLine(strArray[4]);
                pSettings.DBUser = GetValueFromLine(strArray[5]);

                PrintLog("Settings load finished.");
            }
            else
            {
                PrintLog($"{pSettings.SettingsFile} not exist.");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            PrintLog($"TEST:{pSettings.DBHost}");

            ItemEditor pItemEditor = new ItemEditor(this);
            pItemEditor.Show();
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

            public string DBHost { get; set; } = "";
            public string DBUsername { get; set; } = "";
            public string DBPassword { get; set; } = ""; 
            public string DBAuth { get; set; } = ""; 
            public string DBData { get; set; } = "";
            public string DBUser { get; set; } = "";
            public string DBCharset { get; set; } = "utf8";
        }
    }
}

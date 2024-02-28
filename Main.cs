﻿using System;
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
		// Global Vals
		public Settings pSettings = new Settings();
		public MySqlConnection mysqlConn;
		public DataTable pItemTable = null;

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
			// TODO: NOTE: ¿Limitar la cantidad de editores de un mismo tipo que se pueden abrir?
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

		public void PrintLog(string strMsg)
		{
			StackFrame stackFrame = new StackFrame(1, true);

			string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{Path.GetFileName(stackFrame.GetFileName())} : {stackFrame.GetFileLineNumber()} : {stackFrame.GetMethod().Name}] > {strMsg}";

			using (StreamWriter pStreamWriter = File.AppendText("Logs.log"))
			{
				pStreamWriter.WriteLine(strLog);
			}
#if DEBUG
			Debug.WriteLine(strLog);
#else
			Console.WriteLine(strLog);
#endif
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
				pSettings.DefaultEditNation = GetValueFromLine(strArray[7]).ToLower();

				PrintLog("Settings load finished.");
			}
			else
			{
				PrintLog($"{pSettings.SettingsFile} not exist.");
			}
		}
		// General Help Functions
		// TODO: ...

		// Database Functions
		public DataTable QuerySelect(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;
				
				MySqlConnection mysqlConnection = new MySqlConnection(strConnect);
				mysqlConnection.Open();

				MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection);

				DataTable pTable = new DataTable();
				pTable.Load(mysqlCommand.ExecuteReader());

				mysqlConnection.Close();

				PrintLog("MySql Query (CharSet: " + strCharset + ")\n" + strQuery + "\nExecute successfully.");

				return pTable;
			}
			catch (Exception ex)
			{
				PrintLog($"MySql Query (CharSet: {strCharset})\n{strQuery}\nFail > {ex.Message}");

				return null;
			}
		}

		public bool QueryUpdateInsert(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;

				MySqlConnection mysqlConnection = new MySqlConnection(strConnect);
				mysqlConnection.Open();

				MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection);
				mysqlCommand.ExecuteReader();

				mysqlConnection.Close();

				PrintLog("MySql Query (CharSet: " + strCharset + ")\n" + strQuery + "\nExecute successfully.");

				return true;
			}
			catch(Exception ex)
			{
				PrintLog($"MySql Query \n{strQuery}\nFail > {ex.Message}");

				return false;
			}
		}

		void ConnectToDatabase()
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET={pSettings.DBCharset}";
			   
				mysqlConn = new MySqlConnection(strConnect);

				PrintLog("MySQL > Trying to connect to Database (" + strConnect + ")");

				mysqlConn.Open();

				PrintLog("MySQL > Connected successfully.");
			}
			catch (Exception ex)
			{
				PrintLog($"MySQL > {ex.Message}");

				DialogResult pDialogReturn = MessageBox.Show($"{ex.Message}\n\nWould you like to retry the connection?", "MySQL > It was not possible to connect to your Database Server.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.Yes)
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

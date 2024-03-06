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
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO;
using IniParser;
using IniParser.Model;
using LastChaos_ToolBox_2024.Editors;

namespace LastChaos_ToolBox_2024
{
	public partial class Main : Form
	{
		private string strWindowsTitle;

		// Global Vals
		public Settings pSettings = new Settings();
		public MySqlConnection mysqlConn;
		public DataTable pItemTable = null;
		public DataTable pZoneTable = null;
		public DataTable pSkillTable = null;
		public DataTable pSkillLevelTable = null;
        public DataTable pRareOptionTable = null;

        public class Settings
		{
			public string SettingsFile = "Settings.ini";

			public string DBHost = "";
			public string DBUsername = "";
			public string DBPassword = "";
			public string DBAuth = "";
			public string DBData = "";
			public string DBUser = "";
			public string DBCharset = "utf8";
			public string WorkLocale = "USA";

			public string ClientPath = "";
			public string[] NationSupported;
			public Dictionary<string, string> ShowRenderDialog { get; set; } = new Dictionary<string, string>();
		}

		public Main()
		{
			InitializeComponent();

			Assembly pAssembly = Assembly.GetAssembly(typeof(Main));

			this.Text = strWindowsTitle = pAssembly.GetName().Name + " Build: " + pAssembly.GetName().Version.Revision;
		}

		private void Main_Load(object sender, EventArgs e)
		{
#if DEBUG
			Monitor.Start();
#endif
			LoadSettings();

			ConnectToDatabase();
		}

		private void monitor_Tick(object sender, EventArgs e)
		{
			this.Text = strWindowsTitle + " (Ram Usage: " + (GC.GetTotalMemory(true) / 1024) + "KB's)";
		}

		private void ReloadSettings_Click(object sender, EventArgs e) { LoadSettings(); }

		private void ClearGlobalTables()
		{
			// TODO: ¿Cerrar todos los dialogos abiertos?
            // TODO: Add dispose to all global tables
            if (pItemTable != null)
            {
                pItemTable.Dispose();
                pItemTable = null;
            }

            if (pZoneTable != null)
            {
                pZoneTable.Dispose();
                pItemTable = null;
            }

            if (pSkillTable != null)
            {
                pSkillTable.Dispose();
                pSkillTable = null;
            }

            if (pSkillLevelTable != null)
            {
                pSkillLevelTable.Dispose();
                pSkillLevelTable = null;
            }

            if (pRareOptionTable != null)
            {
                pRareOptionTable.Dispose();
                pRareOptionTable = null;
            }
        }

		private void Reconnect_Click(object sender, EventArgs e)
		{
			if (mysqlConn.State == ConnectionState.Open)
			{
				PrintLog("MySQL > Closing existing connection.");

				mysqlConn.Close();
			}

            // NOTE: Posible Bug: User can reload when some editor is opened.
            ConnectToDatabase();
		}

		private void ItemEditor_Click(object sender, EventArgs e)
		{
			ItemEditor pItemEditor = new ItemEditor(this);
			pItemEditor.Show();
		}
        
        public void PrintLog(string strMsg, Color? ColorMsg = null)
		{
			StackFrame stackFrame = new StackFrame(1, true);

			string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{Path.GetFileName(stackFrame.GetFileName())} : {stackFrame.GetFileLineNumber()} : {stackFrame.GetMethod().Name}] > {strMsg}";

			using (StreamWriter pStreamWriter = File.AppendText("Logs.log"))
				pStreamWriter.WriteLine(strLog);

			rtbConsole.Invoke((MethodInvoker)delegate
			{
				int nStartPos = rtbConsole.TextLength;
				rtbConsole.AppendText(strLog + Environment.NewLine);
				int nEndPos = rtbConsole.TextLength;

				rtbConsole.Select(nStartPos, nEndPos - nStartPos);
				rtbConsole.SelectionColor = ColorMsg ?? Color.FromArgb(208, 203, 148);
				rtbConsole.SelectionLength = 0;

				rtbConsole.ScrollToCaret();
			});
		}

		void LoadSettings()
		{
			PrintLog("Loading Settings...");

			if (File.Exists(pSettings.SettingsFile))
			{
				FileIniDataParser pParser = new FileIniDataParser();
				IniData pData = pParser.ReadFile(pSettings.SettingsFile);

				// Database Settings
				pSettings.DBHost = pData["Settings"]["MySQLHost"];
				pSettings.DBUsername = pData["Settings"]["MySQLUsername"];
				pSettings.DBPassword = pData["Settings"]["MySQLPassword"];
				pSettings.DBAuth = pData["Settings"]["MySQLDBAuth"];
				pSettings.DBData = pData["Settings"]["MySQLDBData"];
				pSettings.DBUser = pData["Settings"]["MySQLDBUser"];
				pSettings.DBCharset = pData["Settings"]["Charset"];
				pSettings.WorkLocale = pData["Settings"]["Nation"].ToLower();

				// General Settings
				pSettings.ClientPath = pData["Settings"]["ClientPath"];
				/****************************************/
				string[] strArrayNations = pData["Settings"]["NationSupported"].Split(',');

				pSettings.NationSupported = new string[strArrayNations.Length];

				for (int i = 0; i < strArrayNations.Length; i++)
					pSettings.NationSupported[i] = strArrayNations[i];
				/****************************************/
				KeyDataCollection arrayKeys = pData["RenderDialog"];

				foreach (KeyData pKey in arrayKeys)
					pSettings.ShowRenderDialog[pKey.KeyName] = pKey.Value;
				/****************************************/

				PrintLog("Settings load finished.", Color.Lime);
			}
			else
			{
				PrintLog($"Settings load failed ({pSettings.SettingsFile} not exist).", Color.Red);
			}
		}

		// General Help Functions
		public Bitmap GetIcon(string BtnType, string nImage, int nRow, int nCol)
		{
			string strComposePath = BtnType + "/" + BtnType + nImage + ".png";

			if (File.Exists(strComposePath))
			{
				using (Image pImage = Image.FromFile(strComposePath))
				{
					// Create new Bitmap
					Bitmap pBitmap = new Bitmap(32, 32);
					// Generate Bitmap content
					using (Graphics pGraphics = Graphics.FromImage((Image)pBitmap))
						pGraphics.DrawImage(pImage, 0, 0, (new Rectangle(nCol * 32, nRow * 32, 32, 32)), GraphicsUnit.Pixel);

					return pBitmap;
				}
			}
			else
			{
				PrintLog("Error while trying to get Icon. Path: " + strComposePath, Color.Red);

				return null;
			}
		}

		// Database Functions
		public DataTable QuerySelect(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;

				using (MySqlConnection mysqlConnection = new MySqlConnection(strConnect))
				{
					mysqlConnection.Open();

					using (MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection))
					{
						DataTable pTable = new DataTable();
						pTable.Load(mysqlCommand.ExecuteReader());

						mysqlConnection.Close();

						PrintLog("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return pTable;
					}
				}
			}
			catch (Exception ex)
			{
				PrintLog($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

				return null;
			}
		}

		public bool QueryUpdateInsert(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;

				using (MySqlConnection mysqlConnection = new MySqlConnection(strConnect))
				{
					mysqlConnection.Open();

					using (MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection))
					{
						mysqlCommand.ExecuteNonQuery();

						mysqlConnection.Close();

						PrintLog("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return true;
					}
				}
			}
			catch (Exception ex)
			{
				PrintLog($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

				return false;
			}
		}

		// NOTE: I try with pMain.pItemTable = await pMain.QuerySelectAsync(pMain.pSettings.DBCharset, $"SELECT {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;"); and took 300ms more
		/*public async Task<DataTable> QuerySelectAsync(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;

				using (MySqlConnection mysqlConnection = new MySqlConnection(strConnect))
				{
					await mysqlConnection.OpenAsync(); //mysqlConnection.Open();

					using (MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection))
					{
						DataTable pTable = new DataTable();
						pTable.Load(await mysqlCommand.ExecuteReaderAsync());   //pTable.Load(mysqlCommand.ExecuteReader());

						mysqlConnection.Close();

						PrintLog("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return pTable;
					}
				}
			}
			catch (Exception ex)
			{
				PrintLog($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

				return null;
			}
		}

		public async Task<bool> QueryUpdateInsertAsync(string strCharset, string strQuery)
		{
			try
			{
				string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET=" + strCharset;

				using (MySqlConnection mysqlConnection = new MySqlConnection(strConnect))
				{
					await mysqlConnection.OpenAsync();  //mysqlConnection.Open();

					using (MySqlCommand mysqlCommand = new MySqlCommand(strQuery, mysqlConnection))
					{
						await mysqlCommand.ExecuteNonQueryAsync(); //mysqlCommand.ExecuteReader();

						mysqlConnection.Close();

						PrintLog("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return true;
					}
				}
			}
			catch (Exception ex)
			{
				PrintLog($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

				return false;
			}
		}*/

		void ConnectToDatabase()
		{
			try
			{
                ClearGlobalTables();

                string strConnect = $"SERVER={pSettings.DBHost};DATABASE={pSettings.DBData};UID={pSettings.DBUsername};PASSWORD={pSettings.DBPassword};CHARSET={pSettings.DBCharset}";

				mysqlConn = new MySqlConnection(strConnect);

				PrintLog("MySQL > Trying to connect to Database (" + strConnect + ")");

				mysqlConn.Open();

				PrintLog("MySQL > Connected successfully.", Color.Lime);
			}
			catch (Exception ex)
			{
				PrintLog($"MySQL > {ex.Message}", Color.Red);

				DialogResult pDialogReturn = MessageBox.Show($"{ex.Message}\n\nWould you like to retry the connection?", "LastChaos ToolBox", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.Yes)
					ConnectToDatabase();
				else
					Application.Exit();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			int nIters = 100000;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			
			string strConcatenate = "";
			for (int i = 0; i < nIters; i++)
                strConcatenate += i + "\n";

			stopwatch.Stop();
			PrintLog($"String Concatenate Test took: {stopwatch.ElapsedMilliseconds} ms", Color.CornflowerBlue);
			
			stopwatch.Reset();
			stopwatch.Start();
			
			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < nIters; i++)
                strBuilder.Append(i + "\n");

			strBuilder.ToString();

            stopwatch.Stop();
			PrintLog($"String Builder Test took: {stopwatch.ElapsedMilliseconds} ms", Color.CornflowerBlue);

			stopwatch.Reset();
			stopwatch.Start();
			
			List<int> listString = new List<int>();	// allowed duplicity
            for (int i = 0; i < nIters; i++)
                listString.Add(i);

			string.Join("\n", listString);

            stopwatch.Stop();
			PrintLog($"List Add and Join Test took: {stopwatch.ElapsedMilliseconds} ms", Color.CornflowerBlue);

            stopwatch.Reset();
            stopwatch.Start();

            HashSet<int> hashsetString = new HashSet<int>();	// uniqueness
            for (int i = 0; i < nIters; i++)
                hashsetString.Add(i);

            string.Join("\n", hashsetString);

            stopwatch.Stop();
            PrintLog($"HashSet Add and Join Test took: {stopwatch.ElapsedMilliseconds} ms", Color.CornflowerBlue);

            /*
			String Concatenate Test took: 14260 ms
			String Builder Test took: 10 ms
			List Add and Join Test took: 9 ms
			HashSet Add and Join Test took: 12 ms

			String Concatenate Test took: 14109 ms
			String Builder Test took: 9 ms
			List Add and Join Test took: 9 ms
			HashSet Add and Join Test took: 11 ms

			String Concatenate Test took: 14124 ms
			String Builder Test took: 10 ms
			List Add and Join Test took: 9 ms
			HashSet Add and Join Test took: 12 ms
			*/
        }
    }
}

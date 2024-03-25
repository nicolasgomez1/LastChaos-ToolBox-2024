using IniParser;
using IniParser.Model;
using LastChaos_ToolBox_2024.Editors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024
{
	public partial class Main : Form
	{
		private string strWindowsTitle;
		private MySqlConnection mysqlConn;

		// Global Vals
		public Settings pSettings = new Settings();
		
		// { get; set; }
		public DataTable pItemTable = null;
		public DataTable pZoneTable = null;
		public DataTable pSkillTable = null;
		public DataTable pSkillLevelTable = null;
		public DataTable pRareOptionTable = null;
		public DataTable pItemFortuneHeadTable = null;
		public DataTable pItemFortuneDataTable = null;
		public DataTable pStringTable = null;
		public DataTable pOptionTable = null;
		public DataTable pMagicTable = null;
		public DataTable pMagicLevelTable = null;

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
			public string ItemEditorAutoShowFortune = "false";

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

		private void monitor_Tick(object sender, EventArgs e) { this.Text = strWindowsTitle + " (Ram Usage: " + (GC.GetTotalMemory(true) / 1024) + "KB's)"; }

		private void ReloadSettings_Click(object sender, EventArgs e) { LoadSettings(); }

		private void ClearGlobalTables()
		{
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

			if (pItemFortuneHeadTable != null)
			{
				pItemFortuneHeadTable.Dispose();
				pItemFortuneHeadTable = null;
			}

			if (pItemFortuneDataTable != null)
			{
				pItemFortuneDataTable.Dispose();
				pItemFortuneDataTable = null;
			}

			if (pStringTable != null)
			{
				pStringTable.Dispose();
				pStringTable = null;
			}

			if (pOptionTable != null)
			{
				pOptionTable.Dispose();
				pOptionTable = null;
			}

			if (pMagicTable != null)
			{
				pMagicTable.Dispose();
				pMagicTable = null;
			}

			if (pMagicLevelTable != null)
			{
				pMagicLevelTable.Dispose();
				pMagicLevelTable = null;
			}
			/****************************************/
			List<Form> formsToClose = new List<Form>();

			foreach (Form form in Application.OpenForms)
			{
				if (form != this)
					formsToClose.Add(form);
			}

			foreach (Form form in formsToClose)
				form.Close();
		}

		private void Reconnect_Click(object sender, EventArgs e)
		{
			if (mysqlConn.State == ConnectionState.Open)
			{
				Logger("MySQL > Closing existing connection.");

				mysqlConn.Close();
			}

			ConnectToDatabase();
		}

		private void ItemEditor_Click(object sender, EventArgs e)
		{
			ItemEditor pItemEditor = new ItemEditor(this);
			pItemEditor.Show();
		}
		/****************************************/
		private static StreamWriter pStreamWriter = new StreamWriter("Logs.log", true);

		public void Logger(string strMsg, Color? ColorMsg = null)
		{
			StackFrame stackFrame = new StackFrame(1, true);

			StringBuilder strLog = new StringBuilder();
			strLog.Append($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{Path.GetFileName(stackFrame.GetFileName())} : {stackFrame.GetFileLineNumber()} : {stackFrame.GetMethod().Name}] > {strMsg}");

			lock (pStreamWriter) { pStreamWriter.WriteLine(strLog.ToString()); }

			rtbConsole.BeginInvoke((MethodInvoker)delegate
			{
				int nStartPos = rtbConsole.TextLength;
				rtbConsole.AppendText(strLog.ToString() + Environment.NewLine);
				int nEndPos = rtbConsole.TextLength;

				rtbConsole.Select(nStartPos, nEndPos - nStartPos);
				rtbConsole.SelectionColor = ColorMsg ?? Color.FromArgb(208, 203, 148);
				rtbConsole.SelectionLength = 0;

				rtbConsole.ScrollToCaret();
			});
		}
		/****************************************/
		private void LoadSettings()
		{
			Logger("Loading Settings...");

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
				pSettings.ItemEditorAutoShowFortune = pData["Settings"]["ItemEditorAutoLoadFortune"].ToLower();
				/****************************************/
				KeyDataCollection arrayKeys = pData["RenderDialog"];

				foreach (KeyData pKey in arrayKeys)
					pSettings.ShowRenderDialog[pKey.KeyName] = pKey.Value.ToLower();
				/****************************************/
				Logger("Settings load finished.", Color.Lime);
			}
			else
			{
				Logger($"Settings load failed ({pSettings.SettingsFile} not exist).", Color.Red);
			}
		}

		// General Help Functions
		public string EscapeChars(string strInput)
		{
			// Escape \ to \\
			strInput = strInput.Replace("\\", "\\\\");

			// Escape ' to \'
			strInput = strInput.Replace("'", "\\'");

			return strInput;
		}

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
				Logger("Error while trying to get Icon. Path: " + strComposePath, Color.Red);

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

						Logger("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return pTable;
					}
				}
			}
			catch (Exception ex)
			{
				Logger($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

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

						Logger("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Logger($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

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

				Logger("MySQL > Trying to connect to Database (" + strConnect + ")...");

				mysqlConn.Open();

				Logger("MySQL > Connected successfully.", Color.Lime);
			}
			catch (Exception ex)
			{
				Logger($"MySQL > {ex.Message}", Color.Red);

				DialogResult pDialogReturn = MessageBox.Show($"{ex.Message}\n\nWould you like to retry the connection?", "LastChaos ToolBox", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.Yes)
					ConnectToDatabase();
				else
					Application.Exit();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			/*int nIters = 100000;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			string strConcatenate = "";
			for (int i = 0; i < nIters; i++)
				strConcatenate += i + "\n";

			stopwatch.Stop();
			Logger($"String Concatenate Test took: {stopwatch.ElapsedMilliseconds} ms.");

			stopwatch.Reset();
			stopwatch.Start();

			StringBuilder strBuilder = new StringBuilder();
			for (int i = 0; i < nIters; i++)
				strBuilder.Append(i + "\n");

			strBuilder.ToString();

			stopwatch.Stop();
			Logger($"String Builder Test took: {stopwatch.ElapsedMilliseconds} ms.");

			stopwatch.Reset();
			stopwatch.Start();

			List<int> listString = new List<int>(); // allowed duplicity
			for (int i = 0; i < nIters; i++)
				listString.Add(i);

			string.Join("\n", listString);

			stopwatch.Stop();
			Logger($"List Add and Join Test took: {stopwatch.ElapsedMilliseconds} ms.");

			stopwatch.Reset();
			stopwatch.Start();

			HashSet<int> hashsetString = new HashSet<int>();    // uniqueness
			for (int i = 0; i < nIters; i++)
				hashsetString.Add(i);

			string.Join("\n", hashsetString);

			stopwatch.Stop();
			Logger($"HashSet Add and Join Test took: {stopwatch.ElapsedMilliseconds} ms.");

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

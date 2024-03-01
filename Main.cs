using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SlimDX.Direct3D9;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO;
using IniParser;
using IniParser.Model;
using LastChaos_ToolBox_2024.Editors;
using Definitions;

namespace LastChaos_ToolBox_2024
{
	public partial class Main : Form
	{
		// Global Vals
		public Settings pSettings = new Settings();
		public MySqlConnection mysqlConn;
		public DataTable pItemTable = null;
		private string strWindowsTitle;

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
			public string DefaultEditNation = "USA";

			public string ClientPath = "";
			public string[] NationSupported;
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
				PrintLog("Settings file is corrupted or wrong formed.", Color.Red);
				return "";
			}
		}

		public void PrintLog(string strMsg, Color? ColorMsg = null)
		{
			StackFrame stackFrame = new StackFrame(1, true);

			string strLog = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} [{Path.GetFileName(stackFrame.GetFileName())} : {stackFrame.GetFileLineNumber()} : {stackFrame.GetMethod().Name}] > {strMsg}";

			using (StreamWriter pStreamWriter = File.AppendText("Logs.log"))
			{
				pStreamWriter.WriteLine(strLog);
			}

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
			PrintLog("Starting settings load...");

			if (File.Exists(pSettings.SettingsFile))
			{
				FileIniDataParser pParser = new FileIniDataParser();
				IniData pData = pParser.ReadFile(pSettings.SettingsFile);

				// Database Settings
				pSettings.DBHost = pData["Database"]["Host"];
				pSettings.DBUsername = pData["Database"]["Username"];
				pSettings.DBPassword = pData["Database"]["Password"];
				pSettings.DBAuth = pData["Database"]["Auth"];
				pSettings.DBData = pData["Database"]["Data"];
				pSettings.DBUser = pData["Database"]["User"];
				pSettings.DBCharset = pData["Database"]["Charset"];
				pSettings.DefaultEditNation = pData["Database"]["Main_Lang"].ToLower();

				// General Settings
				pSettings.ClientPath = pData["General"]["ClientPath"];

				string[] strArrayNations = pData["General"]["NationSupported"].Split(',');

				pSettings.NationSupported = new string[strArrayNations.Length];

				for (int i = 0; i < strArrayNations.Length; i++)
					pSettings.NationSupported[i] = strArrayNations[i];

				PrintLog("Settings load finished.", Color.Lime);
			}
			else
			{
				PrintLog($"{pSettings.SettingsFile} not exist.", Color.Red);
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
					// NOTE: Create new Bitmap
					Bitmap pBitmap = new Bitmap(32, 32);
					// NOTE: Generate Bitmap content
					using (Graphics pGraphics = Graphics.FromImage((Image)pBitmap))
					{
						pGraphics.DrawImage(pImage, 0, 0, (new Rectangle(nCol * 32, nRow * 32, 32, 32)), GraphicsUnit.Pixel);
					}

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
						mysqlCommand.ExecuteReader();

						mysqlConnection.Close();

						PrintLog("MySql Query (Charset: " + strCharset + ")\n" + strQuery + "\nExecute successfully.", Color.Lime);

						return true;
					}
				}
			}
			catch(Exception ex)
			{
				PrintLog($"MySql Query (Charset: {strCharset})\n{strQuery}\nFail > {ex.Message}", Color.Red);

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

				PrintLog("MySQL > Connected successfully.", Color.Lime);
			}
			catch (Exception ex)
			{
				PrintLog($"MySQL > {ex.Message}", Color.Red);

				DialogResult pDialogReturn = MessageBox.Show($"{ex.Message}\n\nWould you like to retry the connection?", "MySQL > It was not possible to connect to your Database Server.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

				if (pDialogReturn == DialogResult.Yes)
					ConnectToDatabase();
				else
					Application.Exit();
			}
		}
	}
}

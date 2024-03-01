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

namespace LastChaos_ToolBox_2024
{
	public partial class Main : Form
	{
		// Global Vals
		public Settings pSettings = new Settings();
		public MySqlConnection mysqlConn;
		public DataTable pItemTable = null;
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
			this.Text = pAssembly.GetName().Name + " Build: " + pAssembly.GetName().Version.Revision;
		}

		private void Main_Load(object sender, EventArgs e)
		{
			LoadSettings();
			ConnectToDatabase();
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

        void LoadSettings()
		{
			PrintLog("Starting settings load...");

			if (File.Exists(pSettings.SettingsFile))
			{
#if true
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
#else
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

                pSettings.ClientPath = GetValueFromLine(strArray[8]);
#endif
                PrintLog("Settings load finished.");
			}
			else
			{
				PrintLog($"{pSettings.SettingsFile} not exist.");
			}
		}

        // General Help Functions
        public Bitmap GetIcon(string BtnType, string nImage, int nRow, int nCol)
        {
			string strComposePath = BtnType + "/" + BtnType + nImage + ".png";

			if (File.Exists(strComposePath))
			{
				// NOTE: Load png to memory
				Image pImage = Image.FromFile(strComposePath);
				// NOTE: Create new Bitmap
				Bitmap pBitmap = new Bitmap(32, 32);
				// NOTE: Generate Bitmap content
				Graphics pGraphics = Graphics.FromImage((Image)pBitmap);
				pGraphics.DrawImage(pImage, 0, 0, (new Rectangle(nCol * 32, nRow * 32, 32, 32)), GraphicsUnit.Pixel);
				// NOTE: Free it
				pGraphics.Dispose();

				return pBitmap;
			}
			else
			{
				PrintLog("Error while trying to get Icon. Path: " + strComposePath);

                return null;
            }
        }

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

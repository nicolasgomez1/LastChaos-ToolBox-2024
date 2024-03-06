# LastChaos ToolBox <img align="left" src="https://user-images.githubusercontent.com/5092697/138568453-9cbbedb8-7889-4a9d-ac72-5d2dae9bae9f.png" width="100px">

<br/>
<br/>

It provides the basics for creating tools to manage Databases and perhaps files related to LastChaos.

In Item Editor there are notes and examples on how to manage the request, storage and management of data.


# Concept of Global Tables
* The idea behind the project is to have a fast and efficient tool in terms of requests to the database. With that in mind I designed a scheme in which there are __Global Tables__, these are populated for the first time by the Tool that requires the information, and later said information can be used by another tool, Avoiding constants requests each time some Tool open.

* When a Tool populates a __Global Table__, it is not necessarily populated with all the information available in the Database, but rather the system is designed so that different tools request only the columns necessary for the operation of said Tool. Being able to load different columns by different Tools without the information overlapping or replacing.

* Finally, when in a Tool the operator decides to apply changes made, an attempt is made to execute a Query either type UPDATE or INSERT, in case of success, said changes are updated in the __Global Tables__.

# Hardcoded definitions and information
* This information is stored in [Definitions.cs](Definitions.cs)

# Help Dialogs
* Pickers
1) [Flag Picker Implementation Example](Pickers/FlagPicker.cs)
2) [Icon Picker Implementation Example](Pickers/IconPicker.cs)
3) [Skill Picker Implementation Example](Pickers/SkillPicker.cs)
4) [Item Picker Implementation Example](Pickers/ItemPicker.cs)
5) [Rare Option Picker Implementation Example](Pickers/RareOptionPicker.cs)


- NOTE: Picker Dialogs are intended to complement larger Tools, however, they have the ability to request information autonomously. This means that you can make the decision to load, for example, t_skill names to be able to display them in your Tool, which will increase loading times. On the other hand, you could not request this information and work only with IDS, but when invoking the Skill Picker Dialog, it will request data such as the name and description of the skills automatically if necessary.

* Others
1) [Progress Dialog Implementation Example](ProgressDialog.cs)


# Practical examples
* Example of requesting and storing t_item data in the __Global Table__: pItemTable. To later store information in a temporary variable to work with, to finally pass that temporary data to the __Global Table__.

```c#
// This function will be executed asynchronously when opening the Item Editor Tool
private async void ItemEditor_LoadAsync(object sender, EventArgs e)
{
	// In my case I decided for readability reasons to separate the functions that request and store information in the __Global Tables__ into 3 different asynchronous functions. Taking this into account, I decided to use: <a href="hhttps://learn.microsoft.com/es-es/dotnet/api/system.threading.tasks.task.whenall?view=net-8.0">await Task.WhenAll</a>. But to simplify the explanation, I will do it with a single asynchronous function.
	await LoadItemDataAsync();

	// Once we have the necessary information stored in the Global Table, we can proceed to create a temporary Row based on the structure and data of the Global Table, but outside of it.
	if (pMain.pItemTable != null)
	{
		// We can declare a private variable for our Tool using: private DataRow pTempRow; if necessary

		// Using: NewRow() we can replicate the structure of the Global Table in a single row.
		pTempRow = pMain.pItemTable.NewRow();

		// Finally we can clone the content of a desired row to our temporary variable. To later be able to work with said variable and its content temporarily, without adulterating the content of the Global Table.
		pTempRow.ItemArray = (object[])pMain.pItemTable.Select("a_index = 19")[0].ItemArray.Clone();

		/*------------------------------------------------------------------*/

		// Eventually we can get information from our temporary variable by doing the following.
		string strGetItemEnable = pTempRow["a_enable"].ToString();

		/*------------------------------------------------------------------*/

		// By deduction we can alter the content of temporary variable by doing:
		pTempRow["a_enable"] = "0";

		/*------------------------------------------------------------------*/

		// To transfer all the data from our temporary variable to the Global Table we can do the following...

		// We obtain the reference to the desired row to alter.
		DataRow pItemTableRow = pMain.pItemTable.Select("a_index = 19").FirstOrDefault();
		if (pItemTableRow != null)	// We verify that said row exists.
		{
			//In case of original structure of the Global Table is not altered we can do: pItemTableRow.ItemArray = pTempRow.ItemArray;

			//In case of original structure of the Global Table is altered we can do the following...
			
			foreach (DataColumn column in pTempRow.Table.Columns)	// We can iterate through all the columns of the temporary variable.
			{
				if (!pMain.pItemTable.Columns.Contains(column.ColumnName))	// In case any of the columns do not exist in the Global Table.
					pMain.pItemTable.Columns.Add(column.ColumnName, column.DataType);	// We add it. Keep in mind, this adds the column only for a single row, the rest will not have that new column.

				pItemTableRow[column.ColumnName] = pTempRow[column.ColumnName];	// Finally we write the values of all the columns of the Global Table with the data of the temporary variable.
			}
		}
	}
}

private async Task LoadItemDataAsync()
{
	bool bRequestNeeded = false;

	// Here you must define the columns that you want to request from the Database.
	HashSet<string> listQueryCompose = new HashSet<string> { "a_enable", "a_texture_id", "a_texture_row", "a_texture_col" };

	// If columns related to locale are required, they must be defined here.
	for (int i = 0; i < pMain.pSettings.NationSupported.Length; i++)
	{
		string strNation = pMain.pSettings.NationSupported[i].ToLower();

		listQueryCompose.Add("a_name_" + strNation);
		listQueryCompose.Add("a_descr_" + strNation);
	}

	if (pMain.pItemTable == null)	// If the global table is empty, directly indicate that a Query must be executed requesting all previously defined columns
	{
		bRequestNeeded = true;
	}
	else	// If the Global Table is not empty, check if any of the columns to request are already present. To remove it from the Query and not request redundant information.
	{
		foreach (var column in listQueryCompose.ToList())
		{
			if (!pMain.pItemTable.Columns.Contains(column))
				bRequestNeeded = true;
			else
				listQueryCompose.Remove(column);
		}
	}

	if (bRequestNeeded)
	{
		pMain.pItemTable = await Task.Run(() =>
		{
			// As you can see, regardless of the columns to request, it is always necessary to request the reference column, in this case a_index. Because this column will be used for the storage/overwriting process of the Global Table.
			return pMain.QuerySelect(pMain.pSettings.DBCharset, $"SELECT a_index, {string.Join(",", listQueryCompose)} FROM {pMain.pSettings.DBData}.t_item ORDER BY a_index;");
		});
	}
}
```
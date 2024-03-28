namespace LastChaos_ToolBox_2024
{
	partial class GenericTypePicker
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.MainList = new System.Windows.Forms.ListBox();
			this.btnRemoveType = new System.Windows.Forms.Button();
			this.cbTypesListSelector = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// tbSearch
			// 
			this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSearch.Location = new System.Drawing.Point(12, 39);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(250, 20);
			this.tbSearch.TabIndex = 1026;
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
			// 
			// MainList
			// 
			this.MainList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.MainList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.MainList.FormattingEnabled = true;
			this.MainList.Location = new System.Drawing.Point(12, 70);
			this.MainList.Name = "MainList";
			this.MainList.Size = new System.Drawing.Size(250, 379);
			this.MainList.TabIndex = 1027;
			this.MainList.DoubleClick += new System.EventHandler(MainList_DoubleClick);
			// 
			// btnRemoveType
			// 
			this.btnRemoveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveType.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRemoveType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRemoveType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRemoveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRemoveType.Location = new System.Drawing.Point(12, 465);
			this.btnRemoveType.Name = "btnRemoveType";
			this.btnRemoveType.Size = new System.Drawing.Size(250, 23);
			this.btnRemoveType.TabIndex = 1028;
			this.btnRemoveType.Text = "Remove Type";
			this.btnRemoveType.UseVisualStyleBackColor = true;
			this.btnRemoveType.Click += new System.EventHandler(this.btnRemoveZone_Click);
			// 
			// cbTypesListSelector
			// 
			this.cbTypesListSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbTypesListSelector.BackColor = System.Drawing.Color.White;
			this.cbTypesListSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypesListSelector.ForeColor = System.Drawing.Color.Black;
			this.cbTypesListSelector.FormattingEnabled = true;
			this.cbTypesListSelector.Location = new System.Drawing.Point(12, 12);
			this.cbTypesListSelector.Name = "cbTypesListSelector";
			this.cbTypesListSelector.Size = new System.Drawing.Size(250, 21);
			this.cbTypesListSelector.TabIndex = 1029;
			this.cbTypesListSelector.SelectedIndexChanged += new System.EventHandler(this.cbTypesListSelector_SelectedIndexChanged);
			// 
			// GenericTypePicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(274, 500);
			this.Controls.Add(this.cbTypesListSelector);
			this.Controls.Add(this.btnRemoveType);
			this.Controls.Add(this.MainList);
			this.Controls.Add(this.tbSearch);
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MinimizeBox = false;
			this.Name = "GenericTypePicker";
			this.ShowInTaskbar = false;
			this.Text = "Generic Type Picker";
			this.Load += new System.EventHandler(this.GenericTypePicker_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.ListBox MainList;
		private System.Windows.Forms.Button btnRemoveType;
		private System.Windows.Forms.ComboBox cbTypesListSelector;
	}
}
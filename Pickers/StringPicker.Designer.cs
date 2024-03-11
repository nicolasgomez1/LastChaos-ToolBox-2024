namespace LastChaos_ToolBox_2024
{
	partial class StringPicker
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
			this.btnRemoveString = new System.Windows.Forms.Button();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.MainList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnRemoveString
			// 
			this.btnRemoveString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveString.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRemoveString.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRemoveString.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRemoveString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRemoveString.Location = new System.Drawing.Point(12, 465);
			this.btnRemoveString.Name = "btnRemoveString";
			this.btnRemoveString.Size = new System.Drawing.Size(359, 23);
			this.btnRemoveString.TabIndex = 1014;
			this.btnRemoveString.Text = "Remove String";
			this.btnRemoveString.UseVisualStyleBackColor = true;
			this.btnRemoveString.Click += new System.EventHandler(this.btnRemoveString_Click);
			// 
			// tbSearch
			// 
			this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSearch.Location = new System.Drawing.Point(12, 12);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(359, 20);
			this.tbSearch.TabIndex = 1026;
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
			this.MainList.Location = new System.Drawing.Point(12, 44);
			this.MainList.Name = "MainList";
			this.MainList.Size = new System.Drawing.Size(359, 405);
			this.MainList.TabIndex = 1027;
			this.MainList.SelectedIndexChanged += new System.EventHandler(this.MainList_SelectedIndexChanged);
			// 
			// StringPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(384, 500);
			this.Controls.Add(this.MainList);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.btnRemoveString);
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MinimizeBox = false;
			this.Name = "StringPicker";
			this.ShowInTaskbar = false;
			this.Text = "String Picker";
			this.Load += new System.EventHandler(this.StringPicker_LoadAsync);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ComboBox cbFileSelector;
		private System.Windows.Forms.PictureBox pbImageViewer;
		private System.Windows.Forms.Label lbLocation;
		private System.Windows.Forms.Button btnRemoveString;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.ListBox MainList;
	}
}
namespace LastChaos_ToolBox_2024
{
	partial class ZonePicker
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
			this.SuspendLayout();
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
			this.tbSearch.Size = new System.Drawing.Size(210, 20);
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
			this.MainList.Location = new System.Drawing.Point(12, 44);
			this.MainList.Name = "MainList";
			this.MainList.Size = new System.Drawing.Size(210, 444);
			this.MainList.TabIndex = 1027;
			this.MainList.SelectedIndexChanged += new System.EventHandler(this.MainList_SelectedIndexChanged);
			// 
			// ZonePicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(234, 500);
			this.Controls.Add(this.MainList);
			this.Controls.Add(this.tbSearch);
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MinimizeBox = false;
			this.Name = "ZonePicker";
			this.ShowInTaskbar = false;
			this.Text = "Zone Picker";
			this.Load += new System.EventHandler(this.ZonePicker_LoadAsync);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ComboBox cbFileSelector;
		private System.Windows.Forms.PictureBox pbImageViewer;
		private System.Windows.Forms.Label lbLocation;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.ListBox MainList;
	}
}
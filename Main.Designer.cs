using LastChaos_ToolBox_2024.Properties;

namespace LastChaos_ToolBox_2024
{
    partial class Main
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
			this.components = new System.ComponentModel.Container();
			this.btnItemEditor = new System.Windows.Forms.Button();
			this.btnReconnect = new System.Windows.Forms.Button();
			this.btnReloadSettings = new System.Windows.Forms.Button();
			this.Monitor = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rtbConsole = new System.Windows.Forms.RichTextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.btnCheckUpdates = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnItemEditor
			// 
			this.btnItemEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItemEditor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItemEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItemEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItemEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItemEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItemEditor.Location = new System.Drawing.Point(6, 19);
			this.btnItemEditor.Name = "btnItemEditor";
			this.btnItemEditor.Size = new System.Drawing.Size(100, 23);
			this.btnItemEditor.TabIndex = 0;
			this.btnItemEditor.Text = "Item Editor";
			this.btnItemEditor.UseVisualStyleBackColor = false;
			this.btnItemEditor.Click += new System.EventHandler(this.btnItemEditor_Click);
			// 
			// btnReconnect
			// 
			this.btnReconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnReconnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnReconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnReconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnReconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnReconnect.Location = new System.Drawing.Point(118, 12);
			this.btnReconnect.Name = "btnReconnect";
			this.btnReconnect.Size = new System.Drawing.Size(100, 23);
			this.btnReconnect.TabIndex = 1;
			this.btnReconnect.Text = "Reconnect";
			this.btnReconnect.UseVisualStyleBackColor = false;
			this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
			// 
			// btnReloadSettings
			// 
			this.btnReloadSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnReloadSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnReloadSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnReloadSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnReloadSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnReloadSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnReloadSettings.Location = new System.Drawing.Point(12, 12);
			this.btnReloadSettings.Name = "btnReloadSettings";
			this.btnReloadSettings.Size = new System.Drawing.Size(100, 23);
			this.btnReloadSettings.TabIndex = 2;
			this.btnReloadSettings.Text = "Reload Settings";
			this.btnReloadSettings.UseVisualStyleBackColor = false;
			this.btnReloadSettings.Click += new System.EventHandler(this.btnReloadSettings_Click);
			// 
			// Monitor
			// 
			this.Monitor.Interval = 1000;
			this.Monitor.Tick += new System.EventHandler(this.monitor_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnItemEditor);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.groupBox1.Location = new System.Drawing.Point(12, 41);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(674, 244);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tools";
			// 
			// rtbConsole
			// 
			this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.rtbConsole.Location = new System.Drawing.Point(12, 291);
			this.rtbConsole.Name = "rtbConsole";
			this.rtbConsole.ReadOnly = true;
			this.rtbConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.rtbConsole.Size = new System.Drawing.Size(674, 119);
			this.rtbConsole.TabIndex = 4;
			this.rtbConsole.Text = "";
			this.rtbConsole.ZoomFactor = 1.2F;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.button4.Location = new System.Drawing.Point(586, 12);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(100, 23);
			this.button4.TabIndex = 1;
			this.button4.Text = "DEV TEST";
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// btnCheckUpdates
			// 
			this.btnCheckUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnCheckUpdates.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnCheckUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnCheckUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnCheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCheckUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnCheckUpdates.Location = new System.Drawing.Point(224, 12);
			this.btnCheckUpdates.Name = "btnCheckUpdates";
			this.btnCheckUpdates.Size = new System.Drawing.Size(110, 23);
			this.btnCheckUpdates.TabIndex = 5;
			this.btnCheckUpdates.Text = "Check for Updates";
			this.btnCheckUpdates.UseVisualStyleBackColor = false;
			this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_ClickAsync);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(698, 422);
			this.Controls.Add(this.btnCheckUpdates);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.rtbConsole);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnReloadSettings);
			this.Controls.Add(this.btnReconnect);
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.Name = "Main";
			this.Text = "LastChaos ToolBox 2024";
			this.Load += new System.EventHandler(this.Main_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button btnItemEditor;
        private System.Windows.Forms.Button btnReconnect;
        private System.Windows.Forms.Button btnReloadSettings;
        private System.Windows.Forms.Timer Monitor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnCheckUpdates;
	}
}


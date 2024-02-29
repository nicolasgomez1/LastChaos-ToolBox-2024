namespace LastChaos_ToolBox_2024
{
    partial class IconPicker
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbFileSelector = new System.Windows.Forms.ComboBox();
            this.pbImageViewer = new System.Windows.Forms.PictureBox();
            this.lbLocation = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageViewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnSelect.Location = new System.Drawing.Point(282, 11);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(60, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbFileSelector
            // 
            this.cbFileSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbFileSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbFileSelector.FormattingEnabled = true;
            this.cbFileSelector.Location = new System.Drawing.Point(12, 12);
            this.cbFileSelector.Name = "cbFileSelector";
            this.cbFileSelector.Size = new System.Drawing.Size(121, 21);
            this.cbFileSelector.TabIndex = 7;
            this.cbFileSelector.SelectedIndexChanged += new System.EventHandler(this.cbFileSelector_SelectedIndexChanged);
            // 
            // pbImageViewer
            // 
            this.pbImageViewer.Location = new System.Drawing.Point(12, 43);
            this.pbImageViewer.Name = "pbImageViewer";
            this.pbImageViewer.Size = new System.Drawing.Size(512, 512);
            this.pbImageViewer.TabIndex = 8;
            this.pbImageViewer.TabStop = false;
            this.pbImageViewer.Click += new System.EventHandler(this.pbImageViewer_Click);
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.lbLocation.Location = new System.Drawing.Point(453, 16);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(71, 13);
            this.lbLocation.TabIndex = 10;
            this.lbLocation.Text = "Row: 0 Col: 0";
            this.lbLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = global::LastChaos_ToolBox_2024.Properties.Resources.DefaultIcon;
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = null;
            this.pbIcon.Location = new System.Drawing.Point(244, 6);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.TabIndex = 14;
            this.pbIcon.TabStop = false;
            // 
            // IconPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(536, 567);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.pbImageViewer);
            this.Controls.Add(this.cbFileSelector);
            this.Controls.Add(this.btnSelect);
            this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IconPicker";
            this.Text = "Icon Picker";
            this.Load += new System.EventHandler(this.IconPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageViewer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbFileSelector;
        private System.Windows.Forms.PictureBox pbImageViewer;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}
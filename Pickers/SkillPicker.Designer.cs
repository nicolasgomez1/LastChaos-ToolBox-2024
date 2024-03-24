namespace LastChaos_ToolBox_2024
{
    partial class SkillPicker
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
			this.btnRemoveSkill = new System.Windows.Forms.Button();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.MainList = new System.Windows.Forms.ListBox();
			this.btnSelect = new System.Windows.Forms.Button();
			this.cbLevelSelector = new System.Windows.Forms.ComboBox();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbDescription = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRemoveSkill
			// 
			this.btnRemoveSkill.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRemoveSkill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRemoveSkill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRemoveSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveSkill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRemoveSkill.Location = new System.Drawing.Point(298, 270);
			this.btnRemoveSkill.Name = "btnRemoveSkill";
			this.btnRemoveSkill.Size = new System.Drawing.Size(224, 23);
			this.btnRemoveSkill.TabIndex = 1014;
			this.btnRemoveSkill.Text = "Remove Skill";
			this.btnRemoveSkill.UseVisualStyleBackColor = true;
			this.btnRemoveSkill.Click += new System.EventHandler(this.btnRemoveSkill_Click);
			// 
			// tbSearch
			// 
			this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSearch.Location = new System.Drawing.Point(12, 12);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(280, 20);
			this.tbSearch.TabIndex = 1026;
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
			// 
			// MainList
			// 
			this.MainList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.MainList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.MainList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MainList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.MainList.FormattingEnabled = true;
			this.MainList.Location = new System.Drawing.Point(12, 44);
			this.MainList.Name = "MainList";
			this.MainList.Size = new System.Drawing.Size(280, 249);
			this.MainList.TabIndex = 1027;
			this.MainList.SelectedIndexChanged += new System.EventHandler(this.MainList_SelectedIndexChanged);
			// 
			// btnSelect
			// 
			this.btnSelect.Enabled = false;
			this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSelect.Location = new System.Drawing.Point(6, 223);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(212, 23);
			this.btnSelect.TabIndex = 1028;
			this.btnSelect.Text = "Select Skill && Level";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// cbLevelSelector
			// 
			this.cbLevelSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbLevelSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLevelSelector.Enabled = false;
			this.cbLevelSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbLevelSelector.FormattingEnabled = true;
			this.cbLevelSelector.Location = new System.Drawing.Point(6, 196);
			this.cbLevelSelector.Name = "cbLevelSelector";
			this.cbLevelSelector.Size = new System.Drawing.Size(212, 21);
			this.cbLevelSelector.TabIndex = 1029;
			// 
			// pbIcon
			// 
			this.pbIcon.BackgroundImage = global::LastChaos_ToolBox_2024.Properties.Resources.DefaultIcon;
			this.pbIcon.ErrorImage = null;
			this.pbIcon.InitialImage = null;
			this.pbIcon.Location = new System.Drawing.Point(6, 19);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(32, 32);
			this.pbIcon.TabIndex = 13;
			this.pbIcon.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbDescription);
			this.groupBox1.Controls.Add(this.pbIcon);
			this.groupBox1.Controls.Add(this.btnSelect);
			this.groupBox1.Controls.Add(this.cbLevelSelector);
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.groupBox1.Location = new System.Drawing.Point(298, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 252);
			this.groupBox1.TabIndex = 1030;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Skill Data";
			// 
			// tbDescription
			// 
			this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbDescription.Location = new System.Drawing.Point(6, 57);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.ReadOnly = true;
			this.tbDescription.Size = new System.Drawing.Size(212, 133);
			this.tbDescription.TabIndex = 1030;
			// 
			// SkillPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(534, 305);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.MainList);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.btnRemoveSkill);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SkillPicker";
			this.ShowInTaskbar = false;
			this.Text = "Skill Picker";
			this.Load += new System.EventHandler(this.SkillPicker_LoadAsync);
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnRemoveSkill;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox MainList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbLevelSelector;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDescription;
    }
}
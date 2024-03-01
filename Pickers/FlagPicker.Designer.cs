namespace LastChaos_ToolBox_2024
{
    partial class FlagPicker
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
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            this.clbFlagList = new System.Windows.Forms.CheckedListBox();
            this.tbFlag = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Enabled = false;
            this.btnUnCheckAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnUnCheckAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUnCheckAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnUnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnCheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnUnCheckAll.Location = new System.Drawing.Point(12, 12);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(206, 23);
            this.btnUnCheckAll.TabIndex = 9;
            this.btnUnCheckAll.Text = "UnCheck All";
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // clbFlagList
            // 
            this.clbFlagList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.clbFlagList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbFlagList.CheckOnClick = true;
            this.clbFlagList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.clbFlagList.FormattingEnabled = true;
            this.clbFlagList.Location = new System.Drawing.Point(12, 41);
            this.clbFlagList.Name = "clbFlagList";
            this.clbFlagList.Size = new System.Drawing.Size(206, 407);
            this.clbFlagList.TabIndex = 11;
            this.clbFlagList.SelectedIndexChanged += new System.EventHandler(this.clbFlagList_SelectedIndexChanged);
            // 
            // tbFlag
            // 
            this.tbFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbFlag.Location = new System.Drawing.Point(45, 466);
            this.tbFlag.Name = "tbFlag";
            this.tbFlag.ReadOnly = true;
            this.tbFlag.Size = new System.Drawing.Size(117, 20);
            this.tbFlag.TabIndex = 1012;
            this.tbFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label10.Location = new System.Drawing.Point(12, 470);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 1013;
            this.label10.Text = "Flag";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.button1.Location = new System.Drawing.Point(168, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 1014;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FlagPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(230, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbFlag);
            this.Controls.Add(this.clbFlagList);
            this.Controls.Add(this.btnUnCheckAll);
            this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlagPicker";
            this.Text = "Flag Picker";
            this.Load += new System.EventHandler(this.FlagPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbFileSelector;
        private System.Windows.Forms.PictureBox pbImageViewer;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Button btnUnCheckAll;
        private System.Windows.Forms.CheckedListBox clbFlagList;
        private System.Windows.Forms.TextBox tbFlag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}
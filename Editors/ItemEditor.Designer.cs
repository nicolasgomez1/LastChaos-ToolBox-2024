using System.Drawing;
using System.Windows.Forms;

namespace LastChaos_ToolBox_2024.Editors
{
    partial class ItemEditor
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
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.MainList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.GeneralPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnSkill1RequiredID = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.tbSkill1RequiredLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSkill2RequiredID = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.tbSkill2RequiredLevel = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tbGrade = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbEffectDamage = new System.Windows.Forms.TextBox();
            this.tbEffectAttack = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbEffectNormal = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbRvRGradeSelector = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbRvRValueSelector = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tbSet4 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tbSet3 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tbSet2 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbSet1 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbSet0 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbOption0 = new System.Windows.Forms.TextBox();
            this.tbOption4 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tbOption1 = new System.Windows.Forms.TextBox();
            this.tbOption3 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.tbOption2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbVariation6 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbVariation5 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbVariation4 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tbVariation3 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbVariation2 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbVariation1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnItemFlag = new System.Windows.Forms.Button();
            this.lAllowedZone = new System.Windows.Forms.Label();
            this.btnAllowedZoneFlag = new System.Windows.Forms.Button();
            this.cbCastleType = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClassFlag = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.tbMaxUse = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbFame = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDurability = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbMaxLevel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbMinLevel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbMaxStack = new System.Windows.Forms.TextBox();
            this.cbWearingPositionSelector = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSubTypeSelector = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTypeSelector = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSMC = new System.Windows.Forms.TextBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbNationSelector = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.tbAllowedZoneFlag = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.GeneralPanel.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Enabled = false;
            this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnReload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnReload.Location = new System.Drawing.Point(12, 565);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 23);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNew.Enabled = false;
            this.btnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnAddNew.Location = new System.Drawing.Point(78, 565);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(60, 23);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // MainList
            // 
            this.MainList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MainList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.MainList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.MainList.FormattingEnabled = true;
            this.MainList.Location = new System.Drawing.Point(12, 38);
            this.MainList.Name = "MainList";
            this.MainList.Size = new System.Drawing.Size(258, 522);
            this.MainList.TabIndex = 0;
            this.MainList.SelectedIndexChanged += new System.EventHandler(this.MainList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox1.Location = new System.Drawing.Point(276, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Data";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnUpdate.Location = new System.Drawing.Point(6, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(1043, 23);
            this.btnUpdate.TabIndex = 999;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // GeneralPanel
            // 
            this.GeneralPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GeneralPanel.AutoScroll = true;
            this.GeneralPanel.Controls.Add(this.tbAllowedZoneFlag);
            this.GeneralPanel.Controls.Add(this.label8);
            this.GeneralPanel.Controls.Add(this.groupBox9);
            this.GeneralPanel.Controls.Add(this.tbGrade);
            this.GeneralPanel.Controls.Add(this.groupBox5);
            this.GeneralPanel.Controls.Add(this.groupBox4);
            this.GeneralPanel.Controls.Add(this.groupBox8);
            this.GeneralPanel.Controls.Add(this.groupBox7);
            this.GeneralPanel.Controls.Add(this.groupBox6);
            this.GeneralPanel.Controls.Add(this.label25);
            this.GeneralPanel.Controls.Add(this.btnItemFlag);
            this.GeneralPanel.Controls.Add(this.lAllowedZone);
            this.GeneralPanel.Controls.Add(this.btnAllowedZoneFlag);
            this.GeneralPanel.Controls.Add(this.cbCastleType);
            this.GeneralPanel.Controls.Add(this.label23);
            this.GeneralPanel.Controls.Add(this.label22);
            this.GeneralPanel.Controls.Add(this.btnClassFlag);
            this.GeneralPanel.Controls.Add(this.label16);
            this.GeneralPanel.Controls.Add(this.tbMaxUse);
            this.GeneralPanel.Controls.Add(this.label15);
            this.GeneralPanel.Controls.Add(this.tbFame);
            this.GeneralPanel.Controls.Add(this.label14);
            this.GeneralPanel.Controls.Add(this.tbDurability);
            this.GeneralPanel.Controls.Add(this.label13);
            this.GeneralPanel.Controls.Add(this.tbMaxLevel);
            this.GeneralPanel.Controls.Add(this.label12);
            this.GeneralPanel.Controls.Add(this.tbMinLevel);
            this.GeneralPanel.Controls.Add(this.label11);
            this.GeneralPanel.Controls.Add(this.tbPrice);
            this.GeneralPanel.Controls.Add(this.label10);
            this.GeneralPanel.Controls.Add(this.tbMaxStack);
            this.GeneralPanel.Controls.Add(this.cbWearingPositionSelector);
            this.GeneralPanel.Controls.Add(this.label7);
            this.GeneralPanel.Controls.Add(this.cbSubTypeSelector);
            this.GeneralPanel.Controls.Add(this.label6);
            this.GeneralPanel.Controls.Add(this.cbTypeSelector);
            this.GeneralPanel.Controls.Add(this.label5);
            this.GeneralPanel.Controls.Add(this.label4);
            this.GeneralPanel.Controls.Add(this.tbSMC);
            this.GeneralPanel.Controls.Add(this.pbIcon);
            this.GeneralPanel.Controls.Add(this.cbEnable);
            this.GeneralPanel.Controls.Add(this.label1);
            this.GeneralPanel.Controls.Add(this.tbID);
            this.GeneralPanel.Controls.Add(this.groupBox2);
            this.GeneralPanel.Location = new System.Drawing.Point(282, 54);
            this.GeneralPanel.Name = "GeneralPanel";
            this.GeneralPanel.Size = new System.Drawing.Size(1043, 528);
            this.GeneralPanel.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label8.Location = new System.Drawing.Point(456, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 1036;
            this.label8.Text = "Grade";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnSkill1RequiredID);
            this.groupBox9.Controls.Add(this.label42);
            this.groupBox9.Controls.Add(this.tbSkill1RequiredLevel);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.btnSkill2RequiredID);
            this.groupBox9.Controls.Add(this.label43);
            this.groupBox9.Controls.Add(this.tbSkill2RequiredLevel);
            this.groupBox9.Controls.Add(this.label44);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox9.Location = new System.Drawing.Point(0, 192);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(734, 225);
            this.groupBox9.TabIndex = 1035;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Crafting Data";
            // 
            // btnSkill1RequiredID
            // 
            this.btnSkill1RequiredID.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnSkill1RequiredID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSkill1RequiredID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnSkill1RequiredID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkill1RequiredID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnSkill1RequiredID.Location = new System.Drawing.Point(84, 19);
            this.btnSkill1RequiredID.Name = "btnSkill1RequiredID";
            this.btnSkill1RequiredID.Size = new System.Drawing.Size(135, 23);
            this.btnSkill1RequiredID.TabIndex = 1038;
            this.btnSkill1RequiredID.UseVisualStyleBackColor = true;
            this.btnSkill1RequiredID.Click += new System.EventHandler(this.btnSkill1RequiredID_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label42.Location = new System.Drawing.Point(225, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(55, 13);
            this.label42.TabIndex = 1040;
            this.label42.Text = "Skill Level";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSkill1RequiredLevel
            // 
            this.tbSkill1RequiredLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSkill1RequiredLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSkill1RequiredLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSkill1RequiredLevel.Location = new System.Drawing.Point(286, 20);
            this.tbSkill1RequiredLevel.Name = "tbSkill1RequiredLevel";
            this.tbSkill1RequiredLevel.Size = new System.Drawing.Size(40, 20);
            this.tbSkill1RequiredLevel.TabIndex = 1041;
            this.tbSkill1RequiredLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSkill1RequiredLevel.TextChanged += new System.EventHandler(this.tbSkill1RequiredLevel_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label9.Location = new System.Drawing.Point(6, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1038;
            this.label9.Text = "Skill Required";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSkill2RequiredID
            // 
            this.btnSkill2RequiredID.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnSkill2RequiredID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSkill2RequiredID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnSkill2RequiredID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkill2RequiredID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnSkill2RequiredID.Location = new System.Drawing.Point(185, -8);
            this.btnSkill2RequiredID.Name = "btnSkill2RequiredID";
            this.btnSkill2RequiredID.Size = new System.Drawing.Size(37, 23);
            this.btnSkill2RequiredID.TabIndex = 1046;
            this.btnSkill2RequiredID.UseVisualStyleBackColor = true;
            this.btnSkill2RequiredID.Visible = false;
            this.btnSkill2RequiredID.Click += new System.EventHandler(this.btnSkill2RequiredID_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label43.Location = new System.Drawing.Point(228, -3);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(55, 13);
            this.label43.TabIndex = 1044;
            this.label43.Text = "Skill Level";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label43.Visible = false;
            // 
            // tbSkill2RequiredLevel
            // 
            this.tbSkill2RequiredLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSkill2RequiredLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSkill2RequiredLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSkill2RequiredLevel.Location = new System.Drawing.Point(289, -7);
            this.tbSkill2RequiredLevel.Name = "tbSkill2RequiredLevel";
            this.tbSkill2RequiredLevel.Size = new System.Drawing.Size(40, 20);
            this.tbSkill2RequiredLevel.TabIndex = 1045;
            this.tbSkill2RequiredLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSkill2RequiredLevel.Visible = false;
            this.tbSkill2RequiredLevel.TextChanged += new System.EventHandler(this.tbSkill2RequiredLevel_TextChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label44.Location = new System.Drawing.Point(98, -3);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(81, 13);
            this.label44.TabIndex = 1042;
            this.label44.Text = "Skill 2 Required";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label44.Visible = false;
            // 
            // tbGrade
            // 
            this.tbGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbGrade.Location = new System.Drawing.Point(498, 30);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(50, 20);
            this.tbGrade.TabIndex = 1037;
            this.tbGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbGrade.TextChanged += new System.EventHandler(this.tbGrade_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbEffectDamage);
            this.groupBox5.Controls.Add(this.tbEffectAttack);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.tbEffectNormal);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox5.Location = new System.Drawing.Point(540, 83);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 103);
            this.groupBox5.TabIndex = 1023;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Effects Data";
            // 
            // tbEffectDamage
            // 
            this.tbEffectDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbEffectDamage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEffectDamage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbEffectDamage.Location = new System.Drawing.Point(52, 73);
            this.tbEffectDamage.Name = "tbEffectDamage";
            this.tbEffectDamage.Size = new System.Drawing.Size(136, 20);
            this.tbEffectDamage.TabIndex = 1011;
            this.tbEffectDamage.TextChanged += new System.EventHandler(this.tbEffectDamage_TextChanged);
            // 
            // tbEffectAttack
            // 
            this.tbEffectAttack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbEffectAttack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEffectAttack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbEffectAttack.Location = new System.Drawing.Point(52, 47);
            this.tbEffectAttack.Name = "tbEffectAttack";
            this.tbEffectAttack.Size = new System.Drawing.Size(136, 20);
            this.tbEffectAttack.TabIndex = 1010;
            this.tbEffectAttack.TextChanged += new System.EventHandler(this.tbEffectAttack_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label21.Location = new System.Drawing.Point(3, 77);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 1009;
            this.label21.Text = "Damage";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label20.Location = new System.Drawing.Point(8, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 1008;
            this.label20.Text = "Attack";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label19.Location = new System.Drawing.Point(6, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 1006;
            this.label19.Text = "Normal";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbEffectNormal
            // 
            this.tbEffectNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbEffectNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEffectNormal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbEffectNormal.Location = new System.Drawing.Point(52, 20);
            this.tbEffectNormal.Name = "tbEffectNormal";
            this.tbEffectNormal.Size = new System.Drawing.Size(137, 20);
            this.tbEffectNormal.TabIndex = 1007;
            this.tbEffectNormal.TextChanged += new System.EventHandler(this.tbEffectNormal_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbRvRGradeSelector);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.cbRvRValueSelector);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox4.Location = new System.Drawing.Point(248, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 76);
            this.groupBox4.TabIndex = 1023;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RvR Data";
            // 
            // cbRvRGradeSelector
            // 
            this.cbRvRGradeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbRvRGradeSelector.Enabled = false;
            this.cbRvRGradeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbRvRGradeSelector.FormattingEnabled = true;
            this.cbRvRGradeSelector.Location = new System.Drawing.Point(48, 46);
            this.cbRvRGradeSelector.Name = "cbRvRGradeSelector";
            this.cbRvRGradeSelector.Size = new System.Drawing.Size(100, 21);
            this.cbRvRGradeSelector.TabIndex = 1007;
            this.cbRvRGradeSelector.SelectedIndexChanged += new System.EventHandler(this.cbRvRGradeSelector_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label18.Location = new System.Drawing.Point(8, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 1008;
            this.label18.Text = "Grade";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbRvRValueSelector
            // 
            this.cbRvRValueSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbRvRValueSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbRvRValueSelector.FormattingEnabled = true;
            this.cbRvRValueSelector.Location = new System.Drawing.Point(48, 19);
            this.cbRvRValueSelector.Name = "cbRvRValueSelector";
            this.cbRvRValueSelector.Size = new System.Drawing.Size(100, 21);
            this.cbRvRValueSelector.TabIndex = 16;
            this.cbRvRValueSelector.SelectedIndexChanged += new System.EventHandler(this.cbRvRValueSelector_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label17.Location = new System.Drawing.Point(8, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 1006;
            this.label17.Text = "Value";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label36);
            this.groupBox8.Controls.Add(this.tbSet4);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Controls.Add(this.tbSet3);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.tbSet2);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.tbSet1);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.tbSet0);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox8.Location = new System.Drawing.Point(827, 83);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(81, 156);
            this.groupBox8.TabIndex = 1034;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Set Data";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label36.Location = new System.Drawing.Point(11, 129);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(13, 13);
            this.label36.TabIndex = 1030;
            this.label36.Text = "4";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSet4
            // 
            this.tbSet4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSet4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSet4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSet4.Location = new System.Drawing.Point(30, 125);
            this.tbSet4.Name = "tbSet4";
            this.tbSet4.Size = new System.Drawing.Size(40, 20);
            this.tbSet4.TabIndex = 1031;
            this.tbSet4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSet4.TextChanged += new System.EventHandler(this.tbSet4_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label35.Location = new System.Drawing.Point(11, 103);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(13, 13);
            this.label35.TabIndex = 1028;
            this.label35.Text = "3";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSet3
            // 
            this.tbSet3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSet3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSet3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSet3.Location = new System.Drawing.Point(30, 99);
            this.tbSet3.Name = "tbSet3";
            this.tbSet3.Size = new System.Drawing.Size(40, 20);
            this.tbSet3.TabIndex = 1029;
            this.tbSet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSet3.TextChanged += new System.EventHandler(this.tbSet3_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label34.Location = new System.Drawing.Point(11, 76);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(13, 13);
            this.label34.TabIndex = 1026;
            this.label34.Text = "2";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSet2
            // 
            this.tbSet2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSet2.Location = new System.Drawing.Point(30, 72);
            this.tbSet2.Name = "tbSet2";
            this.tbSet2.Size = new System.Drawing.Size(40, 20);
            this.tbSet2.TabIndex = 1027;
            this.tbSet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSet2.TextChanged += new System.EventHandler(this.tbSet2_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label33.Location = new System.Drawing.Point(11, 50);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(13, 13);
            this.label33.TabIndex = 1024;
            this.label33.Text = "1";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSet1
            // 
            this.tbSet1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSet1.Location = new System.Drawing.Point(30, 46);
            this.tbSet1.Name = "tbSet1";
            this.tbSet1.Size = new System.Drawing.Size(40, 20);
            this.tbSet1.TabIndex = 1025;
            this.tbSet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSet1.TextChanged += new System.EventHandler(this.tbSet1_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label30.Location = new System.Drawing.Point(11, 23);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 1022;
            this.label30.Text = "0";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSet0
            // 
            this.tbSet0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSet0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSet0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSet0.Location = new System.Drawing.Point(30, 19);
            this.tbSet0.Name = "tbSet0";
            this.tbSet0.Size = new System.Drawing.Size(40, 20);
            this.tbSet0.TabIndex = 1023;
            this.tbSet0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSet0.TextChanged += new System.EventHandler(this.tbSet0_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label37);
            this.groupBox7.Controls.Add(this.tbOption0);
            this.groupBox7.Controls.Add(this.tbOption4);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.label38);
            this.groupBox7.Controls.Add(this.tbOption1);
            this.groupBox7.Controls.Add(this.tbOption3);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.label39);
            this.groupBox7.Controls.Add(this.tbOption2);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox7.Location = new System.Drawing.Point(914, 83);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(84, 156);
            this.groupBox7.TabIndex = 1033;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Options Data";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label37.Location = new System.Drawing.Point(11, 129);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(13, 13);
            this.label37.TabIndex = 1040;
            this.label37.Text = "4";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOption0
            // 
            this.tbOption0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbOption0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOption0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbOption0.Location = new System.Drawing.Point(30, 19);
            this.tbOption0.Name = "tbOption0";
            this.tbOption0.Size = new System.Drawing.Size(40, 20);
            this.tbOption0.TabIndex = 1033;
            this.tbOption0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbOption0.TextChanged += new System.EventHandler(this.tbOption0_TextChanged);
            // 
            // tbOption4
            // 
            this.tbOption4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbOption4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOption4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbOption4.Location = new System.Drawing.Point(30, 125);
            this.tbOption4.Name = "tbOption4";
            this.tbOption4.Size = new System.Drawing.Size(40, 20);
            this.tbOption4.TabIndex = 1041;
            this.tbOption4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbOption4.TextChanged += new System.EventHandler(this.tbOption4_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label41.Location = new System.Drawing.Point(11, 23);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(13, 13);
            this.label41.TabIndex = 1032;
            this.label41.Text = "0";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label38.Location = new System.Drawing.Point(11, 103);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(13, 13);
            this.label38.TabIndex = 1038;
            this.label38.Text = "3";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOption1
            // 
            this.tbOption1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbOption1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOption1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbOption1.Location = new System.Drawing.Point(30, 46);
            this.tbOption1.Name = "tbOption1";
            this.tbOption1.Size = new System.Drawing.Size(40, 20);
            this.tbOption1.TabIndex = 1035;
            this.tbOption1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbOption1.TextChanged += new System.EventHandler(this.tbOption1_TextChanged);
            // 
            // tbOption3
            // 
            this.tbOption3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbOption3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOption3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbOption3.Location = new System.Drawing.Point(30, 99);
            this.tbOption3.Name = "tbOption3";
            this.tbOption3.Size = new System.Drawing.Size(40, 20);
            this.tbOption3.TabIndex = 1039;
            this.tbOption3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbOption3.TextChanged += new System.EventHandler(this.tbOption2_TextChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label40.Location = new System.Drawing.Point(11, 50);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(13, 13);
            this.label40.TabIndex = 1034;
            this.label40.Text = "1";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label39.Location = new System.Drawing.Point(11, 76);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(13, 13);
            this.label39.TabIndex = 1036;
            this.label39.Text = "2";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOption2
            // 
            this.tbOption2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbOption2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOption2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbOption2.Location = new System.Drawing.Point(30, 72);
            this.tbOption2.Name = "tbOption2";
            this.tbOption2.Size = new System.Drawing.Size(40, 20);
            this.tbOption2.TabIndex = 1037;
            this.tbOption2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbOption2.TextChanged += new System.EventHandler(this.tbOption2_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.tbVariation6);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.tbVariation5);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.tbVariation4);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.tbVariation3);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.tbVariation2);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.tbVariation1);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox6.Location = new System.Drawing.Point(740, 83);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(81, 182);
            this.groupBox6.TabIndex = 1032;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Origin Data";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label31.Location = new System.Drawing.Point(10, 156);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(13, 13);
            this.label31.TabIndex = 1020;
            this.label31.Text = "6";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation6
            // 
            this.tbVariation6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation6.Location = new System.Drawing.Point(29, 152);
            this.tbVariation6.Name = "tbVariation6";
            this.tbVariation6.Size = new System.Drawing.Size(40, 20);
            this.tbVariation6.TabIndex = 1021;
            this.tbVariation6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation6.TextChanged += new System.EventHandler(this.tbVariation6_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label32.Location = new System.Drawing.Point(10, 130);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(13, 13);
            this.label32.TabIndex = 1018;
            this.label32.Text = "5";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation5
            // 
            this.tbVariation5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation5.Location = new System.Drawing.Point(29, 126);
            this.tbVariation5.Name = "tbVariation5";
            this.tbVariation5.Size = new System.Drawing.Size(40, 20);
            this.tbVariation5.TabIndex = 1019;
            this.tbVariation5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation5.TextChanged += new System.EventHandler(this.tbVariation5_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label28.Location = new System.Drawing.Point(10, 104);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 1016;
            this.label28.Text = "4";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation4
            // 
            this.tbVariation4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation4.Location = new System.Drawing.Point(29, 100);
            this.tbVariation4.Name = "tbVariation4";
            this.tbVariation4.Size = new System.Drawing.Size(40, 20);
            this.tbVariation4.TabIndex = 1017;
            this.tbVariation4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation4.TextChanged += new System.EventHandler(this.tbVariation4_TextChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label29.Location = new System.Drawing.Point(10, 77);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 1014;
            this.label29.Text = "3";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation3
            // 
            this.tbVariation3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation3.Location = new System.Drawing.Point(29, 73);
            this.tbVariation3.Name = "tbVariation3";
            this.tbVariation3.Size = new System.Drawing.Size(40, 20);
            this.tbVariation3.TabIndex = 1015;
            this.tbVariation3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation3.TextChanged += new System.EventHandler(this.tbVariation3_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label27.Location = new System.Drawing.Point(10, 51);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 13);
            this.label27.TabIndex = 1012;
            this.label27.Text = "2";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation2
            // 
            this.tbVariation2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation2.Location = new System.Drawing.Point(29, 47);
            this.tbVariation2.Name = "tbVariation2";
            this.tbVariation2.Size = new System.Drawing.Size(40, 20);
            this.tbVariation2.TabIndex = 1013;
            this.tbVariation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation2.TextChanged += new System.EventHandler(this.tbVariation2_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label26.Location = new System.Drawing.Point(10, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 1010;
            this.label26.Text = "1";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVariation1
            // 
            this.tbVariation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbVariation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVariation1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbVariation1.Location = new System.Drawing.Point(29, 20);
            this.tbVariation1.Name = "tbVariation1";
            this.tbVariation1.Size = new System.Drawing.Size(40, 20);
            this.tbVariation1.TabIndex = 1011;
            this.tbVariation1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVariation1.TextChanged += new System.EventHandler(this.tbVariation1_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label25.Location = new System.Drawing.Point(859, 62);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 1031;
            this.label25.Text = "Item Flag";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnItemFlag
            // 
            this.btnItemFlag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnItemFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnItemFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnItemFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnItemFlag.Location = new System.Drawing.Point(915, 57);
            this.btnItemFlag.Name = "btnItemFlag";
            this.btnItemFlag.Size = new System.Drawing.Size(100, 23);
            this.btnItemFlag.TabIndex = 1030;
            this.btnItemFlag.UseVisualStyleBackColor = true;
            this.btnItemFlag.Click += new System.EventHandler(this.btnItemFlag_Click);
            // 
            // lAllowedZone
            // 
            this.lAllowedZone.AutoSize = true;
            this.lAllowedZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.lAllowedZone.Location = new System.Drawing.Point(675, 62);
            this.lAllowedZone.Name = "lAllowedZone";
            this.lAllowedZone.Size = new System.Drawing.Size(72, 13);
            this.lAllowedZone.TabIndex = 1029;
            this.lAllowedZone.Text = "Allowed Zone";
            this.lAllowedZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAllowedZoneFlag
            // 
            this.btnAllowedZoneFlag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnAllowedZoneFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAllowedZoneFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnAllowedZoneFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllowedZoneFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnAllowedZoneFlag.Location = new System.Drawing.Point(753, 57);
            this.btnAllowedZoneFlag.Name = "btnAllowedZoneFlag";
            this.btnAllowedZoneFlag.Size = new System.Drawing.Size(100, 23);
            this.btnAllowedZoneFlag.TabIndex = 1028;
            this.btnAllowedZoneFlag.UseVisualStyleBackColor = true;
            this.btnAllowedZoneFlag.Visible = false;
            this.btnAllowedZoneFlag.Click += new System.EventHandler(this.btnAllowedZoneFlag_Click);
            // 
            // cbCastleType
            // 
            this.cbCastleType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbCastleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbCastleType.FormattingEnabled = true;
            this.cbCastleType.Location = new System.Drawing.Point(623, 30);
            this.cbCastleType.Name = "cbCastleType";
            this.cbCastleType.Size = new System.Drawing.Size(100, 21);
            this.cbCastleType.TabIndex = 1027;
            this.cbCastleType.SelectedIndexChanged += new System.EventHandler(this.cbCastleType_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label23.Location = new System.Drawing.Point(554, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(63, 13);
            this.label23.TabIndex = 1026;
            this.label23.Text = "Castle Type";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label22.Location = new System.Drawing.Point(541, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 13);
            this.label22.TabIndex = 1025;
            this.label22.Text = "Allowed Class";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClassFlag
            // 
            this.btnClassFlag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnClassFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClassFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnClassFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnClassFlag.Location = new System.Drawing.Point(619, 57);
            this.btnClassFlag.Name = "btnClassFlag";
            this.btnClassFlag.Size = new System.Drawing.Size(50, 23);
            this.btnClassFlag.TabIndex = 1000;
            this.btnClassFlag.UseVisualStyleBackColor = true;
            this.btnClassFlag.Click += new System.EventHandler(this.btnClassFlag_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label16.Location = new System.Drawing.Point(345, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 1023;
            this.label16.Text = "Max Use";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMaxUse
            // 
            this.tbMaxUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbMaxUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbMaxUse.Location = new System.Drawing.Point(400, 30);
            this.tbMaxUse.Name = "tbMaxUse";
            this.tbMaxUse.Size = new System.Drawing.Size(50, 20);
            this.tbMaxUse.TabIndex = 1024;
            this.tbMaxUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxUse.TextChanged += new System.EventHandler(this.tbMaxUse_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label15.Location = new System.Drawing.Point(250, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 1020;
            this.label15.Text = "Fame";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFame
            // 
            this.tbFame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbFame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbFame.Location = new System.Drawing.Point(289, 30);
            this.tbFame.Name = "tbFame";
            this.tbFame.Size = new System.Drawing.Size(50, 20);
            this.tbFame.TabIndex = 1021;
            this.tbFame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFame.TextChanged += new System.EventHandler(this.tbFame_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label14.Location = new System.Drawing.Point(908, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 1018;
            this.label14.Text = "Durability";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDurability
            // 
            this.tbDurability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbDurability.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDurability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbDurability.Location = new System.Drawing.Point(964, 6);
            this.tbDurability.Name = "tbDurability";
            this.tbDurability.Size = new System.Drawing.Size(50, 20);
            this.tbDurability.TabIndex = 1019;
            this.tbDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDurability.TextChanged += new System.EventHandler(this.tbDurability_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label13.Location = new System.Drawing.Point(790, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 1016;
            this.label13.Text = "Max Level";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMaxLevel
            // 
            this.tbMaxLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbMaxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbMaxLevel.Location = new System.Drawing.Point(852, 6);
            this.tbMaxLevel.Name = "tbMaxLevel";
            this.tbMaxLevel.Size = new System.Drawing.Size(50, 20);
            this.tbMaxLevel.TabIndex = 1017;
            this.tbMaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxLevel.TextChanged += new System.EventHandler(this.tbMaxLevel_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label12.Location = new System.Drawing.Point(675, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 1014;
            this.label12.Text = "Min Level";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMinLevel
            // 
            this.tbMinLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbMinLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMinLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbMinLevel.Location = new System.Drawing.Point(734, 6);
            this.tbMinLevel.Name = "tbMinLevel";
            this.tbMinLevel.Size = new System.Drawing.Size(50, 20);
            this.tbMinLevel.TabIndex = 1015;
            this.tbMinLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMinLevel.TextChanged += new System.EventHandler(this.tbMinLevel_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label11.Location = new System.Drawing.Point(543, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 1012;
            this.label11.Text = "Price";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbPrice.Location = new System.Drawing.Point(580, 6);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(89, 20);
            this.tbPrice.TabIndex = 1013;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label10.Location = new System.Drawing.Point(423, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 1010;
            this.label10.Text = "Max Stack";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMaxStack
            // 
            this.tbMaxStack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbMaxStack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxStack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbMaxStack.Location = new System.Drawing.Point(487, 6);
            this.tbMaxStack.Name = "tbMaxStack";
            this.tbMaxStack.Size = new System.Drawing.Size(50, 20);
            this.tbMaxStack.TabIndex = 1011;
            this.tbMaxStack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxStack.TextChanged += new System.EventHandler(this.tbMaxStack_TextChanged);
            // 
            // cbWearingPositionSelector
            // 
            this.cbWearingPositionSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbWearingPositionSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbWearingPositionSelector.FormattingEnabled = true;
            this.cbWearingPositionSelector.Location = new System.Drawing.Point(824, 30);
            this.cbWearingPositionSelector.Name = "cbWearingPositionSelector";
            this.cbWearingPositionSelector.Size = new System.Drawing.Size(138, 21);
            this.cbWearingPositionSelector.TabIndex = 16;
            this.cbWearingPositionSelector.SelectedIndexChanged += new System.EventHandler(this.cbWearingPositionSelector_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label7.Location = new System.Drawing.Point(732, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 1005;
            this.label7.Text = "Wearing Position";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSubTypeSelector
            // 
            this.cbSubTypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbSubTypeSelector.Enabled = false;
            this.cbSubTypeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbSubTypeSelector.FormattingEnabled = true;
            this.cbSubTypeSelector.Location = new System.Drawing.Point(305, 83);
            this.cbSubTypeSelector.Name = "cbSubTypeSelector";
            this.cbSubTypeSelector.Size = new System.Drawing.Size(229, 21);
            this.cbSubTypeSelector.TabIndex = 15;
            this.cbSubTypeSelector.SelectedIndexChanged += new System.EventHandler(this.cbSubTypeSelector_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label6.Location = new System.Drawing.Point(246, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 1003;
            this.label6.Text = "Sub Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTypeSelector
            // 
            this.cbTypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbTypeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbTypeSelector.FormattingEnabled = true;
            this.cbTypeSelector.Location = new System.Drawing.Point(305, 56);
            this.cbTypeSelector.Name = "cbTypeSelector";
            this.cbTypeSelector.Size = new System.Drawing.Size(229, 21);
            this.cbTypeSelector.TabIndex = 14;
            this.cbTypeSelector.SelectedIndexChanged += new System.EventHandler(this.cbTypeSelector_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label5.Location = new System.Drawing.Point(268, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1001;
            this.label5.Text = "Type";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label4.Location = new System.Drawing.Point(185, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "SMC";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSMC
            // 
            this.tbSMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSMC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSMC.Location = new System.Drawing.Point(221, 6);
            this.tbSMC.Name = "tbSMC";
            this.tbSMC.ReadOnly = true;
            this.tbSMC.Size = new System.Drawing.Size(196, 20);
            this.tbSMC.TabIndex = 10;
            this.tbSMC.DoubleClick += new System.EventHandler(this.tbSMC_DoubleClick);
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = global::LastChaos_ToolBox_2024.Properties.Resources.DefaultIcon;
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = null;
            this.pbIcon.Location = new System.Drawing.Point(147, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(32, 32);
            this.pbIcon.TabIndex = 13;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbEnable.Location = new System.Drawing.Point(82, 8);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(59, 17);
            this.cbEnable.TabIndex = 9;
            this.cbEnable.Text = "Enable";
            this.cbEnable.UseVisualStyleBackColor = true;
            this.cbEnable.CheckedChanged += new System.EventHandler(this.cbEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbID
            // 
            this.tbID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbID.Location = new System.Drawing.Point(26, 6);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(50, 20);
            this.tbID.TabIndex = 1;
            this.tbID.Text = "123456";
            this.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbNationSelector);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(0, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 152);
            this.groupBox2.TabIndex = 1000;
            this.groupBox2.TabStop = false;
            // 
            // cbNationSelector
            // 
            this.cbNationSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbNationSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbNationSelector.FormattingEnabled = true;
            this.cbNationSelector.Location = new System.Drawing.Point(6, 13);
            this.cbNationSelector.Name = "cbNationSelector";
            this.cbNationSelector.Size = new System.Drawing.Size(229, 21);
            this.cbNationSelector.TabIndex = 11;
            this.cbNationSelector.SelectedIndexChanged += new System.EventHandler(this.cbNationSelector_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbName.Location = new System.Drawing.Point(39, 40);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(196, 20);
            this.tbName.TabIndex = 12;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbDescription.Location = new System.Drawing.Point(6, 79);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(229, 64);
            this.tbDescription.TabIndex = 13;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnCopy.Location = new System.Drawing.Point(144, 565);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnDelete.Location = new System.Drawing.Point(210, 566);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbSearch.Location = new System.Drawing.Point(12, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(258, 20);
            this.tbSearch.TabIndex = 1025;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // tbAllowedZoneFlag
            // 
            this.tbAllowedZoneFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbAllowedZoneFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAllowedZoneFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbAllowedZoneFlag.Location = new System.Drawing.Point(753, 58);
            this.tbAllowedZoneFlag.Name = "tbAllowedZoneFlag";
            this.tbAllowedZoneFlag.ReadOnly = true;
            this.tbAllowedZoneFlag.Size = new System.Drawing.Size(100, 20);
            this.tbAllowedZoneFlag.TabIndex = 1038;
            this.tbAllowedZoneFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAllowedZoneFlag.Visible = false;
            this.tbAllowedZoneFlag.TextChanged += new System.EventHandler(this.tbAllowedZoneFlag_TextChanged);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1343, 600);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.MainList);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.GeneralPanel);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
            this.MinimumSize = new System.Drawing.Size(1359, 639);
            this.Name = "ItemEditor";
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.ItemEditor_LoadAsync);
            this.groupBox1.ResumeLayout(false);
            this.GeneralPanel.ResumeLayout(false);
            this.GeneralPanel.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ListBox MainList;
        private System.Windows.Forms.GroupBox groupBox1;
        private TextBox tbID;
        private Button btnUpdate;
        private Button btnCopy;
        private Button btnDelete;
        private Label label1;
        private Panel GeneralPanel;
        private CheckBox cbEnable;
        private PictureBox pbIcon;
        private Label label2;
        private TextBox tbName;
        private Label label3;
        private TextBox tbDescription;
        private Label label4;
        private TextBox tbSMC;
        private ComboBox cbNationSelector;
        private GroupBox groupBox2;
        private ComboBox cbTypeSelector;
        private Label label5;
        private ComboBox cbSubTypeSelector;
        private Label label6;
        private ComboBox cbWearingPositionSelector;
        private Label label7;
        private Label label11;
        private TextBox tbPrice;
        private Label label10;
        private TextBox tbMaxStack;
        private Label label12;
        private TextBox tbMinLevel;
        private Label label13;
        private TextBox tbMaxLevel;
        private Label label14;
        private TextBox tbDurability;
        private Label label15;
        private TextBox tbFame;
        private Label label16;
        private TextBox tbMaxUse;
        private GroupBox groupBox4;
        private Label label17;
        private ComboBox cbRvRGradeSelector;
        private Label label18;
        private ComboBox cbRvRValueSelector;
        private GroupBox groupBox5;
        private Label label19;
        private TextBox tbEffectNormal;
        private TextBox tbSearch;
        private TextBox tbEffectDamage;
        private TextBox tbEffectAttack;
        private Label label21;
        private Label label20;
        private Button btnClassFlag;
        private Label label22;
        private Label label23;
        private ComboBox cbCastleType;
        private Label lAllowedZone;
        private Button btnAllowedZoneFlag;
        private Label label25;
        private Button btnItemFlag;
        private GroupBox groupBox6;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
        private GroupBox groupBox9;
        private Label label26;
        private TextBox tbVariation1;
        private Label label27;
        private TextBox tbVariation2;
        private Label label28;
        private TextBox tbVariation4;
        private Label label29;
        private TextBox tbVariation3;
        private Label label31;
        private TextBox tbVariation6;
        private Label label32;
        private TextBox tbVariation5;
        private Label label30;
        private TextBox tbSet0;
        private Label label33;
        private TextBox tbSet1;
        private Label label34;
        private TextBox tbSet2;
        private Label label36;
        private TextBox tbSet4;
        private Label label35;
        private TextBox tbSet3;
        private Label label37;
        private TextBox tbOption0;
        private TextBox tbOption4;
        private Label label41;
        private Label label38;
        private TextBox tbOption1;
        private TextBox tbOption3;
        private Label label40;
        private Label label39;
        private TextBox tbOption2;
        private Label label8;
        private TextBox tbGrade;
        private Label label42;
        private TextBox tbSkill1RequiredLevel;
        private Label label9;
        private Label label43;
        private TextBox tbSkill2RequiredLevel;
        private Label label44;
        private Button btnSkill1RequiredID;
        private Button btnSkill2RequiredID;
        private TextBox tbAllowedZoneFlag;
    }
}
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
            this.BtnAddNew = new System.Windows.Forms.Button();
            this.MainList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnOthers = new System.Windows.Forms.Button();
            this.btnCrafting = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.OthersPanel = new System.Windows.Forms.Panel();
            this.CraftingPanel = new System.Windows.Forms.Panel();
            this.GeneralPanel = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClassFlag = new System.Windows.Forms.Button();
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
            this.label16 = new System.Windows.Forms.Label();
            this.tbMaxUse = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbQuestTriggerID = new System.Windows.Forms.TextBox();
            this.tbQuestTriggerCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.BtnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.GeneralPanel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // BtnAddNew
            // 
            this.BtnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.BtnAddNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.BtnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.BtnAddNew.Location = new System.Drawing.Point(78, 565);
            this.BtnAddNew.Name = "BtnAddNew";
            this.BtnAddNew.Size = new System.Drawing.Size(60, 23);
            this.BtnAddNew.TabIndex = 2;
            this.BtnAddNew.Text = "Add New";
            this.BtnAddNew.UseVisualStyleBackColor = true;
            this.BtnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            this.groupBox1.Controls.Add(this.btnOthers);
            this.groupBox1.Controls.Add(this.btnCrafting);
            this.groupBox1.Controls.Add(this.btnGeneral);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox1.Location = new System.Drawing.Point(276, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1212, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Data";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnUpdate.Location = new System.Drawing.Point(1146, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(60, 23);
            this.btnUpdate.TabIndex = 999;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnOthers
            // 
            this.btnOthers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnOthers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnOthers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnOthers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOthers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnOthers.Location = new System.Drawing.Point(138, 19);
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(60, 23);
            this.btnOthers.TabIndex = 2;
            this.btnOthers.Text = "Others";
            this.btnOthers.UseVisualStyleBackColor = true;
            this.btnOthers.Click += new System.EventHandler(this.btnOthers_Click);
            // 
            // btnCrafting
            // 
            this.btnCrafting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnCrafting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCrafting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnCrafting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrafting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnCrafting.Location = new System.Drawing.Point(72, 19);
            this.btnCrafting.Name = "btnCrafting";
            this.btnCrafting.Size = new System.Drawing.Size(60, 23);
            this.btnCrafting.TabIndex = 1;
            this.btnCrafting.Text = "Crafting";
            this.btnCrafting.UseVisualStyleBackColor = true;
            this.btnCrafting.Click += new System.EventHandler(this.btnCrafting_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnGeneral.Location = new System.Drawing.Point(6, 19);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(60, 23);
            this.btnGeneral.TabIndex = 8;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // OthersPanel
            // 
            this.OthersPanel.Location = new System.Drawing.Point(414, 594);
            this.OthersPanel.Name = "OthersPanel";
            this.OthersPanel.Size = new System.Drawing.Size(200, 100);
            this.OthersPanel.TabIndex = 10;
            // 
            // CraftingPanel
            // 
            this.CraftingPanel.Location = new System.Drawing.Point(622, 594);
            this.CraftingPanel.Name = "CraftingPanel";
            this.CraftingPanel.Size = new System.Drawing.Size(200, 100);
            this.CraftingPanel.TabIndex = 9;
            // 
            // GeneralPanel
            // 
            this.GeneralPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GeneralPanel.Controls.Add(this.label22);
            this.GeneralPanel.Controls.Add(this.btnClassFlag);
            this.GeneralPanel.Controls.Add(this.groupBox5);
            this.GeneralPanel.Controls.Add(this.groupBox4);
            this.GeneralPanel.Controls.Add(this.label16);
            this.GeneralPanel.Controls.Add(this.tbMaxUse);
            this.GeneralPanel.Controls.Add(this.groupBox3);
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
            this.GeneralPanel.Size = new System.Drawing.Size(1200, 528);
            this.GeneralPanel.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label22.Location = new System.Drawing.Point(546, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 13);
            this.label22.TabIndex = 1025;
            this.label22.Text = "Class Flag";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClassFlag
            // 
            this.btnClassFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClassFlag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.btnClassFlag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClassFlag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.btnClassFlag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.btnClassFlag.Location = new System.Drawing.Point(607, 38);
            this.btnClassFlag.Name = "btnClassFlag";
            this.btnClassFlag.Size = new System.Drawing.Size(44, 23);
            this.btnClassFlag.TabIndex = 1000;
            this.btnClassFlag.UseVisualStyleBackColor = true;
            this.btnClassFlag.Click += new System.EventHandler(this.btnClassFlag_Click);
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
            this.groupBox5.Location = new System.Drawing.Point(0, 269);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 96);
            this.groupBox5.TabIndex = 1023;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Effects Data";
            // 
            // tbEffectDamage
            // 
            this.tbEffectDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbEffectDamage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEffectDamage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbEffectDamage.Location = new System.Drawing.Point(53, 69);
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
            this.tbEffectAttack.Location = new System.Drawing.Point(53, 43);
            this.tbEffectAttack.Name = "tbEffectAttack";
            this.tbEffectAttack.Size = new System.Drawing.Size(136, 20);
            this.tbEffectAttack.TabIndex = 1010;
            this.tbEffectAttack.TextChanged += new System.EventHandler(this.tbEffectAttack_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label21.Location = new System.Drawing.Point(4, 73);
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
            this.label20.Location = new System.Drawing.Point(9, 47);
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
            this.label19.Location = new System.Drawing.Point(7, 21);
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
            this.tbEffectNormal.Location = new System.Drawing.Point(53, 17);
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
            this.groupBox4.Location = new System.Drawing.Point(0, 187);
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label16.Location = new System.Drawing.Point(1091, 10);
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
            this.tbMaxUse.Location = new System.Drawing.Point(1146, 6);
            this.tbMaxUse.Name = "tbMaxUse";
            this.tbMaxUse.Size = new System.Drawing.Size(40, 20);
            this.tbMaxUse.TabIndex = 1024;
            this.tbMaxUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxUse.TextChanged += new System.EventHandler(this.tbMaxUse_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tbQuestTriggerID);
            this.groupBox3.Controls.Add(this.tbQuestTriggerCount);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.groupBox3.Location = new System.Drawing.Point(251, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 52);
            this.groupBox3.TabIndex = 1022;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quest Trigger Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label8.Location = new System.Drawing.Point(6, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 1006;
            this.label8.Text = "ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbQuestTriggerID
            // 
            this.tbQuestTriggerID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbQuestTriggerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQuestTriggerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbQuestTriggerID.Location = new System.Drawing.Point(30, 22);
            this.tbQuestTriggerID.Name = "tbQuestTriggerID";
            this.tbQuestTriggerID.Size = new System.Drawing.Size(57, 20);
            this.tbQuestTriggerID.TabIndex = 1007;
            this.tbQuestTriggerID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQuestTriggerID.TextChanged += new System.EventHandler(this.tbQuestTriggerID_TextChanged);
            // 
            // tbQuestTriggerCount
            // 
            this.tbQuestTriggerCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.tbQuestTriggerCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQuestTriggerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.tbQuestTriggerCount.Location = new System.Drawing.Point(134, 22);
            this.tbQuestTriggerCount.Name = "tbQuestTriggerCount";
            this.tbQuestTriggerCount.Size = new System.Drawing.Size(57, 20);
            this.tbQuestTriggerCount.TabIndex = 1009;
            this.tbQuestTriggerCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQuestTriggerCount.TextChanged += new System.EventHandler(this.tbQuestTriggerCount_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label9.Location = new System.Drawing.Point(93, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1008;
            this.label9.Text = "Count";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label15.Location = new System.Drawing.Point(989, 10);
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
            this.tbFame.Location = new System.Drawing.Point(1028, 6);
            this.tbFame.Name = "tbFame";
            this.tbFame.Size = new System.Drawing.Size(57, 20);
            this.tbFame.TabIndex = 1021;
            this.tbFame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFame.TextChanged += new System.EventHandler(this.tbFame_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label14.Location = new System.Drawing.Point(870, 10);
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
            this.tbDurability.Location = new System.Drawing.Point(926, 6);
            this.tbDurability.Name = "tbDurability";
            this.tbDurability.Size = new System.Drawing.Size(57, 20);
            this.tbDurability.TabIndex = 1019;
            this.tbDurability.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDurability.TextChanged += new System.EventHandler(this.tbDurability_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label13.Location = new System.Drawing.Point(762, 10);
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
            this.tbMaxLevel.Location = new System.Drawing.Point(824, 6);
            this.tbMaxLevel.Name = "tbMaxLevel";
            this.tbMaxLevel.Size = new System.Drawing.Size(40, 20);
            this.tbMaxLevel.TabIndex = 1017;
            this.tbMaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxLevel.TextChanged += new System.EventHandler(this.tbMaxLevel_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label12.Location = new System.Drawing.Point(657, 10);
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
            this.tbMinLevel.Location = new System.Drawing.Point(716, 6);
            this.tbMinLevel.Name = "tbMinLevel";
            this.tbMinLevel.Size = new System.Drawing.Size(40, 20);
            this.tbMinLevel.TabIndex = 1015;
            this.tbMinLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMinLevel.TextChanged += new System.EventHandler(this.tbMinLevel_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label11.Location = new System.Drawing.Point(557, 10);
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
            this.tbPrice.Location = new System.Drawing.Point(594, 6);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(57, 20);
            this.tbPrice.TabIndex = 1013;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label10.Location = new System.Drawing.Point(430, 10);
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
            this.tbMaxStack.Location = new System.Drawing.Point(494, 6);
            this.tbMaxStack.Name = "tbMaxStack";
            this.tbMaxStack.Size = new System.Drawing.Size(57, 20);
            this.tbMaxStack.TabIndex = 1011;
            this.tbMaxStack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMaxStack.TextChanged += new System.EventHandler(this.tbMaxStack_TextChanged);
            // 
            // cbWearingPositionSelector
            // 
            this.cbWearingPositionSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.cbWearingPositionSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbWearingPositionSelector.FormattingEnabled = true;
            this.cbWearingPositionSelector.Location = new System.Drawing.Point(340, 93);
            this.cbWearingPositionSelector.Name = "cbWearingPositionSelector";
            this.cbWearingPositionSelector.Size = new System.Drawing.Size(148, 21);
            this.cbWearingPositionSelector.TabIndex = 16;
            this.cbWearingPositionSelector.SelectedIndexChanged += new System.EventHandler(this.cbWearingPositionSelector_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label7.Location = new System.Drawing.Point(248, 97);
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
            this.cbSubTypeSelector.Location = new System.Drawing.Point(311, 66);
            this.cbSubTypeSelector.Name = "cbSubTypeSelector";
            this.cbSubTypeSelector.Size = new System.Drawing.Size(229, 21);
            this.cbSubTypeSelector.TabIndex = 15;
            this.cbSubTypeSelector.SelectedIndexChanged += new System.EventHandler(this.cbSubTypeSelector_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label6.Location = new System.Drawing.Point(252, 70);
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
            this.cbTypeSelector.Location = new System.Drawing.Point(311, 39);
            this.cbTypeSelector.Name = "cbTypeSelector";
            this.cbTypeSelector.Size = new System.Drawing.Size(229, 21);
            this.cbTypeSelector.TabIndex = 14;
            this.cbTypeSelector.SelectedIndexChanged += new System.EventHandler(this.cbTypeSelector_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label5.Location = new System.Drawing.Point(274, 43);
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
            this.label4.Location = new System.Drawing.Point(192, 10);
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
            this.tbSMC.Location = new System.Drawing.Point(228, 6);
            this.tbSMC.Name = "tbSMC";
            this.tbSMC.ReadOnly = true;
            this.tbSMC.ShortcutsEnabled = false;
            this.tbSMC.Size = new System.Drawing.Size(196, 20);
            this.tbSMC.TabIndex = 10;
            this.tbSMC.DoubleClick += new System.EventHandler(this.tbSMC_DoubleClick);
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = global::LastChaos_ToolBox_2024.Properties.Resources.DefaultIcon;
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = null;
            this.pbIcon.Location = new System.Drawing.Point(154, 0);
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
            this.cbEnable.Location = new System.Drawing.Point(89, 8);
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
            this.tbID.Size = new System.Drawing.Size(57, 20);
            this.tbID.TabIndex = 1;
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
            this.groupBox2.Size = new System.Drawing.Size(242, 147);
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
            this.tbName.ShortcutsEnabled = false;
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
            this.tbDescription.ShortcutsEnabled = false;
            this.tbDescription.Size = new System.Drawing.Size(229, 61);
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
            // BtnCopy
            // 
            this.BtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
            this.BtnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
            this.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.BtnCopy.Location = new System.Drawing.Point(144, 565);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(60, 23);
            this.BtnCopy.TabIndex = 3;
            this.BtnCopy.Text = "Copy";
            this.BtnCopy.UseVisualStyleBackColor = true;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1500, 600);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.CraftingPanel);
            this.Controls.Add(this.OthersPanel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.MainList);
            this.Controls.Add(this.BtnAddNew);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.GeneralPanel);
            this.Controls.Add(this.groupBox1);
            this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
            this.MinimumSize = new System.Drawing.Size(1500, 600);
            this.Name = "ItemEditor";
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.ItemEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.GeneralPanel.ResumeLayout(false);
            this.GeneralPanel.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button BtnAddNew;
        private System.Windows.Forms.ListBox MainList;
        private System.Windows.Forms.GroupBox groupBox1;
        private TextBox tbID;
        private Button btnUpdate;
        private Button BtnCopy;
        private Button btnDelete;
        private Button btnGeneral;
        private Button btnCrafting;
        private Button btnOthers;
        private Label label1;
        private Panel GeneralPanel;
        private CheckBox cbEnable;
        private PictureBox pbIcon;
        private Panel CraftingPanel;
        private Label label2;
        private TextBox tbName;
        private Label label3;
        private TextBox tbDescription;
        private Label label4;
        private TextBox tbSMC;
        private ComboBox cbNationSelector;
        private GroupBox groupBox2;
        private Panel OthersPanel;
        private ComboBox cbTypeSelector;
        private Label label5;
        private ComboBox cbSubTypeSelector;
        private Label label6;
        private ComboBox cbWearingPositionSelector;
        private Label label7;
        private Label label8;
        private TextBox tbQuestTriggerID;
        private Label label9;
        private TextBox tbQuestTriggerCount;
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
        private GroupBox groupBox3;
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
    }
}
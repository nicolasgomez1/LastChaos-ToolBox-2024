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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnReload = new System.Windows.Forms.Button();
			this.btnAddNew = new System.Windows.Forms.Button();
			this.MainList = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.GeneralPanel = new System.Windows.Forms.Panel();
			this.cbGrade = new System.Windows.Forms.ComboBox();
			this.gbFortune = new System.Windows.Forms.GroupBox();
			this.rtFortuneWarning = new System.Windows.Forms.RichTextBox();
			this.cbFortuneProbType = new System.Windows.Forms.ComboBox();
			this.cbFortuneEnable = new System.Windows.Forms.CheckBox();
			this.lProbType = new System.Windows.Forms.Label();
			this.gridFortune = new System.Windows.Forms.DataGridView();
			this.btnAddFortune = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lRareProb9Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex9 = new System.Windows.Forms.Button();
			this.lRareProbType9 = new System.Windows.Forms.Label();
			this.label81 = new System.Windows.Forms.Label();
			this.tbRareProb9 = new System.Windows.Forms.TextBox();
			this.lRareProb5Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex5 = new System.Windows.Forms.Button();
			this.lRareProbType5 = new System.Windows.Forms.Label();
			this.label84 = new System.Windows.Forms.Label();
			this.tbRareProb5 = new System.Windows.Forms.TextBox();
			this.lRareProb6Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex6 = new System.Windows.Forms.Button();
			this.lRareProbType6 = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.tbRareProb6 = new System.Windows.Forms.TextBox();
			this.lRareProb7Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex7 = new System.Windows.Forms.Button();
			this.lRareProbType7 = new System.Windows.Forms.Label();
			this.label90 = new System.Windows.Forms.Label();
			this.tbRareProb7 = new System.Windows.Forms.TextBox();
			this.lRareProb8Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex8 = new System.Windows.Forms.Button();
			this.lRareProbType8 = new System.Windows.Forms.Label();
			this.label93 = new System.Windows.Forms.Label();
			this.tbRareProb8 = new System.Windows.Forms.TextBox();
			this.lRareProb4Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex4 = new System.Windows.Forms.Button();
			this.lRareProbType4 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.tbRareProb4 = new System.Windows.Forms.TextBox();
			this.lRareProb0Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex0 = new System.Windows.Forms.Button();
			this.lRareProbType0 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.tbRareProb0 = new System.Windows.Forms.TextBox();
			this.lRareProb1Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex1 = new System.Windows.Forms.Button();
			this.lRareProbType1 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.tbRareProb1 = new System.Windows.Forms.TextBox();
			this.lRareProb2Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex2 = new System.Windows.Forms.Button();
			this.lRareProbType2 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.tbRareProb2 = new System.Windows.Forms.TextBox();
			this.lRareProb3Percentage = new System.Windows.Forms.Label();
			this.btnRareIndex3 = new System.Windows.Forms.Button();
			this.lRareProbType3 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.tbRareProb3 = new System.Windows.Forms.TextBox();
			this.tbAllowedZoneFlag = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label62 = new System.Windows.Forms.Label();
			this.tbItem9RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem9Required = new System.Windows.Forms.Button();
			this.label63 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.tbItem8RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem8Required = new System.Windows.Forms.Button();
			this.label61 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.tbItem7RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem7Required = new System.Windows.Forms.Button();
			this.label59 = new System.Windows.Forms.Label();
			this.label56 = new System.Windows.Forms.Label();
			this.tbItem6RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem6Required = new System.Windows.Forms.Button();
			this.label57 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.tbItem5RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem5Required = new System.Windows.Forms.Button();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.tbItem4RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem4Required = new System.Windows.Forms.Button();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.tbItem3RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem3Required = new System.Windows.Forms.Button();
			this.label55 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.tbItem2RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem2Required = new System.Windows.Forms.Button();
			this.label49 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.tbItem1RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem1Required = new System.Windows.Forms.Button();
			this.label47 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.tbItem0RequiredAmount = new System.Windows.Forms.TextBox();
			this.btnItem0Required = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.btnSkill1RequiredID = new System.Windows.Forms.Button();
			this.label42 = new System.Windows.Forms.Label();
			this.tbSkill1RequiredLevel = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnSkill2RequiredID = new System.Windows.Forms.Button();
			this.label43 = new System.Windows.Forms.Label();
			this.tbSkill2RequiredLevel = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
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
			this.gbQuestData = new System.Windows.Forms.GroupBox();
			this.cbSet0 = new System.Windows.Forms.ComboBox();
			this.lSet4 = new System.Windows.Forms.Label();
			this.tbSet4 = new System.Windows.Forms.TextBox();
			this.lSet3 = new System.Windows.Forms.Label();
			this.tbSet3 = new System.Windows.Forms.TextBox();
			this.lSet2 = new System.Windows.Forms.Label();
			this.tbSet2 = new System.Windows.Forms.TextBox();
			this.lSet1 = new System.Windows.Forms.Label();
			this.tbSet1 = new System.Windows.Forms.TextBox();
			this.lSet0 = new System.Windows.Forms.Label();
			this.gbSetData = new System.Windows.Forms.GroupBox();
			this.btnSet4 = new System.Windows.Forms.Button();
			this.btnSet3 = new System.Windows.Forms.Button();
			this.btnSet2 = new System.Windows.Forms.Button();
			this.btnSet1 = new System.Windows.Forms.Button();
			this.btnSet0 = new System.Windows.Forms.Button();
			this.label30 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
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
			this.cbRenderDialog = new System.Windows.Forms.CheckBox();
			this.cbAutoLoadFortuneData = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.GeneralPanel.SuspendLayout();
			this.gbFortune.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridFortune)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gbQuestData.SuspendLayout();
			this.gbSetData.SuspendLayout();
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
			this.btnReload.Location = new System.Drawing.Point(12, 545);
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
			this.btnAddNew.Location = new System.Drawing.Point(78, 545);
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
			this.MainList.Enabled = false;
			this.MainList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.MainList.FormattingEnabled = true;
			this.MainList.Location = new System.Drawing.Point(12, 38);
			this.MainList.Name = "MainList";
			this.MainList.Size = new System.Drawing.Size(258, 496);
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
			this.groupBox1.Size = new System.Drawing.Size(1032, 582);
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
			this.btnUpdate.Size = new System.Drawing.Size(1020, 23);
			this.btnUpdate.TabIndex = 999;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// GeneralPanel
			// 
			this.GeneralPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GeneralPanel.AutoScroll = true;
			this.GeneralPanel.Controls.Add(this.cbGrade);
			this.GeneralPanel.Controls.Add(this.gbFortune);
			this.GeneralPanel.Controls.Add(this.groupBox3);
			this.GeneralPanel.Controls.Add(this.tbAllowedZoneFlag);
			this.GeneralPanel.Controls.Add(this.label8);
			this.GeneralPanel.Controls.Add(this.groupBox9);
			this.GeneralPanel.Controls.Add(this.groupBox5);
			this.GeneralPanel.Controls.Add(this.groupBox4);
			this.GeneralPanel.Controls.Add(this.gbQuestData);
			this.GeneralPanel.Controls.Add(this.gbSetData);
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
			this.GeneralPanel.Size = new System.Drawing.Size(1021, 528);
			this.GeneralPanel.TabIndex = 0;
			// 
			// cbGrade
			// 
			this.cbGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbGrade.FormattingEnabled = true;
			this.cbGrade.Location = new System.Drawing.Point(498, 30);
			this.cbGrade.Name = "cbGrade";
			this.cbGrade.Size = new System.Drawing.Size(86, 21);
			this.cbGrade.TabIndex = 1009;
			this.cbGrade.SelectedIndexChanged += new System.EventHandler(this.cbGrade_SelectedIndexChanged);
			// 
			// gbFortune
			// 
			this.gbFortune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbFortune.Controls.Add(this.rtFortuneWarning);
			this.gbFortune.Controls.Add(this.cbFortuneProbType);
			this.gbFortune.Controls.Add(this.cbFortuneEnable);
			this.gbFortune.Controls.Add(this.lProbType);
			this.gbFortune.Controls.Add(this.gridFortune);
			this.gbFortune.Controls.Add(this.btnAddFortune);
			this.gbFortune.Location = new System.Drawing.Point(0, 543);
			this.gbFortune.Name = "gbFortune";
			this.gbFortune.Size = new System.Drawing.Size(998, 288);
			this.gbFortune.TabIndex = 1041;
			this.gbFortune.TabStop = false;
			this.gbFortune.Text = "Fortune Data";
			// 
			// rtFortuneWarning
			// 
			this.rtFortuneWarning.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.rtFortuneWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.rtFortuneWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtFortuneWarning.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.rtFortuneWarning.DetectUrls = false;
			this.rtFortuneWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtFortuneWarning.ForeColor = System.Drawing.Color.Red;
			this.rtFortuneWarning.Location = new System.Drawing.Point(307, 18);
			this.rtFortuneWarning.Multiline = false;
			this.rtFortuneWarning.Name = "rtFortuneWarning";
			this.rtFortuneWarning.ReadOnly = true;
			this.rtFortuneWarning.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtFortuneWarning.ShortcutsEnabled = false;
			this.rtFortuneWarning.Size = new System.Drawing.Size(384, 24);
			this.rtFortuneWarning.TabIndex = 1044;
			this.rtFortuneWarning.Text = "PUT MOUSE INSIDE OF THIS GROUP TO LOAD FORTUNE DATA";
			this.rtFortuneWarning.Visible = false;
			// 
			// cbFortuneProbType
			// 
			this.cbFortuneProbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbFortuneProbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFortuneProbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbFortuneProbType.FormattingEnabled = true;
			this.cbFortuneProbType.Location = new System.Drawing.Point(159, 17);
			this.cbFortuneProbType.Name = "cbFortuneProbType";
			this.cbFortuneProbType.Size = new System.Drawing.Size(86, 21);
			this.cbFortuneProbType.TabIndex = 1044;
			this.cbFortuneProbType.SelectedIndexChanged += new System.EventHandler(this.cbIFortuneProbType_SelectedIndexChanged);
			// 
			// cbFortuneEnable
			// 
			this.cbFortuneEnable.AutoSize = true;
			this.cbFortuneEnable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbFortuneEnable.Location = new System.Drawing.Point(6, 19);
			this.cbFortuneEnable.Name = "cbFortuneEnable";
			this.cbFortuneEnable.Size = new System.Drawing.Size(59, 17);
			this.cbFortuneEnable.TabIndex = 1044;
			this.cbFortuneEnable.Text = "Enable";
			this.cbFortuneEnable.UseVisualStyleBackColor = true;
			this.cbFortuneEnable.CheckedChanged += new System.EventHandler(this.cbFortuneEnable_CheckedChanged);
			// 
			// lProbType
			// 
			this.lProbType.AutoSize = true;
			this.lProbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lProbType.Location = new System.Drawing.Point(71, 21);
			this.lProbType.Name = "lProbType";
			this.lProbType.Size = new System.Drawing.Size(82, 13);
			this.lProbType.TabIndex = 1087;
			this.lProbType.Text = "Probability Type";
			this.lProbType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gridFortune
			// 
			this.gridFortune.AllowUserToAddRows = false;
			this.gridFortune.AllowUserToDeleteRows = false;
			this.gridFortune.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridFortune.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.gridFortune.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Red;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridFortune.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.gridFortune.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridFortune.DefaultCellStyle = dataGridViewCellStyle6;
			this.gridFortune.EnableHeadersVisualStyles = false;
			this.gridFortune.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.gridFortune.Location = new System.Drawing.Point(6, 44);
			this.gridFortune.MultiSelect = false;
			this.gridFortune.Name = "gridFortune";
			this.gridFortune.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.gridFortune.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.gridFortune.Size = new System.Drawing.Size(986, 238);
			this.gridFortune.TabIndex = 2;
			this.gridFortune.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridFortune_CellMouseClick);
			this.gridFortune.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFortune_CellValueChanged);
			this.gridFortune.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridFortune_EditingControlShowing);
			// 
			// btnAddFortune
			// 
			this.btnAddFortune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddFortune.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnAddFortune.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnAddFortune.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnAddFortune.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddFortune.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnAddFortune.Location = new System.Drawing.Point(6, 16);
			this.btnAddFortune.Name = "btnAddFortune";
			this.btnAddFortune.Size = new System.Drawing.Size(986, 23);
			this.btnAddFortune.TabIndex = 1044;
			this.btnAddFortune.Text = "Add Fortune";
			this.btnAddFortune.UseVisualStyleBackColor = true;
			this.btnAddFortune.Visible = false;
			this.btnAddFortune.Click += new System.EventHandler(this.btnAddFortune_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lRareProb9Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex9);
			this.groupBox3.Controls.Add(this.lRareProbType9);
			this.groupBox3.Controls.Add(this.label81);
			this.groupBox3.Controls.Add(this.tbRareProb9);
			this.groupBox3.Controls.Add(this.lRareProb5Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex5);
			this.groupBox3.Controls.Add(this.lRareProbType5);
			this.groupBox3.Controls.Add(this.label84);
			this.groupBox3.Controls.Add(this.tbRareProb5);
			this.groupBox3.Controls.Add(this.lRareProb6Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex6);
			this.groupBox3.Controls.Add(this.lRareProbType6);
			this.groupBox3.Controls.Add(this.label87);
			this.groupBox3.Controls.Add(this.tbRareProb6);
			this.groupBox3.Controls.Add(this.lRareProb7Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex7);
			this.groupBox3.Controls.Add(this.lRareProbType7);
			this.groupBox3.Controls.Add(this.label90);
			this.groupBox3.Controls.Add(this.tbRareProb7);
			this.groupBox3.Controls.Add(this.lRareProb8Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex8);
			this.groupBox3.Controls.Add(this.lRareProbType8);
			this.groupBox3.Controls.Add(this.label93);
			this.groupBox3.Controls.Add(this.tbRareProb8);
			this.groupBox3.Controls.Add(this.lRareProb4Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex4);
			this.groupBox3.Controls.Add(this.lRareProbType4);
			this.groupBox3.Controls.Add(this.label78);
			this.groupBox3.Controls.Add(this.tbRareProb4);
			this.groupBox3.Controls.Add(this.lRareProb0Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex0);
			this.groupBox3.Controls.Add(this.lRareProbType0);
			this.groupBox3.Controls.Add(this.label72);
			this.groupBox3.Controls.Add(this.tbRareProb0);
			this.groupBox3.Controls.Add(this.lRareProb1Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex1);
			this.groupBox3.Controls.Add(this.lRareProbType1);
			this.groupBox3.Controls.Add(this.label75);
			this.groupBox3.Controls.Add(this.tbRareProb1);
			this.groupBox3.Controls.Add(this.lRareProb2Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex2);
			this.groupBox3.Controls.Add(this.lRareProbType2);
			this.groupBox3.Controls.Add(this.label69);
			this.groupBox3.Controls.Add(this.tbRareProb2);
			this.groupBox3.Controls.Add(this.lRareProb3Percentage);
			this.groupBox3.Controls.Add(this.btnRareIndex3);
			this.groupBox3.Controls.Add(this.lRareProbType3);
			this.groupBox3.Controls.Add(this.label65);
			this.groupBox3.Controls.Add(this.tbRareProb3);
			this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.groupBox3.Location = new System.Drawing.Point(348, 192);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(308, 315);
			this.groupBox3.TabIndex = 1039;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Origin / Rare / Costume Suit Options Data";
			// 
			// lRareProb9Percentage
			// 
			this.lRareProb9Percentage.AutoSize = true;
			this.lRareProb9Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb9Percentage.Location = new System.Drawing.Point(266, 287);
			this.lRareProb9Percentage.Name = "lRareProb9Percentage";
			this.lRareProb9Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb9Percentage.TabIndex = 1131;
			this.lRareProb9Percentage.Text = "-";
			this.lRareProb9Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex9
			// 
			this.btnRareIndex9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex9.Location = new System.Drawing.Point(59, 282);
			this.btnRareIndex9.Name = "btnRareIndex9";
			this.btnRareIndex9.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex9.TabIndex = 1132;
			this.btnRareIndex9.UseVisualStyleBackColor = true;
			this.btnRareIndex9.Click += new System.EventHandler(this.btnRareIndex9_Click);
			// 
			// lRareProbType9
			// 
			this.lRareProbType9.AutoSize = true;
			this.lRareProbType9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType9.Location = new System.Drawing.Point(185, 287);
			this.lRareProbType9.Name = "lRareProbType9";
			this.lRareProbType9.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType9.TabIndex = 1134;
			this.lRareProbType9.Text = "Level";
			this.lRareProbType9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label81
			// 
			this.label81.AutoSize = true;
			this.label81.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label81.Location = new System.Drawing.Point(6, 287);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(47, 13);
			this.label81.TabIndex = 1133;
			this.label81.Text = "Option 9";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb9
			// 
			this.tbRareProb9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb9.Location = new System.Drawing.Point(220, 283);
			this.tbRareProb9.Name = "tbRareProb9";
			this.tbRareProb9.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb9.TabIndex = 1135;
			this.tbRareProb9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb9.TextChanged += new System.EventHandler(this.tbRareProb9_TextChanged);
			// 
			// lRareProb5Percentage
			// 
			this.lRareProb5Percentage.AutoSize = true;
			this.lRareProb5Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb5Percentage.Location = new System.Drawing.Point(266, 171);
			this.lRareProb5Percentage.Name = "lRareProb5Percentage";
			this.lRareProb5Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb5Percentage.TabIndex = 1126;
			this.lRareProb5Percentage.Text = "-";
			this.lRareProb5Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex5
			// 
			this.btnRareIndex5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex5.Location = new System.Drawing.Point(59, 166);
			this.btnRareIndex5.Name = "btnRareIndex5";
			this.btnRareIndex5.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex5.TabIndex = 1127;
			this.btnRareIndex5.UseVisualStyleBackColor = true;
			this.btnRareIndex5.Click += new System.EventHandler(this.btnRareIndex5_Click);
			// 
			// lRareProbType5
			// 
			this.lRareProbType5.AutoSize = true;
			this.lRareProbType5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType5.Location = new System.Drawing.Point(185, 171);
			this.lRareProbType5.Name = "lRareProbType5";
			this.lRareProbType5.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType5.TabIndex = 1129;
			this.lRareProbType5.Text = "Level";
			this.lRareProbType5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label84
			// 
			this.label84.AutoSize = true;
			this.label84.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label84.Location = new System.Drawing.Point(6, 171);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(47, 13);
			this.label84.TabIndex = 1128;
			this.label84.Text = "Option 5";
			this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb5
			// 
			this.tbRareProb5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb5.Location = new System.Drawing.Point(220, 167);
			this.tbRareProb5.Name = "tbRareProb5";
			this.tbRareProb5.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb5.TabIndex = 1130;
			this.tbRareProb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb5.TextChanged += new System.EventHandler(this.tbRareProb5_TextChanged);
			// 
			// lRareProb6Percentage
			// 
			this.lRareProb6Percentage.AutoSize = true;
			this.lRareProb6Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb6Percentage.Location = new System.Drawing.Point(266, 200);
			this.lRareProb6Percentage.Name = "lRareProb6Percentage";
			this.lRareProb6Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb6Percentage.TabIndex = 1121;
			this.lRareProb6Percentage.Text = "-";
			this.lRareProb6Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex6
			// 
			this.btnRareIndex6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex6.Location = new System.Drawing.Point(59, 195);
			this.btnRareIndex6.Name = "btnRareIndex6";
			this.btnRareIndex6.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex6.TabIndex = 1122;
			this.btnRareIndex6.UseVisualStyleBackColor = true;
			this.btnRareIndex6.Click += new System.EventHandler(this.btnRareIndex6_Click);
			// 
			// lRareProbType6
			// 
			this.lRareProbType6.AutoSize = true;
			this.lRareProbType6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType6.Location = new System.Drawing.Point(185, 200);
			this.lRareProbType6.Name = "lRareProbType6";
			this.lRareProbType6.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType6.TabIndex = 1124;
			this.lRareProbType6.Text = "Level";
			this.lRareProbType6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label87
			// 
			this.label87.AutoSize = true;
			this.label87.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label87.Location = new System.Drawing.Point(6, 200);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(47, 13);
			this.label87.TabIndex = 1123;
			this.label87.Text = "Option 6";
			this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb6
			// 
			this.tbRareProb6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb6.Location = new System.Drawing.Point(220, 196);
			this.tbRareProb6.Name = "tbRareProb6";
			this.tbRareProb6.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb6.TabIndex = 1125;
			this.tbRareProb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb6.TextChanged += new System.EventHandler(this.tbRareProb6_TextChanged);
			// 
			// lRareProb7Percentage
			// 
			this.lRareProb7Percentage.AutoSize = true;
			this.lRareProb7Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb7Percentage.Location = new System.Drawing.Point(266, 229);
			this.lRareProb7Percentage.Name = "lRareProb7Percentage";
			this.lRareProb7Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb7Percentage.TabIndex = 1116;
			this.lRareProb7Percentage.Text = "-";
			this.lRareProb7Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex7
			// 
			this.btnRareIndex7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex7.Location = new System.Drawing.Point(59, 224);
			this.btnRareIndex7.Name = "btnRareIndex7";
			this.btnRareIndex7.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex7.TabIndex = 1117;
			this.btnRareIndex7.UseVisualStyleBackColor = true;
			this.btnRareIndex7.Click += new System.EventHandler(this.btnRareIndex7_Click);
			// 
			// lRareProbType7
			// 
			this.lRareProbType7.AutoSize = true;
			this.lRareProbType7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType7.Location = new System.Drawing.Point(185, 229);
			this.lRareProbType7.Name = "lRareProbType7";
			this.lRareProbType7.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType7.TabIndex = 1119;
			this.lRareProbType7.Text = "Level";
			this.lRareProbType7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label90
			// 
			this.label90.AutoSize = true;
			this.label90.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label90.Location = new System.Drawing.Point(6, 229);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(47, 13);
			this.label90.TabIndex = 1118;
			this.label90.Text = "Option 7";
			this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb7
			// 
			this.tbRareProb7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb7.Location = new System.Drawing.Point(220, 225);
			this.tbRareProb7.Name = "tbRareProb7";
			this.tbRareProb7.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb7.TabIndex = 1120;
			this.tbRareProb7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb7.TextChanged += new System.EventHandler(this.tbRareProb7_TextChanged);
			// 
			// lRareProb8Percentage
			// 
			this.lRareProb8Percentage.AutoSize = true;
			this.lRareProb8Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb8Percentage.Location = new System.Drawing.Point(266, 258);
			this.lRareProb8Percentage.Name = "lRareProb8Percentage";
			this.lRareProb8Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb8Percentage.TabIndex = 1112;
			this.lRareProb8Percentage.Text = "-";
			this.lRareProb8Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex8
			// 
			this.btnRareIndex8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex8.Location = new System.Drawing.Point(59, 253);
			this.btnRareIndex8.Name = "btnRareIndex8";
			this.btnRareIndex8.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex8.TabIndex = 1111;
			this.btnRareIndex8.UseVisualStyleBackColor = true;
			this.btnRareIndex8.Click += new System.EventHandler(this.btnRareIndex8_Click);
			// 
			// lRareProbType8
			// 
			this.lRareProbType8.AutoSize = true;
			this.lRareProbType8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType8.Location = new System.Drawing.Point(185, 258);
			this.lRareProbType8.Name = "lRareProbType8";
			this.lRareProbType8.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType8.TabIndex = 1114;
			this.lRareProbType8.Text = "Level";
			this.lRareProbType8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label93
			// 
			this.label93.AutoSize = true;
			this.label93.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label93.Location = new System.Drawing.Point(6, 258);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(47, 13);
			this.label93.TabIndex = 1113;
			this.label93.Text = "Option 8";
			this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb8
			// 
			this.tbRareProb8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb8.Location = new System.Drawing.Point(220, 254);
			this.tbRareProb8.Name = "tbRareProb8";
			this.tbRareProb8.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb8.TabIndex = 1115;
			this.tbRareProb8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb8.TextChanged += new System.EventHandler(this.tbRareProb8_TextChanged);
			// 
			// lRareProb4Percentage
			// 
			this.lRareProb4Percentage.AutoSize = true;
			this.lRareProb4Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb4Percentage.Location = new System.Drawing.Point(266, 142);
			this.lRareProb4Percentage.Name = "lRareProb4Percentage";
			this.lRareProb4Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb4Percentage.TabIndex = 1106;
			this.lRareProb4Percentage.Text = "-";
			this.lRareProb4Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex4
			// 
			this.btnRareIndex4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex4.Location = new System.Drawing.Point(59, 137);
			this.btnRareIndex4.Name = "btnRareIndex4";
			this.btnRareIndex4.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex4.TabIndex = 1107;
			this.btnRareIndex4.UseVisualStyleBackColor = true;
			this.btnRareIndex4.Click += new System.EventHandler(this.btnRareIndex4_Click);
			// 
			// lRareProbType4
			// 
			this.lRareProbType4.AutoSize = true;
			this.lRareProbType4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType4.Location = new System.Drawing.Point(185, 142);
			this.lRareProbType4.Name = "lRareProbType4";
			this.lRareProbType4.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType4.TabIndex = 1109;
			this.lRareProbType4.Text = "Level";
			this.lRareProbType4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label78
			// 
			this.label78.AutoSize = true;
			this.label78.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label78.Location = new System.Drawing.Point(6, 142);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(47, 13);
			this.label78.TabIndex = 1108;
			this.label78.Text = "Option 4";
			this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb4
			// 
			this.tbRareProb4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb4.Location = new System.Drawing.Point(220, 138);
			this.tbRareProb4.Name = "tbRareProb4";
			this.tbRareProb4.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb4.TabIndex = 1110;
			this.tbRareProb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb4.TextChanged += new System.EventHandler(this.tbRareProb4_TextChanged);
			// 
			// lRareProb0Percentage
			// 
			this.lRareProb0Percentage.AutoSize = true;
			this.lRareProb0Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb0Percentage.Location = new System.Drawing.Point(266, 26);
			this.lRareProb0Percentage.Name = "lRareProb0Percentage";
			this.lRareProb0Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb0Percentage.TabIndex = 1101;
			this.lRareProb0Percentage.Text = "-";
			this.lRareProb0Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex0
			// 
			this.btnRareIndex0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex0.Location = new System.Drawing.Point(59, 21);
			this.btnRareIndex0.Name = "btnRareIndex0";
			this.btnRareIndex0.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex0.TabIndex = 1102;
			this.btnRareIndex0.UseVisualStyleBackColor = true;
			this.btnRareIndex0.Click += new System.EventHandler(this.btnRareIndex0_Click);
			// 
			// lRareProbType0
			// 
			this.lRareProbType0.AutoSize = true;
			this.lRareProbType0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType0.Location = new System.Drawing.Point(185, 26);
			this.lRareProbType0.Name = "lRareProbType0";
			this.lRareProbType0.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType0.TabIndex = 1104;
			this.lRareProbType0.Text = "Level";
			this.lRareProbType0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label72.Location = new System.Drawing.Point(6, 26);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(47, 13);
			this.label72.TabIndex = 1103;
			this.label72.Text = "Option 0";
			this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb0
			// 
			this.tbRareProb0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb0.Location = new System.Drawing.Point(220, 22);
			this.tbRareProb0.Name = "tbRareProb0";
			this.tbRareProb0.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb0.TabIndex = 1105;
			this.tbRareProb0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb0.TextChanged += new System.EventHandler(this.tbRareProb0_TextChanged);
			// 
			// lRareProb1Percentage
			// 
			this.lRareProb1Percentage.AutoSize = true;
			this.lRareProb1Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb1Percentage.Location = new System.Drawing.Point(266, 55);
			this.lRareProb1Percentage.Name = "lRareProb1Percentage";
			this.lRareProb1Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb1Percentage.TabIndex = 1096;
			this.lRareProb1Percentage.Text = "-";
			this.lRareProb1Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex1
			// 
			this.btnRareIndex1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex1.Location = new System.Drawing.Point(59, 50);
			this.btnRareIndex1.Name = "btnRareIndex1";
			this.btnRareIndex1.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex1.TabIndex = 1097;
			this.btnRareIndex1.UseVisualStyleBackColor = true;
			this.btnRareIndex1.Click += new System.EventHandler(this.btnRareIndex1_Click);
			// 
			// lRareProbType1
			// 
			this.lRareProbType1.AutoSize = true;
			this.lRareProbType1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType1.Location = new System.Drawing.Point(185, 55);
			this.lRareProbType1.Name = "lRareProbType1";
			this.lRareProbType1.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType1.TabIndex = 1099;
			this.lRareProbType1.Text = "Level";
			this.lRareProbType1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label75.Location = new System.Drawing.Point(6, 55);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(47, 13);
			this.label75.TabIndex = 1098;
			this.label75.Text = "Option 1";
			this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb1
			// 
			this.tbRareProb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb1.Location = new System.Drawing.Point(220, 51);
			this.tbRareProb1.Name = "tbRareProb1";
			this.tbRareProb1.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb1.TabIndex = 1100;
			this.tbRareProb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb1.TextChanged += new System.EventHandler(this.tbRareProb1_TextChanged);
			// 
			// lRareProb2Percentage
			// 
			this.lRareProb2Percentage.AutoSize = true;
			this.lRareProb2Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb2Percentage.Location = new System.Drawing.Point(266, 84);
			this.lRareProb2Percentage.Name = "lRareProb2Percentage";
			this.lRareProb2Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb2Percentage.TabIndex = 1091;
			this.lRareProb2Percentage.Text = "-";
			this.lRareProb2Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex2
			// 
			this.btnRareIndex2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex2.Location = new System.Drawing.Point(59, 79);
			this.btnRareIndex2.Name = "btnRareIndex2";
			this.btnRareIndex2.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex2.TabIndex = 1092;
			this.btnRareIndex2.UseVisualStyleBackColor = true;
			this.btnRareIndex2.Click += new System.EventHandler(this.btnRareIndex2_Click);
			// 
			// lRareProbType2
			// 
			this.lRareProbType2.AutoSize = true;
			this.lRareProbType2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType2.Location = new System.Drawing.Point(185, 84);
			this.lRareProbType2.Name = "lRareProbType2";
			this.lRareProbType2.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType2.TabIndex = 1094;
			this.lRareProbType2.Text = "Level";
			this.lRareProbType2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label69.Location = new System.Drawing.Point(6, 84);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(47, 13);
			this.label69.TabIndex = 1093;
			this.label69.Text = "Option 2";
			this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb2
			// 
			this.tbRareProb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb2.Location = new System.Drawing.Point(220, 80);
			this.tbRareProb2.Name = "tbRareProb2";
			this.tbRareProb2.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb2.TabIndex = 1095;
			this.tbRareProb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb2.TextChanged += new System.EventHandler(this.tbRareProb2_TextChanged);
			// 
			// lRareProb3Percentage
			// 
			this.lRareProb3Percentage.AutoSize = true;
			this.lRareProb3Percentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProb3Percentage.Location = new System.Drawing.Point(266, 113);
			this.lRareProb3Percentage.Name = "lRareProb3Percentage";
			this.lRareProb3Percentage.Size = new System.Drawing.Size(10, 13);
			this.lRareProb3Percentage.TabIndex = 1087;
			this.lRareProb3Percentage.Text = "-";
			this.lRareProb3Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRareIndex3
			// 
			this.btnRareIndex3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnRareIndex3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnRareIndex3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnRareIndex3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRareIndex3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnRareIndex3.Location = new System.Drawing.Point(59, 108);
			this.btnRareIndex3.Name = "btnRareIndex3";
			this.btnRareIndex3.Size = new System.Drawing.Size(120, 23);
			this.btnRareIndex3.TabIndex = 1087;
			this.btnRareIndex3.UseVisualStyleBackColor = true;
			this.btnRareIndex3.Click += new System.EventHandler(this.btnRareIndex3_Click);
			// 
			// lRareProbType3
			// 
			this.lRareProbType3.AutoSize = true;
			this.lRareProbType3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lRareProbType3.Location = new System.Drawing.Point(185, 113);
			this.lRareProbType3.Name = "lRareProbType3";
			this.lRareProbType3.Size = new System.Drawing.Size(33, 13);
			this.lRareProbType3.TabIndex = 1089;
			this.lRareProbType3.Text = "Level";
			this.lRareProbType3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label65.Location = new System.Drawing.Point(6, 113);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(47, 13);
			this.label65.TabIndex = 1088;
			this.label65.Text = "Option 3";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbRareProb3
			// 
			this.tbRareProb3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbRareProb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbRareProb3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbRareProb3.Location = new System.Drawing.Point(220, 109);
			this.tbRareProb3.Name = "tbRareProb3";
			this.tbRareProb3.Size = new System.Drawing.Size(40, 20);
			this.tbRareProb3.TabIndex = 1090;
			this.tbRareProb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbRareProb3.TextChanged += new System.EventHandler(this.tbRareProb3_TextChanged);
			// 
			// tbAllowedZoneFlag
			// 
			this.tbAllowedZoneFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbAllowedZoneFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbAllowedZoneFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbAllowedZoneFlag.Location = new System.Drawing.Point(736, 58);
			this.tbAllowedZoneFlag.Name = "tbAllowedZoneFlag";
			this.tbAllowedZoneFlag.ReadOnly = true;
			this.tbAllowedZoneFlag.Size = new System.Drawing.Size(100, 20);
			this.tbAllowedZoneFlag.TabIndex = 1038;
			this.tbAllowedZoneFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbAllowedZoneFlag.Visible = false;
			this.tbAllowedZoneFlag.TextChanged += new System.EventHandler(this.tbAllowedZoneFlag_TextChanged);
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
			this.groupBox9.Controls.Add(this.label62);
			this.groupBox9.Controls.Add(this.tbItem9RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem9Required);
			this.groupBox9.Controls.Add(this.label63);
			this.groupBox9.Controls.Add(this.label60);
			this.groupBox9.Controls.Add(this.tbItem8RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem8Required);
			this.groupBox9.Controls.Add(this.label61);
			this.groupBox9.Controls.Add(this.label58);
			this.groupBox9.Controls.Add(this.tbItem7RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem7Required);
			this.groupBox9.Controls.Add(this.label59);
			this.groupBox9.Controls.Add(this.label56);
			this.groupBox9.Controls.Add(this.tbItem6RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem6Required);
			this.groupBox9.Controls.Add(this.label57);
			this.groupBox9.Controls.Add(this.label50);
			this.groupBox9.Controls.Add(this.tbItem5RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem5Required);
			this.groupBox9.Controls.Add(this.label51);
			this.groupBox9.Controls.Add(this.label52);
			this.groupBox9.Controls.Add(this.tbItem4RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem4Required);
			this.groupBox9.Controls.Add(this.label53);
			this.groupBox9.Controls.Add(this.label54);
			this.groupBox9.Controls.Add(this.tbItem3RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem3Required);
			this.groupBox9.Controls.Add(this.label55);
			this.groupBox9.Controls.Add(this.label48);
			this.groupBox9.Controls.Add(this.tbItem2RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem2Required);
			this.groupBox9.Controls.Add(this.label49);
			this.groupBox9.Controls.Add(this.label46);
			this.groupBox9.Controls.Add(this.tbItem1RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem1Required);
			this.groupBox9.Controls.Add(this.label47);
			this.groupBox9.Controls.Add(this.label45);
			this.groupBox9.Controls.Add(this.tbItem0RequiredAmount);
			this.groupBox9.Controls.Add(this.btnItem0Required);
			this.groupBox9.Controls.Add(this.label24);
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
			this.groupBox9.Size = new System.Drawing.Size(342, 345);
			this.groupBox9.TabIndex = 1035;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Crafting Data";
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label62.Location = new System.Drawing.Point(240, 316);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(43, 13);
			this.label62.TabIndex = 1085;
			this.label62.Text = "Amount";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem9RequiredAmount
			// 
			this.tbItem9RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem9RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem9RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem9RequiredAmount.Location = new System.Drawing.Point(289, 312);
			this.tbItem9RequiredAmount.Name = "tbItem9RequiredAmount";
			this.tbItem9RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem9RequiredAmount.TabIndex = 1086;
			this.tbItem9RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem9RequiredAmount.TextChanged += new System.EventHandler(this.tbItem9RequiredAmount_TextChanged);
			// 
			// btnItem9Required
			// 
			this.btnItem9Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem9Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem9Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem9Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem9Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem9Required.Location = new System.Drawing.Point(84, 311);
			this.btnItem9Required.Name = "btnItem9Required";
			this.btnItem9Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem9Required.TabIndex = 1083;
			this.btnItem9Required.UseVisualStyleBackColor = true;
			this.btnItem9Required.Click += new System.EventHandler(this.btnItem9Required_Click);
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label63.Location = new System.Drawing.Point(6, 316);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(73, 13);
			this.label63.TabIndex = 1084;
			this.label63.Text = "Item Required";
			this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label60.Location = new System.Drawing.Point(240, 287);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(43, 13);
			this.label60.TabIndex = 1081;
			this.label60.Text = "Amount";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem8RequiredAmount
			// 
			this.tbItem8RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem8RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem8RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem8RequiredAmount.Location = new System.Drawing.Point(289, 283);
			this.tbItem8RequiredAmount.Name = "tbItem8RequiredAmount";
			this.tbItem8RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem8RequiredAmount.TabIndex = 1082;
			this.tbItem8RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem8RequiredAmount.TextChanged += new System.EventHandler(this.tbItem8RequiredAmount_TextChanged);
			// 
			// btnItem8Required
			// 
			this.btnItem8Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem8Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem8Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem8Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem8Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem8Required.Location = new System.Drawing.Point(84, 282);
			this.btnItem8Required.Name = "btnItem8Required";
			this.btnItem8Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem8Required.TabIndex = 1079;
			this.btnItem8Required.UseVisualStyleBackColor = true;
			this.btnItem8Required.Click += new System.EventHandler(this.btnItem8Required_Click);
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label61.Location = new System.Drawing.Point(6, 287);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(73, 13);
			this.label61.TabIndex = 1080;
			this.label61.Text = "Item Required";
			this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label58.Location = new System.Drawing.Point(240, 258);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(43, 13);
			this.label58.TabIndex = 1077;
			this.label58.Text = "Amount";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem7RequiredAmount
			// 
			this.tbItem7RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem7RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem7RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem7RequiredAmount.Location = new System.Drawing.Point(289, 254);
			this.tbItem7RequiredAmount.Name = "tbItem7RequiredAmount";
			this.tbItem7RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem7RequiredAmount.TabIndex = 1078;
			this.tbItem7RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem7RequiredAmount.TextChanged += new System.EventHandler(this.tbItem7RequiredAmount_TextChanged);
			// 
			// btnItem7Required
			// 
			this.btnItem7Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem7Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem7Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem7Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem7Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem7Required.Location = new System.Drawing.Point(84, 253);
			this.btnItem7Required.Name = "btnItem7Required";
			this.btnItem7Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem7Required.TabIndex = 1075;
			this.btnItem7Required.UseVisualStyleBackColor = true;
			this.btnItem7Required.Click += new System.EventHandler(this.btnItem7Required_Click);
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label59.Location = new System.Drawing.Point(6, 258);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(73, 13);
			this.label59.TabIndex = 1076;
			this.label59.Text = "Item Required";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label56.Location = new System.Drawing.Point(240, 229);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(43, 13);
			this.label56.TabIndex = 1073;
			this.label56.Text = "Amount";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem6RequiredAmount
			// 
			this.tbItem6RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem6RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem6RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem6RequiredAmount.Location = new System.Drawing.Point(289, 225);
			this.tbItem6RequiredAmount.Name = "tbItem6RequiredAmount";
			this.tbItem6RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem6RequiredAmount.TabIndex = 1074;
			this.tbItem6RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem6RequiredAmount.TextChanged += new System.EventHandler(this.tbItem6RequiredAmount_TextChanged);
			// 
			// btnItem6Required
			// 
			this.btnItem6Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem6Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem6Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem6Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem6Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem6Required.Location = new System.Drawing.Point(84, 224);
			this.btnItem6Required.Name = "btnItem6Required";
			this.btnItem6Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem6Required.TabIndex = 1071;
			this.btnItem6Required.UseVisualStyleBackColor = true;
			this.btnItem6Required.Click += new System.EventHandler(this.btnItem6Required_Click);
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label57.Location = new System.Drawing.Point(6, 229);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(73, 13);
			this.label57.TabIndex = 1072;
			this.label57.Text = "Item Required";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label50.Location = new System.Drawing.Point(240, 200);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(43, 13);
			this.label50.TabIndex = 1069;
			this.label50.Text = "Amount";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem5RequiredAmount
			// 
			this.tbItem5RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem5RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem5RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem5RequiredAmount.Location = new System.Drawing.Point(289, 196);
			this.tbItem5RequiredAmount.Name = "tbItem5RequiredAmount";
			this.tbItem5RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem5RequiredAmount.TabIndex = 1070;
			this.tbItem5RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem5RequiredAmount.TextChanged += new System.EventHandler(this.tbItem5RequiredAmount_TextChanged);
			// 
			// btnItem5Required
			// 
			this.btnItem5Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem5Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem5Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem5Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem5Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem5Required.Location = new System.Drawing.Point(84, 195);
			this.btnItem5Required.Name = "btnItem5Required";
			this.btnItem5Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem5Required.TabIndex = 1067;
			this.btnItem5Required.UseVisualStyleBackColor = true;
			this.btnItem5Required.Click += new System.EventHandler(this.btnItem5Required_Click);
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label51.Location = new System.Drawing.Point(6, 200);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(73, 13);
			this.label51.TabIndex = 1068;
			this.label51.Text = "Item Required";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label52.Location = new System.Drawing.Point(240, 171);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(43, 13);
			this.label52.TabIndex = 1065;
			this.label52.Text = "Amount";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem4RequiredAmount
			// 
			this.tbItem4RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem4RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem4RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem4RequiredAmount.Location = new System.Drawing.Point(289, 167);
			this.tbItem4RequiredAmount.Name = "tbItem4RequiredAmount";
			this.tbItem4RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem4RequiredAmount.TabIndex = 1066;
			this.tbItem4RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem4RequiredAmount.TextChanged += new System.EventHandler(this.tbItem4RequiredAmount_TextChanged);
			// 
			// btnItem4Required
			// 
			this.btnItem4Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem4Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem4Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem4Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem4Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem4Required.Location = new System.Drawing.Point(84, 166);
			this.btnItem4Required.Name = "btnItem4Required";
			this.btnItem4Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem4Required.TabIndex = 1063;
			this.btnItem4Required.UseVisualStyleBackColor = true;
			this.btnItem4Required.Click += new System.EventHandler(this.btnItem4Required_Click);
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label53.Location = new System.Drawing.Point(6, 171);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(73, 13);
			this.label53.TabIndex = 1064;
			this.label53.Text = "Item Required";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label54.Location = new System.Drawing.Point(240, 142);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(43, 13);
			this.label54.TabIndex = 1061;
			this.label54.Text = "Amount";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem3RequiredAmount
			// 
			this.tbItem3RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem3RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem3RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem3RequiredAmount.Location = new System.Drawing.Point(289, 138);
			this.tbItem3RequiredAmount.Name = "tbItem3RequiredAmount";
			this.tbItem3RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem3RequiredAmount.TabIndex = 1062;
			this.tbItem3RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem3RequiredAmount.TextChanged += new System.EventHandler(this.tbItem3RequiredAmount_TextChanged);
			// 
			// btnItem3Required
			// 
			this.btnItem3Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem3Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem3Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem3Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem3Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem3Required.Location = new System.Drawing.Point(84, 137);
			this.btnItem3Required.Name = "btnItem3Required";
			this.btnItem3Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem3Required.TabIndex = 1059;
			this.btnItem3Required.UseVisualStyleBackColor = true;
			this.btnItem3Required.Click += new System.EventHandler(this.btnItem3Required_Click);
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label55.Location = new System.Drawing.Point(6, 142);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(73, 13);
			this.label55.TabIndex = 1060;
			this.label55.Text = "Item Required";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label48.Location = new System.Drawing.Point(240, 113);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(43, 13);
			this.label48.TabIndex = 1057;
			this.label48.Text = "Amount";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem2RequiredAmount
			// 
			this.tbItem2RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem2RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem2RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem2RequiredAmount.Location = new System.Drawing.Point(289, 109);
			this.tbItem2RequiredAmount.Name = "tbItem2RequiredAmount";
			this.tbItem2RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem2RequiredAmount.TabIndex = 1058;
			this.tbItem2RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem2RequiredAmount.TextChanged += new System.EventHandler(this.tbItem2RequiredAmount_TextChanged);
			// 
			// btnItem2Required
			// 
			this.btnItem2Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem2Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem2Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem2Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem2Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem2Required.Location = new System.Drawing.Point(84, 108);
			this.btnItem2Required.Name = "btnItem2Required";
			this.btnItem2Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem2Required.TabIndex = 1055;
			this.btnItem2Required.UseVisualStyleBackColor = true;
			this.btnItem2Required.Click += new System.EventHandler(this.btnItem2Required_Click);
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label49.Location = new System.Drawing.Point(6, 113);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(73, 13);
			this.label49.TabIndex = 1056;
			this.label49.Text = "Item Required";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label46.Location = new System.Drawing.Point(240, 84);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(43, 13);
			this.label46.TabIndex = 1053;
			this.label46.Text = "Amount";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem1RequiredAmount
			// 
			this.tbItem1RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem1RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem1RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem1RequiredAmount.Location = new System.Drawing.Point(289, 80);
			this.tbItem1RequiredAmount.Name = "tbItem1RequiredAmount";
			this.tbItem1RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem1RequiredAmount.TabIndex = 1054;
			this.tbItem1RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem1RequiredAmount.TextChanged += new System.EventHandler(this.tbItem1RequiredAmount_TextChanged);
			// 
			// btnItem1Required
			// 
			this.btnItem1Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem1Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem1Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem1Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem1Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem1Required.Location = new System.Drawing.Point(84, 79);
			this.btnItem1Required.Name = "btnItem1Required";
			this.btnItem1Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem1Required.TabIndex = 1051;
			this.btnItem1Required.UseVisualStyleBackColor = true;
			this.btnItem1Required.Click += new System.EventHandler(this.btnItem1Required_Click);
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label47.Location = new System.Drawing.Point(6, 84);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(73, 13);
			this.label47.TabIndex = 1052;
			this.label47.Text = "Item Required";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label45.Location = new System.Drawing.Point(240, 55);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(43, 13);
			this.label45.TabIndex = 1049;
			this.label45.Text = "Amount";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbItem0RequiredAmount
			// 
			this.tbItem0RequiredAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbItem0RequiredAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbItem0RequiredAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbItem0RequiredAmount.Location = new System.Drawing.Point(289, 51);
			this.tbItem0RequiredAmount.Name = "tbItem0RequiredAmount";
			this.tbItem0RequiredAmount.Size = new System.Drawing.Size(40, 20);
			this.tbItem0RequiredAmount.TabIndex = 1050;
			this.tbItem0RequiredAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbItem0RequiredAmount.TextChanged += new System.EventHandler(this.tbItem0RequiredAmount_TextChanged);
			// 
			// btnItem0Required
			// 
			this.btnItem0Required.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnItem0Required.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnItem0Required.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnItem0Required.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItem0Required.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnItem0Required.Location = new System.Drawing.Point(84, 50);
			this.btnItem0Required.Name = "btnItem0Required";
			this.btnItem0Required.Size = new System.Drawing.Size(150, 23);
			this.btnItem0Required.TabIndex = 1047;
			this.btnItem0Required.UseVisualStyleBackColor = true;
			this.btnItem0Required.Click += new System.EventHandler(this.btnItem0Required_Click);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label24.Location = new System.Drawing.Point(6, 55);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(73, 13);
			this.label24.TabIndex = 1048;
			this.label24.Text = "Item Required";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.btnSkill1RequiredID.Size = new System.Drawing.Size(150, 23);
			this.btnSkill1RequiredID.TabIndex = 1038;
			this.btnSkill1RequiredID.UseVisualStyleBackColor = true;
			this.btnSkill1RequiredID.Click += new System.EventHandler(this.btnSkill1RequiredID_Click);
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label42.Location = new System.Drawing.Point(240, 24);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(33, 13);
			this.label42.TabIndex = 1040;
			this.label42.Text = "Level";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSkill1RequiredLevel
			// 
			this.tbSkill1RequiredLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSkill1RequiredLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSkill1RequiredLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSkill1RequiredLevel.Location = new System.Drawing.Point(280, 20);
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
			this.btnSkill2RequiredID.Location = new System.Drawing.Point(156, -4);
			this.btnSkill2RequiredID.Name = "btnSkill2RequiredID";
			this.btnSkill2RequiredID.Size = new System.Drawing.Size(35, 23);
			this.btnSkill2RequiredID.TabIndex = 1046;
			this.btnSkill2RequiredID.UseVisualStyleBackColor = true;
			this.btnSkill2RequiredID.Visible = false;
			this.btnSkill2RequiredID.Click += new System.EventHandler(this.btnSkill2RequiredID_Click);
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label43.Location = new System.Drawing.Point(197, 0);
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
			this.tbSkill2RequiredLevel.Location = new System.Drawing.Point(258, -4);
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
			this.label44.Location = new System.Drawing.Point(69, 1);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(81, 13);
			this.label44.TabIndex = 1042;
			this.label44.Text = "Skill 2 Required";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label44.Visible = false;
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
			this.tbEffectDamage.Location = new System.Drawing.Point(52, 72);
			this.tbEffectDamage.Name = "tbEffectDamage";
			this.tbEffectDamage.Size = new System.Drawing.Size(135, 20);
			this.tbEffectDamage.TabIndex = 1011;
			this.tbEffectDamage.TextChanged += new System.EventHandler(this.tbEffectDamage_TextChanged);
			// 
			// tbEffectAttack
			// 
			this.tbEffectAttack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbEffectAttack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEffectAttack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbEffectAttack.Location = new System.Drawing.Point(52, 46);
			this.tbEffectAttack.Name = "tbEffectAttack";
			this.tbEffectAttack.Size = new System.Drawing.Size(135, 20);
			this.tbEffectAttack.TabIndex = 1010;
			this.tbEffectAttack.TextChanged += new System.EventHandler(this.tbEffectAttack_TextChanged);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label21.Location = new System.Drawing.Point(3, 76);
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
			this.label20.Location = new System.Drawing.Point(8, 50);
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
			this.label19.Location = new System.Drawing.Point(6, 23);
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
			this.tbEffectNormal.Location = new System.Drawing.Point(52, 19);
			this.tbEffectNormal.Name = "tbEffectNormal";
			this.tbEffectNormal.Size = new System.Drawing.Size(135, 20);
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
			this.groupBox4.Size = new System.Drawing.Size(161, 76);
			this.groupBox4.TabIndex = 1023;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "RvR Data";
			// 
			// cbRvRGradeSelector
			// 
			this.cbRvRGradeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbRvRGradeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.cbRvRValueSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			// gbQuestData
			// 
			this.gbQuestData.Controls.Add(this.cbSet0);
			this.gbQuestData.Controls.Add(this.lSet4);
			this.gbQuestData.Controls.Add(this.tbSet4);
			this.gbQuestData.Controls.Add(this.lSet3);
			this.gbQuestData.Controls.Add(this.tbSet3);
			this.gbQuestData.Controls.Add(this.lSet2);
			this.gbQuestData.Controls.Add(this.tbSet2);
			this.gbQuestData.Controls.Add(this.lSet1);
			this.gbQuestData.Controls.Add(this.tbSet1);
			this.gbQuestData.Controls.Add(this.lSet0);
			this.gbQuestData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gbQuestData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.gbQuestData.Location = new System.Drawing.Point(742, 83);
			this.gbQuestData.Name = "gbQuestData";
			this.gbQuestData.Size = new System.Drawing.Size(256, 103);
			this.gbQuestData.TabIndex = 1034;
			this.gbQuestData.TabStop = false;
			this.gbQuestData.Text = "Quest Data";
			this.gbQuestData.Visible = false;
			// 
			// cbSet0
			// 
			this.cbSet0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbSet0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSet0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbSet0.FormattingEnabled = true;
			this.cbSet0.Location = new System.Drawing.Point(48, 19);
			this.cbSet0.Name = "cbSet0";
			this.cbSet0.Size = new System.Drawing.Size(195, 21);
			this.cbSet0.TabIndex = 1042;
			this.cbSet0.SelectedIndexChanged += new System.EventHandler(this.cbQuestZoneID_SelectedIndexChanged);
			// 
			// lSet4
			// 
			this.lSet4.AutoSize = true;
			this.lSet4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lSet4.Location = new System.Drawing.Point(10, 76);
			this.lSet4.Name = "lSet4";
			this.lSet4.Size = new System.Drawing.Size(39, 13);
			this.lSet4.TabIndex = 1030;
			this.lSet4.Text = "Range";
			this.lSet4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSet4
			// 
			this.tbSet4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSet4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSet4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSet4.Location = new System.Drawing.Point(55, 72);
			this.tbSet4.Name = "tbSet4";
			this.tbSet4.Size = new System.Drawing.Size(187, 20);
			this.tbSet4.TabIndex = 1031;
			this.tbSet4.TextChanged += new System.EventHandler(this.tbSet4_TextChanged);
			// 
			// lSet3
			// 
			this.lSet3.AutoSize = true;
			this.lSet3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lSet3.Location = new System.Drawing.Point(184, 50);
			this.lSet3.Name = "lSet3";
			this.lSet3.Size = new System.Drawing.Size(14, 13);
			this.lSet3.TabIndex = 1028;
			this.lSet3.Text = "Y";
			this.lSet3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSet3
			// 
			this.tbSet3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSet3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSet3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSet3.Location = new System.Drawing.Point(203, 46);
			this.tbSet3.Name = "tbSet3";
			this.tbSet3.Size = new System.Drawing.Size(40, 20);
			this.tbSet3.TabIndex = 1029;
			this.tbSet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbSet3.TextChanged += new System.EventHandler(this.tbSet3_TextChanged);
			// 
			// lSet2
			// 
			this.lSet2.AutoSize = true;
			this.lSet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lSet2.Location = new System.Drawing.Point(97, 50);
			this.lSet2.Name = "lSet2";
			this.lSet2.Size = new System.Drawing.Size(14, 13);
			this.lSet2.TabIndex = 1026;
			this.lSet2.Text = "Z";
			this.lSet2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSet2
			// 
			this.tbSet2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSet2.Location = new System.Drawing.Point(116, 46);
			this.tbSet2.Name = "tbSet2";
			this.tbSet2.Size = new System.Drawing.Size(40, 20);
			this.tbSet2.TabIndex = 1027;
			this.tbSet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbSet2.TextChanged += new System.EventHandler(this.tbSet2_TextChanged);
			// 
			// lSet1
			// 
			this.lSet1.AutoSize = true;
			this.lSet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lSet1.Location = new System.Drawing.Point(10, 50);
			this.lSet1.Name = "lSet1";
			this.lSet1.Size = new System.Drawing.Size(14, 13);
			this.lSet1.TabIndex = 1024;
			this.lSet1.Text = "X";
			this.lSet1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbSet1
			// 
			this.tbSet1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbSet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbSet1.Location = new System.Drawing.Point(29, 46);
			this.tbSet1.Name = "tbSet1";
			this.tbSet1.Size = new System.Drawing.Size(40, 20);
			this.tbSet1.TabIndex = 1025;
			this.tbSet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbSet1.TextChanged += new System.EventHandler(this.tbSet1_TextChanged);
			// 
			// lSet0
			// 
			this.lSet0.AutoSize = true;
			this.lSet0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.lSet0.Location = new System.Drawing.Point(10, 23);
			this.lSet0.Name = "lSet0";
			this.lSet0.Size = new System.Drawing.Size(32, 13);
			this.lSet0.TabIndex = 1022;
			this.lSet0.Text = "Zone";
			this.lSet0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbSetData
			// 
			this.gbSetData.Controls.Add(this.btnSet4);
			this.gbSetData.Controls.Add(this.btnSet3);
			this.gbSetData.Controls.Add(this.btnSet2);
			this.gbSetData.Controls.Add(this.btnSet1);
			this.gbSetData.Controls.Add(this.btnSet0);
			this.gbSetData.Controls.Add(this.label30);
			this.gbSetData.Controls.Add(this.label33);
			this.gbSetData.Controls.Add(this.label34);
			this.gbSetData.Controls.Add(this.label35);
			this.gbSetData.Controls.Add(this.label36);
			this.gbSetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gbSetData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.gbSetData.Location = new System.Drawing.Point(742, 83);
			this.gbSetData.Name = "gbSetData";
			this.gbSetData.Size = new System.Drawing.Size(256, 171);
			this.gbSetData.TabIndex = 1043;
			this.gbSetData.TabStop = false;
			this.gbSetData.Text = "Set Data";
			// 
			// btnSet4
			// 
			this.btnSet4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSet4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSet4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSet4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSet4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSet4.Location = new System.Drawing.Point(30, 134);
			this.btnSet4.Name = "btnSet4";
			this.btnSet4.Size = new System.Drawing.Size(213, 23);
			this.btnSet4.TabIndex = 1091;
			this.btnSet4.UseVisualStyleBackColor = true;
			this.btnSet4.Click += new System.EventHandler(this.btnSet4_Click);
			// 
			// btnSet3
			// 
			this.btnSet3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSet3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSet3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSet3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSet3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSet3.Location = new System.Drawing.Point(30, 105);
			this.btnSet3.Name = "btnSet3";
			this.btnSet3.Size = new System.Drawing.Size(213, 23);
			this.btnSet3.TabIndex = 1090;
			this.btnSet3.UseVisualStyleBackColor = true;
			this.btnSet3.Click += new System.EventHandler(this.btnSet3_Click);
			// 
			// btnSet2
			// 
			this.btnSet2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSet2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSet2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSet2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSet2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSet2.Location = new System.Drawing.Point(29, 76);
			this.btnSet2.Name = "btnSet2";
			this.btnSet2.Size = new System.Drawing.Size(213, 23);
			this.btnSet2.TabIndex = 1089;
			this.btnSet2.UseVisualStyleBackColor = true;
			this.btnSet2.Click += new System.EventHandler(this.btnSet2_Click);
			// 
			// btnSet1
			// 
			this.btnSet1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSet1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSet1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSet1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSet1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSet1.Location = new System.Drawing.Point(29, 47);
			this.btnSet1.Name = "btnSet1";
			this.btnSet1.Size = new System.Drawing.Size(213, 23);
			this.btnSet1.TabIndex = 1088;
			this.btnSet1.UseVisualStyleBackColor = true;
			this.btnSet1.Click += new System.EventHandler(this.btnSet1_Click);
			// 
			// btnSet0
			// 
			this.btnSet0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnSet0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnSet0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnSet0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSet0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnSet0.Location = new System.Drawing.Point(29, 18);
			this.btnSet0.Name = "btnSet0";
			this.btnSet0.Size = new System.Drawing.Size(213, 23);
			this.btnSet0.TabIndex = 1087;
			this.btnSet0.UseVisualStyleBackColor = true;
			this.btnSet0.Click += new System.EventHandler(this.btnSet0_Click);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label30.Location = new System.Drawing.Point(10, 81);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(13, 13);
			this.label30.TabIndex = 1030;
			this.label30.Text = "2";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label33.Location = new System.Drawing.Point(10, 139);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(13, 13);
			this.label33.TabIndex = 1028;
			this.label33.Text = "4";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label34.Location = new System.Drawing.Point(10, 110);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(13, 13);
			this.label34.TabIndex = 1026;
			this.label34.Text = "3";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label35.Location = new System.Drawing.Point(10, 52);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(13, 13);
			this.label35.TabIndex = 1024;
			this.label35.Text = "1";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label36.Location = new System.Drawing.Point(10, 23);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(13, 13);
			this.label36.TabIndex = 1022;
			this.label36.Text = "0";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.groupBox7.Location = new System.Drawing.Point(886, 260);
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
			this.groupBox6.Location = new System.Drawing.Point(742, 260);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(138, 106);
			this.groupBox6.TabIndex = 1032;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Origin Reform Data";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label31.Location = new System.Drawing.Point(71, 76);
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
			this.tbVariation6.Location = new System.Drawing.Point(90, 72);
			this.tbVariation6.Name = "tbVariation6";
			this.tbVariation6.Size = new System.Drawing.Size(35, 20);
			this.tbVariation6.TabIndex = 1021;
			this.tbVariation6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation6.TextChanged += new System.EventHandler(this.tbVariation6_TextChanged);
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label32.Location = new System.Drawing.Point(71, 50);
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
			this.tbVariation5.Location = new System.Drawing.Point(90, 46);
			this.tbVariation5.Name = "tbVariation5";
			this.tbVariation5.Size = new System.Drawing.Size(35, 20);
			this.tbVariation5.TabIndex = 1019;
			this.tbVariation5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation5.TextChanged += new System.EventHandler(this.tbVariation5_TextChanged);
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label28.Location = new System.Drawing.Point(71, 23);
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
			this.tbVariation4.Location = new System.Drawing.Point(90, 19);
			this.tbVariation4.Name = "tbVariation4";
			this.tbVariation4.Size = new System.Drawing.Size(35, 20);
			this.tbVariation4.TabIndex = 1017;
			this.tbVariation4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation4.TextChanged += new System.EventHandler(this.tbVariation4_TextChanged);
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label29.Location = new System.Drawing.Point(10, 76);
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
			this.tbVariation3.Location = new System.Drawing.Point(29, 72);
			this.tbVariation3.Name = "tbVariation3";
			this.tbVariation3.Size = new System.Drawing.Size(35, 20);
			this.tbVariation3.TabIndex = 1015;
			this.tbVariation3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation3.TextChanged += new System.EventHandler(this.tbVariation3_TextChanged);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label27.Location = new System.Drawing.Point(10, 50);
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
			this.tbVariation2.Location = new System.Drawing.Point(29, 46);
			this.tbVariation2.Name = "tbVariation2";
			this.tbVariation2.Size = new System.Drawing.Size(35, 20);
			this.tbVariation2.TabIndex = 1013;
			this.tbVariation2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation2.TextChanged += new System.EventHandler(this.tbVariation2_TextChanged);
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label26.Location = new System.Drawing.Point(10, 23);
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
			this.tbVariation1.Location = new System.Drawing.Point(29, 19);
			this.tbVariation1.Name = "tbVariation1";
			this.tbVariation1.Size = new System.Drawing.Size(35, 20);
			this.tbVariation1.TabIndex = 1011;
			this.tbVariation1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbVariation1.TextChanged += new System.EventHandler(this.tbVariation1_TextChanged);
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label25.Location = new System.Drawing.Point(842, 62);
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
			this.btnItemFlag.Location = new System.Drawing.Point(898, 57);
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
			this.lAllowedZone.Location = new System.Drawing.Point(658, 62);
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
			this.btnAllowedZoneFlag.Location = new System.Drawing.Point(736, 57);
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
			this.cbCastleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCastleType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbCastleType.FormattingEnabled = true;
			this.cbCastleType.Location = new System.Drawing.Point(659, 30);
			this.cbCastleType.Name = "cbCastleType";
			this.cbCastleType.Size = new System.Drawing.Size(100, 21);
			this.cbCastleType.TabIndex = 1027;
			this.cbCastleType.SelectedIndexChanged += new System.EventHandler(this.cbCastleType_SelectedIndexChanged);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label23.Location = new System.Drawing.Point(590, 34);
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
			this.label22.Location = new System.Drawing.Point(524, 62);
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
			this.btnClassFlag.Location = new System.Drawing.Point(602, 57);
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
			this.label14.Location = new System.Drawing.Point(892, 10);
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
			this.tbDurability.Location = new System.Drawing.Point(948, 6);
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
			this.label13.Location = new System.Drawing.Point(776, 10);
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
			this.tbMaxLevel.Location = new System.Drawing.Point(838, 6);
			this.tbMaxLevel.Name = "tbMaxLevel";
			this.tbMaxLevel.Size = new System.Drawing.Size(45, 20);
			this.tbMaxLevel.TabIndex = 1017;
			this.tbMaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbMaxLevel.TextChanged += new System.EventHandler(this.tbMaxLevel_TextChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label12.Location = new System.Drawing.Point(666, 10);
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
			this.tbMinLevel.Location = new System.Drawing.Point(725, 6);
			this.tbMinLevel.Name = "tbMinLevel";
			this.tbMinLevel.Size = new System.Drawing.Size(45, 20);
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
			this.tbPrice.Size = new System.Drawing.Size(80, 20);
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
			this.cbWearingPositionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWearingPositionSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbWearingPositionSelector.FormattingEnabled = true;
			this.cbWearingPositionSelector.Location = new System.Drawing.Point(860, 30);
			this.cbWearingPositionSelector.Name = "cbWearingPositionSelector";
			this.cbWearingPositionSelector.Size = new System.Drawing.Size(138, 21);
			this.cbWearingPositionSelector.TabIndex = 16;
			this.cbWearingPositionSelector.SelectedIndexChanged += new System.EventHandler(this.cbWearingPositionSelector_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.label7.Location = new System.Drawing.Point(768, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 13);
			this.label7.TabIndex = 1005;
			this.label7.Text = "Wearing Position";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbSubTypeSelector
			// 
			this.cbSubTypeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.cbSubTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.cbTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTypeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbTypeSelector.FormattingEnabled = true;
			this.cbTypeSelector.Location = new System.Drawing.Point(305, 56);
			this.cbTypeSelector.Name = "cbTypeSelector";
			this.cbTypeSelector.Size = new System.Drawing.Size(213, 21);
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
			this.cbNationSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
			this.btnCopy.Location = new System.Drawing.Point(144, 545);
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
			this.btnDelete.Location = new System.Drawing.Point(210, 545);
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
			this.tbSearch.Text = "11016";
			this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
			// 
			// cbRenderDialog
			// 
			this.cbRenderDialog.AutoSize = true;
			this.cbRenderDialog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbRenderDialog.Location = new System.Drawing.Point(12, 574);
			this.cbRenderDialog.Name = "cbRenderDialog";
			this.cbRenderDialog.Size = new System.Drawing.Size(94, 17);
			this.cbRenderDialog.TabIndex = 1044;
			this.cbRenderDialog.Text = "Render Dialog";
			this.cbRenderDialog.UseVisualStyleBackColor = true;
			this.cbRenderDialog.CheckedChanged += new System.EventHandler(this.cbRenderDialog_CheckedChanged);
			// 
			// cbAutoLoadFortuneData
			// 
			this.cbAutoLoadFortuneData.AutoSize = true;
			this.cbAutoLoadFortuneData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.cbAutoLoadFortuneData.Location = new System.Drawing.Point(130, 574);
			this.cbAutoLoadFortuneData.Name = "cbAutoLoadFortuneData";
			this.cbAutoLoadFortuneData.Size = new System.Drawing.Size(140, 17);
			this.cbAutoLoadFortuneData.TabIndex = 1045;
			this.cbAutoLoadFortuneData.Text = "Auto Load Fortune Data";
			this.cbAutoLoadFortuneData.UseVisualStyleBackColor = true;
			this.cbAutoLoadFortuneData.CheckedChanged += new System.EventHandler(this.cbAutoLoadFortuneData_CheckedChanged);
			// 
			// ItemEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.ClientSize = new System.Drawing.Size(1320, 600);
			this.Controls.Add(this.cbAutoLoadFortuneData);
			this.Controls.Add(this.cbRenderDialog);
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.MainList);
			this.Controls.Add(this.btnAddNew);
			this.Controls.Add(this.btnReload);
			this.Controls.Add(this.GeneralPanel);
			this.Controls.Add(this.groupBox1);
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MinimumSize = new System.Drawing.Size(1336, 639);
			this.Name = "ItemEditor";
			this.Text = "Item Editor";
			this.Load += new System.EventHandler(this.ItemEditor_LoadAsync);
			this.groupBox1.ResumeLayout(false);
			this.GeneralPanel.ResumeLayout(false);
			this.GeneralPanel.PerformLayout();
			this.gbFortune.ResumeLayout(false);
			this.gbFortune.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridFortune)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gbQuestData.ResumeLayout(false);
			this.gbQuestData.PerformLayout();
			this.gbSetData.ResumeLayout(false);
			this.gbSetData.PerformLayout();
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
        private GroupBox gbQuestData;
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
        private Label lSet0;
        private Label lSet1;
        private TextBox tbSet1;
        private Label lSet2;
        private TextBox tbSet2;
        private Label lSet4;
        private TextBox tbSet4;
        private Label lSet3;
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
        private Label label42;
        private TextBox tbSkill1RequiredLevel;
        private Label label9;
        private Label label43;
        private TextBox tbSkill2RequiredLevel;
        private Label label44;
        private Button btnSkill1RequiredID;
        private Button btnSkill2RequiredID;
        private TextBox tbAllowedZoneFlag;
        private Label label45;
        private TextBox tbItem0RequiredAmount;
        private Button btnItem0Required;
        private Label label24;
        private Label label62;
        private TextBox tbItem9RequiredAmount;
        private Button btnItem9Required;
        private Label label63;
        private Label label60;
        private TextBox tbItem8RequiredAmount;
        private Button btnItem8Required;
        private Label label61;
        private Label label58;
        private TextBox tbItem7RequiredAmount;
        private Button btnItem7Required;
        private Label label59;
        private Label label56;
        private TextBox tbItem6RequiredAmount;
        private Button btnItem6Required;
        private Label label57;
        private Label label50;
        private TextBox tbItem5RequiredAmount;
        private Button btnItem5Required;
        private Label label51;
        private Label label52;
        private TextBox tbItem4RequiredAmount;
        private Button btnItem4Required;
        private Label label53;
        private Label label54;
        private TextBox tbItem3RequiredAmount;
        private Button btnItem3Required;
        private Label label55;
        private Label label48;
        private TextBox tbItem2RequiredAmount;
        private Button btnItem2Required;
        private Label label49;
        private Label label46;
        private TextBox tbItem1RequiredAmount;
        private Button btnItem1Required;
        private Label label47;
        private GroupBox groupBox3;
        private Label lRareProb3Percentage;
        private Label lRareProbType3;
        private TextBox tbRareProb3;
        private Button btnRareIndex3;
        private Label label65;
        private Label lRareProb9Percentage;
        private Button btnRareIndex9;
        private Label lRareProbType9;
        private Label label81;
        private TextBox tbRareProb9;
        private Label lRareProb5Percentage;
        private Button btnRareIndex5;
        private Label lRareProbType5;
        private Label label84;
        private TextBox tbRareProb5;
        private Label lRareProb6Percentage;
        private Button btnRareIndex6;
        private Label lRareProbType6;
        private Label label87;
        private TextBox tbRareProb6;
        private Label lRareProb7Percentage;
        private Button btnRareIndex7;
        private Label lRareProbType7;
        private Label label90;
        private TextBox tbRareProb7;
        private Label lRareProb8Percentage;
        private Button btnRareIndex8;
        private Label lRareProbType8;
        private Label label93;
        private TextBox tbRareProb8;
        private Label lRareProb4Percentage;
        private Button btnRareIndex4;
        private Label lRareProbType4;
        private Label label78;
        private TextBox tbRareProb4;
        private Label lRareProb0Percentage;
        private Button btnRareIndex0;
        private Label lRareProbType0;
        private Label label72;
        private TextBox tbRareProb0;
        private Label lRareProb1Percentage;
        private Button btnRareIndex1;
        private Label lRareProbType1;
        private Label label75;
        private TextBox tbRareProb1;
        private Label lRareProb2Percentage;
        private Button btnRareIndex2;
        private Label lRareProbType2;
        private Label label69;
        private TextBox tbRareProb2;
        private GroupBox gbFortune;
        private ComboBox cbGrade;
        private ComboBox cbSet0;
        private GroupBox gbSetData;
        private Label label30;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Button btnSet1;
        private Button btnSet0;
        private Button btnSet2;
        private Button btnSet4;
        private Button btnSet3;
		private DataGridView gridFortune;
		private CheckBox cbFortuneEnable;
		private ComboBox cbFortuneProbType;
		private Button btnAddFortune;
		private Label lProbType;
		private RichTextBox rtFortuneWarning;
		private CheckBox cbRenderDialog;
		private CheckBox cbAutoLoadFortuneData;
	}
}
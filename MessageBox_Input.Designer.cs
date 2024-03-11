namespace LastChaos_ToolBox_2024
{
	partial class MessageBox_Input
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
			this.btnOk = new System.Windows.Forms.Button();
			this.tbInput = new System.Windows.Forms.TextBox();
			this.rtbMessage = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(85)))), ((int)(((byte)(76)))));
			this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.btnOk.Location = new System.Drawing.Point(213, 56);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(59, 23);
			this.btnOk.TabIndex = 1012;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// tbInput
			// 
			this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
			this.tbInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.tbInput.Location = new System.Drawing.Point(12, 30);
			this.tbInput.Name = "tbInput";
			this.tbInput.Size = new System.Drawing.Size(260, 20);
			this.tbInput.TabIndex = 1013;
			// 
			// rtbMessage
			// 
			this.rtbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
			this.rtbMessage.Location = new System.Drawing.Point(12, 10);
			this.rtbMessage.Name = "rtbMessage";
			this.rtbMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbMessage.Size = new System.Drawing.Size(260, 14);
			this.rtbMessage.TabIndex = 1015;
			this.rtbMessage.Text = "Message";
			// 
			// MessageBox_Input
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(56)))), ((int)(((byte)(54)))));
			this.ClientSize = new System.Drawing.Size(284, 91);
			this.Controls.Add(this.rtbMessage);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tbInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MessageBox_Input";
			this.ShowInTaskbar = false;
			this.Text = "User Input";
			this.Load += new System.EventHandler(this.MessageBox_Input_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.RichTextBox rtbMessage;
	}
}
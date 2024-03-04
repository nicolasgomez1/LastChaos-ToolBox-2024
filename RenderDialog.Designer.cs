namespace LastChaos_ToolBox_2024
{
    partial class RenderDialog
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
            this.panel3DView = new System.Windows.Forms.Panel();
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.cbRotation = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel3DView
            // 
            this.panel3DView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3DView.Location = new System.Drawing.Point(12, 12);
            this.panel3DView.Name = "panel3DView";
            this.panel3DView.Size = new System.Drawing.Size(230, 230);
            this.panel3DView.TabIndex = 3;
            // 
            // timerRender
            // 
            this.timerRender.Interval = 1;
            this.timerRender.Tick += new System.EventHandler(this.timerRender_Tick);
            // 
            // cbRotation
            // 
            this.cbRotation.AutoSize = true;
            this.cbRotation.Checked = true;
            this.cbRotation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRotation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.cbRotation.Location = new System.Drawing.Point(12, 248);
            this.cbRotation.Name = "cbRotation";
            this.cbRotation.Size = new System.Drawing.Size(66, 17);
            this.cbRotation.TabIndex = 4;
            this.cbRotation.Text = "Rotation";
            this.cbRotation.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(203)))), ((int)(((byte)(148)))));
            this.label4.Location = new System.Drawing.Point(83, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Wheel Zoom Or + Ctrl  ↕ Shift ↔";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RenderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(254, 271);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRotation);
            this.Controls.Add(this.panel3DView);
            this.Icon = global::LastChaos_ToolBox_2024.Properties.Resources.NG;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenderDialog";
            this.Text = "Render";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RenderDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3DView;
        private System.Windows.Forms.Timer timerRender;
        private System.Windows.Forms.CheckBox cbRotation;
        private System.Windows.Forms.Label label4;
    }
}
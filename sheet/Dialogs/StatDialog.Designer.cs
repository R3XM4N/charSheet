namespace sheet.Dialogs
{
    partial class StatDialog
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
            this.statPanel = new System.Windows.Forms.Panel();
            this.throwPanel = new System.Windows.Forms.Panel();
            this.skillPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statPanel
            // 
            this.statPanel.AutoScroll = true;
            this.statPanel.Location = new System.Drawing.Point(25, 91);
            this.statPanel.Name = "statPanel";
            this.statPanel.Size = new System.Drawing.Size(282, 517);
            this.statPanel.TabIndex = 0;
            // 
            // throwPanel
            // 
            this.throwPanel.AutoScroll = true;
            this.throwPanel.Location = new System.Drawing.Point(313, 91);
            this.throwPanel.Name = "throwPanel";
            this.throwPanel.Size = new System.Drawing.Size(282, 517);
            this.throwPanel.TabIndex = 1;
            // 
            // skillPanel
            // 
            this.skillPanel.AutoScroll = true;
            this.skillPanel.Location = new System.Drawing.Point(601, 91);
            this.skillPanel.Name = "skillPanel";
            this.skillPanel.Size = new System.Drawing.Size(282, 517);
            this.skillPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(907, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "I swear to god if you input a string i will break your nico nico kneecaps also wi" +
    "ll if you write proefficency ones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stats";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(389, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Throws";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(696, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 37);
            this.label4.TabIndex = 5;
            this.label4.Text = "Skills";
            // 
            // StatDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(908, 620);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skillPanel);
            this.Controls.Add(this.throwPanel);
            this.Controls.Add(this.statPanel);
            this.Name = "StatDialog";
            this.Text = "StatDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel statPanel;
        private System.Windows.Forms.Panel throwPanel;
        private System.Windows.Forms.Panel skillPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
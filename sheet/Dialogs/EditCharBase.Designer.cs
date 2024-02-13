namespace sheet.Dialogs
{
    partial class EditCharBase
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
            this.label36 = new System.Windows.Forms.Label();
            this.lvlBox = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.classBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.raceBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.charNameBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.xpBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Arial", 12F);
            this.label36.Location = new System.Drawing.Point(203, 90);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 23);
            this.label36.TabIndex = 18;
            this.label36.Text = "LVL";
            // 
            // lvlBox
            // 
            this.lvlBox.Font = new System.Drawing.Font("Arial", 22F);
            this.lvlBox.Location = new System.Drawing.Point(203, 109);
            this.lvlBox.Name = "lvlBox";
            this.lvlBox.ReadOnly = true;
            this.lvlBox.Size = new System.Drawing.Size(49, 50);
            this.lvlBox.TabIndex = 17;
            this.lvlBox.Text = "0";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 12F);
            this.label35.Location = new System.Drawing.Point(14, 90);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(59, 23);
            this.label35.TabIndex = 16;
            this.label35.Text = "Class";
            // 
            // classBox
            // 
            this.classBox.Font = new System.Drawing.Font("Arial", 22F);
            this.classBox.Location = new System.Drawing.Point(17, 109);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(180, 50);
            this.classBox.TabIndex = 15;
            this.classBox.Text = "test man";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.Location = new System.Drawing.Point(332, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Race";
            // 
            // raceBox
            // 
            this.raceBox.Font = new System.Drawing.Font("Arial", 22F);
            this.raceBox.Location = new System.Drawing.Point(332, 46);
            this.raceBox.Name = "raceBox";
            this.raceBox.Size = new System.Drawing.Size(187, 50);
            this.raceBox.TabIndex = 13;
            this.raceBox.Text = "Human";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F);
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Character name:";
            // 
            // charNameBox
            // 
            this.charNameBox.Font = new System.Drawing.Font("Arial", 22F);
            this.charNameBox.Location = new System.Drawing.Point(17, 46);
            this.charNameBox.Name = "charNameBox";
            this.charNameBox.Size = new System.Drawing.Size(309, 50);
            this.charNameBox.TabIndex = 11;
            this.charNameBox.Text = "Sir tom tommington";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(258, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "XP";
            // 
            // xpBox
            // 
            this.xpBox.Font = new System.Drawing.Font("Arial", 22F);
            this.xpBox.Location = new System.Drawing.Point(258, 109);
            this.xpBox.Name = "xpBox";
            this.xpBox.Size = new System.Drawing.Size(115, 50);
            this.xpBox.TabIndex = 20;
            this.xpBox.Text = "0";
            // 
            // EditCharBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 203);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xpBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.lvlBox);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.classBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.raceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.charNameBox);
            this.Name = "EditCharBase";
            this.Text = "CreateCharacterDialog";
            this.Load += new System.EventHandler(this.EditCharBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox lvlBox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox classBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox raceBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox charNameBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xpBox;
    }
}
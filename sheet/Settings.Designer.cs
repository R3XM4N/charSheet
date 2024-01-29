namespace sheet
{
    partial class Settings
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
            this.txt_ocname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chb_autoload = new System.Windows.Forms.CheckBox();
            this.alc_gb = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_sort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.chb_menuskip = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.br_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.alc_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ocname
            // 
            this.txt_ocname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ocname.Location = new System.Drawing.Point(12, 12);
            this.txt_ocname.Name = "txt_ocname";
            this.txt_ocname.Size = new System.Drawing.Size(198, 31);
            this.txt_ocname.TabIndex = 0;
            this.txt_ocname.TextChanged += new System.EventHandler(this.txt_ocname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name";
            // 
            // chb_autoload
            // 
            this.chb_autoload.AutoSize = true;
            this.chb_autoload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_autoload.Location = new System.Drawing.Point(12, 49);
            this.chb_autoload.Name = "chb_autoload";
            this.chb_autoload.Size = new System.Drawing.Size(171, 28);
            this.chb_autoload.TabIndex = 2;
            this.chb_autoload.Text = "auto-load heroes";
            this.chb_autoload.UseVisualStyleBackColor = true;
            this.chb_autoload.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // alc_gb
            // 
            this.alc_gb.Controls.Add(this.label3);
            this.alc_gb.Controls.Add(this.cb_sort);
            this.alc_gb.Controls.Add(this.label2);
            this.alc_gb.Controls.Add(this.txt_path);
            this.alc_gb.Controls.Add(this.chb_menuskip);
            this.alc_gb.Enabled = false;
            this.alc_gb.Location = new System.Drawing.Point(12, 83);
            this.alc_gb.Name = "alc_gb";
            this.alc_gb.Size = new System.Drawing.Size(271, 130);
            this.alc_gb.TabIndex = 3;
            this.alc_gb.TabStop = false;
            this.alc_gb.Text = "auto-load conf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "sort heroes by";
            // 
            // cb_sort
            // 
            this.cb_sort.FormattingEnabled = true;
            this.cb_sort.Items.AddRange(new object[] {
            "Level",
            "Name",
            "Race",
            "Class"});
            this.cb_sort.Location = new System.Drawing.Point(6, 94);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(121, 21);
            this.cb_sort.TabIndex = 4;
            this.cb_sort.SelectedIndexChanged += new System.EventHandler(this.cb_sort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "heroes directory";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(6, 53);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(259, 20);
            this.txt_path.TabIndex = 4;
            this.txt_path.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // chb_menuskip
            // 
            this.chb_menuskip.AutoSize = true;
            this.chb_menuskip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_menuskip.Location = new System.Drawing.Point(6, 19);
            this.chb_menuskip.Name = "chb_menuskip";
            this.chb_menuskip.Size = new System.Drawing.Size(184, 28);
            this.chb_menuskip.TabIndex = 4;
            this.chb_menuskip.Text = "Skip menu on start";
            this.chb_menuskip.UseVisualStyleBackColor = true;
            this.chb_menuskip.CheckedChanged += new System.EventHandler(this.chb_menuskip_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "IDK co všechno dát do Settings XD";
            // 
            // br_folder
            // 
            this.br_folder.Description = "Heroes složka";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.alc_gb);
            this.Controls.Add(this.chb_autoload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ocname);
            this.Name = "Settings";
            this.Text = "Settings";
            this.alc_gb.ResumeLayout(false);
            this.alc_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ocname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_autoload;
        private System.Windows.Forms.GroupBox alc_gb;
        private System.Windows.Forms.CheckBox chb_menuskip;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_sort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog br_folder;
    }
}
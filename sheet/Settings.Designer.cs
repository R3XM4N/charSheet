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
            this.br_folder = new System.Windows.Forms.FolderBrowserDialog();
            this.chb_autosave = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.alc_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ocname
            // 
            this.txt_ocname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_ocname.Location = new System.Drawing.Point(18, 18);
            this.txt_ocname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_ocname.Name = "txt_ocname";
            this.txt_ocname.Size = new System.Drawing.Size(295, 43);
            this.txt_ocname.TabIndex = 0;
            this.txt_ocname.TextChanged += new System.EventHandler(this.txt_ocname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name";
            // 
            // chb_autoload
            // 
            this.chb_autoload.AutoSize = true;
            this.chb_autoload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_autoload.Location = new System.Drawing.Point(18, 75);
            this.chb_autoload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chb_autoload.Name = "chb_autoload";
            this.chb_autoload.Size = new System.Drawing.Size(259, 37);
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
            this.alc_gb.Location = new System.Drawing.Point(18, 128);
            this.alc_gb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alc_gb.Name = "alc_gb";
            this.alc_gb.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alc_gb.Size = new System.Drawing.Size(406, 190);
            this.alc_gb.TabIndex = 3;
            this.alc_gb.TabStop = false;
            this.alc_gb.Text = "auto-load conf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
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
            this.cb_sort.Location = new System.Drawing.Point(9, 145);
            this.cb_sort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(180, 28);
            this.cb_sort.TabIndex = 4;
            this.cb_sort.SelectedIndexChanged += new System.EventHandler(this.cb_sort_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "heroes directory";
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(9, 82);
            this.txt_path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(386, 26);
            this.txt_path.TabIndex = 4;
            this.txt_path.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // chb_menuskip
            // 
            this.chb_menuskip.AutoSize = true;
            this.chb_menuskip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_menuskip.Location = new System.Drawing.Point(9, 29);
            this.chb_menuskip.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chb_menuskip.Name = "chb_menuskip";
            this.chb_menuskip.Size = new System.Drawing.Size(284, 37);
            this.chb_menuskip.TabIndex = 4;
            this.chb_menuskip.Text = "Skip menu on start";
            this.chb_menuskip.UseVisualStyleBackColor = true;
            this.chb_menuskip.CheckedChanged += new System.EventHandler(this.chb_menuskip_CheckedChanged);
            // 
            // br_folder
            // 
            this.br_folder.Description = "Heroes složka";
            // 
            // chb_autosave
            // 
            this.chb_autosave.AutoSize = true;
            this.chb_autosave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chb_autosave.Location = new System.Drawing.Point(18, 347);
            this.chb_autosave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chb_autosave.Name = "chb_autosave";
            this.chb_autosave.Size = new System.Drawing.Size(248, 37);
            this.chb_autosave.TabIndex = 4;
            this.chb_autosave.Text = "auto-save sheet";
            this.chb_autosave.UseVisualStyleBackColor = true;
            this.chb_autosave.CheckedChanged += new System.EventHandler(this.chb_autosave_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(18, 393);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(248, 69);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 10;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(272, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "auto-save frequency";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "10 s";
            this.label5.Visible = false;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 632);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.chb_autosave);
            this.Controls.Add(this.alc_gb);
            this.Controls.Add(this.chb_autoload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ocname);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Settings";
            this.Text = "Settings";
            this.alc_gb.ResumeLayout(false);
            this.alc_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.FolderBrowserDialog br_folder;
        private System.Windows.Forms.CheckBox chb_autosave;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
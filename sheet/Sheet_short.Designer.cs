namespace sheet
{
    partial class Sheet_short
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_rccl = new System.Windows.Forms.Label();
            this.lbl_lvl = new System.Windows.Forms.Label();
            this.lbl_xp = new System.Windows.Forms.Label();
            this.gp_money = new System.Windows.Forms.GroupBox();
            this.lbl_pp = new System.Windows.Forms.Label();
            this.lbl_gp = new System.Windows.Forms.Label();
            this.lbl_ep = new System.Windows.Forms.Label();
            this.lbl_sp = new System.Windows.Forms.Label();
            this.lbl_cp = new System.Windows.Forms.Label();
            this.xp_bar = new System.Windows.Forms.ProgressBar();
            this.lbl_maxhp = new System.Windows.Forms.Label();
            this.lbl_hp = new System.Windows.Forms.Label();
            this.pb_avatar = new System.Windows.Forms.PictureBox();
            this.lbl_bg = new System.Windows.Forms.Label();
            this.lbl_alm = new System.Windows.Forms.Label();
            this.gp_money.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.Location = new System.Drawing.Point(118, 13);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(120, 25);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "Hero Name";
            // 
            // lbl_rccl
            // 
            this.lbl_rccl.AutoSize = true;
            this.lbl_rccl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_rccl.Location = new System.Drawing.Point(120, 38);
            this.lbl_rccl.Name = "lbl_rccl";
            this.lbl_rccl.Size = new System.Drawing.Size(75, 16);
            this.lbl_rccl.TabIndex = 1;
            this.lbl_rccl.Text = "Race class";
            // 
            // lbl_lvl
            // 
            this.lbl_lvl.AutoSize = true;
            this.lbl_lvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_lvl.Location = new System.Drawing.Point(119, 118);
            this.lbl_lvl.Name = "lbl_lvl";
            this.lbl_lvl.Size = new System.Drawing.Size(46, 20);
            this.lbl_lvl.TabIndex = 2;
            this.lbl_lvl.Text = "Level";
            // 
            // lbl_xp
            // 
            this.lbl_xp.AutoSize = true;
            this.lbl_xp.Location = new System.Drawing.Point(12, 141);
            this.lbl_xp.Name = "lbl_xp";
            this.lbl_xp.Size = new System.Drawing.Size(21, 13);
            this.lbl_xp.TabIndex = 3;
            this.lbl_xp.Text = "XP";
            this.lbl_xp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_money
            // 
            this.gp_money.Controls.Add(this.lbl_pp);
            this.gp_money.Controls.Add(this.lbl_gp);
            this.gp_money.Controls.Add(this.lbl_ep);
            this.gp_money.Controls.Add(this.lbl_sp);
            this.gp_money.Controls.Add(this.lbl_cp);
            this.gp_money.Location = new System.Drawing.Point(264, 13);
            this.gp_money.Name = "gp_money";
            this.gp_money.Size = new System.Drawing.Size(69, 97);
            this.gp_money.TabIndex = 5;
            this.gp_money.TabStop = false;
            this.gp_money.Text = "Money";
            // 
            // lbl_pp
            // 
            this.lbl_pp.AutoSize = true;
            this.lbl_pp.Location = new System.Drawing.Point(7, 72);
            this.lbl_pp.Name = "lbl_pp";
            this.lbl_pp.Size = new System.Drawing.Size(24, 13);
            this.lbl_pp.TabIndex = 2;
            this.lbl_pp.Text = "PP:";
            // 
            // lbl_gp
            // 
            this.lbl_gp.AutoSize = true;
            this.lbl_gp.Location = new System.Drawing.Point(7, 59);
            this.lbl_gp.Name = "lbl_gp";
            this.lbl_gp.Size = new System.Drawing.Size(25, 13);
            this.lbl_gp.TabIndex = 2;
            this.lbl_gp.Text = "GP:";
            // 
            // lbl_ep
            // 
            this.lbl_ep.AutoSize = true;
            this.lbl_ep.Location = new System.Drawing.Point(7, 46);
            this.lbl_ep.Name = "lbl_ep";
            this.lbl_ep.Size = new System.Drawing.Size(24, 13);
            this.lbl_ep.TabIndex = 2;
            this.lbl_ep.Text = "EP:";
            // 
            // lbl_sp
            // 
            this.lbl_sp.AutoSize = true;
            this.lbl_sp.Location = new System.Drawing.Point(7, 33);
            this.lbl_sp.Name = "lbl_sp";
            this.lbl_sp.Size = new System.Drawing.Size(24, 13);
            this.lbl_sp.TabIndex = 1;
            this.lbl_sp.Text = "SP:";
            // 
            // lbl_cp
            // 
            this.lbl_cp.AutoSize = true;
            this.lbl_cp.Location = new System.Drawing.Point(7, 20);
            this.lbl_cp.Name = "lbl_cp";
            this.lbl_cp.Size = new System.Drawing.Size(24, 13);
            this.lbl_cp.TabIndex = 0;
            this.lbl_cp.Text = "CP:";
            // 
            // xp_bar
            // 
            this.xp_bar.Location = new System.Drawing.Point(13, 115);
            this.xp_bar.Name = "xp_bar";
            this.xp_bar.Size = new System.Drawing.Size(100, 23);
            this.xp_bar.TabIndex = 6;
            // 
            // lbl_maxhp
            // 
            this.lbl_maxhp.AutoSize = true;
            this.lbl_maxhp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_maxhp.Location = new System.Drawing.Point(222, 121);
            this.lbl_maxhp.Name = "lbl_maxhp";
            this.lbl_maxhp.Size = new System.Drawing.Size(73, 15);
            this.lbl_maxhp.TabIndex = 7;
            this.lbl_maxhp.Text = "Max Health:";
            // 
            // lbl_hp
            // 
            this.lbl_hp.AutoSize = true;
            this.lbl_hp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_hp.Location = new System.Drawing.Point(224, 141);
            this.lbl_hp.Name = "lbl_hp";
            this.lbl_hp.Size = new System.Drawing.Size(46, 15);
            this.lbl_hp.TabIndex = 8;
            this.lbl_hp.Text = "Health:";
            // 
            // pb_avatar
            // 
            this.pb_avatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_avatar.Location = new System.Drawing.Point(12, 8);
            this.pb_avatar.Name = "pb_avatar";
            this.pb_avatar.Size = new System.Drawing.Size(100, 100);
            this.pb_avatar.TabIndex = 4;
            this.pb_avatar.TabStop = false;
            // 
            // lbl_bg
            // 
            this.lbl_bg.AutoSize = true;
            this.lbl_bg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_bg.Location = new System.Drawing.Point(120, 60);
            this.lbl_bg.Name = "lbl_bg";
            this.lbl_bg.Size = new System.Drawing.Size(73, 15);
            this.lbl_bg.TabIndex = 1;
            this.lbl_bg.Text = "Background";
            // 
            // lbl_alm
            // 
            this.lbl_alm.AutoSize = true;
            this.lbl_alm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_alm.Location = new System.Drawing.Point(120, 75);
            this.lbl_alm.Name = "lbl_alm";
            this.lbl_alm.Size = new System.Drawing.Size(55, 15);
            this.lbl_alm.TabIndex = 1;
            this.lbl_alm.Text = "Aligment";
            // 
            // Sheet_short
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 161);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_hp);
            this.Controls.Add(this.lbl_maxhp);
            this.Controls.Add(this.xp_bar);
            this.Controls.Add(this.gp_money);
            this.Controls.Add(this.pb_avatar);
            this.Controls.Add(this.lbl_xp);
            this.Controls.Add(this.lbl_lvl);
            this.Controls.Add(this.lbl_alm);
            this.Controls.Add(this.lbl_bg);
            this.Controls.Add(this.lbl_rccl);
            this.Controls.Add(this.lbl_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sheet_short";
            this.Text = "Sheet_short";
            this.gp_money.ResumeLayout(false);
            this.gp_money.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lbl_alm;
        public System.Windows.Forms.Label lbl_name;
        public System.Windows.Forms.Label lbl_rccl;
        public System.Windows.Forms.Label lbl_lvl;
        public System.Windows.Forms.Label lbl_xp;
        public System.Windows.Forms.PictureBox pb_avatar;
        public System.Windows.Forms.GroupBox gp_money;
        public System.Windows.Forms.Label lbl_pp;
        public System.Windows.Forms.Label lbl_gp;
        public System.Windows.Forms.Label lbl_ep;
        public System.Windows.Forms.Label lbl_sp;
        public System.Windows.Forms.Label lbl_cp;
        public System.Windows.Forms.ProgressBar xp_bar;
        public System.Windows.Forms.Label lbl_maxhp;
        public System.Windows.Forms.Label lbl_hp;
        public System.Windows.Forms.Label lbl_bg;
    }
}
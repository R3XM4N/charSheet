namespace sheet
{
    partial class Heroes
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
            this.btn_nhero = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p_heroes = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_nhero
            // 
            this.btn_nhero.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_nhero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nhero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_nhero.Location = new System.Drawing.Point(0, 457);
            this.btn_nhero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_nhero.Name = "btn_nhero";
            this.btn_nhero.Size = new System.Drawing.Size(876, 92);
            this.btn_nhero.TabIndex = 4;
            this.btn_nhero.Text = "New Hero";
            this.btn_nhero.UseVisualStyleBackColor = true;
            this.btn_nhero.Click += new System.EventHandler(this.btn_nhero_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.p_heroes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 457);
            this.panel1.TabIndex = 5;
            // 
            // p_heroes
            // 
            this.p_heroes.AutoScroll = true;
            this.p_heroes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_heroes.Location = new System.Drawing.Point(0, 0);
            this.p_heroes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.p_heroes.Name = "p_heroes";
            this.p_heroes.Size = new System.Drawing.Size(876, 457);
            this.p_heroes.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_delete.Location = new System.Drawing.Point(0, 549);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(876, 83);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Heroes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 632);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_nhero);
            this.Controls.Add(this.btn_delete);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Heroes";
            this.ShowIcon = false;
            this.Text = "Heroes";
            this.Load += new System.EventHandler(this.Heroes_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_nhero;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.FlowLayoutPanel p_heroes;
    }
}
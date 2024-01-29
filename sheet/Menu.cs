using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet
{
    public partial class Menu : Form
    {
        public Settings settings = new Settings();
        public Menu()
        {
            InitializeComponent();
        }

        protected void changeFormInPanel(Form form)
        {
            Panel p = this.panel_display;
            if (p.Controls.Count > 0)
                p.Controls.RemoveAt(0);
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Width = this.Width-200;
            form.Height = this.Height;
            p.Controls.Add(form);
            p.Tag = form;
            form.Show();
        }

        private void btn_heroes_Click(object sender, EventArgs e)
        {
            // otevře form "Heroes" s tabulkou hrdinů
            changeFormInPanel(new Heroes());
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            // otevře form "Settings" s nastavením
            changeFormInPanel(settings);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // ukončí aplikaci
            //Application.Exit();

            //:)
            CharSheet form = new CharSheet();
            form.ShowDialog();
        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            // otevře form "Roll" s kostkami a výsledky
            changeFormInPanel(new Roll());
        }
    }
}

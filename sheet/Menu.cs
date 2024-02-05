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
        public Menu()
        {
            InitializeComponent();
            check_Settings();
        }

        private void check_Settings()
        {
            bool skipmenu = Properties.Settings.Default.skipmenu;
            if(skipmenu)
            {
                // načíst hrdiny z databáze
                changeFormInPanel(new Heroes());
            }
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
            changeFormInPanel(new Settings());
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // ukončí aplikaci
            Application.Exit();   
        }

        private void btn_roll_Click(object sender, EventArgs e)
        {
            // otevře form "Roll" s kostkami a výsledky
            changeFormInPanel(new Roll());
        }
        //temporary yoink pro debug :)
        private void DEBUGSHEET(object sender, EventArgs e)
        {
            CharSheet sheeet = new CharSheet();
            sheeet.Show();
        }
    }
}

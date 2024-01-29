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
    public partial class Heroes : Form
    {
        public Heroes()
        {
            InitializeComponent();
        }

        private void Heroes_Load(object sender, EventArgs e)
        {
            // použij form "Hero Short" a vlož ho do tabulky, maybe ještě sortnout podle jména či tak něco (v nastavení by to mělo být)
            // vložit do tabulky všechny hrdiny z databáze přidat event handler na kliknutí na form
            // při kliknutí na form se otevře form "Sheet" s daným hrdinou

            for (int i = 0; i < 10; i++)
            {
                add_miniSheet(p_heroes);
            }
        }



        private void add_miniSheet(Panel p)
        {

            // vytvořit form "Hero Short" a vložit ho do panelu
            // při kliknutí na form se otevře form "Sheet" s daným hrdinou
            Sheet_short miniSheet = new Sheet_short();
            miniSheet.TopLevel = false;
            miniSheet.Click += new EventHandler(hero_Click);
            // add this event handler to all controls in miniSheet will evoke click event on miniSheet
            foreach (Control c in miniSheet.Controls)
            {
                c.Click += new EventHandler(subcontrol_Click);
            }
            p.Controls.Add(miniSheet);
            miniSheet.Show();
        }

        private void hero_Click(object sender, EventArgs e)
        {
            // get control from sender
            Control c = (Control)sender;
            // get index of control in panel
            int index = p_heroes.Controls.IndexOf(c);

            MessageBox.Show($"You clicked on hero number {index}");
        }

        private void subcontrol_Click(object sender, EventArgs e)
        {
            // get control from sender
            Control c = ((Control)sender).Parent;
            // get index of control in panel
            int index = p_heroes.Controls.IndexOf(c);

            MessageBox.Show($"You clicked on hero number {index}");
        }

        private void putFormToTable(Form form, TableLayoutPanel table)
        {
            table.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            table.Controls.Add(form);
            table.Tag = form;
            form.Show();
        }

        private void btn_nhero_Click(object sender, EventArgs e)
        {
            // při kliknutí na tlačítko "New Hero" se otevře form "Sheet" s novým hrdinou (předat mu prázdný objekt)
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // při kliknutí na tlačítko "Delete Hero" se zeptat, jestli je si jistý, a pak smazat hrdinu z databáze
            DialogResult res = MessageBox.Show("Are you sure you want to delete this hero?", "Delete Hero", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                // smazat hrdinu z databáze
            } else
            {
                // nic nedělat
            }
        }
    }
}

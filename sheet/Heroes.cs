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
            // dynamicky vytvořit tabulku a vložit do ní formy podle počtu hrdinů v databázi
            // při kliknutí na form se otevře form "Sheet" s daným hrdinou

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

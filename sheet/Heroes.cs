using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace sheet
{
    public partial class Heroes : Form
    {
        List<Character> characterList = new List<Character>();

        public Heroes()
        {
            InitializeComponent();
        }

        private void check_Settings()
        {
            bool autoload = Properties.Settings.Default.autoload;
            if (autoload)
            {
                try
                {
                    // get all xml files from directory
                    string[] files = Directory.GetFiles(Properties.Settings.Default.path, "*.xml");
                    // load all heroes from files
                    characterList.AddRange(DataHandler.loadCharacterList(Properties.Settings.Default.path));
                    characterList = sortBy();
                    // add all heroes to panel
                    foreach (Character c in characterList)
                    {
                        add_miniSheet(p_heroes, c);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            }
        }

        private void Heroes_Load(object sender, EventArgs e)
        {
            // použij form "Hero Short" a vlož ho do tabulky, maybe ještě sortnout podle jména či tak něco (v nastavení by to mělo být)
            // vložit do tabulky všechny hrdiny z databáze přidat event handler na kliknutí na form
            // při kliknutí na form se otevře form "Sheet" s daným hrdinou

            /*for (int i = 0; i < 10; i++)
            {
                add_miniSheet(p_heroes);
            }*/
            check_Settings();
        }

        private List<Character> sortBy()
        {
            switch (Properties.Settings.Default.sorting_val)
            {
                case 0:
                    return DataHandler.getSortedByLevel(characterList);
                case 1:
                    return DataHandler.getSortedByName(characterList);
                case 2:
                    return DataHandler.getSortedByRace(characterList);
                case 3:
                    return DataHandler.getSortedByClass(characterList);
                default:
                    return characterList;
            }
        }

        private void add_miniSheet(Panel p, Character ch)
        {
            // vytvořit form "Hero Short" a vložit ho do panelu
            // při kliknutí na form se otevře form "Sheet" s daným hrdinou
            Sheet_short miniSheet = new Sheet_short(ch);
            miniSheet.TopLevel = false;
            miniSheet.Click += new EventHandler(hero_Click);
            miniSheet.DoubleClick += MiniSheet_DoubleClick;
            miniSheet.Text = ch.cName;
            // add this event handler to all controls in miniSheet will evoke click event on miniSheet
            foreach (Control c in miniSheet.Controls)
            {
                c.Click += new EventHandler(subcontrol_Click);
                c.DoubleClick += MiniSheet_Subcontrol_DoubleClick;
            }
            p.Controls.Add(miniSheet);
            miniSheet.Show();
        }

        private void MiniSheet_DoubleClick(object sender, EventArgs e)
        {
            // open sheet with selected hero
            Sheet_short s = sender as Sheet_short;
            CharSheet sheet = new CharSheet(characterList[getSelectedIndex()]);
            sheet.Show();
        }

        private void MiniSheet_Subcontrol_DoubleClick(object sender, EventArgs e)
        {
            Sheet_short s = ((Control)sender).Parent as Sheet_short;
            Character c = characterList[getSelectedIndex()];    
            CharSheet sheet = new CharSheet(c);
            sheet.Show();
        }

        private void hero_Click(object sender, EventArgs e)
        {
            // get control from sender
            Control c = (Control)sender;
            // get index of control in panel
            int index = p_heroes.Controls.IndexOf(c);
            // add border to control to show it's selected
            if(c is Sheet_short)
            {
                Sheet_short s = (Sheet_short)c;
                s.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            // remove border from all other controls
            foreach (Control c2 in p_heroes.Controls)
            {
                if (c2 != c)
                {
                    if (c2 is Sheet_short)
                    {
                        Sheet_short s = (Sheet_short)c2;
                        s.FormBorderStyle = FormBorderStyle.None;
                    }
                }
            }
        }

        private void subcontrol_Click(object sender, EventArgs e)
        {
            // get control from sender
            Control c = ((Control)sender).Parent;
            // get index of control in panel
            int index = p_heroes.Controls.IndexOf(c);

            // add border to control to show it's selected
            if (c is Sheet_short)
            {
                Sheet_short s = (Sheet_short)c;
                s.FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            // remove border from all other controls
            foreach (Control c2 in p_heroes.Controls)
            {
                if (c2 != c)
                {
                    if (c2 is Sheet_short)
                    {
                        Sheet_short s = (Sheet_short)c2;
                        s.FormBorderStyle = FormBorderStyle.None;
                    }
                }
            }

        }

        private int getSelectedIndex()
        {
            int id = 0;
            // get selected hero from panel
            foreach (Control c in p_heroes.Controls)
            {
                if (c is Sheet_short)
                {
                    Sheet_short s = (Sheet_short)c;
                    if (s.FormBorderStyle == FormBorderStyle.FixedSingle)
                    {
                        return id;
                    }
                    id++;
                }
            }
            return 0;
        }

        private void btn_nhero_Click(object sender, EventArgs e)
        {
            // při kliknutí na tlačítko "New Hero" se otevře form "Sheet" s novým hrdinou (předat mu prázdný objekt)
            CharSheet sheet = new CharSheet();
            sheet.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // při kliknutí na tlačítko "Delete Hero" se zeptat, jestli je si jistý, a pak smazat hrdinu z databáze
            DialogResult res = MessageBox.Show("Are you sure you want to delete this hero?", "Delete Hero", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                // get selected hero from panel
                foreach (Control c in p_heroes.Controls)
                {
                    if (c is Sheet_short)
                    {
                        Sheet_short s = (Sheet_short)c;
                        if (s.FormBorderStyle == FormBorderStyle.FixedSingle)
                        {
                            // delete hero from database
                            // delete hero from panel
                            p_heroes.Controls.Remove(s);
                            characterList.RemoveAt(getSelectedIndex());
                            DataHandler.deleteCharacter(s.lbl_name.Text);
                            break;
                        }
                    }
                }
            }
        }
    }
}

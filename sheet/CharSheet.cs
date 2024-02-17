﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sheet.Character;
using Newtonsoft.Json;
using sheet.Dialogs;

namespace sheet
{
    public partial class CharSheet : Form
    {
        DataHandler dataHandler = new DataHandler();
        #region main
        CheckBox[] checkBoxesThrow;
        CheckBox[] checkBoxesSkills;
        public Character currentChar;

        bool autosave = false;
        public CharSheet()
        {
            InitializeComponent();
            setupDialogs();
            prepareForm();
            copySpellTabs();
            setupToolStrip();
        }

        public CharSheet(Character character)
        {
            InitializeComponent();
            setupDialogs();
            prepareForm();
            autosave = Properties.Settings.Default.autosave;
            currentChar = character;
            LoadToCurrent();
            if (File.Exists($"{Properties.Settings.Default.path}\\{currentChar.cName.Replace(' ', '_')}.xml"))
            {
                autosave = Properties.Settings.Default.autosave;
                if (autosave)
                {
                    autoSavePreparation();
                }
            }
            copySpellTabs();
            setupToolStrip();
        }

        private void setupToolStrip()
        {
            ToolStripMenuItem ts = spToolStripMenuItem;
            foreach (ToolStripItem item in ts.DropDownItems)
            {
                item.Click += new EventHandler(spellCreateClick);
            }
        }

        private void spellCreateClick(object sender, EventArgs e)
        {
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            // get level from text
            if (btn.Text.Contains("Cantrip"))
            {
                createSpell(0);
            }
            else
            {
                int level = Convert.ToInt32(btn.Text.Split(' ')[1]);
                createSpell(level);
            }
        }

        private void autoSavePreparation()
        {
            // set autosave timer
            Timer autosaveTimer = new Timer();
            autosaveTimer.Interval = Properties.Settings.Default.as_freq * 1000;
            autosaveTimer.Tick += new EventHandler(autoSave);
            autosaveTimer.Start();
        }

        private void setupDialogs()
        {
            openFileDialog1.InitialDirectory = Properties.Settings.Default.path;
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.path;
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.DefaultExt = "xml";
        }
        public CharSheet(Character character)
        {
            InitializeComponent();
            currentChar = character;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var sd = new SaveFileDialog())
            {
                sd.Title = "Select a location";
                sd.AddExtension = true;
                sd.DefaultExt = "json";
                sd.Filter = "JSON files (*.json)|*.json";
                sd.ShowDialog();
                currentChar.SaveAsFile(sd.FileName);
            }
            
        }

        //temp data saving
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
        }
        #endregion

        #region Data-Handle
        void UpdateAll()
        {
            StatsUpdate(true, true, true, statCheck.Checked);
            UpdateHeader();
            IAintDealingWithThis(false);
            updateInventory(false);
        }
        void UpdateHeader()
        {
            fdsfs.Text = currentChar.cName;
            lvlBox.Text = currentChar.level.ToString();
            raceBox.Text = currentChar.race;
            classBox.Text = currentChar.charClass;
        }
        void StatsUpdate(bool updateStats, bool updateThrows,bool updateSkills,bool statsFunctional)
        {
            {
                if (statsFunctional)
                {
                    int[] temp = currentChar.stats.Get();
                    TextBox[] tempBoxes = new TextBox[6] { strBox, dexBox, constBox, intBox, wisdBox, charBox };
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = (int)Math.Floor((Convert.ToDouble(temp[i]) - 10) / 2);
                        if (temp[i] > 0)
                        {
                            tempBoxes[i].Text = $"+{temp[i]}";
                        }
                        else
                        {
                            tempBoxes[i].Text = $"{temp[i]}";
                        }
                    }
                }
                else
                {
                    dataHandler.FillTextBoxes<int>(currentChar.stats.Get(), new TextBox[6] { strBox, dexBox, constBox, intBox, wisdBox, charBox });
                }
            }
            if (updateThrows)
            {
                dataHandler.FillTextBoxesReadableProf(currentChar.savingThrows.Get(), new TextBox[6] { statBox1, statBox2, statBox3, statBox4, statBox5, statBox6 }, currentChar.bonus[0], currentChar.proefficency);
            }
            if (updateSkills)
            {
                dataHandler.FillTextBoxesReadableProf(currentChar.skills.Get(), new TextBox[18] { statBox7, statBox8, statBox9, statBox10, statBox11, statBox12, statBox13, statBox14, statBox15, statBox16, statBox17, statBox18, statBox19, statBox20, statBox21, statBox22, statBox23, statBox24 }, currentChar.bonus[1], currentChar.proefficency);
            }
        }

        #endregion

        #region hell
        /*
             _          _ _ 
            | |        | | |
            | |__   ___| | |
            | '_ \ / _ \ | |
            | | | |  __/ | |
            |_| |_|\___|_|_|
        */


        private void ListHell(CheckBox checkBox)
        {
            if (checkBoxesSkills.Contains<CheckBox>(checkBox))
            {
                if (checkBox.Checked)
                {
                    currentChar.bonus[1].Add(Array.IndexOf(checkBoxesSkills, checkBox));
                }
                else
                {
                    currentChar.bonus[1].Remove(Array.IndexOf(checkBoxesSkills, checkBox));
                }
                StatsUpdate(false, false, true, false);
            }
            else
            {
                if (checkBox.Checked)
                {
                    currentChar.bonus[0].Add(Array.IndexOf(checkBoxesThrow, checkBox));
                }
                else
                {
                    currentChar.bonus[0].Remove(Array.IndexOf(checkBoxesThrow, checkBox));
                }
                StatsUpdate(false, true, false, false);
            }
           
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox1);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox2);
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox3);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox4);
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox5);
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox6);
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox7);
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox8);
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox9);
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox10);
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox11);
        }
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox12);
        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox13);
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox14);
        }
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox15);
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox16);
        }
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox17);
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox18);
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox19);
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox20);
        }
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox21);
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox22);
        }
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox23);
        }
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox24);
        }

        #endregion

        #region David's Shit
        private void btn_sel_pic_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            //charImage.Image = Image.FromFile(openFileDialog1.FileName);
            charImage.ImageLocation = openFileDialog2.FileName;
            charImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void CharSheet_FormClosing(object sender, FormClosingEventArgs e)
        {/*
            // messagebox for saving
            DialogResult dialogResult = MessageBox.Show("Do you want to save the sheet?", "Save", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                quickSave();
            }
            */
        }

        private void copySpellTabs()
        {
            // copy all controls from tab_sp1 to tab_sp2-9
            TabControl tabC = tabC_spells;
            tab_cantrip.Controls.Add(createSpellDataGrid(0));
            for (int i = 1; i < 10; i++)
            {
                TabPage tab = new TabPage();
                tab.Text = $"Spells {i}";
                tab.Name = $"tab_sp{i}";
                tabC.TabPages.Add(tab);

                Panel p = new Panel();
                p.Dock = DockStyle.Top;
                p.Height = 55;
                p.Controls.AddRange(getSpellTextboxes(p, i));
                p.Controls.AddRange(getSpellLabels(p, i));
                tab.Controls.Add(p);
                tab.Controls.Add(createSpellDataGrid(i));
            }
        }

        private TextBox[] getSpellTextboxes(Panel parent, int id)
        {
            TextBox b1 = new TextBox();
            b1.Name = "txt_sp" + id + "to";
            b1.Text = "0";
            b1.Parent = parent;
            b1.Size = new Size(42, 42);
            b1.Location = new Point(3, 3);


            TextBox b2 = new TextBox();
            b2.Name = "txt_sp" + id + "sp";
            b2.Text = "0";
            b2.Parent = parent;
            b2.Size = new Size(42, 42);
            b2.Location = new Point(162, 3);

            TextBox b3 = new TextBox();
            b3.Name = "txt_sp" + id + "level";
            b3.Text = id.ToString();
            b3.Parent = parent;
            b3.Size = new Size(42, 42);
            b3.Location = new Point(632, 3);
            b3.Enabled = false;

            return new TextBox[] { b1, b2, b3 };
        }

        private Label[] getSpellLabels(Panel parent, int id)
        {
            Label l1 = new Label();
            l1.Name = "lbl_sp" + id + "to";
            l1.Text = "Slots Total";
            l1.Parent = parent;
            l1.Font = new Font("Arial", 10);
            l1.Location = new Point(51, 13);


            Label l2 = new Label();
            l2.Name = "lbl_sp" + id + "sp";
            l2.Text = "Slots Used";
            l2.Parent = parent;
            l2.Font = new Font("Arial", 10);
            l2.Location = new Point(210, 13);

            Label l3 = new Label();
            l3.Name = "lbl_sp" + id + "level";
            l3.Text = "Level";
            l3.Parent = parent;
            l3.Font = new Font("Arial", 10);
            l3.Location = new Point(680, 13);

            return new Label[] { l1, l2, l3 };
        }

        private DataGridView createSpellDataGrid(int id)
        {
            DataGridView dg = new DataGridView();
            dg.Name = "db_spells" + id;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToOrderColumns = false;
            dg.AllowUserToResizeColumns = false;
            dg.AllowUserToResizeRows = false;

            dg.Columns.AddRange(getBaseSpellColumns().ToArray());
            // fix height of column headers
            dg.Font = new Font("Arial", 10);
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dg.AllowUserToResizeColumns = true;


            dg.Size = new Size(788, 609);
            dg.Location = new Point(3, 58);
            //add scrollbars
            dg.ScrollBars = ScrollBars.Both;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            return dg;
        }

        private List<DataGridViewColumn> getBaseSpellColumns()
        {
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "School", HeaderText = "School", Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "CastingTime", HeaderText = "Casting Time", Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "Range", HeaderText = "Range",  Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "Comp", HeaderText = "Components",  Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "Duration", HeaderText = "Duration",  Width=150, Resizable=DataGridViewTriState.True},
                new DataGridViewTextBoxColumn() { Name = "Description", HeaderText = "Description",  Width=150, Resizable=DataGridViewTriState.True}
            };
            return columns;
        }

        private void createSpell(int level)
        {
            SpellCreator sc = new SpellCreator();
            sc.Show();
            // on sc button click get data and add to datagrid
            sc.btn_create.Click += (sender, e) =>
            {
                String[] data = sc.getSpellData();
                DataGridView dg = (DataGridView)tabC_spells.Controls.Find("db_spells" + level, true)[0];
                dg.Rows.Add(data);
                sc.Close();
            };
        }


        #endregion


        private void addAttackPanel()
        {
            Panel p = new Panel();
            p.Dock = DockStyle.Top;
            p.Height = 61;
            p.BorderStyle = BorderStyle.FixedSingle;
            
            p.Controls.AddRange(getAttackData(attack_panel.Controls.Count, p));
            p.Click += new EventHandler(txt_selectWeapon);
            
            attack_panel.Controls.Add(p);
        }

        private TextBox[] getAttackData(int id, Control parent)
        {
            TextBox b1 = new TextBox();
            b1.Name = "txt_atk_" + id + "_name";
            b1.Text = "Name";
            b1.ForeColor = Color.Gray;
            b1.Parent = parent;
            b1.Size = new Size(155, 40);
            b1.Location = new Point(5, 13);

            TextBox b2 = new TextBox();
            b2.Name = "txt_atk_" + id + "_dmg";
            b2.Text = "Dmg";
            b2.ForeColor = Color.Gray;
            b2.Parent = parent;
            b2.Size = new Size(90, 40);
            b2.Location = new Point(185, 13);

            TextBox b3 = new TextBox();
            b3.Name = "txt_atk_" + id + "_attributes";
            b3.Text = "Attributes";
            b3.ForeColor = Color.Gray;
            b3.Parent = parent;
            b3.Size = new Size(220, 40);
            b3.Location = new Point(300, 13);

            TextBox[] textBoxes = new TextBox[] { b1, b2, b3 };
            foreach (TextBox tb in textBoxes)
            {
                tb.Enter += new EventHandler(txt_attack_Enter);
                tb.Leave += new EventHandler(txt_attack_Leave);
                tb.Click += new EventHandler(txt_selectWeapon);
            }

            return textBoxes;
        }

        private void txt_attack_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Name" || tb.Text == "Dmg" || tb.Text == "Attributes")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        private void txt_attack_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = tb.Name.Split('_')[3];
                //make first letter big
                tb.Text = char.ToUpper(tb.Text[0]) + tb.Text.Substring(1);
                tb.ForeColor = Color.Gray;
            }
        }

        private void txt_selectWeapon(object sender, EventArgs e)
        {
            Panel panel;
            if (sender is Panel)
            {
                panel = (Panel)sender;
            }else
            {
                panel = (Panel)((Control)sender).Parent;
            }

            panel.BackColor = Color.LightGray;
            panel.BorderStyle = BorderStyle.None;

            foreach (Panel p in attack_panel.Controls)
            {
                if (p != panel)
                {
                    p.BackColor = Color.White;
                    p.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private Panel getSelectedPanel()
        {
            foreach (Panel p in attack_panel.Controls)
            {
                if (p.BackColor == Color.LightGray)
                {
                    return p;
                }
            }
            return null;
        }

        private int getSelectedPanelId()
        {
            for (int i = 0; i < attack_panel.Controls.Count; i++)
            {
                if (attack_panel.Controls[i].BackColor == Color.LightGray)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btn_add_attack_Click(object sender, EventArgs e)
        {
            addAttackPanel();
        }

        private void btn_delete_attack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the selected attack?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                attack_panel.Controls.Remove(getSelectedPanel());
        }

        private void btn_roll_attack_Click(object sender, EventArgs e)
        {
            Panel p = getSelectedPanel();
            string[] data = new string[2];
            foreach (Control c in p.Controls)
            {
                if (c is TextBox)
                {
                    TextBox tb = (TextBox)c;
                    if (tb.Name.Contains("dmg"))
                    {
                        data[0] = tb.Text;
                    }
                    else if (tb.Name.Contains("attributes"))
                    {
                        data[1] = tb.Text;
                    }
                }
            }

            if (data[0] == null || data[1] == null)
            {
                MessageBox.Show("Please fill in all the fields");
                return;
            }

            if (roll_selector.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a dice to roll");
                return;
            }else if (roll_selector.SelectedIndex == 0)
            {
                performAttack("1d20", data[1], false);
                return;
            }else if (roll_selector.SelectedIndex == 1)
            {
                performAttack(data[0], data[1], true);
                return;
            }
        }

        private void performAttack(string dice, string attributes, bool isDamage)
        {
            string modifier_toUse = "";
            dice = dice.ToLower().Trim();
            attributes = attributes.ToLower().Trim();
            if (attributes.Contains("finesse"))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to use STR[Yes] or DEX[No]?", "Finesse", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    modifier_toUse = "str";
                }
                else
                {
                    modifier_toUse = "dex";
                }
            } 
            else
                modifier_toUse = "str";
            
            if (isDamage)
            {
                if (attributes.Contains("versatile"))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to use 1[Yes] or 2[No] hands?", "Versatile", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dice = dice.Split(',')[0];
                    }
                    else
                    {
                        dice = dice.Split(',')[1];
                    }
                }
            }
            
            int rolls = int.Parse(dice.Split('d')[0]);
            int sides = int.Parse(dice.Split('d')[1]);


            for (int i = 0; i < rolls; i++)
            {
                int roll = iniciateRoll(sides, modifier_toUse,isDamage,false);
            }
        }
        private int iniciateRoll(int sides, string modifier, bool isDamage, bool hasProficiency)
        {
            int fin_mod = 0;
            if (chb_use_mod.Checked)
            {
                switch (modifier)
                {
                    case "str":
                        fin_mod = (currentChar.mainStats.Str - 10) / 2;
                        break;
                    case "dex":
                        fin_mod = (currentChar.mainStats.Dex - 10) / 2;
                        break;
                    case "const":
                        fin_mod = (currentChar.mainStats.Const - 10) / 2;
                        break;
                    case "int":
                        fin_mod = (currentChar.mainStats.Int - 10) / 2;
                        break;
                    case "wis":
                        fin_mod = (currentChar.mainStats.Wis - 10) / 2;
                        break;
                    case "char":
                        fin_mod = (currentChar.mainStats.Char - 10) / 2;
                        break;
                    default:
                        fin_mod = Convert.ToInt32(modifier);
                        break;
                }
            }

            if (hasProficiency)
                fin_mod += currentChar.pro;

            string weapon = "";
            if (isDamage)
            {
                string weapon_name = getSelectedPanel().Controls.Find("txt_atk_" + getSelectedPanelId() + "_name", true)[0].Text;
                string damage_type = getSelectedPanel().Controls.Find("txt_atk_" + getSelectedPanelId() + "_attributes", true)[0].Text;
                Random rnd = new Random();
                foreach (string s in damage_type.Split(','))
                {
                    if (s.Contains("bludgeoning"))
                    {
                        int r = rnd.Next(0, 5);
                        if (r == 0)
                            damage_type = "bludgeoned";
                        else if (r == 1)
                            damage_type = "smashed";
                        else if (r == 2)
                            damage_type = "crushed";
                        else if (r == 3)
                            damage_type = "bashed";
                        else
                            damage_type = "pounded";
                        break;
                    }
                    else if (s.Contains("piercing"))
                    {
                        int r = rnd.Next(0, 5);
                        if (r == 0)
                            damage_type = "pierced";
                        else if (r == 1)
                            damage_type = "punctured";
                        else if (r == 2)
                            damage_type = "stabbed";
                        else if (r == 3)
                            damage_type = "poked";
                        else
                            damage_type = "gored";
                        break;
                    }
                    else if (s.Contains("slashing"))
                    {
                        int r = rnd.Next(0, 5);
                        if (r == 0)
                            damage_type = "cut";
                        else if (r == 1)
                            damage_type = "slashed";
                        else if (r == 2)
                            damage_type = "gashed";
                        else if (r == 3)
                            damage_type = "sliced";
                        else
                            damage_type = "chopped";
                        break;
                    }
                }
                weapon = $"{weapon_name},{damage_type}";
            }

            Roll roll = new Roll(fin_mod,weapon);
            if (isDamage)
                roll.pc_name = currentChar.cName;
            roll.rollDice(sides);
            roll.MaximumSize = roll.Size;
            roll.MinimumSize = roll.Size;
            roll.ShowDialog();
            return roll.last_roll;
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var load = new LoadDialog())
            {
                load.ShowDialog();
                currentChar = load.character;
            }
            checkBoxesThrow = new CheckBox[6] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            checkBoxesSkills = new CheckBox[18] { checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24 };
            UpdateAll();
        }
        private void setImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var open = new OpenFileDialog())
            {
                open.Title = "Select a file.";
                open.ShowDialog();
                if (open.FileName != "" || open.FileName != null)
                {
                    currentChar.SetImage(Image.FromFile(open.FileName));

                    charImage.Image = currentChar.GetImage();
                    littleImageBox.Image = currentChar.GetImage();
                }
                else
                {
                    MessageBox.Show("An error has occured, this could be a file issue.");
                }
            }
        }

        private void statCheck_CheckedChanged(object sender, EventArgs e)
        {
            StatsUpdate(true,false,false,statCheck.Checked);
        }
        void IAintDealingWithThis(bool save)
        {
            if (save)
            {
                currentChar.characteristics.bonds = bondsText.Text;
                currentChar.characteristics.backstory = backstoryText.Text;
                currentChar.characteristics.ideals = idealsText.Text;
                currentChar.characteristics.featuresTraits = featuresText.Text;
                currentChar.characteristics.personalTraits = perTraitText.Text;
                currentChar.characteristics.profLanguages = profnLanguagesText.Text;
                currentChar.characteristics.allies = AlliesText.Text;

                currentChar.characteristics.background = backgroundBox.Text;
                currentChar.characteristics.age = ageBox.Text;
                currentChar.characteristics.height = heightBox.Text;
                currentChar.characteristics.weight = weightBox.Text;
                currentChar.characteristics.skin = skinBox.Text;
                currentChar.characteristics.eye = eyeBox.Text;
                currentChar.characteristics.hair = hairBox.Text;
                currentChar.characteristics.alignment = alignBox.Text;
            }
            else
            {
                bondsText.Text = currentChar.characteristics.bonds;
                backstoryText.Text = currentChar.characteristics.backstory;
                idealsText.Text = currentChar.characteristics.ideals;
                featuresText.Text = currentChar.characteristics.featuresTraits;
                perTraitText.Text = currentChar.characteristics.personalTraits;
                profnLanguagesText.Text = currentChar.characteristics.profLanguages;
                AlliesText.Text = currentChar.characteristics.allies;

                backgroundBox.Text = currentChar.characteristics.background;
                ageBox.Text = currentChar.characteristics.age;
                heightBox.Text = currentChar.characteristics.height;
                weightBox.Text = currentChar.characteristics.weight;
                skinBox.Text = currentChar.characteristics.skin;
                eyeBox.Text = currentChar.characteristics.eye;
                hairBox.Text = currentChar.characteristics.hair;
                alignBox.Text = currentChar.characteristics.alignment;

            }
        }
        void updateInventory(bool save)
        {
            if (save)
            {
                currentChar.inventory[0] = inventoryBox.Text;
                currentChar.inventory[1] = treasureText.Text;
            }
            else
            {
                inventoryBox.Text = currentChar.inventory[0];
                treasureText.Text = currentChar.inventory[1];
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAintDealingWithThis(true);
        }

        private void changeBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ecb = new EditCharBase(currentChar))
            {
                currentChar = ecb.character;
                ecb.ShowDialog();
                UpdateHeader();
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateInventory(true);
            IAintDealingWithThis(true);

        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace sheet
{
    public partial class CharSheet : Form
    {
        #region main
        public List<int> prof;
        CheckBox[] checkBoxesThrow;
        CheckBox[] checkBoxesSkills;
        TextBox[] statBoxesThrow;
        TextBox[] statBoxesSkills;

        XmlSerializer serializer = new XmlSerializer(typeof(Character));
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
        //save sheet
        private void saveAsFile()
        {
            SaveToCurrent();
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                DataHandler.saveCharacter(currentChar, saveFileDialog1.FileName);
            }
        }
        //load sheet
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            try
            {
                FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                currentChar = (Character)serializer.Deserialize(fileStream);
                fileStream.Close();
                LoadToCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading file: " + ex.Message);
            }

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void prepareForm()
        {
            prof = new List<int>();

            currentChar = new Character();

            currentChar.apearance = new Apearance();
            currentChar.personality = new Personality();

            currentChar.mainStats = new mainStats();
            currentChar.savingThrows = new Sthrows();
            currentChar.skills = new Skills();

            currentChar.inventory = new Inventory();

            currentChar.money = new Money();

            checkBoxesThrow = new CheckBox[6] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            checkBoxesSkills = new CheckBox[18] { checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24 };

            statBoxesThrow = new TextBox[6] { statBox1, statBox2, statBox3, statBox4, statBox5, statBox6 };
            statBoxesSkills = new TextBox[18] { statBox7, statBox8, statBox9, statBox10, statBox11, statBox12, statBox13, statBox14, statBox15, statBox16, statBox17, statBox18, statBox19, statBox20, statBox21, statBox22, statBox23, statBox24 };
        }

        private void autoSave(object sender, EventArgs e)
        {
            if (autosave)
            {
                try
                {
                    simulateSaving().ContinueWith((t) => quickSave());
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private Task simulateSaving()
        {
            return Task.Run(() =>
            {
                this.UseWaitCursor = true;
                System.Threading.Thread.Sleep(1000);
                this.UseWaitCursor = false;
            });
        }

        //temp data saving
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            SaveToCurrent();
        }
        #endregion

        #region Data-Handle
        /*
        Handling each load and save seperatelly is probably gonna be more efficent,
        considering all the different loads can be triggered all the time and calling everything all the time,
        sounds just like good way to explode.
        Also i would consider this place Hell2
        */
        //HEADER
        void UpdateHeader(bool save)
        {
            if (save)
            {
                currentChar.cName = charNameBox.Text;
                currentChar.level = ToInt(lvlBox.Text);
                currentChar.race = raceBox.Text;
                currentChar._class = classBox.Text;
            }
            else
            {
                charNameBox.Text = currentChar.cName;
                lvlBox.Text = currentChar.level.ToString();
                raceBox.Text = currentChar.race;
                classBox.Text = currentChar._class;
            }
        }
        //PAGE 1
        void CharInfoUpdate(bool save)
        {
            if (save)
            {
                currentChar.personality.bonds = bondsText.Text;
                currentChar.personality.backstory = backstoryText.Text;
                currentChar.personality.ideals = idealsText.Text;
                currentChar.personality.featuresTraits = featuresText.Text;
                currentChar.personality.personalTraits = perTraitText.Text;
                currentChar.personality.profLanguages = profnLanguagesText.Text;
                currentChar.personality.allies = AlliesText.Text;

                currentChar.apearance.background = backgroundBox.Text;
                currentChar.apearance.age = ageBox.Text;
                currentChar.apearance.height = heightBox.Text;
                currentChar.apearance.weight = weightBox.Text;
                currentChar.apearance.skin = skinBox.Text;
                currentChar.apearance.eye = eyeBox.Text;
                currentChar.apearance.hair = hairBox.Text;
                currentChar.apearance.alignment = alignBox.Text;

                if (charImage.Image != null)
                {
                    currentChar.apearance.image = charImage.ImageLocation;
                }
            }
            else
            {
                bondsText.Text = currentChar.personality.bonds;
                backstoryText.Text = currentChar.personality.backstory;
                idealsText.Text = currentChar.personality.ideals;
                featuresText.Text = currentChar.personality.featuresTraits;
                perTraitText.Text = currentChar.personality.personalTraits;
                profnLanguagesText.Text = currentChar.personality.profLanguages;
                AlliesText.Text = currentChar.personality.allies;

                backgroundBox.Text = currentChar.apearance.background;
                ageBox.Text = currentChar.apearance.age;
                heightBox.Text = currentChar.apearance.height;
                weightBox.Text = currentChar.apearance.weight;
                skinBox.Text = currentChar.apearance.skin;
                eyeBox.Text = currentChar.apearance.eye;
                hairBox.Text = currentChar.apearance.hair;
                alignBox.Text = currentChar.apearance.alignment;

                if (currentChar.apearance.image != null)
                {
                    charImage.ImageLocation = currentChar.apearance.image;
                    charImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
        }
        //PAGE 2
        void MainStatsUpdate(bool save, bool plusState)
        {
            Dictionary<string, int> stats = new Dictionary<string, int>() {
                {"str",currentChar.mainStats.Str},{"dex",currentChar.mainStats.Dex},{"const",currentChar.mainStats.Const},
                {"int",currentChar.mainStats.Int},{"wis",currentChar.mainStats.Wis},{"char",currentChar.mainStats.Char}
            };
            Dictionary<string, string> textBoxes = new Dictionary<string, string>{
                {"str",strBox.Text},{"dex",dexBox.Text},{"const",constBox.Text},
                {"int",intBox.Text},{"wis",wisdBox.Text},{"char",charBox.Text}
            };

            if (save && plusState == false)
            {
                currentChar.mainStats.Str = ToInt(textBoxes["str"]);
                currentChar.mainStats.Dex = ToInt(textBoxes["dex"]);
                currentChar.mainStats.Const = ToInt(textBoxes["const"]);
                currentChar.mainStats.Int = ToInt(textBoxes["int"]);
                currentChar.mainStats.Wis = ToInt(textBoxes["wis"]);
                currentChar.mainStats.Char = ToInt(textBoxes["char"]);
            }
            else
            {
                if (plusState)
                {
                    strBox.Text = $"{MainToFlat(stats["str"])}";
                    dexBox.Text = $"{MainToFlat(stats["dex"])}";
                    constBox.Text = $"{MainToFlat(stats["const"])}";
                    intBox.Text = $"{MainToFlat(stats["int"])}";
                    wisdBox.Text = $"{MainToFlat(stats["wis"])}";
                    charBox.Text = $"{MainToFlat(stats["char"])}";

                }
                else
                {
                    strBox.Text = $"{stats["str"]}";
                    dexBox.Text = $"{stats["dex"]}";
                    constBox.Text = $"{stats["const"]}";
                    intBox.Text = $"{stats["int"]}";
                    wisdBox.Text = $"{stats["wis"]}";
                    charBox.Text = $"{stats["char"]}";
                }
            }
        }

        void ThrowsUpdate(bool save)
        {
            if (save)
            {
                int[] ints = new int[6];
                int i = 1;
                foreach (TextBox box in statBoxesThrow)
                {
                    if (prof.Contains(i))
                    {
                        ints[i - 1] = ToInt(box.Text) - currentChar.pro;
                    }
                    else
                    {
                        ints[i - 1] = ToInt(box.Text);
                    }
                    i++;
                }
                currentChar.savingThrows.throwsSave(ints);
            }
            else
            {
                int i = 1;
                foreach (TextBox box in statBoxesThrow)
                {
                    if (prof.Contains(i))
                    {
                        box.Text = (currentChar.savingThrows.throwsLoad()[i - 1] + currentChar.pro).ToString();
                    }
                    else
                    {
                        box.Text = currentChar.savingThrows.throwsLoad()[i - 1].ToString();
                    }
                    i++;
                }
            }
        }
        void SkillsUpdate(bool save)
        {
            if (save)
            {
                int[] ints = new int[18];
                int i = 1;
                foreach (TextBox box in statBoxesSkills)
                {
                    if (prof.Contains(i + 6))
                    {
                        ints[i - 1] = ToInt(box.Text) - currentChar.pro;
                    }
                    else
                    {
                        ints[i - 1] = ToInt(box.Text);
                    }
                    i++;
                }
                currentChar.skills.skillsSave(ints);
            }
            else
            {
                int i = 1;
                foreach (TextBox box in statBoxesSkills)
                {
                    if (prof.Contains(i + 6))
                    {
                        box.Text = (currentChar.skills.skillsLoad()[i - 1] + currentChar.pro).ToString();
                    }
                    else
                    {
                        box.Text = currentChar.skills.skillsLoad()[i - 1].ToString();
                    }
                    i++;
                }
            }
        }
        //PAGE 3
        void InvUpdate(bool save)
        {
            if (save)
            {
                currentChar.inventory.treasure = treasureText.Text;
                currentChar.inventory.equipment = inventoryBox.Text;
            }
            else
            {
                treasureText.Text = currentChar.inventory.treasure;
                inventoryBox.Text = currentChar.inventory.equipment;
            }
        }
        //PAGE 4

        //PAGE 5

        void MoneyUpdate(bool save)
        {
            if (save)
            {
                currentChar.money.copperC = ToDouble(cpText.Text);
                currentChar.money.silverC = ToDouble(spText.Text);
                currentChar.money.electrumC = ToDouble(epText.Text);
                currentChar.money.goldC = ToDouble(gpText.Text);
                currentChar.money.platinumC = ToDouble(ppText.Text);
            }
            else
            {
                cpText.Text = currentChar.money.copperC.ToString();
                spText.Text = currentChar.money.silverC.ToString();
                epText.Text = currentChar.money.electrumC.ToString();
                gpText.Text = currentChar.money.goldC.ToString();
                ppText.Text = currentChar.money.platinumC.ToString();
            }
        }

        //UPDATES
        void UpdateAllLoad()
        {
            if (statCheck.Checked)
            {
                MainStatsUpdate(false, true);
            }
            else
            {
                MainStatsUpdate(false, false);
            }
            UpdateHeader(false);
            CharInfoUpdate(false);
            prof = currentChar.proficiencies;
            ThrowsUpdate(false);
            SkillsUpdate(false);
            int i = 1;
            foreach (CheckBox check in checkBoxesThrow)
            {
                if (prof.Contains(i))
                {
                    check.Checked = true;
                }
                else
                {
                    check.Checked = false;
                }
                i++;
            }
            i = 1;
            foreach (CheckBox check in checkBoxesSkills)
            {
                if (prof.Contains(i + 6))
                {
                    check.Checked = true;
                }
                else
                {
                    check.Checked = false;
                }
                i++;
            }
        }
        void UpdateAllSave()
        {
            UpdateHeader(true);
            MainStatsUpdate(true, statCheck.Checked);
            CharInfoUpdate(true);
            currentChar.proficiencies = prof;
            ThrowsUpdate(true);
            SkillsUpdate(true);

        }
        void LoadToCurrent()
        {
            UpdateAllLoad();

        }
        void SaveToCurrent()
        {
            // fill blank spaces with 0
            new Task(() => fillBlanks(statBoxesThrow, statBoxesSkills)).Start();
            UpdateAllSave();
        }

        void fillBlanks(TextBox[] t1, TextBox[] t2)
        {
            foreach (TextBox box in statBoxesThrow)
            {
                if (box.Text == "")
                {
                    box.Text = "0";
                }
            }
            foreach (TextBox box in statBoxesSkills)
            {
                if (box.Text == "")
                {
                    box.Text = "0";
                }
            }
        }
        //OTHER
        private string ShowRollStr(int a)
        {
            if (a > 0)
            {
                return $"+{a}";
            }
            else
            {
                return $"{a}";
            }
        }
        private string MainToFlat(int stat)
        {
            double temp = stat;
            double temp2 = (int)Math.Floor((temp - 10) / 2);
            if (temp2 > 0)
            {
                return $"+{temp2}";
            }
            else
            {
                return $"{temp2}";
            }
        }
        private void statStateChange(object sender, EventArgs e)
        {
            if (statCheck.Checked)
            {
                MainStatsUpdate(false, true);
            }
            else
            {
                MainStatsUpdate(false, false);
            }
        }
        int ToInt(string a)
        {
            //yay fix for a dumb bug made it -404 for obiousity that its a error
            if (a == null || a == "")
            {
                //MessageBox.Show("Stat is missing a value");
                return -404;
            }
            return Convert.ToInt32(a);
        }
        double ToDouble(string a)
        {
            //yay fix for a dumb bug made it -404 for obiousity that its a error
            if (a == null || a == "")
            {
                //MessageBox.Show("Stat is missing a value");
                return -404.404;
            }
            return Convert.ToDouble(a);
        }
        private string StringCheck(string a)
        {
            if (a == null || a == "")
            {
                return "";
            }
            else
            {
                return a;
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

        private void ListHell(CheckBox checkBox, int a)
        {
            if (prof.Contains(a))
            {
                if (checkBox.Checked == false)
                {
                    prof.Remove(a);
                }
            }
            else
            {
                if (checkBox.Checked)
                {
                    prof.Add(a);
                }
            }
            ThrowsUpdate(false);
            SkillsUpdate(false);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox1, 1);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox2, 2);
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox3, 3);
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox4, 4);
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox5, 5);
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox6, 6);
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox7, 7);
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox8, 8);
        }
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox9, 9);
        }
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox10, 10);
        }
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox11, 11);
        }
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox12, 12);
        }
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox13, 13);
        }
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox14, 14);
        }
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox15, 15);
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox16, 16);
        }
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox17, 17);
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox18, 18);
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox19, 19);
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox20, 20);
        }
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox21, 21);
        }
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox22, 22);
        }
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox23, 23);
        }
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(checkBox24, 24);
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
        {
            // messagebox for saving
            DialogResult dialogResult = MessageBox.Show("Do you want to save the sheet?", "Save", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                quickSave();
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            quickSave();
            MessageBox.Show("Quick save successful");
        }

        private void quickSave()
        {
            SaveToCurrent();
            try
            {
                DataHandler.saveCharacter(currentChar, Properties.Settings.Default.path);
                this.UseWaitCursor = false;
            }catch (Exception)
            {
                MessageBox.Show("Error saving file");
            }
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
    }
}

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
        public CharSheet()
        {
            InitializeComponent();
        }
        //save sheet
        private void saveAsFile()
        {
            StreamWriter streamWriter;
            SaveToCurrent();
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName.Contains(".xml"))
            {
                streamWriter = new StreamWriter(saveFileDialog1.FileName);
            }
            else
            {
                streamWriter = new StreamWriter($"{saveFileDialog1.FileName}.xml");
            }
            serializer.Serialize(streamWriter, currentChar);
            streamWriter.Close();
        }
        //load sheet

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
            currentChar = (Character)serializer.Deserialize(fileStream);
            fileStream.Close();
            LoadToCurrent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveAsFile();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                        ints[i-1] = ToInt(box.Text) - currentChar.proeff;
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
                        box.Text = (currentChar.savingThrows.throwsLoad()[i - 1] + currentChar.proeff).ToString();
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
                        ints[i - 1] = ToInt(box.Text) - currentChar.proeff;
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
                        box.Text = (currentChar.skills.skillsLoad()[i - 1] + currentChar.proeff).ToString();
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
                if (prof.Contains(i+6))
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
            UpdateAllSave();


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
                MessageBox.Show("Stat is missing a value");
                return -404;
            }
            return Convert.ToInt32(a);
        }
        double ToDouble(string a)
        {
            //yay fix for a dumb bug made it -404 for obiousity that its a error
            if (a == null || a == "")
            {
                MessageBox.Show("Stat is missing a value");
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

        private void ListHell(CheckBox checkBox,int a)
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

        private void btn_sel_pic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //charImage.Image = Image.FromFile(openFileDialog1.FileName);
            charImage.ImageLocation = openFileDialog1.FileName;
            charImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}

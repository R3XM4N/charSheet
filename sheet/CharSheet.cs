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
using static sheet.Character;

namespace sheet
{
    public partial class CharSheet : Form
    {
        DataHandler dataHandler = new DataHandler();
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
                currentChar.AddXP(ToInt(lvlBox.Text));
                currentChar.SetBase(charNameBox.Text, raceBox.Text, classBox.Text);
            }
            else
            {
                charNameBox.Text = currentChar.cName;
                lvlBox.Text = currentChar.level.ToString();
                raceBox.Text = currentChar.race;
                classBox.Text = currentChar.charClass;
            }
        }
        //PAGE 1
        void CharInfoUpdate(bool save)
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
        //PAGE 2
        void MainStatsUpdate(bool save, bool plusState)
        {
            if (save && plusState == false)
            {
                //no saving rn
            }
            else
            {
                if (plusState)
                {
                    int[] temp = currentChar.stats.Get();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (currentChar.bonus[0].Contains(i))
                        {
                            temp[i] = temp[i] + currentChar.proefficency;
                        }
                    }
                    dataHandler.FillTextBoxes<int>(temp, new TextBox[6] { strBox, dexBox, constBox, intBox, wisdBox, charBox });
                }
                else
                {
                    dataHandler.FillTextBoxes<int>(currentChar.stats.Get(), new TextBox[6] { strBox, dexBox, constBox, intBox, wisdBox, charBox });
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
                        ints[i-1] = ToInt(box.Text) - currentChar.proefficency;
                    }
                    else
                    {
                        ints[i - 1] = ToInt(box.Text);
                    }
                    i++;
                }
                currentChar.savingThrows.Set(ints);
            }
            else
            {
                int i = 1;
                foreach (TextBox box in statBoxesThrow)
                {
                    if (prof.Contains(i))
                    {
                        box.Text = (currentChar.savingThrows.Get()[i - 1] + currentChar.proefficency).ToString();
                    }
                    else
                    {
                        box.Text = currentChar.savingThrows.Get()[i - 1].ToString();
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
                        ints[i - 1] = ToInt(box.Text) - currentChar.proefficency;
                    }
                    else
                    {
                        ints[i - 1] = ToInt(box.Text);
                    }
                    i++;
                }
                currentChar.skills.Set(ints);
            }
            else
            {
                int i = 1;
                foreach (TextBox box in statBoxesSkills)
                {
                    if (prof.Contains(i + 6))
                    {
                        box.Text = (currentChar.skills.Get()[i - 1] + currentChar.proefficency).ToString();
                    }
                    else
                    {
                        box.Text = currentChar.skills.Get()[i - 1].ToString();
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
                
            }
            else
            {
                TextBox[] temp = new TextBox[2] { treasureText, inventoryBox };
                dataHandler.FillTextBoxes<string>(currentChar.inventory, temp);
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
                dataHandler.FillTextBoxes<double>(currentChar.money.Get(), new TextBox[5] { cpText, spText, epText, gpText, ppText });
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
            }
            ThrowsUpdate(false);
            SkillsUpdate(false);
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

        private void btn_sel_pic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //charImage.Image = Image.FromFile(openFileDialog1.FileName);
            charImage.ImageLocation = openFileDialog1.FileName;
            charImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentChar = new Character();
            currentChar.characteristics = new Characteristics();
            currentChar.stats = new Stats();
            currentChar.savingThrows = new SavingThrows();
            currentChar.skills = new Skills();
            currentChar.money = new Money();

            checkBoxesThrow = new CheckBox[6] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };
            checkBoxesSkills = new CheckBox[18] { checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, checkBox20, checkBox21, checkBox22, checkBox23, checkBox24 };
            statBoxesThrow = new TextBox[6] { statBox1, statBox2, statBox3, statBox4, statBox5, statBox6 };
            statBoxesSkills = new TextBox[18] { statBox7, statBox8, statBox9, statBox10, statBox11, statBox12, statBox13, statBox14, statBox15, statBox16, statBox17, statBox18, statBox19, statBox20, statBox21, statBox22, statBox23, statBox24 };
        }
    }
}

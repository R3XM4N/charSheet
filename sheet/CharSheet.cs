using System;
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
        public List<int> prof = new List<int> { };
        CheckBox[] checkBoxesThrow;
        CheckBox[] checkBoxesSkills;
        public Character currentChar;
        public CharSheet()
        {
            InitializeComponent();
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
        }
        void UpdateHeader()
        {
            charNameBox.Text = currentChar.cName;
            lvlBox.Text = currentChar.level.ToString();
            raceBox.Text = currentChar.race;
            classBox.Text = currentChar.charClass;
        }
        void StatsUpdate(bool updateStats, bool updateThrows,bool updateSkills,bool statsFunctional)
        {
            if (updateStats)
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

        private void btn_sel_pic_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //charImage.Image = Image.FromFile(openFileDialog1.FileName);
            charImage.ImageLocation = openFileDialog1.FileName;
            charImage.SizeMode = PictureBoxSizeMode.StretchImage;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAintDealingWithThis(true);
        }
    }
}

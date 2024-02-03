﻿using System;
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
        public List<int> prof;
        public List<RadioButton> radioButtons;
        
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

            radioButtons = new List<RadioButton>{radio0, radio1, radio2, radio3, radio4, radio5, radio6, radio7, radio8, radio9, radio10,
                radio11, radio12, radio13, radio14, radio15, radio16, radio17, radio18, radio19, radio20,radio21, radio22, radio23
            };
        }
        //temp data saving
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            SaveToCurrent();
        }
        
        public void SaveToCurrent()
        {
            currentChar.cName = charNameBox.Text;
            currentChar.level = ToInt(lvlBox.Text);
            currentChar.race = raceBox.Text;
            currentChar._class = classBox.Text;

            currentChar.mainStats.Str = ToInt(strBox.Text);
            currentChar.mainStats.Dex = ToInt(dexBox.Text);
            currentChar.mainStats.Const = ToInt(constBox.Text);
            currentChar.mainStats.Int = ToInt(intBox.Text);
            currentChar.mainStats.Wis = ToInt(wisdBox.Text);
            currentChar.mainStats.Char = ToInt(charBox.Text);

            currentChar.savingThrows.Strenghth = ToInt(throwStrBox.Text);
            currentChar.savingThrows.Dexterity = ToInt(throwDexBox.Text);
            currentChar.savingThrows.Constitution = ToInt(throwConstBox.Text);
            currentChar.savingThrows.Inteligence = ToInt(throwIntBox.Text);
            currentChar.savingThrows.Wisdom = ToInt(throwWisdBox.Text);
            currentChar.savingThrows.Charisma = ToInt(throwCharBox.Text);

        }
        
        public void LoadToCurrent()
        {
            charNameBox.Text = currentChar.cName;
            lvlBox.Text = currentChar.level.ToString();
            raceBox.Text = currentChar.race;
            classBox.Text = currentChar._class;

            strBox.Text = currentChar.mainStats.Str.ToString();
            dexBox.Text = currentChar.mainStats.Dex.ToString();
            constBox.Text = currentChar.mainStats.Const.ToString();
            intBox.Text = currentChar.mainStats.Int.ToString();
            wisdBox.Text = currentChar.mainStats.Wis.ToString();
            charBox.Text = currentChar.mainStats.Char.ToString();
            
            throwStrBox.Text = currentChar.savingThrows.Strenghth.ToString();
            throwDexBox.Text = currentChar.savingThrows.Dexterity.ToString();
            throwConstBox.Text = currentChar.savingThrows.Constitution.ToString();
            throwIntBox.Text = currentChar.savingThrows.Inteligence.ToString();
            throwWisdBox.Text = currentChar.savingThrows.Wisdom.ToString();
            throwCharBox.Text = currentChar.savingThrows.Charisma.ToString();
            
        }
        public int ToInt(string a)
        {
            return Convert.ToInt32(a);
        }

        private void statStateChange(object sender, EventArgs e)
        {

        }

        /*
             _          _ _ 
            | |        | | |
            | |__   ___| | |
            | '_ \ / _ \ | |
            | | | |  __/ | |
            |_| |_|\___|_|_|
        */

        private void ListHell(RadioButton radioButton,int a)
        {
            if (prof.Contains(a))
            {
                if (radioButton.Checked == false)
                {
                    prof.Remove(a);
                }
            }
            else
            {
                if (radioButton.Checked)
                {
                    prof.Add(a);
                }
            }
        }
        private void radio0_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio0, 0);
        }
        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio1, 1);
        }
        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio2, 2);
        }
        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio3, 3);
        }
        private void radio4_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio4, 4);
        }
        private void radio5_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio5, 5);
        }
        private void radio6_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio6, 6);
        }
        private void radio7_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio7, 7);
        }
        private void radio8_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio8, 8);
        }
        private void radio9_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio9, 9);
        }
        private void radio10_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio10, 10);
        }
        private void radio11_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio11, 11);
        }
        private void radio12_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio12, 12);
        }
        private void radio13_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio13, 13);
        }
        private void radio14_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio14, 14);
        }
        private void radio15_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio15, 15);
        }

        private void radio16_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio16, 16);
        }
        private void radio17_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio17, 17);
        }
        private void radio18_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio18, 18);
        }
        private void radio19_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio19, 19);
        }
        private void radio20_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio20, 20);
        }
        private void radio21_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio21, 21);
        }
        private void radio22_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio22, 22);
        }
        private void radio23_CheckedChanged(object sender, EventArgs e)
        {
            ListHell(radio23, 23);
        }
    }
}
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
    public partial class Form1 : Form
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Character));
        public Character currentChar;
        public Form1()
        {
            InitializeComponent();
        }
        //save sheet
        private void toolStripButton1_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            currentChar = new Character();
            currentChar.stats = new Stats();
            currentChar.skills = new Skills();
            currentChar.savingThrows = new Sthrows();
            currentChar.charDescription = new CharDescription();

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

            currentChar.stats.Str = ToInt(strBox.Text);
            currentChar.stats.Dex = ToInt(dexBox.Text);
            currentChar.stats.Const = ToInt(constBox.Text);
            currentChar.stats.Int = ToInt(intBox.Text);
            currentChar.stats.Wis = ToInt(wisdBox.Text);
            currentChar.stats.Char = ToInt(charBox.Text);

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

            strBox.Text = currentChar.stats.Str.ToString();
            dexBox.Text = currentChar.stats.Dex.ToString();
            constBox.Text = currentChar.stats.Const.ToString();
            intBox.Text = currentChar.stats.Int.ToString();
            wisdBox.Text = currentChar.stats.Wis.ToString();
            charBox.Text = currentChar.stats.Char.ToString();
            
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
    }
}

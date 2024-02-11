using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static sheet.Character;

namespace sheet.Dialogs
{
    public partial class LoadDialog : Form
    {
        public Character character;
        public LoadDialog()
        {
            InitializeComponent();
        }
        private void LoadDialog_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var dh = new DataHandler())
            {
                using (var fd = new OpenFileDialog())
                {
                    fd.Title = "Select a character file.";
                    fd.Filter = "Json files (*.json)|*.json";
                    fd.ShowDialog();
                    character = dh.FromJsonFile<Character>(fd.FileName);
                }
            }
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            character = new Character();
            character.characteristics = new Characteristics();
            character.stats = new Stats();
            character.savingThrows = new SavingThrows();
            character.skills = new Skills();
            character.money = new Money();
            this.Close();
        }
    }
}

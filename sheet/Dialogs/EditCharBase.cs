using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet.Dialogs
{
    public partial class EditCharBase : Form
    {
        public Character character;
        public EditCharBase(Character character)
        {
            this.character = character;
            InitializeComponent();
        }
        private void EditCharBase_Load(object sender, EventArgs e)
        {
            DataHandler.FillTextBoxes(new string[5] {character.cName,character.race,character.charClass,character.level.ToString(),character.exp.ToString() },new TextBox[5] { charNameBox, raceBox, classBox,lvlBox,xpBox});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            character.SetBase(charNameBox.Text, raceBox.Text, classBox.Text);
            try
            {
                character.AddXP(Convert.ToInt32(xpBox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("An invalid XP value");
            }
            

        }
    }
}

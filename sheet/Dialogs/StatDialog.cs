using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet.Dialogs
{
    public partial class StatDialog : Form
    {
        public Character characterlol;
        GUIHandler handler;
        string[] stats = new string[6] { "Strength", "Dexterity","Constitution","Intelligence","Wisdom","Charisma"};
        string[] throws = new string[6] { "tStrength", "tDexterity", "tConstitution", "tIntelligence", "tWisdom", "tCharisma" };
        string[] skills = new string[18] { "Acrobatics", "Animal_Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation",
            "Investigation", "Medicine", "Nature", "Perception","Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealth","Survival"
        };

        public StatDialog(Character character)
        {
            InitializeComponent();
            characterlol = character;
            handler = new GUIHandler(this);

            handler.CreateTextBoxCollum(stats, stats, 15, 15, 18, 100, 10, statPanel);
            handler.CreateTextBoxCollum(throws, throws, 15, 15, 18, 100, 10, throwPanel);
            handler.CreateTextBoxCollum(skills, skills, 15, 15, 18, 100, 10, skillPanel);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClose);
        }
        void FormClose(object sender, FormClosingEventArgs e)
        {
            characterlol.stats.Set(DataHandler.StringArrayToInts(handler.GetControlsTextsArray(stats)));
            characterlol.skills.Set(DataHandler.StringArrayToInts(handler.GetControlsTextsArray(skills)));
            characterlol.savingThrows.Set(DataHandler.StringArrayToInts(handler.GetControlsTextsArray(throws)));
        }
    }
}

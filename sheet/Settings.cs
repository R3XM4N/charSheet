using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sheet
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can't change your username.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alc_gb.Enabled = !alc_gb.Enabled;
        }
    }
}

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
            txt_path.Text = Properties.Settings.Default.path;
            txt_ocname.Text = Properties.Settings.Default.pl_name;
            chb_autoload.Checked = Properties.Settings.Default.autoload;
            chb_menuskip.Checked = Properties.Settings.Default.skipmenu;
            cb_sort.SelectedIndex = Properties.Settings.Default.sorting_val;
            chb_autosave.Checked = Properties.Settings.Default.autosave;
            trackBar1.Value = Properties.Settings.Default.as_freq;
            label5.Text = Properties.Settings.Default.as_freq.ToString() + "s";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txt_path.Text = "";
            br_folder.ShowDialog();
            txt_path.Text = br_folder.SelectedPath;
            Properties.Settings.Default.path = txt_path.Text;
            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alc_gb.Enabled = !alc_gb.Enabled;
            Properties.Settings.Default.autoload = chb_autoload.Checked;
            Properties.Settings.Default.Save();
        }

        private void txt_ocname_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.pl_name = txt_ocname.Text;
            Properties.Settings.Default.Save();
        }

        private void chb_menuskip_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.skipmenu = chb_menuskip.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.sorting_val = cb_sort.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void chb_autosave_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autosave = chb_autosave.Checked;
            trackBar1.Visible = chb_autosave.Checked;
            label4.Visible = chb_autosave.Checked;
            label5.Visible = chb_autosave.Checked;
            Properties.Settings.Default.Save();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trackBar1.Value.ToString() + "s";
            Properties.Settings.Default.as_freq = trackBar1.Value;
            Properties.Settings.Default.Save();
        }
    }
}

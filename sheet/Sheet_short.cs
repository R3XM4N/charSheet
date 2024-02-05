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
    public partial class Sheet_short : Form
    {
        public Sheet_short(Character c)
        {
            InitializeComponent();
            setupSheet(c);
        }


        private void setupSheet(Character c)
        {
            lbl_bg.Text = c.apearance.background;
            lbl_rccl.Text = $"{c.race}/{c._class}";
            lbl_name.Text = c.cName;
            lbl_lvl.Text = c.level.ToString() + " level";
            lbl_alm.Text = c.apearance.alignment;
            lbl_cp.Text = c.money.copperC.ToString();
            lbl_sp.Text = c.money.silverC.ToString();
            lbl_ep.Text = c.money.electrumC.ToString();
            lbl_gp.Text = c.money.goldC.ToString();
            lbl_pp.Text = c.money.platinumC.ToString();
            //setPicture(c.apearance.image);
        }

        private void setPicture(string path)
        {
            pb_avatar.Image = Image.FromFile(path);
            pb_avatar.ImageLocation = path;
            pb_avatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}

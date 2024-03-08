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
            lbl_bg.Text = c.characteristics.background;
            lbl_rccl.Text = $"{c.race}/{c.charClass}";
            lbl_name.Text = c.cName;
            lbl_lvl.Text = c.level.ToString() + " level";
            lbl_alm.Text = c.characteristics.alignment;
            lbl_cp.Text = c.money[0].ToString();
            lbl_sp.Text = c.money[1].ToString();
            lbl_ep.Text = c.money[2].ToString();
            lbl_gp.Text = c.money[3].ToString();
            lbl_pp.Text = c.money[4].ToString();
            if (c.image != null)
            {
                setPicture(c.GetImage());
            }
        }

        private void setPicture(Image img)
        {
            pb_avatar.Image = img;
            pb_avatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}

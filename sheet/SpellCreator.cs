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
    public partial class SpellCreator : Form
    {
        public SpellCreator()
        {
            InitializeComponent();
        }

        public String[] getSpellData()
        {
            String[] data = new String[7];
            data[0] = txt_name.Text;
            data[1] = txt_school.Text;
            data[2] = txt_ct.Text;
            data[3] = txt_range.Text;
            data[4] = txt_comp.Text;
            data[5] = txt_dur.Text;
            data[6] = txt_desc.Text;
            return data;
        }
    }
}

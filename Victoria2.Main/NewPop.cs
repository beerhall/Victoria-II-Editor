//
//Du 2016.4.12
//


using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace Victoria2.Main
{
    public partial class NewPop : Form
    {
        public delegate void getNewPop(s_Pop newpop);
        private getNewPop getnewpop { get; set; }

        public NewPop(getNewPop p_getNewPop)
        {
            InitializeComponent();
            getCultureList();
            getReligionList();
            getPoptypeList();
            getnewpop = p_getNewPop;
        }

        private void getCultureList()
        {
            comboBoxCulture.Items.Clear();
            var l = LoadMethods.getCultures();
            foreach (s_Culture c in l)
            {
                comboBoxCulture.Items.Add(c.Name);
            }
        }

        private void getReligionList()
        {
            comboBoxReligion.Items.Clear();
            var l = LoadMethods.getReligions();
            foreach (s_Religion r in l)
            {
                comboBoxReligion.Items.Add(r.Name);
            }
        }

        private void getPoptypeList()
        {
            comboBoxPoptype.Items.Clear();
            var l = LoadMethods.getPoptypeList();
            foreach (string s in l)
            {
                comboBoxPoptype.Items.Add(s);
            }
        }


        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            s_Religion r = new s_Religion(comboBoxReligion.Text);
            s_Culture c = new s_Culture(comboBoxReligion.Text);
            s_Pop p = new s_Pop(r, c, textBoxSize.Text);
            getnewpop(p);
            this.Close();
        }
    }
}

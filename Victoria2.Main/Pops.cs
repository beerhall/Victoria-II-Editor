using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victoria2.Main
{
    public partial class Pops : Form
    {
        private string currentProvince;

        private s_Pop pop_got { get; set; }
        private void getNewPop(s_Pop p)
        {
            pop_got = p;
            checkedListBoxPops.Items.Add(p.ToString());
        }

        public Pops()
        {
            InitializeComponent();
            getPopsList();
        }

        private void getPopsList()
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            NewPop np = new NewPop(getNewPop);
            np.Show();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}

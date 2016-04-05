using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Victoria2.Main
{
    public partial class NewGovernment : Form
    {
        MainForm mf;
        XmlDocument governments = new XmlDocument();
        public NewGovernment(MainForm mfPass)
        {
            InitializeComponent();
            mf = mfPass;
        }

        private void buttonSaveGovernments_Click(object sender, EventArgs e)
        {
            if (!confirmInput())
            {
                return;
            }

            XmlElement node = governments.CreateElement(textBoxGovernmentName.Text);
            foreach (var ideos in checkedListBoxIdeologies.CheckedItems)
            {
                XmlElement ele = governments.CreateElement(ideos.ToString());
                ele.InnerText = "yes";
                node.AppendChild(ele);
            }

            XmlElement election = governments.CreateElement("election");
            election.InnerText = checkBoxElection.Checked ? "yes" : "no";
            node.AppendChild(election);

            if (checkBoxElection.Checked)
            {
                XmlElement duration = governments.CreateElement("duration");
                duration.InnerText = numericUpDownDuration.Value.ToString();
                node.AppendChild(duration);
            }

            XmlElement appoint_ruling_party = governments.CreateElement("appoint_ruling_party");
            appoint_ruling_party.InnerText = checkBoxAppointRulingParty.Checked ? "yes" : "no";
            node.AppendChild(appoint_ruling_party);

            if (comboBoxFlagType.Text != "默认")
            {
                XmlElement flagType = governments.CreateElement("flagType");
                flagType.InnerText = comboBoxFlagType.Text;
                node.AppendChild(flagType);
            }

            governments.ChildNodes[1].AppendChild(node);
            governments.Save(".\\xml\\common\\governments.txt.xml");
            MessageBox.Show("保存成功！");
            mf.Reload();
            this.Close();
        }

        private void getIdeologies()
        {
            XmlDocument ideologies = new XmlDocument();
            ideologies.Load(".\\xml\\common\\ideologies.txt.xml");
            foreach (XmlNode node1 in ideologies.ChildNodes[1])
            {
                foreach (XmlNode node2 in node1)
                {
                    checkedListBoxIdeologies.Items.Add(node2.Name);
                }
            }
        }

        private void NewGovernment_Load(object sender, EventArgs e)
        {
            getIdeologies();
            governments.Load(".\\xml\\common\\governments.txt.xml");
        }

        private bool confirmInput()
        {
            if (checkedListBoxIdeologies.CheckedItems.Count == 0)
            {
                MessageBox.Show("请至少选择一项允许的意识形态！");
                return false;
            }
            if (!Regex.IsMatch(textBoxGovernmentName.Text, @"\w+"))
            {
                MessageBox.Show("政体名格式错误！");
                return false;
            }
            foreach (XmlNode node in governments.ChildNodes[1])
            {
                if (node.Name == textBoxGovernmentName.Text)
                {
                    MessageBox.Show("政体名已经存在！");
                    return false;
                }
            }
            if (checkBoxElection.Checked && numericUpDownDuration.Value < 3)
            {
                MessageBox.Show("选举间隔太短！");
                return false;
            }
            return true;
        }

        private void buttonCancelGovernment_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxElection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxElection.Checked)
            {
                numericUpDownDuration.Enabled = true;
            }
            else
            {
                numericUpDownDuration.Enabled = false;
            }
        }
    }
}

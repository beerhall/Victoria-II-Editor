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
using System.Collections;

namespace Victoria2.Main
{
    public partial class NewParty : Form
    {
        XmlDocument ideologies_txt_xml = new XmlDocument();
        XmlDocument issues_txt_xml = new XmlDocument();
        ArrayList partyNameList = new ArrayList();
        string countryName;
        public NewParty(string countryName_pass)
        {
            InitializeComponent();
            countryName = countryName_pass;
        }

        private void NewParty_Load(object sender, EventArgs e)
        {
            ideologies_txt_xml.Load(".\\xml\\common\\ideologies.txt.xml");
            issues_txt_xml.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in ideologies_txt_xml.ChildNodes[1])
            {
                foreach (XmlNode node_in in node)
                {
                    comboBoxIdeologies.Items.Add(node_in.Name);
                }
            }
            XmlNode party_issues = issues_txt_xml.ChildNodes[1].SelectSingleNode("party_issues");
            XmlNode trade_policy = party_issues.SelectSingleNode("trade_policy");
            foreach (XmlNode node2 in trade_policy)
            {
                comboBoxTradePolicy.Items.Add(node2.Name);
            }
            XmlNode economic_policy = party_issues.SelectSingleNode("economic_policy");
            foreach (XmlNode node2 in economic_policy)
            {
                comboBoxEconomicPolicy.Items.Add(node2.Name);
            }
            XmlNode religious_policy = party_issues.SelectSingleNode("religious_policy");
            foreach (XmlNode node2 in religious_policy)
            {
                comboBoxReligiousPolicy.Items.Add(node2.Name);
            }
            XmlNode citizenship_policy = party_issues.SelectSingleNode("citizenship_policy");
            foreach (XmlNode node2 in citizenship_policy)
            {
                comboBoxCitizenshipPolicy.Items.Add(node2.Name);
            }
            XmlNode war_policy = party_issues.SelectSingleNode("war_policy");
            foreach (XmlNode node2 in war_policy)
            {
                comboBoxWarPolicy.Items.Add(node2.Name);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            XmlDocument country = new XmlDocument();
            country.Load(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            XmlNode node = country.CreateElement("party");

            if (textBoxPartyName.Text == "" || textBoxStartDate.Text == "" || textBoxEndDate.Text == ""
                || comboBoxIdeologies.Text == "" || comboBoxEconomicPolicy.Text == "" || comboBoxTradePolicy.Text == ""
              || comboBoxReligiousPolicy.Text == "" || comboBoxCitizenshipPolicy.Text == "" || comboBoxWarPolicy.Text == "")
            {
                MessageBox.Show("文本框不能为空！");
                return;
            }
            if (!Victoria2.Main.Program.isDate(textBoxStartDate.Text) || !Victoria2.Main.Program.isDate(textBoxEndDate.Text))
            {
                MessageBox.Show("日期格式错误！");
                return;
            }
            foreach (XmlNode xn in country.ChildNodes[1])
            {
                if (xn.Name == "party" && Victoria2.Domain.Comm.FileHelper.Unescape(xn.SelectSingleNode("name").InnerText) == "\"" + textBoxPartyName.Text + "\"")
                {
                    MessageBox.Show("政党已经存在！");
                    return;
                }
            }

            XmlElement name = country.CreateElement("name");
            name.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("\"" + textBoxPartyName.Text + "\"");
            node.AppendChild(name);

            XmlElement start_date = country.CreateElement("start_date");
            start_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxStartDate.Text);
            node.AppendChild(start_date);

            XmlElement end_date = country.CreateElement("end_date");
            end_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxEndDate.Text);
            node.AppendChild(end_date);

            XmlElement ideology = country.CreateElement("ideology");
            ideology.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxIdeologies.Text);
            node.AppendChild(ideology);

            XmlElement economic_policy = country.CreateElement("economic_policy");
            economic_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxEconomicPolicy.Text);
            node.AppendChild(economic_policy);

            XmlElement trade_policy = country.CreateElement("trade_policy");
            trade_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxTradePolicy.Text);
            node.AppendChild(trade_policy);

            XmlElement religious_policy = country.CreateElement("religious_policy");
            religious_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxReligiousPolicy.Text);
            node.AppendChild(religious_policy);

            XmlElement citizenship_policy = country.CreateElement("citizenship_policy");
            citizenship_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxCitizenshipPolicy.Text);
            node.AppendChild(citizenship_policy);

            XmlElement war_policy = country.CreateElement("war_policy");
            war_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxWarPolicy.Text);
            node.AppendChild(war_policy);

            country.ChildNodes[1].InsertBefore(node, country.ChildNodes[1].SelectSingleNode("unit_names"));

            //country.ChildNodes[1].AppendChild(node);
            country.Save(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            this.Close();
            MessageBox.Show("添加新政党成功！");
            return;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

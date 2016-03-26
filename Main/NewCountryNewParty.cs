using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace Victoria2.Main
{
    public partial class NewCountryNewParty : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;

        public NewCountryNewParty(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void NewCountryNewParty_Load(object sender, EventArgs e)
        {
            getIdeologies();
            getEconomicPolicies();
            getTradePolicies();
            getReligiousPolicies();
            getCitizenshipPolicies();
            getWarPolocies();
        }

        private void getIdeologies()
        {
            XmlDocument ideologoes = new XmlDocument();
            ideologoes.Load(".\\xml\\common\\ideologies.txt.xml");
            foreach (XmlNode node1 in ideologoes.ChildNodes[1])
            {
                foreach (XmlNode node2 in node1)
                {
                    comboBoxIdeologies.Items.Add(node2.Name);
                }
            }
        }

        private void getEconomicPolicies()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("party_issues").SelectSingleNode("economic_policy"))
            {
                comboBoxEconomicPolicy.Items.Add(node.Name);
            }
        }

        private void getTradePolicies()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("party_issues").SelectSingleNode("trade_policy"))
            {
                comboBoxTradePolicy.Items.Add(node.Name);
            }
        }

        private void getReligiousPolicies()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("party_issues").SelectSingleNode("religious_policy"))
            {
                comboBoxReligiousPolicy.Items.Add(node.Name);
            }
        }

        private void getCitizenshipPolicies()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("party_issues").SelectSingleNode("citizenship_policy"))
            {
                comboBoxCitizenshipPolicy.Items.Add(node.Name);
            }
        }

        private void getWarPolocies()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("party_issues").SelectSingleNode("war_policy"))
            {
                comboBoxWarPolicy.Items.Add(node.Name);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxPartyName.Text, @"\w+"))
            {
                MessageBox.Show("请正确填写政党名！");
                return;
            }
            if (!Victoria2.Main.Program.isDate(textBoxStartDate.Text) || !Victoria2.Main.Program.isDate(textBoxEndDate.Text))
            {
                MessageBox.Show("日期格式错误！");
                return;
            }
            //3/23/22/56
            if (comboBoxIdeologies.SelectedIndex == -1 || comboBoxEconomicPolicy.SelectedIndex == -1
                || comboBoxTradePolicy.SelectedIndex == -1 || comboBoxReligiousPolicy.SelectedIndex == -1
                || comboBoxCitizenshipPolicy.SelectedIndex == -1 || comboBoxWarPolicy.SelectedIndex == -1)
            {
                MessageBox.Show("选项不能为空！");
                return;
            }
            XmlDocument countries = new XmlDocument();
            countries.Load(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            XmlElement party = countries.CreateElement("party");


            XmlElement name = countries.CreateElement("name");
            name.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("\"" + textBoxPartyName.Text + "\"");
            party.AppendChild(name);

            XmlElement start_date = countries.CreateElement("start_date");
            start_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxStartDate.Text);
            party.AppendChild(start_date);

            XmlElement end_date = countries.CreateElement("end_date");
            end_date.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxEndDate.Text);
            party.AppendChild(end_date);

            XmlElement ideology = countries.CreateElement("ideology");
            ideology.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxIdeologies.SelectedItem.ToString());
            party.AppendChild(ideology);

            XmlElement economic_policy = countries.CreateElement("economic_policy");
            economic_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxEconomicPolicy.SelectedItem.ToString());
            party.AppendChild(economic_policy);//trade_policy

            XmlElement trade_policy = countries.CreateElement("trade_policy");
            trade_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxTradePolicy.SelectedItem.ToString());
            party.AppendChild(trade_policy);

            XmlElement religious_policy = countries.CreateElement("religious_policy");
            religious_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxReligiousPolicy.SelectedItem.ToString());
            party.AppendChild(religious_policy);

            XmlElement citizenship_policy = countries.CreateElement("citizenship_policy");
            citizenship_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxCitizenshipPolicy.SelectedItem.ToString());
            party.AppendChild(citizenship_policy);

            XmlElement war_policy = countries.CreateElement("war_policy");
            war_policy.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxWarPolicy.SelectedItem.ToString());
            party.AppendChild(war_policy);


            countries.ChildNodes[1].InsertBefore(party, countries.ChildNodes[1].SelectSingleNode("unit_names"));
            countries.Save(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            NewCountryParty ncp = new NewCountryParty(countryTagName, countryName, mf);
            ncp.Show();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            NewCountryParty ncp = new NewCountryParty(countryTagName, countryName, mf);
            ncp.Show();
            this.Close();
        }
    }
}

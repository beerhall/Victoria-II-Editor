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
    public partial class NewCountryParty : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument country = new XmlDocument();
        public NewCountryParty(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void NewCountryParty_Load(object sender, EventArgs e)
        {
            getIdeologies();
            getEconomicPolicies();
            getTradePolicies();
            getReligiousPolicies();
            getCitizenshipPolicies();
            getWarPolocies();
            country.Load(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            getParties();
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

        private void getParties()
        {
            if (country.ChildNodes[1].SelectSingleNode("party") != null)
            {
                foreach (XmlNode node in country.ChildNodes[1].SelectNodes("party"))
                {
                    listBoxParties.Items.Add(Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText).Replace("\"", ""));
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            NewCountryNewParty ncnp = new NewCountryNewParty(countryTagName, countryName, mf);
            ncnp.Show();
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            File.Delete(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
            File.Delete(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            XmlDocument countries = new XmlDocument();
            countries.Load(".\\xml\\common\\countries.txt.xml");
            countries.ChildNodes[1].RemoveChild(countries.ChildNodes[1].SelectSingleNode(countryTagName));
            countries.Save(".\\xml\\common\\countries.txt.xml");
            NewCountry nc = new NewCountry(countryTagName, countryName, mf);
            nc.Show();
            this.Close();
        }

        private void listBoxParties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxParties.SelectedIndex == -1)
            {
                return;
            }
            foreach (XmlNode node in country.ChildNodes[1].SelectNodes("party"))
            {
                if (Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText) == "\"" + listBoxParties.SelectedItem.ToString() + "\"")
                {
                    textBoxStartDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("start_date").InnerText);
                    textBoxEndDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("end_date").InnerText);
                    comboBoxIdeologies.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("ideology").InnerText);
                    comboBoxEconomicPolicy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("economic_policy").InnerText);
                    comboBoxTradePolicy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("trade_policy").InnerText);
                    comboBoxReligiousPolicy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("religious_policy").InnerText);
                    comboBoxCitizenshipPolicy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("citizenship_policy").InnerText);
                    comboBoxWarPolicy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("war_policy").InnerText);
                    return;
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            foreach (XmlNode node in country.ChildNodes[1].SelectNodes("party"))
            {
                if (Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText) == "\"" + listBoxParties.SelectedItem.ToString() + "\"")
                {
                    country.ChildNodes[1].RemoveChild(node);
                    country.Save(".\\xml\\common\\countries\\" + countryName + ".txt.xml");
                    listBoxParties.Items.Clear();
                    getParties();
                    return;
                }
            }
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            NewCountryHistory nch = new NewCountryHistory(countryTagName, countryName, mf);
            nch.Show();
            //nch.MdiParent = this.MdiParent;
            this.Close();
        }
    }
}

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
    public partial class NewCountrySocialReforms : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countryHistory = new XmlDocument();
        XmlDocument issues = new XmlDocument();

        public NewCountrySocialReforms(string countryTagNamePass, string countryNamePass,MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void NewCountrySocialReforms_Load(object sender, EventArgs e)
        {
            countryHistory.Load(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            issues.Load(".\\xml\\common\\issues.txt.xml");
            getSocialReforms();
        }

        private void getSocialReforms()
        {
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("social_reforms"))
            {
                listBoxSocialReforms.Items.Add(node.Name);
                XmlElement socialReform = countryHistory.CreateElement(node.Name);
                socialReform.InnerText = "";
                countryHistory.ChildNodes[1].InsertAfter(socialReform, countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal"));
            }
        }

        private void listBoxSocialReforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxSocialReformsValues.Items.Clear();
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("social_reforms").SelectSingleNode(listBoxSocialReforms.SelectedItem.ToString()))
            {
                if (node.Name != "next_step_only")
                {
                    listBoxSocialReformsValues.Items.Add(node.Name);
                }
            }
            if (!string.IsNullOrEmpty(countryHistory.ChildNodes[1].SelectSingleNode(listBoxSocialReforms.SelectedItem.ToString()).InnerText))
            {
                listBoxSocialReformsValues.Text = countryHistory.ChildNodes[1].SelectSingleNode(listBoxSocialReforms.SelectedItem.ToString()).InnerText;
            }
        }

        private void listBoxSocialReformsValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            countryHistory.ChildNodes[1].SelectSingleNode(listBoxSocialReforms.SelectedItem.ToString()).InnerText = listBoxSocialReformsValues.SelectedItem.ToString();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("social_reforms"))
            {
                if (string.IsNullOrEmpty(countryHistory.ChildNodes[1].SelectSingleNode(node.Name).InnerText))
                {
                    MessageBox.Show("社会改革不能为空！");
                    return;
                }
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountryTechnology nct = new NewCountryTechnology(countryTagName, countryName,mf);
            nct.Show();
            //nct.MdiParent = this.MdiParent;
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            NewCountryCultrues ncc = new NewCountryCultrues(countryTagName, countryName,mf);
            foreach (XmlNode node in countryHistory.ChildNodes[1])
            {
                foreach (var reforms in listBoxSocialReforms.Items)
                {
                    if (node.Name == reforms.ToString())
                    {
                        countryHistory.ChildNodes[1].RemoveChild(node);
                    }
                }
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            ncc.Show();
            this.Close();
        }
    }
}


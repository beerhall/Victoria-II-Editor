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
    public partial class NewCountryPoliticalReforms : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countryHistory = new XmlDocument();
        XmlDocument issues = new XmlDocument();

        public NewCountryPoliticalReforms(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void NewCountryPoliticalReforms_Load(object sender, EventArgs e)
        {
            countryHistory.Load(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            issues.Load(".\\xml\\common\\issues.txt.xml");
            getPoliticalReforms();
        }

        private void getPoliticalReforms()
        {
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("political_reforms"))
            {
                Console.WriteLine(node.Name);
                listBoxPoliticalReforms.Items.Add(node.Name);

                XmlElement politicalReform = countryHistory.CreateElement(node.Name);
                politicalReform.InnerText = "";
                countryHistory.ChildNodes[1].InsertAfter(politicalReform, countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal"));
            }
        }

        private void listBoxPoliticalReforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPoliticalReforms.SelectedIndex == -1)
            {
                return;
            }
            listBoxPoliticalReformsValues.Items.Clear();
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("political_reforms").SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()))
            {
                if (node.Name != "next_step_only")
                {
                    listBoxPoliticalReformsValues.Items.Add(node.Name);
                }
            }
            if (!string.IsNullOrEmpty(countryHistory.ChildNodes[1].SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()).InnerText))
            {
                listBoxPoliticalReformsValues.Text = countryHistory.ChildNodes[1].SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()).InnerText;
            }
        }

        private void listBoxPoliticalReformsValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            countryHistory.ChildNodes[1].SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()).InnerText = listBoxPoliticalReformsValues.SelectedItem.ToString();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("political_reforms"))
            {
                if (string.IsNullOrEmpty(countryHistory.ChildNodes[1].SelectSingleNode(node.Name).InnerText))
                {
                    MessageBox.Show("政治改革不能为空！");
                    return;
                }
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountrySocialReforms ncsr = new NewCountrySocialReforms(countryTagName, countryName, mf);
            ncsr.Show();
            //ncsr.MdiParent = this.MdiParent;
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            NewCountryCultrues ncc = new NewCountryCultrues(countryTagName, countryName, mf);
            foreach (XmlNode node in countryHistory.ChildNodes[1])
            {
                foreach (var reforms in listBoxPoliticalReforms.Items)
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

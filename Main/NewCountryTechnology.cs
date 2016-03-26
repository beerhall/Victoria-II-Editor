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
    public partial class NewCountryTechnology : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countryHistory = new XmlDocument();

        public NewCountryTechnology(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void NewCountryTechnology_Load(object sender, EventArgs e)
        {
            countryHistory.Load(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            getTechnologies();
        }

        private void getTechnologies()
        {
            XmlDocument technologies = new XmlDocument();

            foreach (string filename in Directory.GetFiles(".\\xml\\technologies"))
            {
                string fn = filename.Substring(filename.LastIndexOf("\\"));
                technologies.Load(".\\xml\\technologies" + fn);
                foreach (XmlNode node in technologies.ChildNodes[1])
                {
                    checkedListBoxTechnologies.Items.Add(node.Name.Trim());
                }
            }
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            foreach (var tech in checkedListBoxTechnologies.CheckedItems)
            {
                XmlElement ele = countryHistory.CreateElement(tech.ToString());
                ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("1");
                countryHistory.ChildNodes[1].AppendChild(ele);
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountryUpperHouse ncuh = new NewCountryUpperHouse(countryTagName, countryName, mf);
            ncuh.Show();
            //ncuh.MdiParent = this.MdiParent;
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            NewCountrySocialReforms ncsr = new NewCountrySocialReforms(countryTagName, countryName, mf);
            foreach (XmlNode node in countryHistory.ChildNodes[1])
            {
                foreach (var techs in checkedListBoxTechnologies.Items)
                {
                    if (node.Name == techs.ToString())
                    {
                        countryHistory.ChildNodes[1].RemoveChild(node);
                    }
                }
            }
            ncsr.Show();
            this.Close();
        }

    }
}

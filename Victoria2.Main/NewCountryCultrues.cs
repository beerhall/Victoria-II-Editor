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
    public partial class NewCountryCultrues : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countryHistory = new XmlDocument();

        public NewCountryCultrues(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryName = countryNamePass;
            countryTagName = countryTagNamePass;
            mf = mfPass;
        }

        private void NewCountryCultrues_Load(object sender, EventArgs e)
        {
            getCultrueList();
            countryHistory.Load(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
        }

        private void getCultrueList()
        {
            XmlDocument cultures = new XmlDocument();
            cultures.Load(".\\xml\\common\\cultures.txt.xml");
            foreach (XmlNode cultureGruop in cultures.ChildNodes[1])
            {
                foreach (XmlNode cultureNode in cultureGruop)
                {
                    if (cultureNode.Name != "leader" && cultureNode.Name != "unit" && cultureNode.Name != "union" && cultureNode.Name != "is_overseas")
                    {
                        checkedListBoxCultrues.Items.Add(cultureNode.Name);
                    }
                }
            }
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            foreach (var it in checkedListBoxCultrues.CheckedItems)
            {
                XmlElement culture = countryHistory.CreateElement("culture");
                culture.InnerText = it.ToString();
                countryHistory.ChildNodes[1].InsertAfter(culture, countryHistory.ChildNodes[1].SelectSingleNode("primary_culture"));
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountryPoliticalReforms ncpr = new NewCountryPoliticalReforms(countryTagName, countryName, mf);
            ncpr.Show();
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            foreach (XmlNode node in countryHistory.ChildNodes[1].SelectNodes("culture"))
            {
                countryHistory.ChildNodes[1].RemoveChild(node);
            }
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountryHistory nch = new NewCountryHistory(countryTagName, countryName, mf);
            nch.Show();
            this.Close();
        }
    }
}

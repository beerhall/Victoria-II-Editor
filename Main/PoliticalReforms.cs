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
    public partial class PoliticalReforms : Form
    {
        string countryName;
        Dictionary<string, string> countriesDic = new Dictionary<string, string>();
        Dictionary<string, string> countriesHistoryDic = new Dictionary<string, string>();
        public PoliticalReforms(string CountryNamePass)
        {
            InitializeComponent();
            countryName = CountryNamePass;
        }

        private void PoliticalReforms_Load(object sender, EventArgs e)
        {
            getPoloticalReforms();
            this.Text = countryName + " PoliticalReforms";
            getCountriesNames();
            getCountriesHistoryDic();
        }

        private void getPoloticalReforms()
        {
            XmlDocument issues = new XmlDocument();
            issues.Load(".\\xml\\common\\issues.txt.xml");
            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("political_reforms"))
            {
                listBoxPoliticalReforms.Items.Add(node.Name);
            }
        }

        private void listBoxPoliticalReforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPoliticalReformsValues.Items.Clear();
            XmlDocument issues = new XmlDocument();
            XmlDocument countryHistory = new XmlDocument();
            if (!Regex.IsMatch(countriesDic[countryName], @"\S\d\d"))
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + " - " + countriesHistoryDic[countriesDic[countryName]] + ".txt.xml");
            }
            else
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + ".txt.xml");
            }
            issues.Load(".\\xml\\common\\issues.txt.xml");

            foreach (XmlNode node in issues.ChildNodes[1].SelectSingleNode("political_reforms").SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()))
            {
                if (node.Name != "next_step_only")
                {
                    listBoxPoliticalReformsValues.Items.Add(node.Name);
                }
            }
            listBoxPoliticalReformsValues.Text = countryHistory.ChildNodes[1].SelectSingleNode(listBoxPoliticalReforms.SelectedItem.ToString()).InnerText;
        }

        private void getCountriesHistoryDic()
        {
            string[] files = Directory.GetFiles(".\\xml\\history\\countries");
            foreach (string fn in files)
            {
                string filename = fn.Substring(fn.LastIndexOf("\\") + 1).Replace(".txt.xml", "");
                if (filename.Contains('-'))
                {
                    string tagName = filename.Substring(0, 3);
                    string historyName = filename.Substring(filename.IndexOf("-") + 1);
                    countriesHistoryDic.Add(tagName.Trim(), historyName.Trim());
                }
            }
        }

        public void getCountriesNames()
        {
            XmlDocument countries_txt_xml = new XmlDocument();
            countries_txt_xml.Load(".\\xml\\common\\countries.txt.xml");
            foreach (XmlNode node in countries_txt_xml.ChildNodes[1])
            {
                string str = Victoria2.Domain.Comm.FileHelper.Unescape(node.InnerText);
                if (str == "yes" || str.Contains("rebels") || Regex.IsMatch(str, @"\S\d\d"))
                {
                    continue;
                }
                StringBuilder sb = new StringBuilder(str);
                sb = sb.Replace("\"", "");
                sb = sb.Replace("countries/", "");
                sb = sb.Replace(".txt", "");
                countriesDic.Add(sb.ToString(), Victoria2.Domain.Comm.FileHelper.Unescape(node.Name));
            }
        }

        private void listBoxPoliticalReformsValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument countryHistory = new XmlDocument();
            if (!Regex.IsMatch(countriesDic[countryName], @"\S\d\d"))
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + " - " + countriesHistoryDic[countriesDic[countryName]] + ".txt.xml");
            }
            else
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + ".txt.xml");
            }
            countryHistory.ChildNodes[1].SelectSingleNode(listBoxPoliticalReforms.Text).InnerText = listBoxPoliticalReformsValues.Text;
            if (!Regex.IsMatch(countriesDic[countryName], @"\S\d\d"))
            {
                countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[countryName] + " - " + countriesHistoryDic[countriesDic[countryName]] + ".txt.xml");
            }
            else
            {
                countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[countryName] + ".txt.xml");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

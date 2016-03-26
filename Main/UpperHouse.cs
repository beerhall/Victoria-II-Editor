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
using System.Text.RegularExpressions;
using System.IO;

namespace Victoria2.Main
{
    public partial class UpperHouse : Form
    {
        string countryName;
        Dictionary<string, string> countriesDic = new Dictionary<string, string>();
        Dictionary<string, string> countriesHistoryDic = new Dictionary<string, string>();
        XmlDocument countryHistory = new XmlDocument();

        public UpperHouse(string countryNamePass)
        {
            InitializeComponent();
            countryName = countryNamePass;
            this.Text = countryName + " UpperHouse";
        }

        private void UpperHouse_Load(object sender, EventArgs e)
        {
            getCountriesHistoryDic();
            getCountriesNames();
            getIdeologies();
            getCountryHistory();
        }

        private void getIdeologies()
        {
            XmlDocument ideologies = new XmlDocument();
            ideologies.Load(".\\xml\\common\\ideologies.txt.xml");
            foreach (XmlNode node in ideologies.ChildNodes[1])
            {
                foreach (XmlNode node_in in node)
                {
                    listBoxIdeologies.Items.Add(node_in.Name);
                }
            }
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

        private void getCountryHistory()
        {
            if (!Regex.IsMatch(countriesDic[countryName], @"\S\d\d"))
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + " - " + countriesHistoryDic[countriesDic[countryName]] + ".txt.xml");
            }
            else
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[countryName] + ".txt.xml");
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

        private void listBoxIdeologies_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownValue.Value = int.Parse(Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("upper_house").SelectSingleNode(listBoxIdeologies.SelectedItem.ToString()).InnerText));
        }

        private void numericUpDownValue_ValueChanged(object sender, EventArgs e)
        {
            countryHistory.ChildNodes[1].SelectSingleNode("upper_house").SelectSingleNode(listBoxIdeologies.SelectedItem.ToString()).InnerText = Victoria2.Domain.Comm.FileHelper.Escape(numericUpDownValue.Value.ToString());
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (XmlNode node in countryHistory.ChildNodes[1].SelectSingleNode("upper_house"))
            {
                total += int.Parse(Victoria2.Domain.Comm.FileHelper.Unescape(node.InnerText));
            }
            if (total != 100)
            {
                MessageBox.Show("比例总和不为100！");
                return;
            }
            else
            {
                if (!Regex.IsMatch(countriesDic[countryName], @"\S\d\d"))
                {
                    countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[countryName] + " - " + countriesHistoryDic[countriesDic[countryName]] + ".txt.xml");
                }
                else
                {
                    countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[countryName] + ".txt.xml");
                }
                this.Close();
            }
        }
    }
}

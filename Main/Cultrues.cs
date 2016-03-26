using System;
using System.IO;
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

namespace Victoria2.Main
{
    public partial class Cultrues : Form
    {
        string countryName;
        Dictionary<string, string> countriesDic = new Dictionary<string, string>();
        Dictionary<string, string> countriesHistoryDic = new Dictionary<string, string>();
        Dictionary<string, int> checkedListBoxItemsIndex = new Dictionary<string, int>();
        int index = 0;
        public Cultrues(string countryNamePass)
        {
            countryName = countryNamePass;
            InitializeComponent();
        }

        private void Cultrues_Load(object sender, EventArgs e)
        {
            this.Text = countryName + " cultrues";
            getCultureList();
            getCountriesNames();
            getCountriesHistoryDic();
            getSelectedCultrues();
        }

        private void getCultureList()
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
                        if (!checkedListBoxItemsIndex.ContainsKey(cultureNode.Name))
                        {
                            checkedListBoxItemsIndex.Add(cultureNode.Name, index++);
                        }
                    }
                }
            }
        }

        private void getSelectedCultrues()
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
            foreach (XmlNode node in countryHistory.ChildNodes[1].SelectNodes("culture"))
            {
                checkedListBoxCultrues.SetItemChecked(checkedListBoxItemsIndex[node.InnerText], true);
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

        private void buttonConfirm_Click(object sender, EventArgs e)
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
            foreach (XmlNode node in countryHistory.ChildNodes[1].SelectNodes("culture"))
            {
                countryHistory.ChildNodes[1].RemoveChild(node);
            }
            foreach (var SelectedItem in checkedListBoxCultrues.CheckedItems)
            {
                XmlElement cultureEle = countryHistory.CreateElement("culture");
                cultureEle.InnerText = SelectedItem.ToString();
                countryHistory.ChildNodes[1].InsertAfter(cultureEle, countryHistory.ChildNodes[1].SelectSingleNode("primary_culture"));
            }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

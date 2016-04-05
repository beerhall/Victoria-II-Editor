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
    public partial class Technology : Form
    {
        string countryName;
        int index = 0;
        Dictionary<string, string> countriesDic = new Dictionary<string, string>();
        Dictionary<string, string> countriesHistoryDic = new Dictionary<string, string>();
        Dictionary<string, int> checkedListBoxItemsIndex = new Dictionary<string, int>();

        public Technology(string countryNamePass)
        {
            InitializeComponent();
            countryName = countryNamePass;
        }

        private void Technology_Load(object sender, EventArgs e)
        {
            this.Text = countryName + " Technology";
            getCountriesNames();
            getCountriesHistoryDic();
            getTechnologies();
            getCheckedItems();
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
                    checkedListBoxItemsIndex.Add(node.Name.Trim(), index++);
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

        private void getCheckedItems()
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
            foreach (XmlNode node in countryHistory.ChildNodes[1])
            {
                if (checkedListBoxItemsIndex.ContainsKey(node.Name))
                {
                    checkedListBoxTechnologies.SetItemChecked(checkedListBoxItemsIndex[Victoria2.Domain.Comm.FileHelper.Unescape(node.Name)], true);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

            for (int i = 0; i < countryHistory.ChildNodes[1].ChildNodes.Count; i++)
            {
                if (checkedListBoxItemsIndex.ContainsKey(countryHistory.ChildNodes[1].ChildNodes[i].Name))
                {
                    countryHistory.ChildNodes[1].RemoveChild(countryHistory.ChildNodes[1].ChildNodes[i]);
                    i--;
                }
            }

            foreach (var SelectedItem in checkedListBoxTechnologies.CheckedItems)
            {
                XmlElement techEle = countryHistory.CreateElement(SelectedItem.ToString());
                techEle.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("1");
                countryHistory.ChildNodes[1].InsertAfter(techEle, countryHistory.ChildNodes[1].SelectSingleNode("school_reforms "));
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
    }
}

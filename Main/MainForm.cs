using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        XmlDocument countries_txt_xml = new XmlDocument();
        XmlDocument ideologies_txt_xml = new XmlDocument();
        XmlDocument issues_txt_xml = new XmlDocument();
        XmlDocument governments = new XmlDocument();
        Dictionary<string, string> countriesDic = new Dictionary<string, string>();
        Dictionary<string, string> countriesHistoryDic = new Dictionary<string, string>();
        Dictionary<string, string> provincesDic = new Dictionary<string, string>();
        Dictionary<int, string> comboIndexDic = new Dictionary<int, string>();
        IDictionary<string, int> ideoIndexDic = new Dictionary<string, int>();
        int index = 0;

        public MainForm()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(".\\xml\\common\\countries.txt.xml"))
            {
                ideologies_txt_xml.Load(".\\xml\\common\\ideologies.txt.xml");
                issues_txt_xml.Load(".\\xml\\common\\issues.txt.xml");
                governments.Load(".\\xml\\common\\governments.txt.xml");
                getCountriesNames();
                getGC();
                getProvinces();
                getCountriesHistoryDic();
                getCultureList();
                getReligion();
                getGovernments();
                getNationalValue();
                getTechonologies();
                getIdeologies();
            }
        }

        public void listBoxCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIdeologies.Items.Clear();
            comboBoxEconomicPolicy.Items.Clear();
            comboBoxTradePolicy.Items.Clear();
            comboBoxReligiousPolicy.Items.Clear();
            comboBoxCitizenshipPolicy.Items.Clear();
            comboBoxWarPolicy.Items.Clear();
            textBoxStartDate.Text = "";
            textBoxEndDate.Text = "";
            comboBoxParties.Text = "";
            comboBoxIdeologies.Text = "";
            comboBoxEconomicPolicy.Text = "";
            comboBoxTradePolicy.Text = "";
            comboBoxReligiousPolicy.Text = "";
            comboBoxCitizenshipPolicy.Text = "";
            comboBoxWarPolicy.Text = "";
            comboBoxParties.Items.Clear();

            string str = listBoxCountries.SelectedItem.ToString().Trim();
            textBoxCountryTagName.Text = countriesDic[str];
            XmlDocument country = new XmlDocument();
            XmlDocument countryHistory = new XmlDocument();
            if (!Regex.IsMatch(countriesDic[str], @"\S\d\d"))
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[str] + " - " + countriesHistoryDic[countriesDic[str]] + ".txt.xml");
            }
            else
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[str] + ".txt.xml");
            }
            country.Load(".\\xml\\common\\countries\\" + str + ".txt.xml");

            string[] color = Victoria2.Domain.Comm.FileHelper.Unescape(country.ChildNodes[1].SelectSingleNode("color").InnerText).Replace("{", "").Replace("}", "").Trim().Replace("  ", " ").Split(' ');
            textBoxRed.Text = color[0];
            textBoxGreen.Text = color[1];
            textBoxBlue.Text = color[2];
            labelColor.BackColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
            labelColor.ForeColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));

            comboBoxGraphics.Text = Victoria2.Domain.Comm.FileHelper.Unescape(country.ChildNodes[1].SelectSingleNode("graphical_culture").InnerText);
            foreach (XmlNode node in country.ChildNodes[1])
            {
                string partyName = "";
                if (node.Name == "party")
                {
                    partyName = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText);
                    partyName = partyName.Replace("\"", "");
                    comboBoxParties.Items.Add(partyName);
                }
            }
            comboBoxParties.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("ruling_party ").InnerText);
            comboBoxCaptial.Text = provincesDic[Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("capital ").InnerText)];
            comboBoxPrimaryCulture.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("primary_culture").InnerText);
            comboBoxReligion.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("religion").InnerText);
            comboBoxGovernment.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("government").InnerText);
            comboBoxNationalValue.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("nationalvalue").InnerText);
            comboBoxSchool.Text = (countryHistory.ChildNodes[1].SelectSingleNode("schools") != null) ? Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("schools").InnerText) : "traditional_academic";
            textBoxPlurality.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("plurality").InnerText);
            textBoxLiteracy.Text = Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("literacy").InnerText);
            textBoxNonStateCultureLiteracy.Text = (countryHistory.ChildNodes[1].SelectSingleNode("non_state_culture_literacy") != null) ? Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("non_state_culture_literacy").InnerText) : "";
            textBoxPrestige.Text = (countryHistory.ChildNodes[1].SelectSingleNode("prestige") != null) ? Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("prestige").InnerText) : "";
            textBoxConsciousness.Text = (countryHistory.ChildNodes[1].SelectSingleNode("consciousness") != null) ? Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("consciousness").InnerText) : "";
            textBoxNonstateConsciousness.Text = (countryHistory.ChildNodes[1].SelectSingleNode("nonstate_consciousness") != null) ? Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("nonstate_consciousness").InnerText) : "";
            checkBoxCivilized.Checked = (countryHistory.ChildNodes[1].SelectSingleNode("civilized ") != null) ? (Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("civilized ").InnerText) == "yes") : false;
            checkBoxIsReleasableVassal.Checked = (countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal ") != null) ? (Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal ").InnerText) == "yes") : true;
        }

        public void clearCountriesNames()
        {
            listBoxCountries.Items.Clear();
            countriesDic.Clear();
            countriesHistoryDic.Clear();
        }

        public void countryRefresh()
        {
            comboBoxGovernment.Items.Clear();
            listBoxGovernments.Items.Clear();
            ideoIndexDic.Clear();
            index = 0;
            checkedListBoxIdeologies.Items.Clear();
            getGovernments();
            getIdeologies();
            clearCountriesNames();
            getCountriesNames();
            getCountriesHistoryDic();
        }

        public void getCountriesNames()
        {
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
                listBoxCountries.Items.Add(sb.ToString());
                countriesDic.Add(sb.ToString(), Victoria2.Domain.Comm.FileHelper.Unescape(node.Name));
            }
        }

        public void comboBoxParties_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIdeologies.Items.Clear();
            comboBoxEconomicPolicy.Items.Clear();
            comboBoxTradePolicy.Items.Clear();
            comboBoxReligiousPolicy.Items.Clear();
            comboBoxCitizenshipPolicy.Items.Clear();
            comboBoxWarPolicy.Items.Clear();

            foreach (XmlNode node in ideologies_txt_xml.ChildNodes[1])
            {
                foreach (XmlNode node_in in node)
                {
                    comboBoxIdeologies.Items.Add(node_in.Name);
                }
            }
            XmlNode party_issues = issues_txt_xml.ChildNodes[1].SelectSingleNode("party_issues");
            XmlNode trade_policy = party_issues.SelectSingleNode("trade_policy");
            foreach (XmlNode node2 in trade_policy)
            {
                comboBoxTradePolicy.Items.Add(node2.Name);
            }
            XmlNode economic_policy = party_issues.SelectSingleNode("economic_policy");
            foreach (XmlNode node2 in economic_policy)
            {
                comboBoxEconomicPolicy.Items.Add(node2.Name);
            }
            XmlNode religious_policy = party_issues.SelectSingleNode("religious_policy");
            foreach (XmlNode node2 in religious_policy)
            {
                comboBoxReligiousPolicy.Items.Add(node2.Name);
            }
            XmlNode citizenship_policy = party_issues.SelectSingleNode("citizenship_policy");
            foreach (XmlNode node2 in citizenship_policy)
            {
                comboBoxCitizenshipPolicy.Items.Add(node2.Name);
            }
            XmlNode war_policy = party_issues.SelectSingleNode("war_policy");
            foreach (XmlNode node2 in war_policy)
            {
                comboBoxWarPolicy.Items.Add(node2.Name);
            }


            string str = listBoxCountries.SelectedItem.ToString().Trim();
            textBoxCountryTagName.Text = countriesDic[str];
            XmlDocument country = new XmlDocument();
            country.Load(".\\xml\\common\\countries\\" + str + ".txt.xml");

            foreach (XmlNode node in country.ChildNodes[1])
            {
                if (node.Name == "party" && ("\"" + comboBoxParties.SelectedItem.ToString() + "\"" == Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText)))
                {
                    textBoxStartDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("start_date").InnerText);
                    textBoxEndDate.Text = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("end_date").InnerText);
                    comboBoxIdeologies.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("ideology").InnerText);
                    comboBoxEconomicPolicy.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("economic_policy").InnerText);
                    comboBoxTradePolicy.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("trade_policy").InnerText);
                    comboBoxReligiousPolicy.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("religious_policy").InnerText);
                    comboBoxCitizenshipPolicy.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("citizenship_policy").InnerText);
                    comboBoxWarPolicy.SelectedItem = Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("war_policy").InnerText);
                }
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxRed.Text, @"(\d)+") && Regex.IsMatch(textBoxGreen.Text, @"(\d)+") && Regex.IsMatch(textBoxBlue.Text, @"(\d)+"))
            {
                if (!isColor(int.Parse(textBoxRed.Text)) || !isColor(int.Parse(textBoxGreen.Text)) || !isColor(int.Parse(textBoxBlue.Text)))
                {
                    MessageBox.Show("保存失败！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("保存失败！");
                return;
            }
            string str = listBoxCountries.SelectedItem.ToString().Trim();
            XmlDocument countryHistory = new XmlDocument();
            if (!Regex.IsMatch(countriesDic[str], @"\S\d\d"))
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[str] + " - " + countriesHistoryDic[countriesDic[str]] + ".txt.xml");
            }
            else
            {
                countryHistory.Load(".\\xml\\history\\countries\\" + countriesDic[str] + ".txt.xml");
            }
            XmlDocument country = new XmlDocument();
            country.Load(".\\xml\\common\\countries\\" + listBoxCountries.SelectedItem.ToString() + ".txt.xml");
            country.ChildNodes[1].SelectSingleNode("color").InnerText = "{ " + textBoxRed.Text + "  " + textBoxGreen.Text + "  " + textBoxBlue.Text + " }";
            country.ChildNodes[1].SelectSingleNode("graphical_culture").InnerText = comboBoxGraphics.Text;

            countryHistory.ChildNodes[1].SelectSingleNode("ruling_party").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxParties.Text);
            countryHistory.ChildNodes[1].SelectSingleNode("capital").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboIndexDic[comboBoxCaptial.SelectedIndex]);
            countryHistory.ChildNodes[1].SelectSingleNode("primary_culture").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxPrimaryCulture.SelectedItem.ToString());
            countryHistory.ChildNodes[1].SelectSingleNode("religion").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxReligion.SelectedItem.ToString());
            countryHistory.ChildNodes[1].SelectSingleNode("government").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxGovernment.SelectedItem.ToString());
            if (comboBoxSchool.Enabled)
            {
                if (countryHistory.ChildNodes[1].SelectSingleNode("schools") != null)
                {
                    countryHistory.ChildNodes[1].SelectSingleNode("schools").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxSchool.SelectedItem.ToString());
                }
                else
                {
                    XmlElement ele = countryHistory.CreateElement("schools");
                    ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxSchool.SelectedItem.ToString());
                    countryHistory.ChildNodes[1].InsertAfter(ele, countryHistory.ChildNodes[1].SelectSingleNode("upper_house"));
                }
            }
            countryHistory.ChildNodes[1].SelectSingleNode("plurality").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxPlurality.Text);
            countryHistory.ChildNodes[1].SelectSingleNode("literacy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxLiteracy.Text);
            if (!string.IsNullOrEmpty(textBoxNonStateCultureLiteracy.Text))
            {
                if (countryHistory.ChildNodes[1].SelectSingleNode("non_state_culture_literacy") != null)
                {
                    countryHistory.ChildNodes[1].SelectSingleNode("non_state_culture_literacy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxNonStateCultureLiteracy.Text);
                }
                else
                {
                    XmlElement ele = countryHistory.CreateElement("non_state_culture_literacy");
                    ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxNonStateCultureLiteracy.Text);
                    countryHistory.ChildNodes[1].InsertAfter(ele, countryHistory.ChildNodes[1].SelectSingleNode("literacy"));
                }
            }//textBoxPrestige
            if (!string.IsNullOrEmpty(textBoxPrestige.Text))
            {
                if (countryHistory.ChildNodes[1].SelectSingleNode("prestige") != null)
                {
                    countryHistory.ChildNodes[1].SelectSingleNode("prestige").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxPrestige.Text);
                }
                else
                {
                    XmlElement ele = countryHistory.CreateElement("prestige");
                    ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxPrestige.Text);
                    countryHistory.ChildNodes[1].InsertAfter(ele, countryHistory.ChildNodes[1].SelectSingleNode("civilized"));
                }
            }//textBoxConsciousness
            if (!string.IsNullOrEmpty(textBoxConsciousness.Text))
            {
                if (countryHistory.ChildNodes[1].SelectSingleNode("consciousness") != null)
                {
                    countryHistory.ChildNodes[1].SelectSingleNode("consciousness").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxConsciousness.Text);
                }
                else
                {
                    XmlElement ele = countryHistory.CreateElement("consciousness");
                    ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxConsciousness.Text);
                    countryHistory.ChildNodes[1].InsertAfter(ele, countryHistory.ChildNodes[1].SelectSingleNode("upper_house"));
                }
            }//textBoxNonstateConsciousness
            if (!string.IsNullOrEmpty(textBoxNonstateConsciousness.Text))
            {
                if (countryHistory.ChildNodes[1].SelectSingleNode("nonstate_consciousness") != null)
                {
                    countryHistory.ChildNodes[1].SelectSingleNode("nonstate_consciousness").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxNonstateConsciousness.Text);
                }
                else
                {
                    XmlElement ele = countryHistory.CreateElement("nonstate_consciousness");
                    ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxNonstateConsciousness.Text);
                    countryHistory.ChildNodes[1].InsertAfter(ele, countryHistory.ChildNodes[1].SelectSingleNode("consciousness") != null ? countryHistory.ChildNodes[1].SelectSingleNode("consciousness") : countryHistory.ChildNodes[1].SelectSingleNode("upper_house"));
                }
            }//checkBoxCivilized
            if (countryHistory.ChildNodes[1].SelectSingleNode("civilized") != null)
            {
                XmlNode civilized = countryHistory.ChildNodes[1].SelectSingleNode("civilized");
                countryHistory.ChildNodes[1].RemoveChild(civilized);
            }
            if (checkBoxCivilized.Checked)
            {
                XmlElement civ = countryHistory.CreateElement("civilized");
                civ.InnerText = "yes";
                countryHistory.ChildNodes[1].InsertAfter(civ, countryHistory.ChildNodes[1].SelectSingleNode("literacy"));
            }
            //checkBoxIsReleasableVassal
            if (countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal") != null)
            {
                XmlNode civilized = countryHistory.ChildNodes[1].SelectSingleNode("is_releasable_vassal");
                countryHistory.ChildNodes[1].RemoveChild(civilized);
            }
            if (checkBoxIsReleasableVassal.Checked)
            {
                XmlElement civ = countryHistory.CreateElement("is_releasable_vassal");
                civ.InnerText = "yes";
                countryHistory.ChildNodes[1].InsertAfter(civ, countryHistory.ChildNodes[1].SelectSingleNode("civilized") != null ? countryHistory.ChildNodes[1].SelectSingleNode("civilized") : countryHistory.ChildNodes[1].SelectSingleNode("literacy"));
            }

            if (!Regex.IsMatch(countriesDic[str], @"\S\d\d"))
            {
                countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[str] + " - " + countriesHistoryDic[countriesDic[str]] + ".txt.xml");
            }
            else
            {
                countryHistory.Save(".\\xml\\history\\countries\\" + countriesDic[str] + ".txt.xml");
            }

            if (comboBoxParties.SelectedIndex != -1)
            {
                foreach (XmlElement node in country.ChildNodes[1])
                {
                    if (node.Name == "party")
                    {
                        if (Victoria2.Domain.Comm.FileHelper.Unescape(node.SelectSingleNode("name").InnerText).Replace("\"", "") == comboBoxParties.SelectedItem.ToString())
                        {
                            if (!Victoria2.Main.Program.isDate(textBoxStartDate.Text) || !Victoria2.Main.Program.isDate(textBoxEndDate.Text))
                            {
                                MessageBox.Show("日期格式错误！");
                                return;
                            }
                            node.SelectSingleNode("start_date").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxStartDate.Text);
                            node.SelectSingleNode("end_date").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(textBoxEndDate.Text);
                            node.SelectSingleNode("ideology").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxIdeologies.SelectedItem.ToString());
                            node.SelectSingleNode("economic_policy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxEconomicPolicy.SelectedItem.ToString());
                            node.SelectSingleNode("trade_policy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxTradePolicy.SelectedItem.ToString());
                            node.SelectSingleNode("religious_policy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxReligiousPolicy.SelectedItem.ToString());
                            node.SelectSingleNode("citizenship_policy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxCitizenshipPolicy.SelectedItem.ToString());
                            node.SelectSingleNode("war_policy").InnerText = Victoria2.Domain.Comm.FileHelper.Escape(comboBoxWarPolicy.SelectedItem.ToString());
                            country.Save(".\\xml\\common\\countries\\" + listBoxCountries.SelectedItem.ToString() + ".txt.xml");
                            MessageBox.Show("保存成功！");
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("保存成功！");
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuItemLoad_Click_1(object sender, EventArgs e)
        {
            progressBarLoad.Visible = true;
            progressBarLoad.Value = 0;
            Victoria2.Main.Program.translate_to_xml("units");    //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("common");  //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("common\\countries"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("decisions");    //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("events");   //通过测试
            progressBarLoad.PerformStep();
            //translate_to_xml("inventions");    //通过测试
            //translate_to_xml("map");    //初版无测试计划
            //translate_to_xml("news");    //初版无测试计划
            Victoria2.Main.Program.translate_to_xml("history\\countries"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("history\\diplomacy"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml_double_folder("history\\pops");  //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml_double_folder("history\\provinces"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("history\\units"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml_double_folder("history\\units");   //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("history\\wars");  //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_xml("technologies");
            progressBarLoad.PerformStep();
            progressBarLoad.Value = 100;
            progressBarLoad.Visible = false;
            MessageBox.Show("载入成功!");
            countryRefresh();
        }

        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            progressBarLoad.Visible = true;
            progressBarLoad.Value = 0;
            Victoria2.Main.Program.translate_to_txt("units");    //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("common");   //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("common\\countries");   //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("decisions");   //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("events");   //通过测试
            progressBarLoad.PerformStep();
            //translate_to_txt("inventions");   //测试失败：奇异的编码
            //translate_to_txt("map");    //初版无测试计划
            //translate_to_txt("news");   //初版无测试计划
            Victoria2.Main.Program.translate_to_txt("history\\countries"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("history\\diplomacy"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt_double_folder("history\\pops");  //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt_double_folder("history\\provinces");    //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("history\\units"); //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt_double_folder("history\\units");   //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("history\\wars");  //通过测试
            progressBarLoad.PerformStep();
            Victoria2.Main.Program.translate_to_txt("technologies");
            progressBarLoad.PerformStep();
            progressBarLoad.Value = 100;
            progressBarLoad.Visible = false;
            MessageBox.Show("保存成功!");
        }

        private void buttonNewParty_Click(object sender, EventArgs e)
        {
            NewParty np = new NewParty(listBoxCountries.SelectedItem.ToString());
            np.Show();
        }

        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxRed.Text, @"(\d)+") && Regex.IsMatch(textBoxGreen.Text, @"(\d)+") && Regex.IsMatch(textBoxBlue.Text, @"(\d)+"))
            {
                if (isColor(int.Parse(textBoxRed.Text)) && isColor(int.Parse(textBoxGreen.Text)) && isColor(int.Parse(textBoxBlue.Text)))
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                    labelColor.ForeColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                }
            }
        }

        private bool isColor(int n)
        {
            if (n >= 0 && n <= 255)
            {
                return true;
            }
            return false;
        }

        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxRed.Text, @"(\d)+") && Regex.IsMatch(textBoxGreen.Text, @"(\d)+") && Regex.IsMatch(textBoxBlue.Text, @"(\d)+"))
            {
                if (isColor(int.Parse(textBoxRed.Text)) && isColor(int.Parse(textBoxGreen.Text)) && isColor(int.Parse(textBoxBlue.Text)))
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                    labelColor.ForeColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                }
            }
        }

        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxRed.Text, @"(\d)+") && Regex.IsMatch(textBoxGreen.Text, @"(\d)+") && Regex.IsMatch(textBoxBlue.Text, @"(\d)+"))
            {
                if (isColor(int.Parse(textBoxRed.Text)) && isColor(int.Parse(textBoxGreen.Text)) && isColor(int.Parse(textBoxBlue.Text)))
                {
                    labelColor.BackColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                    labelColor.ForeColor = System.Drawing.Color.FromArgb(int.Parse(textBoxRed.Text), int.Parse(textBoxGreen.Text), int.Parse(textBoxBlue.Text));
                }
            }
        }

        private void getGC()
        {
            string[] line = File.ReadAllLines("..\\common\\graphicalculturetype.txt", Encoding.Default);
            foreach (string str in line)
            {
                comboBoxGraphics.Items.Add(str);
            }
        }

        private void getProvinces()
        {
            string folderpath = "..\\history\\provinces";
            string[] foldernames = Directory.GetDirectories(folderpath);
            foreach (string fon in foldernames)
            {
                string[] filenames = Directory.GetFiles(fon);
                foreach (string fin in filenames)
                {
                    string filename = fin.Substring(fin.LastIndexOf("\\") + 1).Replace(".txt", "");
                    if (Regex.IsMatch(filename, @"(\d)+(\s)+-(\s)+(\S+)"))
                    {
                        string[] provincePair = filename.Split('-');
                        if (provincesDic.ContainsKey(provincePair[0].Trim()))
                        {
                            continue;
                        }
                        provincesDic.Add(provincePair[0].Trim(), provincePair[1].Trim());
                        comboIndexDic.Add(comboBoxCaptial.Items.Count, provincePair[0].Trim());
                        comboBoxCaptial.Items.Add(provincePair[1].Trim());
                    }
                    else if (Regex.IsMatch(filename, @"(\d)+(\s)+(\S+)"))
                    {
                        while (filename.Contains("  "))
                        {
                            filename = filename.Replace("  ", " ");
                        }
                        string[] provincePair = filename.Split(' ');
                        if (provincesDic.ContainsKey(provincePair[0].Trim()))
                        {
                            continue;
                        }
                        provincesDic.Add(provincePair[0].Trim(), provincePair[1].Trim());
                        comboIndexDic.Add(comboBoxCaptial.Items.Count, provincePair[0].Trim());
                        comboBoxCaptial.Items.Add(provincePair[1].Trim());
                    }
                }
            }
        }

        public void getCountriesHistoryDic()
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
                        comboBoxPrimaryCulture.Items.Add(cultureNode.Name);
                    }
                }
            }
        }

        private void getReligion()
        {
            XmlDocument religion = new XmlDocument();
            religion.Load(".\\xml\\common\\religion.txt.xml");
            foreach (XmlNode religionGruop in religion.ChildNodes[1])
            {
                foreach (XmlNode religionNode in religionGruop)
                {
                    comboBoxReligion.Items.Add(religionNode.Name);
                }
            }
        }

        private void getGovernments()
        {
            governments.Load(".\\xml\\common\\governments.txt.xml");
            foreach (XmlNode governmentNode in governments.ChildNodes[1])
            {
                comboBoxGovernment.Items.Add(governmentNode.Name);
                listBoxGovernments.Items.Add(governmentNode.Name);
            }
        }

        private void getNationalValue()
        {
            XmlDocument nationalValue = new XmlDocument();
            nationalValue.Load(".\\xml\\common\\nationalvalues.txt.xml");
            foreach (XmlNode nationalValueNode in nationalValue.ChildNodes[1])
            {
                comboBoxNationalValue.Items.Add(nationalValueNode.Name);
            }
        }

        private void getTechonologies()
        {
            XmlDocument technology = new XmlDocument();
            technology.Load(".\\xml\\common\\technology.txt.xml");
            foreach (XmlNode technologyNode in technology.ChildNodes[1].SelectSingleNode("schools"))
            {
                comboBoxSchool.Items.Add(technologyNode.Name);
            }
        }

        private void getIdeologies()
        {
            XmlDocument ideologies = new XmlDocument();
            ideologies.Load(".\\xml\\common\\ideologies.txt.xml");
            foreach (XmlNode node1 in ideologies.ChildNodes[1])
            {
                foreach (XmlNode node2 in node1)
                {
                    checkedListBoxIdeologies.Items.Add(node2.Name);
                    ideoIndexDic.Add(node2.Name, index++);
                }
            }
        }

        private void checkBoxCivilized_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonCulture_Click(object sender, EventArgs e)
        {
            Cultrues nc = new Cultrues(listBoxCountries.SelectedItem.ToString());
            nc.Show();
        }

        private void buttonPoliticalReforms_Click(object sender, EventArgs e)
        {
            PoliticalReforms pr = new PoliticalReforms(listBoxCountries.SelectedItem.ToString());
            pr.Show();
        }

        private void buttonSocialReforms_Click(object sender, EventArgs e)
        {
            SocialReforms sr = new SocialReforms(listBoxCountries.SelectedItem.ToString());
            sr.Show();
        }

        private void buttonTechnologies_Click(object sender, EventArgs e)
        {
            Technology tech = new Technology(listBoxCountries.SelectedItem.ToString());
            tech.Show();
        }

        private void buttonUpperHouse_Click(object sender, EventArgs e)
        {
            UpperHouse uh = new UpperHouse(listBoxCountries.SelectedItem.ToString());
            uh.Show();
        }

        private void buttonNewCountry_Click(object sender, EventArgs e)
        {
            NewCountry nc = new NewCountry(this);
            //nc.MdiParent = this;
            nc.Show();
        }

        private void listBoxGovernments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxElection.Checked)
            {
                numericUpDownDuration.Enabled = true;
            }
            else
            {
                numericUpDownDuration.Enabled = false;
            }

            int count = checkedListBoxIdeologies.Items.Count;
            for (int i = 0; i < count; i++)
            {
                checkedListBoxIdeologies.SetItemChecked(i, false);
            }

            if (listBoxGovernments.SelectedIndex == -1)
            {
                return;
            }
            foreach (XmlNode node in governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()))
            {
                foreach (var ideoName in checkedListBoxIdeologies.Items)
                {
                    if (node.Name == ideoName.ToString())
                    {
                        checkedListBoxIdeologies.SetItemChecked(ideoIndexDic[node.Name], true);
                        break;
                    }
                }
            }

            if (governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).SelectSingleNode("election").InnerText.ToString() == "yes")
            {
                checkBoxElection.Checked = true;
            }
            else
            {
                checkBoxElection.Checked = false;
            }//appoint_ruling_party 

            if (governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).SelectSingleNode("appoint_ruling_party").InnerText.ToString() == "yes")
            {
                checkBoxAppointRulingParty.Checked = true;
            }
            else
            {
                checkBoxAppointRulingParty.Checked = false;
            }

            if (checkBoxElection.Checked)
            {
                numericUpDownDuration.Enabled = true;
                numericUpDownDuration.Value = int.Parse(Victoria2.Domain.Comm.FileHelper.Unescape(governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).SelectSingleNode("duration").InnerText.ToString()));
            }
            else
            {
                numericUpDownDuration.Value = 0;
                numericUpDownDuration.Enabled = false;
            }

            comboBoxFlagType.Text = governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).SelectSingleNode("flagType") != null ? governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).SelectSingleNode("flagType").InnerText.ToString() : "默认";

        }

        private void buttonSaveGovernments_Click(object sender, EventArgs e)
        {
            governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).RemoveAll();

            foreach (var ideos in checkedListBoxIdeologies.CheckedItems)
            {
                XmlElement ele = governments.CreateElement(ideos.ToString());
                ele.InnerText = "yes";
                governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).AppendChild(ele);
            }

            XmlElement election = governments.CreateElement("election");
            election.InnerText = checkBoxElection.Checked ? "yes" : "no";
            governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).AppendChild(election);

            if (checkBoxElection.Checked)
            {
                XmlElement duration = governments.CreateElement("duration");
                duration.InnerText = numericUpDownDuration.Value.ToString();
                governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).AppendChild(duration);
            }

            XmlElement appoint_ruling_party = governments.CreateElement("appoint_ruling_party");
            appoint_ruling_party.InnerText = checkBoxAppointRulingParty.Checked ? "yes" : "no";
            governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).AppendChild(appoint_ruling_party);

            if (comboBoxFlagType.Text != "默认")
            {
                XmlElement flagType = governments.CreateElement("flagType");
                flagType.InnerText = comboBoxFlagType.Text;
                governments.ChildNodes[1].SelectSingleNode(listBoxGovernments.SelectedItem.ToString()).AppendChild(flagType);
            }

            governments.Save(".\\xml\\common\\governments.txt.xml");
            MessageBox.Show("保存成功！");
        }

        private void buttonNewGovernment_Click(object sender, EventArgs e)
        {
            NewGovernment ng = new NewGovernment(this);
            ng.Show();
        }

        private void checkBoxElection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxElection.Checked)
            {
                numericUpDownDuration.Enabled = true;
            }
            else
            {
                numericUpDownDuration.Enabled = false;
            }
        }
    }
}

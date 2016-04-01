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
    public partial class NewCountryUpperHouse : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        XmlDocument countryHistory = new XmlDocument();

        public NewCountryUpperHouse(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            InitializeComponent();
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
            mf = mfPass;
        }

        private void listBoxIdeologies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxIdeologies.SelectedIndex == -1)
            {
                return;
            }
            numericUpDownValue.Value = int.Parse(Victoria2.Domain.Comm.FileHelper.Unescape(countryHistory.ChildNodes[1].SelectSingleNode("upper_house").SelectSingleNode(listBoxIdeologies.SelectedItem.ToString()).InnerText));
        }

        private void NewCountryUpperHouse_Load(object sender, EventArgs e)
        {
            countryHistory.Load(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            getIdeologies();
        }

        private void getIdeologies()
        {
            XmlDocument ideologies = new XmlDocument();
            ideologies.Load(".\\xml\\common\\ideologies.txt.xml");
            XmlElement upper_hosue = countryHistory.CreateElement("upper_house");
            foreach (XmlNode node in ideologies.ChildNodes[1])
            {
                foreach (XmlNode node_in in node)
                {
                    listBoxIdeologies.Items.Add(node_in.Name);
                    XmlElement ideo = countryHistory.CreateElement(node_in.Name);
                    ideo.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("0");
                    upper_hosue.AppendChild(ideo);
                }
            }
            countryHistory.ChildNodes[1].AppendChild(upper_hosue);
        }

        private void numericUpDownValue_ValueChanged(object sender, EventArgs e)
        {
            countryHistory.ChildNodes[1].SelectSingleNode("upper_house").SelectSingleNode(listBoxIdeologies.SelectedItem.ToString()).InnerText = Victoria2.Domain.Comm.FileHelper.Escape(numericUpDownValue.Value.ToString());
        }

        private void buttonFinish_Click(object sender, EventArgs e)
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
                countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            }
            //this.MdiParent = new MainForm();
            mf.Reload();
            this.Close();
        }

        private void buttonPreviousStep_Click(object sender, EventArgs e)
        {
            countryHistory.ChildNodes[1].RemoveChild(countryHistory.ChildNodes[1].SelectSingleNode("upper_house"));
            countryHistory.Save(".\\xml\\history\\countries\\" + countryTagName + " - " + countryName + ".txt.xml");
            NewCountryTechnology nct = new NewCountryTechnology(countryTagName, countryName, mf);
            nct.Show();
            this.Close();
        }
    }
}

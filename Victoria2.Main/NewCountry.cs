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
    public partial class NewCountry : Form
    {
        MainForm mf;
        string countryTagName;
        string countryName;
        public NewCountry(MainForm mfPass)
        {
            InitializeComponent();
            mf = mfPass;
        }

        public NewCountry(string countryTagNamePass, string countryNamePass, MainForm mfPass)
        {
            mf = mfPass;
            countryTagName = countryTagNamePass;
            countryName = countryNamePass;
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxCountryTagName.Text, @"[A-Z][A-Z][A-Z]"))
            {
                MessageBox.Show("国家简称格式错误！");
                return;
            }
            if (!Regex.IsMatch(textBoxCountryName.Text, @"[A-Za-z ]+"))
            {
                MessageBox.Show("国家名称格式错误！");
                return;
            }
            XmlDocument countries = new XmlDocument();
            countries.Load(".\\xml\\common\\countries.txt.xml");
            if (countries.ChildNodes[1].SelectSingleNode(textBoxCountryTagName.Text) != null)
            {
                MessageBox.Show("国家简称已经存在！");
                return;
            }
            foreach (string str in Directory.GetFiles(".\\xml\\common\\countries"))
            {
                string countryName = str.Substring(str.LastIndexOf("\\") + 1).Replace(".txt.xml", "");
                if (textBoxCountryName.Text == countryName)
                {
                    MessageBox.Show("国家名已经存在！");
                    return;
                }
            }
            XmlElement ele = countries.CreateElement(textBoxCountryTagName.Text);
            ele.InnerText = Victoria2.Domain.Comm.FileHelper.Escape("\"countries/" + textBoxCountryName.Text + ".txt\"");
            countries.ChildNodes[1].InsertBefore(ele, countries.ChildNodes[1].SelectSingleNode("dynamic_tags"));
            countries.Save(".\\xml\\common\\countries.txt.xml");
            FileStream fs = File.Open(".\\xml\\common\\countries\\" + textBoxCountryName.Text + ".txt.xml", FileMode.Create);
            byte[] head = System.Text.Encoding.Default.GetBytes("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\n<root>");
            byte[] end = System.Text.Encoding.Default.GetBytes("</root>");
            fs.Write(head, 0, head.Length);
            fs.Write(end, 0, end.Length);
            fs.Close();

            XmlDocument doc = new XmlDocument();
            doc.Load(".\\xml\\common\\countries\\" + textBoxCountryName.Text + ".txt.xml");
            var color = doc.CreateElement("color");
            color.InnerText = "";
            var graphical_culture = doc.CreateElement("graphical_culture");
            graphical_culture.InnerText = "";
            var unit_names = doc.CreateElement("unit_names");
            unit_names.InnerText = "{\n}";
            doc.ChildNodes[1].AppendChild(color);
            doc.ChildNodes[1].AppendChild(graphical_culture);
            doc.ChildNodes[1].AppendChild(unit_names);
            doc.Save(".\\xml\\common\\countries\\" + textBoxCountryName.Text + ".txt.xml");

            fs = File.Open(".\\xml\\history\\countries\\" + textBoxCountryTagName.Text + " - " + textBoxCountryName.Text + ".txt.xml", FileMode.Create);
            fs.Write(head, 0, head.Length);
            fs.Write(end, 0, end.Length);
            fs.Close();

            NewCountryHistory nch = new NewCountryHistory ( countryTagName , this.countryName , mf );
            this.Close ( );
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (File.Exists(".\\xml\\common\\countries\\" + textBoxCountryName.Text + ".txt.xml"))
            {
                File.Delete(".\\xml\\common\\countries\\" + textBoxCountryName.Text + ".txt.xml");
            }
            if (File.Exists(".\\xml\\history\\countries\\" + textBoxCountryTagName.Text + " - " + textBoxCountryName.Text + ".txt.xml"))
            {
                File.Delete(".\\xml\\history\\countries\\" + textBoxCountryTagName.Text + " - " + textBoxCountryName.Text + ".txt.xml");
            }

            if (!string.IsNullOrEmpty(countryTagName))
            {
                XmlDocument countries = new XmlDocument();
                countries.Load(".\\xml\\common\\countries.txt.xml");
                if (countries.ChildNodes[1].SelectSingleNode(countryTagName) != null)
                {
                    countries.ChildNodes[1].RemoveChild(countries.ChildNodes[1].SelectSingleNode(countryTagName));
                    countries.Save(".\\xml\\common\\countries.txt.xml");
                }
            }
            this.Close();
        }
    }
}

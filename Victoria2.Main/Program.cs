using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Victoria2.Domain.Comm;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Victoria2.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static public void translate_to_xml(string path)
        {
            string filepath = "..\\" + path;
            string[] filenames = Directory.GetFiles(filepath);
            foreach (string fn in filenames)
            {
                string fname = fn.Substring(fn.LastIndexOf("\\"));
                if (Regex.IsMatch(fname, @"^.+\.(t|T)(X|x)(T|t)$"))
                {
                    if (fname.Contains("graphicalculturetype"))
                    {
                        continue;
                    }
                    System.Xml.XmlDocument doc;
                    doc = XmlDoc.CreateModel(@"..\\" + path + "\\" + fname);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(".\\xml\\" + path + fname + ".xml");
                    FileStream fs = File.Open(sb.ToString(), FileMode.Create);
                    byte[] data = System.Text.Encoding.Default.GetBytes(doc.FirstChild.InnerXml.ToString());
                    byte[] head = System.Text.Encoding.Default.GetBytes("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\n<root>");
                    byte[] end = System.Text.Encoding.Default.GetBytes("</root>");
                    fs.Write(head, 0, head.Length);
                    fs.Write(data, 0, data.Length);
                    fs.Write(end, 0, end.Length);
                    fs.Close();
                }
            }
        }

        static public void translate_to_xml_double_folder(string path)
        {
            string folderpath = "..\\" + path;
            string[] foldernames = Directory.GetDirectories(folderpath);
            foreach (string fon in foldernames)
            {
                if (Directory.Exists(fon))
                {
                    string foldername = fon.Substring(fon.LastIndexOf("\\"));
                    string[] filenames = Directory.GetFiles(fon);
                    foreach (string fin in filenames)
                    {
                        string filename = fin.Substring(fin.LastIndexOf("\\"));
                        if (Regex.IsMatch(filename, @"^.+\.(t|T)(X|x)(T|t)$"))
                        {
                            System.Xml.XmlDocument doc;
                            doc = XmlDoc.CreateModel(@"..\\" + path + foldername + filename);
                            StringBuilder sb = new StringBuilder();
                            if (!Directory.Exists(".\\xml\\" + path + foldername))
                            {
                                Directory.CreateDirectory(".\\xml\\" + path + foldername);
                            }
                            sb.Append(".\\xml\\" + path + foldername + filename + ".xml");
                            FileStream fs = File.Open(sb.ToString(), FileMode.Create);
                            byte[] data = System.Text.Encoding.Default.GetBytes(doc.FirstChild.InnerXml.ToString());
                            byte[] head = System.Text.Encoding.Default.GetBytes("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\n<root>");
                            byte[] end = System.Text.Encoding.Default.GetBytes("</root>");
                            fs.Write(head, 0, head.Length);
                            fs.Write(data, 0, data.Length);
                            fs.Write(end, 0, end.Length);
                            fs.Close();
                        }
                    }
                }
            }
        }

        static public void translate_to_txt(string path)
        {
            string filepath = ".\\xml\\" + path;
            string[] filenames = Directory.GetFiles(filepath);
            foreach (string fn in filenames)
            {
                string fname = fn.Substring(fn.LastIndexOf("\\"));
                if (Regex.IsMatch(fname, @"^.+\.xml$"))
                {
                    if (fname.Contains("graphicalculturetype"))
                    {
                        continue;
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load(fn);
                    FileStream fs = File.Open("..\\" + path + fname.Replace(".xml", ""), FileMode.Create);
                    byte[] data = System.Text.Encoding.Default.GetBytes(XmlDoc.ToStringBuilder(doc).ToString());
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }
            }
        }

        static public void translate_to_txt_double_folder(string path)
        {
            string folderpath = ".\\xml\\" + path;
            string[] foldernames = Directory.GetDirectories(folderpath);
            foreach (string fon in foldernames)
            {
                if (Directory.Exists(fon))
                {
                    string foldername = fon.Substring(fon.LastIndexOf("\\"));
                    string[] filenames = Directory.GetFiles(fon);
                    foreach (string fin in filenames)
                    {
                        string filename = fin.Substring(fin.LastIndexOf("\\"));
                        if (Regex.IsMatch(filename, @"^.+\.xml$"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(fin);
                            FileStream fs = File.Open("..\\" + path + foldername + filename.Replace(".xml", ""), FileMode.Create);
                            byte[] data = System.Text.Encoding.Default.GetBytes(XmlDoc.ToStringBuilder(doc).ToString());
                            fs.Write(data, 0, data.Length);
                            fs.Close();
                        }
                    }
                }
            }
        }

        static public bool isDate(string date)
        {
            if (Regex.IsMatch(date, @"(\d)+\.(\d)+\.(\d)+"))
            {
                date = date.Replace('.', '-');
                DateTime dt;
                if (DateTime.TryParse(date, out dt))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}

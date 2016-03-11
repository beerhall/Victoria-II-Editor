using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Victoria2.Domain.Comm;
using System.IO;

namespace Victoria2.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            translate_to_xml("units");
            translate_to_xml("common");
            translate_to_xml("common", "countries");
            translate_to_xml("battleplans");
            translate_to_xml("decisions");
            translate_to_xml("events");
            translate_to_xml("inventions");
            translate_to_xml("map");
            translate_to_xml("news");
            translate_to_xml("history","countries");
            translate_to_xml("history", "diplomacy");
            translate_to_xml("history", "pops");
            translate_to_xml("history", "provinces");
            translate_to_xml("history", "units");
            translate_to_xml("history", "wars");
        }
        static void translate_to_xml(string path)
        {
            string filepath = "..\\" + path;
            string[] filenames = Directory.GetFiles(filepath);
            foreach (string fn in filenames)
            {
                if (Regex.IsMatch(fn, @"^.+\.(t|T)(X|x)(T|t)$"))
                {
                    System.Xml.XmlDocument doc;
                    doc = XmlDoc.CreateModel(@"..\\" + path + "\\" + fn);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(".\\xml\\" + path + "\\");
                    sb.Append(fn);
                    sb.Append(".xml");
                    FileStream fs = File.Open(sb.ToString(), FileMode.Create);
                    byte[] data = System.Text.Encoding.Default.GetBytes(doc.FirstChild.InnerXml.ToString());
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }
            }
        }
        static void translate_to_xml(string folder1, string folder2)
        {
            string filepath = "..\\" + folder1 + "\\" + folder2;
            string[] filenames = Directory.GetFiles(filepath);
            foreach (string fn in filenames)
            {
                if (Regex.IsMatch(fn, @"^.+\.(t|T)(X|x)(T|t)$"))
                {
                    System.Xml.XmlDocument doc;
                    doc = XmlDoc.CreateModel(@"..\\" + folder1 + "\\" + fn);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(".\\xml\\" + folder1 + "\\");
                    sb.Append(fn);
                    sb.Append(".xml");
                    FileStream fs = File.Open(sb.ToString(), FileMode.Create);
                    byte[] data = System.Text.Encoding.Default.GetBytes(doc.FirstChild.InnerXml.ToString());
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }
            }
        }
    }
}

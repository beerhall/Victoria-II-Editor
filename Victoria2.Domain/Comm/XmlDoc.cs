using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Victoria2.Domain.Comm
{
    /// <summary>
    /// Xml存取助手
    /// </summary>
    public static class XmlDoc
    {
        /// <summary>
        /// 将V2文件转化为Xml文档
        /// </summary>
        /// <param name="file">TXT文件路径</param>
        /// <returns>对应Xml文档</returns>
        public static XmlDocument CreateModel(string file)
        {
            var xmlDoc = new XmlDocument();
            var node = xmlDoc.CreateElement("", "victoria2", "");
            GetXml(FileHelper.RemoveAnnotation(file).ToString(), ref node, xmlDoc);
            xmlDoc.AppendChild(node);
            return xmlDoc;
        }

        private static XmlElement GetXml(string text, ref XmlElement xml, XmlDocument xmlDoc)
        {
            var bracket = 0;
            var sb = new StringBuilder();
            foreach (string line in FileHelper.SplitLine(text))
            {
                if (line.Contains("{"))
                {
                    bracket++;
                }
                if (line.Contains("}"))
                {
                    bracket--;
                }
                //bracket = bracket + line.Length - line.Replace("{", "").Length;
                //bracket = bracket - (line.Length - line.Replace("}", "").Length);
                sb.AppendLine(line.Trim());
                if (bracket == 0)
                {
                    var s = sb.ToString();
                    /*if (s.Contains("country_event"))
                    {
                        var b = 1;
                    }*/
                    if (s.Trim().IndexOf("=") == s.Trim().Length - 1)
                    {
                        continue;
                    }
                    while (Regex.IsMatch(s, @"{\s+{"))
                    {
                        s = s.Replace(Regex.Match(s, @"{\s+{").ToString(), "{\n ANONYMOUS = {\n");
                    }
                    while (Regex.IsMatch(s, @"}\s+{"))
                    {
                        s = s.Replace(Regex.Match(s, @"}\s+{").ToString(), "}\n ANONYMOUS = {\n");
                    }
                    if (Regex.IsMatch(s, @"^[^\{\=\r\n]+?\s*\=[^\{\=\r\n]+\r") || Regex.IsMatch(s, @"^[^\{\=\r\n]+?\s*\=\s*\{[^\=]+\}\s*\r"))
                    {
                        //   TAG = USA
                        //   a = { 10 20 30 }
                        //   b = { asd dfg hfb }
                        var str = s.Split('=');
                        if (string.IsNullOrEmpty(str[1].Trim()))
                        {
                            continue;
                        }
                        var node = xmlDoc.CreateElement("", str[0].Trim(), "");
                        node.InnerText = str[1].Trim();
                        xml.AppendChild(node);
                    }
                    else if (Regex.IsMatch(s, @"\S+?\s*\=\s*\{[\S\s]+\}"))
                    {
                        //build_cost = {
                        //small_arms = 10
                        //canned_food = 10
                        //luxury_clothes = 5
                        //}
                        var left = Regex.Match(s, @"\S+?\s*(?=\=)").ToString().Trim();
                        var right = Regex.Match(s, @"(?<=\{)[\S\s]+(?=\})").ToString().Trim();
                        if (string.IsNullOrEmpty(right)) continue;
                        var node = xmlDoc.CreateElement("", left, "");
                        GetXml(right, ref node, xmlDoc);
                        xml.AppendChild(node);
                    }
                    else if (s.Length - s.Replace("=", "").Length > 1)
                    {
                        var eles = Regex.Matches(s, @"\w+\s*\=\s*\w+");
                        foreach (var ele in eles)
                        {
                            var a = ele.ToString().Trim();
                            var str = a.Split('=');
                            if (string.IsNullOrEmpty(str[1].Trim())) continue;
                            var node = xmlDoc.CreateElement("", str[0].Trim(), "");
                            node.InnerText = str[1].Trim();
                            xml.AppendChild(node);
                        }
                    }

                    sb = new StringBuilder();
                }
                else if (bracket < 0) return null;
            }
            return xml;
        }
        /// <summary>
        /// 将Xml文档转化为V2格式的文本
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static StringBuilder ToStringBuilder(XmlDocument xml)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(FileHelper.Unescape(xml.ChildNodes[1].Name) + " = " + "{");
            foreach (XmlNode node in xml.ChildNodes[1])
            {
                ToStringBuilder(node, ref sb, 0);
            }
            //sb.AppendLine("}");

            return sb;
        }

        private static void ToStringBuilder(XmlNode xml, ref StringBuilder sb, int depth)
        {
            string space = null;
            for (int i = 0; i < depth; i++) space = "\t" + space;
            if (xml.FirstChild.HasChildNodes)
            {
                if (FileHelper.Unescape(xml.Name).Trim() == "ANONYMOUS")
                {
                    sb.AppendLine(space + "{");
                }
                else
                {
                    sb.AppendLine(space + FileHelper.Unescape(xml.Name) + " = " + "{");
                }
                foreach (XmlNode node in xml.ChildNodes)
                {
                    ToStringBuilder(node, ref sb, depth + 1);
                }
                sb.AppendLine(space + "}");
            }
            else
            {
                sb.AppendLine(space + FileHelper.Unescape(xml.Name) + " = " + FileHelper.Unescape(xml.InnerText));
            }
        }
    }
}

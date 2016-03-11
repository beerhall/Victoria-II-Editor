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
            GetXml(FileHelper.RemoveAnnotation(file).ToString(), node, xmlDoc);
            xmlDoc.AppendChild(node);
            return xmlDoc;
        }

        private static XmlElement GetXml(string text, XmlElement xml, XmlDocument xmlDoc)
        {
            var bracket = 0;
            var sb = new StringBuilder();
            foreach (string line in FileHelper.SplitLine(text))
            {
                bracket = bracket + line.Length - line.Replace("{", "").Length;
                bracket = bracket - (line.Length - line.Replace("}", "").Length);
                sb.AppendLine(line);
                if (bracket == 0)
                {
                    var s = sb.ToString();
                    if (Regex.IsMatch(s, @"^[^\{\=\r\n]+?\s*\=[^\{\=\r\n]+\r") || Regex.IsMatch(s, @"^[^\{\=\r\n]+?\s*\=\s*\{[^\=]+\}\s*\r"))
                    {
                        var str = s.Split('=');
                        if (string.IsNullOrEmpty(str[1].Trim())) continue;
                        var node = xmlDoc.CreateElement("", str[0].Trim(), "");
                        node.InnerText = str[1].Trim();
                        xml.AppendChild(node);
                    }
                    else
                    {
                        var left = Regex.Match(s, @"\S+?\s*(?=\=)").ToString().Trim();
                        var right = Regex.Match(s, @"(?<=\{)[\S\s]+(?=\})").ToString().Trim();
                        if (string.IsNullOrEmpty(right)) continue;
                        var node = xmlDoc.CreateElement("", left, "");
                        GetXml(right, node, xmlDoc);
                        xml.AppendChild(node);
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
            var sb = new StringBuilder();
            foreach (XmlNode node in xml.FirstChild.ChildNodes)
            {
                ToStringBuilder(node, sb, 0);
            }
            return sb;
        }

        private static void ToStringBuilder(XmlNode xml, StringBuilder sb, int depth)
        {
            string space = null;
            for (int i = 0; i < depth; i++) space = "  " + space;
            if (xml.FirstChild.HasChildNodes)
            {
                sb.AppendLine(space + xml.Name + " = " + "{");
                foreach (XmlNode node in xml.ChildNodes)
                {
                    ToStringBuilder(node, sb, depth + 1);
                }
                sb.AppendLine(space + "}");
            }
            else
            {
                sb.AppendLine(space + xml.Name + " = " + xml.InnerText);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Victoria2.Domain.Comm
{
    /// <summary>
    /// 读取V2文件助手
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 读取指定文件,并去除注释
        /// </summary>
        /// <param name="file">TXT文件路径</param>
        /// <returns>单行文本</returns>
        public static IEnumerable<string> ReadLine(string file)
        {
            using (var sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-1")))//iso-8859-1
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    //去掉注释
                    if (line.Contains('#')) line = line.Substring(0, line.IndexOf('#'));
                    if (line.Contains("--")) line = line.Substring(0, line.IndexOf("--", StringComparison.Ordinal));
                    line = Escape(line).Trim();
                    if (string.IsNullOrEmpty(line)) continue;
                    yield return line;
                }
            }
        }
        /// <summary>
        /// 按格式分割文本
        /// </summary>
        /// <param name="text">V2文本</param>
        /// <returns>单行文本</returns>
        public static IEnumerable<string> SplitLine(string text)
        {
            foreach (var line in text.Split('\n'))
            {
                var str = line;
                if (str.Contains('#')) str = str.Substring(0, str.IndexOf('#'));
                str = str.Trim();
                if (string.IsNullOrEmpty(str)) continue;
                yield return str;
            }
        }
        /// <summary>
        /// 读取指定文件,并去除注释
        /// </summary>
        /// <param name="file">TXT文件路径</param>
        /// <returns>所有文本</returns>
        public static StringBuilder RemoveAnnotation(string file)
        {
            var sb = new StringBuilder();
            foreach (var line in ReadLine(file))
            {
                sb.AppendLine(line);
            }
            return sb;
        }

        /// <summary>
        /// 转义掉不可识别的':' '"' 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Escape(string str)
        {
            str = str.Replace("ESCAPE", "ESCAPEESCAPE");
            str = str.Replace(":", "ESCAPEMAOHAO");
            str = str.Replace("\"", "ESCAPEYINHAO");
            str = str.Replace("0", "ESCAPEZERO");
            str = str.Replace("1", "ESCAPEONE");
            str = str.Replace("2", "ESCAPETWO");
            str = str.Replace("3", "ESCAPETHREE");
            str = str.Replace("4", "ESCAPEFOUR");
            str = str.Replace("5", "ESCAPEFIVE");
            str = str.Replace("6", "ESCAPESIX");
            str = str.Replace("7", "ESCAPESEVEN");
            str = str.Replace("8", "ESCAPEEIGHT");
            str = str.Replace("9", "ESCAPENINE");
            return str;
        }


        public static string Unescape(string str)
        {
            str = str.Replace("ESCAPEMAOHAO", ":");
            str = str.Replace("ESCAPEYINHAO", "\"");
            str = str.Replace("ESCAPEZERO", "0");
            str = str.Replace("ESCAPEONE", "1");
            str = str.Replace("ESCAPETWO", "2");
            str = str.Replace("ESCAPETHREE", "3");
            str = str.Replace("ESCAPEFOUR", "4");
            str = str.Replace("ESCAPEFIVE", "5");
            str = str.Replace("ESCAPESIX", "6");
            str = str.Replace("ESCAPESEVEN", "7");
            str = str.Replace("ESCAPEEIGHT", "8");
            str = str.Replace("ESCAPENINE", "9");
            str = str.Replace("ESCAPEESCAPE", "ESCAPE");
            return str;
        }
    }
}

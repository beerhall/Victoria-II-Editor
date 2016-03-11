using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            using (var sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-1")))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains('#')) line = line.Substring(0, line.IndexOf('#'));
                    if (line.Contains("--")) line = line.Substring(0, line.IndexOf("--", StringComparison.Ordinal));
                    if (line.Contains(":")) line = line.Replace(":", "MAOHAO");
                    if (line.Contains("\"")) line = line.Replace("\"", "SHUANGYINHAO");
                    line = line.Trim();
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
    }
}

//
//Du 2016.4.12
//

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace Victoria2.Main
{
    public class LoadMethods
    {
        public static string getNameInPath(string path)
        {
            string filename = path.Substring(path.LastIndexOf("\\") + 1);
            string f = filename.Substring(0, filename.IndexOf(".") + 1);
            return f;
        }

        public static List<string> getNameListInPath(string path)
        {
            List<string> l = new List<string>();
            string[] files = Directory.GetFiles(path);
            foreach (string s in files)
            {
                l.Add(getNameInPath(s));
            }
            return l;
        }

        public static List<s_Religion> getReligions()
        {
            List<s_Religion> l = new List<s_Religion>();
            XmlDocument religions = new XmlDocument();
            religions.Load(".\\xml\\common\\religion.txt.xml");
            foreach (XmlNode religionGruop in religions.ChildNodes[1])
            {
                foreach (XmlNode religionNode in religionGruop)
                {
                    l.Add(new s_Religion(religionNode.Name));
                }
            }
            return l;
        }

        public static List<s_Culture> getCultures()
        {
            List<s_Culture> l = new List<s_Culture>();
            XmlDocument cultures = new XmlDocument();
            cultures.Load(".\\xml\\common\\cultures.txt.xml");
            foreach (XmlNode cultureGruop in cultures.ChildNodes[1])
            {
                foreach (XmlNode cultureNode in cultureGruop)
                {
                    if (cultureNode.Name != "leader" && cultureNode.Name != "unit" && cultureNode.Name != "union" && cultureNode.Name != "is_overseas")
                    {
                        l.Add(new s_Culture(cultureNode.Name));
                    }
                }
            }
            return l;
        }

        public static s_ProvinceID getProvinceID(string no)
        {
            /////////////////////////////
            //      TODO:get name      //
            /////////////////////////////
            string name = no;
            s_ProvinceID p = new s_ProvinceID(name, no);
            return p;
        }

        public static List<string> getPoptypeList()
        {
            return getNameListInPath(".\\..\\poptypes");
        }

        public static List<s_CountryPops> getCountryPops()
        {
            List<s_CountryPops> l = new List<s_CountryPops>();

            string[] path_dates = Directory.GetDirectories(".\\xml\\history");
            foreach (string pd in path_dates)
            {
                string date = getNameInPath(pd);
                string[] path_countries = Directory.GetFiles(pd);
                foreach (string pc in path_countries)
                {
                    List<s_ProvincePops> lpp = new List<s_ProvincePops>();
                    string country = getNameInPath(pc);
                    XmlDocument countrypops = new XmlDocument();
                    countrypops.Load("pc");
                    foreach (XmlNode prov in countrypops.ChildNodes[1])
                    {
                        string provinceno = prov.Name;
                        provinceno = Victoria2.Domain.Comm.FileHelper.Unescape(provinceno);
                        s_ProvinceID pi = getProvinceID(provinceno);
                        List<s_Pop> lp = new List<s_Pop>();
                        foreach(XmlNode pt in prov)
                        {
                            string poptype = pt.Name;
                            s_Culture culture = new s_Culture(pt.ChildNodes[0].Value);
                            s_Religion religion = new s_Religion(pt.ChildNodes[1].Value);
                            string size = pt.ChildNodes[2].Value;
                            lp.Add(new s_Pop(religion, culture, size, poptype));
                        }
                        s_ProvincePops pp = new s_ProvincePops(pi, lp);
                        lpp.Add(pp);
                    }
                    l.Add(new s_CountryPops(lpp, new s_Country(country), date));
                }
            }

            return l;
        }

    }
}

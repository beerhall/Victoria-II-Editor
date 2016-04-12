//
//Du 2016.4.12
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victoria2.Main
{
    public class s_Religion
    {
        public s_Religion(string p_name) { Name = p_name; }
        public string Name { get; set; }
    }

    public class s_Culture
    {
        public s_Culture(string p_name) { Name = p_name; }
        public string Name { get; set; }
    }

    public class s_Country
    {
        public s_Country(string p_name) { Name = p_name; }
        public string Name { get; set; }
    }

    public class s_Pop
    {
        public s_Pop(s_Religion p_religion, s_Culture p_culture, string p_size, string p_poptype)
        {
            Religion = p_religion;
            Culture = p_culture;
            Size = p_size;
            PopType = p_poptype;
        }
        public s_Religion Religion { get; set; }
        public s_Culture Culture { get; set; }
        public string Size { get; set; }
        public string PopType { get; set; }

        public override string ToString()
        {
            return Culture.Name + " " + PopType + "*" + Size;
        }
    }

    public class s_ProvinceID
    {
        public string ProvinceName;
        public string ProvinceNo;
        public s_ProvinceID(string p_ProvinceName, string p_ProvinceNo)
        {
            ProvinceName = p_ProvinceName;
            ProvinceNo = p_ProvinceNo;
        }
        public override string ToString()
        {
            return ProvinceNo + " - " + ProvinceName;
        }
    }

    public class s_ProvincePops
    {
        public s_ProvincePops(s_ProvinceID p_ProvinceID, List<s_Pop> p_pops)
        {
            ProvinceID = p_ProvinceID;
            Pops = p_pops;
        }
        public List<s_Pop> Pops { get; set; }
        public s_ProvinceID ProvinceID { get; set; }
    }

    public class s_CountryPops
    {
        public s_CountryPops(List<s_ProvincePops> p, s_Country c, string d)
        {
            Pops = p;
            Country = c;
            Date = d;
        }
        public List<s_ProvincePops> Pops;
        public s_Country Country;
        public string Date;
    }


}

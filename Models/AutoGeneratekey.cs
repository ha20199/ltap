using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ltap.Models
{
    public class AutoGeneratekey
    {

        public string GenerateKey(string id)
        {
            string strkey = "";

            string numPart = "", strPart = "", strPhanSo = "";
            //tach phan so: 001
            numPart = Regex.Match(id, @"\d+").Value;
            //them ca so o de kich thuoc = phan so => 1+1 = 2
            int phanso = (Convert.ToInt32(numPart) + 1);
            for (int i = 0; i < numPart.Length - phanso.ToString().Length; i++)
            {
                strPhanSo += "0";
            }
            strPhanSo += phanso;
            //tach phan chu
            strkey = strPart + strPhanSo;
            return strkey;
        }
    }
}
using System.Text.RegularExpressions;

namespace SonKhoatnhom4.Models.Process
{
    public class StringProcess
    {
        public string AutoGenerateCode(string strInput)
        {
            string strResult= "",numPart="",strPart="";
            // tach phan so phan tu strInput
            numPart= Regex.Match(strInput,@"\d+").Value;
            // tach phan chu tu strInput
            strPart = Regex.Match(strInput,@"\D+").Value;
            // tang phan tu so len mot don vi
            int intPart = (Convert.ToInt32(numPart)+1);
            // bo sung cac ky tu 0 con thieu
            for (int i=0;i<numPart.Length - intPart.ToString().Length;i++)
            {
                strPart +="0";
            }
            strResult = strPart +intPart;
            return strResult;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    CountryCode,Language,IsOfficial,Percentage
    ABW,Dutch,T,5.3
 */
namespace WorldModelLibrary.models
{
    public class CountryLanguage
    {
        public string CountryCode { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public bool IsOfficial { get; set; }
        public float Percentage { get; set; }


    }
}

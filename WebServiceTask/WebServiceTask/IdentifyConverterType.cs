using System;
using System.Collections.Generic;

namespace WebServiceTask
{
    public static class IdentifyConverterType
    {
        public static List<string> pinta = new List<string>() { "PINTA", "PIN", "PI", "P", "PT" };
        public static List<string> litr = new List<string>() { "LITR", "L", "LI", "LT", "LIT" };
        public static List<string> gallon = new List<string>() { "GALLON", "GA", "GL", "GAL", "G", "GN" };
        public static List<string> volume = new List<string>() { "PINTA", "PIN", "PI", "P", "PT", "LITR", "L", "LI", "LT", "LIT", "GALLON", "GA", "GL", "GAL", "G", "GN"};

        public static List<string> kelvin = new List<string>() { "KELVIN", "K", "KL", "KV", "KEL", "KE", "KN" };
        public static List<string> celsius = new List<string>() { "CELSIUS", "C", "CL", "CE", "CS", "CELS" };
        public static List<string> farengheit = new List<string>() { "FARENGHEIT", "FA", "F", "FT", "FN", "FAR" };
        public static List<string> temperature = new List<string>() { "KELVIN", "K", "KL", "KV", "KEL", "KE", "KN", "CELSIUS", "C", "CL", "CE", "CS", "CELS", "FARENGHEIT", "FA", "F", "FT", "FN", "FAR" };

        public static List<string> length = new List<string>() { "METR", "METRES", "ME", "MT", "MILE", "MILES", "MI", "ML", "MS", "FUT", "FT", "FS", "FUTS", };
        public static List<string> metr = new List<string>() { "METR", "METRES", "ME", "MT" };
        public static List<string> mile = new List<string>() { "MILE", "MILES", "MI", "ML", "MS" };
        public static List<string> fut = new List<string>() { "FUT", "FT", "FS", "FUTS" };

        public static ConvertersEnum GetConvertersTypes(string basicMeasure)
        {
            basicMeasure = basicMeasure.ToUpper();

            if (temperature.Contains(basicMeasure))
            {
                return ConvertersEnum.Temperature;
            }
            else if (volume.Contains(basicMeasure))
            {
                return ConvertersEnum.Volume;
            }
            else if (length.Contains(basicMeasure))
            {
                return ConvertersEnum.Length;
            }
            else throw new Exception("Wrong data format");
        }
    }
}
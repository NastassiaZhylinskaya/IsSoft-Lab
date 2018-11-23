using System;

namespace WebServiceTask
{
    /// <summary>
    /// Convert length from one measure system to another measure system.
    /// </summary>
    public class ConverterLength : IConvert
    {
        double length;
        static ConverterLength instance;
        const double NULL = 0;

        private ConverterLength()
        {
        }

        /// <summary>
        /// SingleTon.
        /// </summary>
        /// <returns></returns>
        public static ConverterLength GetInstance()
        {
            if (instance == null)
                instance = new ConverterLength();
            return instance;
        }

        /// <summary>
        /// Convert length from one measure system to another measure system.
        /// </summary>
        /// <param name="basicMeasure"></param>
        /// <param name="newMeasure"></param>
        /// <param name="value"></param>
        /// <returns>method.</returns>
        public double ConvertTo(string basicMeasure, string newMeasure, string value)
        {
            basicMeasure = basicMeasure.ToUpper();
            newMeasure = newMeasure.ToUpper();

            if(!(double.TryParse(value, out length)) && ValidationCheck(basicMeasure,newMeasure) )
            {
                throw new Exception("Wrong data format.");
            }
            else
            {
                if (IdentifyConverterType.metr.Contains(basicMeasure) && IdentifyConverterType.mile.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return MetrToMile();
                }
                else if (IdentifyConverterType.metr.Contains(basicMeasure) && IdentifyConverterType.fut.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return MetrToFut();
                }
                else if (IdentifyConverterType.mile.Contains(basicMeasure) && IdentifyConverterType.metr.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return MileToMetr();
                }
                else if (IdentifyConverterType.mile.Contains(basicMeasure) && IdentifyConverterType.fut.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return MileToFut();
                }
                else if (IdentifyConverterType.fut.Contains(basicMeasure) && IdentifyConverterType.metr.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return FutToMetr();
                }
                else if (IdentifyConverterType.fut.Contains(basicMeasure) && IdentifyConverterType.mile.Contains(newMeasure) && ValidationNegativityLength(length))
                {
                    return FutToMile();
                }
                else
                {
                    throw new Exception("System is not exist..");
                }
            }            
        }

        /// <summary>
        /// Check inputted parametres.
        /// </summary>
        /// <param name="basicMeasure"></param>
        /// <param name="newMeasure"></param>
        /// <returns></returns>
        private bool ValidationCheck(string basicMeasure, string newMeasure)
        {
            if(IdentifyConverterType.length.Contains(basicMeasure) && IdentifyConverterType.length.Contains(newMeasure))
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong data format.");
            }
        }

        /// <summary>
        /// Validation negativity length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool ValidationNegativityLength(double length)
        {
            if (length > NULL)
            {
                return true;
            }
            else
            {
                throw new Exception("Negativity length is entered.");
            }
        }

        /// <summary>
        /// Convert metrs to miles.
        /// </summary>
        /// <returns>Miles.</returns>
        public double MetrToMile()
        {
            return length / 1609.344;
        }

        /// <summary>
        /// Convert metrs to futs.
        /// </summary>
        /// <returns>Futs.</returns>
        public double MetrToFut()
        {
            return length * 3.281;
        }

        /// <summary>
        /// Convert miles to metres.
        /// </summary>
        /// <returns>Metrs.</returns>
        public double MileToMetr()
        {
            return length * 1609.344;
        }

        /// <summary>
        /// Convert miles to futs.
        /// </summary>
        /// <returns>Futs.</returns>
        public double MileToFut()
        {
            return length * 5280;
        }

        /// <summary>
        /// Convert futs to metres.
        /// </summary>
        /// <returns>Metres.</returns>
        public double FutToMetr()
        {
            return length / 3.281;
        }

        /// <summary>
        /// Convert futs to miles.
        /// </summary>
        /// <returns>Miles.</returns>
        public double FutToMile()
        {
            return length / 5280;
        }
    }
}
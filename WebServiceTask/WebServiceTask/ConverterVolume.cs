using System;

namespace WebServiceTask
{
    /// <summary>
    /// Convert volume from one measure system to another measure system.
    /// </summary>
    public class ConverterVolume : IConvert
    {
        double volume;
        static ConverterVolume instance;
        const double NULL = 0;

        private ConverterVolume()
        {
        }

        /// <summary>
        /// SingleTon.
        /// </summary>
        /// <returns></returns>
        public static ConverterVolume GetInstance()
        {
            if (instance == null)
                instance = new ConverterVolume();
            return instance;
        }

        /// <summary>
        /// Convert volume from one measure system to another measure system.
        /// </summary>
        /// <param name="basicMeasure"></param>
        /// <param name="newMeasure"></param>
        /// <param name="value"></param>
        /// <returns>method.</returns>
        public double ConvertTo(string basicMeasure, string newMeasure, string value)
        {
            basicMeasure = basicMeasure.ToUpper();
            newMeasure = newMeasure.ToUpper();

            if (!(double.TryParse(value, out volume)) && ValidationCheck(basicMeasure, newMeasure))
            {
                throw new Exception("Wrong data format.");
            }
            else
            {
                if (IdentifyConverterType.pinta.Contains(basicMeasure) && IdentifyConverterType.litr.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return PintaToLitres();
                }
                else if (IdentifyConverterType.pinta.Contains(basicMeasure) && IdentifyConverterType.gallon.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return PintaToGallon();
                }
                else if (IdentifyConverterType.litr.Contains(basicMeasure) && IdentifyConverterType.gallon.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return LitrToGallon();
                }
                else if (IdentifyConverterType.litr.Contains(basicMeasure) && IdentifyConverterType.pinta.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return LitrToPinta();
                }
                else if (IdentifyConverterType.gallon.Contains(basicMeasure) && IdentifyConverterType.pinta.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return GallonToPinta();
                }
                else if (IdentifyConverterType.gallon.Contains(basicMeasure) && IdentifyConverterType.litr.Contains(newMeasure) && ValidationNegativityVolume(volume))
                {
                    return GallonToLitr();
                }
                else
                {
                    throw new Exception("System is not exist.");
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
            if (!(IdentifyConverterType.volume.Contains(basicMeasure)) && (IdentifyConverterType.volume.Contains(newMeasure)))
            {
                throw new Exception("Wrong data format.");
            }
            else
            {
                return volume > 0;
            }
        }

        /// <summary>
        /// Validation negativity volume.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private bool ValidationNegativityVolume(double volume)
        {
            if (volume > NULL)
            {
                return true;
            }
            else
            {
                throw new Exception("Negativity volume is entered.");
            }
        }

        /// <summary>
        /// Convert pintas to litres.
        /// </summary>
        /// <returns>Litres.</returns>
        public double PintaToLitres()
        {
            return volume / 1.76;
        }

        /// <summary>
        /// Convert pintas to gallons.
        /// </summary>
        /// <returns>Gallons.</returns>
        public double PintaToGallon()
        {
            return volume / 8;
        }

        /// <summary>
        /// Convert litres to gallons.
        /// </summary>
        /// <returns>Gallons.</returns>
        public double LitrToGallon()
        {
            return volume / 4.546;
        }

        /// <summary>
        /// Convert litres to pintas.
        /// </summary>
        /// <returns>Pintas.</returns>
        public double LitrToPinta()
        {
            return volume * 1.76;
        }

        /// <summary>
        /// Convert gallons to pintas.
        /// </summary>
        /// <returns>Pintas.</returns>
        public double GallonToPinta()
        {
            return volume * 8;
        }

        /// <summary>
        /// Convert gallons to litres.
        /// </summary>
        /// <returns>Litres.</returns>
        public double GallonToLitr()
        {
            return volume * 4.546;
        }
    }
}
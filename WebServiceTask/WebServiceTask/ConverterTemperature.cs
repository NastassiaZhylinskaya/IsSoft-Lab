using System;

namespace WebServiceTask
{
    /// <summary>
    /// Convert temperature from one measure system to another measure system.
    /// </summary>
    public class ConverterTemperature : IConvert
    {
        double temperature;
        static ConverterTemperature instance;
        const double ABSOLUTEZEROKELVIN = 0;
        const double ABSOLUTEZEROCELSIUS = -273.15;
        const double ABSOLUTEZEROFARENGHEIT = -459.67;

        private ConverterTemperature()
        {
        }

        /// <summary>
        /// SingleTon.
        /// </summary>
        /// <returns></returns>
        public static ConverterTemperature GetInstance()
        {
            if (instance == null)
                instance = new ConverterTemperature();
            return instance;
        }

        /// <summary>
        /// Convert temperature from one measure system to another measure system.
        /// </summary>
        /// <param name="basicMeasure"></param>
        /// <param name="newMeasure"></param>
        /// <param name="value"></param>
        /// <returns>method.</returns>
        public double ConvertTo(string basicMeasure, string newMeasure, string value)
        {
            basicMeasure = basicMeasure.ToUpper();
            newMeasure = newMeasure.ToUpper();

            if (!(double.TryParse(value, out temperature)) && ValidationCheck(basicMeasure, newMeasure))
            {
                throw new Exception("Wrong data format.");
            }
            else
            {
                if (IdentifyConverterType.kelvin.Contains(basicMeasure) && IdentifyConverterType.celsius.Contains(newMeasure) && ValidationCheckKelvin(temperature))
                {                    
                    return KelvinToCelsius();
                }

                else if (IdentifyConverterType.kelvin.Contains(basicMeasure) && IdentifyConverterType.farengheit.Contains(newMeasure) && ValidationCheckKelvin(temperature))
                {                    
                    return KelvinToFarengheit();
                }

                else if (IdentifyConverterType.celsius.Contains(basicMeasure) && IdentifyConverterType.kelvin.Contains(newMeasure) && ValidationCheckCelsius(temperature))
                {                    
                    return CelsiusToKelvin();
                }

                else if (IdentifyConverterType.celsius.Contains(basicMeasure) && IdentifyConverterType.farengheit.Contains(newMeasure) && ValidationCheckCelsius(temperature))
                {                    
                    return CelsiusToFarengheit();
                }

                else if (IdentifyConverterType.farengheit.Contains(basicMeasure) && IdentifyConverterType.celsius.Contains(newMeasure) && ValidationCheckFarengheit(temperature))
                {                    
                    return FarengheitToCelsius();
                }

                else if (IdentifyConverterType.farengheit.Contains(basicMeasure) && IdentifyConverterType.kelvin.Contains(newMeasure) && ValidationCheckFarengheit(temperature))
                {                    
                    return FarengheitToKelvin();
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
            if ((IdentifyConverterType.temperature.Contains(basicMeasure)) && (IdentifyConverterType.temperature.Contains(newMeasure)))
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong data format.");
            }
        }

        /// <summary>
        /// Check validation for kelvin temperature.
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private bool ValidationCheckKelvin(double temperature)
        {
            if (temperature > ABSOLUTEZEROKELVIN)
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong kelvin temperature.");
            }
        }

        /// <summary>
        /// Check validation for celsius temperature.
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private bool ValidationCheckCelsius(double temperature)
        {
            if (temperature > ABSOLUTEZEROCELSIUS)
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong celsius temperature.");
            }
        }

        /// <summary>
        /// Check validation for farengheit temperature.
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        private bool ValidationCheckFarengheit(double temperature)
        {
            if (temperature > ABSOLUTEZEROFARENGHEIT)
            {
                return true;
            }
            else
            {
                throw new Exception("Wrong farengheit temperature.");
            }
        }

        /// <summary>
        /// Convert kelvins to celsius.
        /// </summary>
        /// <returns>Celsius.</returns>
        public double KelvinToCelsius()
        {            
            return temperature - 273.15;
        }

        /// <summary>
        /// Convert kelvins to farengheits.
        /// </summary>
        /// <returns>Farengheits.</returns>
        public double KelvinToFarengheit()
        {
            return ((temperature - 273.15) * (9 / 5)) - 32;
        }

        /// <summary>
        /// Convert celsius to kelvins.
        /// </summary>
        /// <returns>Kelvins.</returns>
        public double CelsiusToKelvin()
        {
            return temperature + 273.15;
        }

        /// <summary>
        /// Convert celsius to farengheits.
        /// </summary>
        /// <returns>Farengheits.</returns>
        public double CelsiusToFarengheit()
        {
            return ((temperature * (9 / 5)) - 32);
        }

        /// <summary>
        /// Convert farengheits to celsius.
        /// </summary>
        /// <returns>Celsius.</returns>
        public double FarengheitToCelsius()
        {
            return ((temperature - 32) * 5) / 9;
        }

        /// <summary>
        /// Convert farengheits to kelvins.
        /// </summary>
        /// <returns>Kelvins.</returns>
        public double FarengheitToKelvin()
        {
            return (((temperature - 32) * (5 / 9)) + 273.15);
        }            
    }
}
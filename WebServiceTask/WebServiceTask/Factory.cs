using System;

namespace WebServiceTask
{
    /// <summary>
    /// Factory pattern for converters.
    /// </summary>
    public static class Factory
    {
        public static IConvert Create(string basicMeasure)
        {
            switch (IdentifyConverterType.GetConvertersTypes(basicMeasure))
            {
                case ConvertersEnum.Length:
                    return ConverterLength.GetInstance();
                case ConvertersEnum.Temperature:
                    return ConverterTemperature.GetInstance();
                case ConvertersEnum.Volume:
                    return ConverterVolume.GetInstance();
                default:
                    throw new Exception("Wrong data");
            }
        }
    }
}
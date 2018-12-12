using System;
using WebServiceTask;

namespace ClientConsole
{
    class EntryPoint
    {
        public delegate void Result();

        static void Main(string[] args)
        {
            Result result;
            try
            {
                string keyValue;
                
                ConverterWebService converterWebService = new ConverterWebService();
                
                do
                {
                    Console.WriteLine("Enter basic measure system: ");
                    string basicMeasure = Console.ReadLine();
                    Console.WriteLine("Enter new measure system: ");
                    string newMeasure = Console.ReadLine();
                    Console.WriteLine("Enter value: ");
                    string value = Console.ReadLine();
                    converterWebService.Converter(basicMeasure, newMeasure, value);
                    result = AddConversation;
                    AddConversation();
                    Console.WriteLine("Enter 'yes', if want to continue convert some data.");
                    keyValue = Console.ReadLine();
                    

                }
                while (keyValue == "yes");                
                
                Console.WriteLine(converterWebService.ShowConvertedResults());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }               
        }
        public static void AddConversation()
        {
           Console.WriteLine("New conversation is added.");
        }
        public static bool SendCommandToConvert(ConverterWebService converterWebService, string basicMeasure, string newMeasure, string value)
        {
            return converterWebService.Converter(basicMeasure, newMeasure, value);
        }
        public static string GetConvertedResult(ConverterWebService converterWebService, string basicMeasure, string newMeasure, string value)
        {
            return converterWebService.ShowConvertedResults();
        }
    }
}

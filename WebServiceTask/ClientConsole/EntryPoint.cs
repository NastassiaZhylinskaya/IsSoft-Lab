using System;
using WebServiceTask;

namespace ClientConsole
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
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
                    converterWebService.Convert(basicMeasure, newMeasure, value);
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
    }
}

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
                Console.WriteLine("Enter basic measure system: ");
                string basicMeasure = Console.ReadLine();
                Console.WriteLine("Enter new measure system: ");
                string newMeasure = Console.ReadLine();
                Console.WriteLine("Enter value: ");
                string value = Console.ReadLine();
                ConverterWebService converter = new ConverterWebService();
                Console.WriteLine("\n{0}", converter.ConvertTo(basicMeasure, newMeasure, value));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }
}

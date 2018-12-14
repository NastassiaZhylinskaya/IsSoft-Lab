using System.Collections.Generic;
using System.Text;
using System.Web.Services;

namespace WebServiceTask
{
    /// <summary>
    /// Summary description for ConvertrWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ConverterWebService : WebService
    {
        public delegate string Result();
        public event Result GetConvertedResult;
        
        List<Result> listOfDelegates = new List<Result>();
        StringBuilder results = new StringBuilder();

        public ConverterWebService()
        {
            GetConvertedResult += FormsStringsWithConvertedResults;
            GetConvertedResult += FormsStringsWithConvertedReversedResults;
        }

        [WebMethod()]
        public void Convert(string basicMeasure, string newMeasure, string value)
        {
            IConvert converter = Factory.Create(basicMeasure);
            CommandConverter commandConverter = new CommandConverter(converter, basicMeasure, newMeasure, value);            
            listOfDelegates.Add(commandConverter.Execute);
        }

        [WebMethod()]
        public string ShowConvertedResults()
        {
            GetConvertedResult();
            return results.ToString();
        }

        private string FormsStringsWithConvertedResults()
        {
            foreach (var convertorDelegate in listOfDelegates)
            {
                results.Append(convertorDelegate.Invoke() + "\n");
            }

            return results.ToString();
        }

        private string FormsStringsWithConvertedReversedResults()
        {
            listOfDelegates.Reverse();

            foreach (var convertorDelegate in listOfDelegates)
            {
                results.Append(convertorDelegate.Invoke() + "\n");
            }

            return results.ToString();
        }
    }
}

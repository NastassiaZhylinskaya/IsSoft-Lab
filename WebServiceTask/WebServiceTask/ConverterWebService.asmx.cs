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
        List<ICommand> listOfCommand = new List<ICommand>();

        public ConverterWebService()
        {
        }

        [WebMethod()]
        public bool Converter(string basicMeasure, string newMeasure, string value)
        {
            IConvert converter = Factory.Create(basicMeasure);
            CommandConverter commandConverter = new CommandConverter(converter, basicMeasure, newMeasure, value);
            string newValue = commandConverter.Execute();
            listOfCommand.Add(commandConverter);
            return true;
        }

        [WebMethod()]
        public string ShowConvertedResults()
        {
            StringBuilder results = new StringBuilder();
            foreach(CommandConverter commandConverter in listOfCommand)
            {
                results.Append(commandConverter.basicMeasure + " " + commandConverter.newMeasure + " " + commandConverter.newValue + "\n");
            }
            return results.ToString();
        }

    }
}

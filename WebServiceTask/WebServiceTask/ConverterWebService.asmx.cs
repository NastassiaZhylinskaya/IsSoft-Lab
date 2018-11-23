using System.Web.Services;

namespace WebServiceTask
{
    /// <summary>
    /// Summary description for ConvertorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ConverterWebService : WebService
    {
        public ConverterWebService()
        {
        }

        [WebMethod()]
        public string ConvertTo(string basicMeasure, string newMeasure, string value)
        {
            IConvert converter = Factory.Create(basicMeasure);
            return converter.ConvertTo(basicMeasure, newMeasure, value).ToString();
        }
    }
}

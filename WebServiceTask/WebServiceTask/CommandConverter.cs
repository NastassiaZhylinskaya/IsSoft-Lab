namespace WebServiceTask
{
    public class CommandConverter : ICommand
    {
        IConvert reciever;
        public string basicMeasure;
        public string newMeasure;
        public string value;
        public string newValue;
        
        public CommandConverter (IConvert convert, string basicMeasure, string newMeasure, string value)
        {
            reciever = convert;
            this.basicMeasure = basicMeasure;
            this.newMeasure = newMeasure;
            this.value = value;
        }

        public string Execute()
        {
            newValue = basicMeasure + " " + newMeasure + " " + reciever.ConvertTo(basicMeasure, newMeasure, value);
            return newValue;
        }
    }
}
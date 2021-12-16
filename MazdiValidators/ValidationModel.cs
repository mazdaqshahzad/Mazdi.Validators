
namespace Mazdi.Validators
{
    public class ValidationModel
    {
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }
        public ValidationType ValidationType { get; set; }
        public int? Maximum { get; set; }
        public int? Minimum { get; set; }
        public string Format { get; set; }
        public string CustomMessage { get; set; }
        public int? DecimalPlaceLimit { get; set; }
    }
}

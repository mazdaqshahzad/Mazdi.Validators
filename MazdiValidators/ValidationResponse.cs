using System.Collections.Generic;

namespace Mazdi.Validators
{
    public class ValidationResponse
    {
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
    }
}

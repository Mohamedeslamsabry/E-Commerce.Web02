using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Error_Models
{
    public class ValiadtionErrorToReturn
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public string ErrorMessage { get; set; } = "Validtion Failed";
        public IEnumerable<ValidtionErrorDetails> validtionErrors { get; set; } = [];

    }
}

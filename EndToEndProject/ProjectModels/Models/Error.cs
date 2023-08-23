using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModels.Models
{
    public class Error
    {
        //public string ErrorCode { get; set; }
        //[JsonProperty("ErrorDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        public string ErrorDescription { get; set; }

        //[JsonProperty("Message", NullValueHandling = NullValueHandling.Ignore)]
        //public string Message { get; set; }
        //[JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
       
    }
}

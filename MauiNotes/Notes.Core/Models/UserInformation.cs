using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Models
{
    public class UserInformation
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = "";

        [JsonProperty("lastName")]
        public string LastName { get; set; } = "";
    }
}

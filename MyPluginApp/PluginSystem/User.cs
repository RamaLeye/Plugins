using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PluginSystem
{
    public class User
    {
        [JsonProperty("first_name")] 
        string FirstName{ get; set; }

        [JsonProperty("last_name")]
        string LastName { get; set; }

        [JsonProperty("email")]
        string Email { get; set; }

       
          public  override string ToString()
        {
            string userString = "First Name : " + FirstName + " ; Last Name : " + LastName + " ; Email : " + Email;
            return userString;
        }
    }
}

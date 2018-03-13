using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DC.Web.Ui.Settings
{

    public class AuthenticationSettings : IAuthenticationSettings
    {
        [JsonRequired]
        public string WtRealm { get; set; }
        [JsonRequired]
        public string MetadataAddress { get; set; }
        
    }

}

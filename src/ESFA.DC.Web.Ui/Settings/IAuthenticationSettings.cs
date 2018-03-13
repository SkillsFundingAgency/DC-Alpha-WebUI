using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC.Web.Ui.Settings
{
    public interface IAuthenticationSettings
    {
        string WtRealm { get; set; }
        string MetadataAddress { get; set; }
        
    }

}

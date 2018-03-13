using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC.Web.Ui.Settings
{
    public interface IWebConfiguration
    {
        AuthenticationSettings Authentication { get; set; }
    }
}

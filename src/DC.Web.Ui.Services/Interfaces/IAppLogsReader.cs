using System;
using System.Collections.Generic;
using System.Text;
using DC.Web.Ui.Services.Models;

namespace DC.Web.Ui.Services.Interfaces
{
    public interface IAppLogsReader
    {
        IEnumerable<AppLog> GetApplicationLogs(string correlationId);
    }
}

﻿using System.Collections.Generic;
using DC.Web.Ui.Services.Models;

namespace DC.Web.Ui.Services.Interfaces
{
    public interface IUkprnClaimsHandlerService
    {
        bool ClaimAccepted(IEnumerable<IdamsClaim> claims);
    }
}

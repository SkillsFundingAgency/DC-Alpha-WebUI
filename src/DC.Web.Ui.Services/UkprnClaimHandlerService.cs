using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DC.Web.Ui.Services.Interfaces;
using DC.Web.Ui.Services.Models;

namespace DC.Web.Ui.Services
{
    public class UkprnClaimHandlerService : IUkprnClaimHandlerService
    {
        public bool ClaimAccepted(IEnumerable<IdamsClaim> claims)
        {
            if (claims == null)
                return false;

            return claims.Any(x => x.Type == "Ukprn" && !string.IsNullOrEmpty(x.Value));
        }
    }
}

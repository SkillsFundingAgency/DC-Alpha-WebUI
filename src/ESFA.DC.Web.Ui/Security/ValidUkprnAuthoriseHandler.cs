using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DC.Web.Ui.ClaimTypes;
using Microsoft.AspNetCore.Authorization;

namespace DC.Web.Ui.Security
{
    public class ValidUkprnAuthoriseHandler : AuthorizationHandler<UkprnRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,UkprnRequirement requirement)
        {
            
            context.Succeed(requirement);
            //if (context.User.HasClaim(c => c.Type == IdamsClaimTypes.UkprnClaim && !string.IsNullOrEmpty(c.Value)))
            //{
            //    context.Succeed(requirement);
            //}
            //else
            //{
            //    context.Fail();
            //}
            return Task.CompletedTask;
            //return Task.FromResult(0);


        }
    }

    public class UkprnRequirement : IAuthorizationRequirement
    {

    }
}

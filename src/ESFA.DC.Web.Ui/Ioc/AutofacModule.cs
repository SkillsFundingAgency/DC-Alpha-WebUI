using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DC.Web.Ui.Services;
using DC.Web.Ui.Services.Interfaces;

namespace DC.Web.Ui.Ioc
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UkprnClaimHandlerService)).As(typeof(IUkprnClaimsHandlerService)).InstancePerLifetimeScope();
        }
    }
}

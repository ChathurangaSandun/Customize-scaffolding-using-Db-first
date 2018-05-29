using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scaffoldingdbcontext.Utils
{
    public class MyDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICSharpEntityTypeGenerator, MyEntityTypeWriter>();
            serviceCollection.AddSingleton<ICSharpDbContextGenerator, MyDbContextGenerator>();
            serviceCollection.AddSingleton<IBaseClassGenerator, MyBaseClassGenerator>();
            serviceCollection.AddSingleton<CSharpScaffoldingGenerator, MyCSharpScaffoldingGenerator>();
        }
    }

}

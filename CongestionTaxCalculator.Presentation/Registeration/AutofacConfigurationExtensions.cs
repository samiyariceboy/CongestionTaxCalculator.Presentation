using Autofac;
using CongestionTaxCalculator.Domain.Common;
using CongestionTaxCalculator.Domain.Common.InterfaceDependency;
using CongestionTaxCalculator.Infrastructure.DbContexts.Sql.SqlServer;
using System.Reflection;

namespace VoipService.Api.Configuration
{
    public static class AutofacConfigurationExtensions
    {
        #region NewConfiguration
        public class ServiceModules : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);

                #region Auto Assembly Registeration services with autofac and interface class
                Assembly ApiAssembly = typeof(Program).Assembly;
                Assembly EntitiesAssembly = typeof(IEntity).Assembly;
                Assembly DataAssembly = typeof(ApplicationDbContext).Assembly;

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<IScopedDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ITransientDependency>()
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

                builder.RegisterAssemblyTypes(ApiAssembly, EntitiesAssembly, DataAssembly)
                    .AssignableTo<ISingletonDependency>()
                    .AsImplementedInterfaces()
                    .SingleInstance();
                #endregion
                #endregion
            }
        }

        #region Accessors

        #endregion
    }
}

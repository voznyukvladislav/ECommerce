using Autofac;
using ECommerceCMSAPI.Core.Interfaces;
using ECommerceCMSAPI.Core.Services;

namespace ECommerceCMSAPI.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();

    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
  }
}

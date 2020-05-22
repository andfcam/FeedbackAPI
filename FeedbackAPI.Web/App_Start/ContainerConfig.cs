using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FeedbackAPI.Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace FeedbackAPI.Web
{
    public static class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<RequestData>()
                .As<IRequestData>()
                .InstancePerRequest();
            builder.RegisterType<FeedbackAPIDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
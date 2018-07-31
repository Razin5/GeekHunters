using Autofac;
using Autofac.Integration.WebApi;
using GeekRegistrationSystemCore;
using System.Reflection;
using System.Web.Http;

namespace GeekRegistrationSystemRestApi
{
    public static class IocConfig
    {
        public static void configure()
        {
            //Dependency Injection
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CandidateRepo>().As<ICandidateRepo>();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
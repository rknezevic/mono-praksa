using Autofac;
using PatientProject.IPersonRepository.Common;
using PersonRepository;
using Service;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace VehicleProject.App_Start
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();

            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<PatientRepository>().As<IPatientRepositoryCommon>();


            IContainer Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            
        }
    }
}
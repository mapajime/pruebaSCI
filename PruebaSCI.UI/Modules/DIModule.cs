using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using PruebaSCI.Business.Repositorios;
using PruebaSCI.Business.Servicios;

namespace PruebaSCI.UI.Modules
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NacionalidadRepositorio>().As<INacionalidadRepositorio>().PropertiesAutowired().InstancePerRequest();
            builder.RegisterType<NacionalidadServicio>().As<INacioanlidadServicio>().PropertiesAutowired().InstancePerRequest();

            base.Load(builder);
        }
    }
}
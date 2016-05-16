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

            builder.RegisterType<EquipoRepositorio>().As<IEquipoRepositorio>().PropertiesAutowired().InstancePerRequest();
            builder.RegisterType<EquipoServicio>().As<IEquipoServicio>().PropertiesAutowired().InstancePerRequest();


            builder.RegisterType<PilotoRepositorio>().As<IPilotoRepositorio>().PropertiesAutowired().InstancePerRequest();
            builder.RegisterType<PilotoServicio>().As<IPilotoServicio>().PropertiesAutowired().InstancePerRequest();

            base.Load(builder);
        }
    }
}
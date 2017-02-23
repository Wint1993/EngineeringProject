using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Domain.Concrete;
using Domain.Entities;
using Domain.Abstract;

namespace WebUi.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
           kernel.Bind<IPersonRepository>().To<EFPersonRepository>();
           kernel.Bind<IWarehousesRepository>().To<EFWarehousesRepository>();
           kernel.Bind<ITransportfleetRepository>().To<EFTransportfleetRepository>();
           kernel.Bind<IPacksRepository>().To<EFPacksRepository>();
           kernel.Bind<ICarriageRepository>().To<EFCarriageRepository>();
           kernel.Bind<IActRepository>().To<EFActRepository>();



        }
    }
}

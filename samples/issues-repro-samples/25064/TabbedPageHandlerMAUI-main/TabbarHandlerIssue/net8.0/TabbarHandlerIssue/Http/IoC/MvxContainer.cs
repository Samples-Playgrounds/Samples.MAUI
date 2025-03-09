using System;
using MvvmCross;
using MvvmCross.IoC;

namespace TabbarHandlerIssue.Http.IoC
{
    public class MvxContainer : IContainer
    {
        public MvxContainer()
        {
            MvxIoCProvider.Initialize();
        }

        void IContainer.Register<TInterface, TType>()
        {
            Register<TInterface, TType>(false);
        }

        void IContainer.RegisterAsSingleton<TInterface, TType>()
        {
            Register<TInterface, TType>(true);
        }

        public void RegisterAsSingleton<TInterface>(Func<TInterface> serviceConstructor) where TInterface : class
        {
            Mvx.IoCProvider.RegisterSingleton(serviceConstructor);
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return Mvx.IoCProvider.Resolve<TInterface>();
        }

        public TType Construct<TType>() where TType : class
        {
            return Mvx.IoCProvider.IoCConstruct<TType>();
        }

        void Register<TInterface, TType>(bool singleton = true)
          where TInterface : class
          where TType : class, TInterface
        {
            if (singleton)
            {
                Mvx.IoCProvider.LazyConstructAndRegisterSingleton<TInterface, TType>();
            }
            else
            {
                Mvx.IoCProvider.RegisterType<TInterface>();
            }
        }
    }
}


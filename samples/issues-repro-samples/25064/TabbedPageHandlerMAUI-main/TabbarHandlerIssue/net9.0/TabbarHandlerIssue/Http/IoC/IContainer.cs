using System;
using System.Xml.Linq;

namespace TabbarHandlerIssue.Http.IoC
{
    public interface IContainer
    {
        void RegisterAsSingleton<TInterface, TType>()
          where TInterface : class
          where TType : class, TInterface;

        void Register<TInterface, TType>()
          where TInterface : class
          where TType : class, TInterface;

        void RegisterAsSingleton<TInterface>(Func<TInterface> serviceConstructor)
          where TInterface : class;

        TInterface Resolve<TInterface>() where TInterface : class;

        TType Construct<TType>() where TType : class;
    }

    public static class Container
    {
        static readonly Lazy<IContainer> sInstance = new Lazy<IContainer>(
          () => new MvxContainer(),
          System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static IContainer Current => sInstance.Value;
    }
}



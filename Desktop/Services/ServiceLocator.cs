using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Desktop.Services
{
    internal class ServiceLocator : IServiceLocator
    {
        // map that contains pairs of interfaces and
        // references to concrete implementations

        private static ServiceLocator _instance;

        internal static ServiceLocator Instance
        {
            get
            {
                if (_instance == null) _instance = new ServiceLocator();
                return _instance;
            }
        }

        private IDictionary<object, object> services;

        private ServiceLocator()
        {
            services = new Dictionary<object, object>();

            services.Add(typeof(IObservable<Page>), null);
            services.Add(typeof(INavigationService, new NavigationService());
        }

        public T GetService<T>()
        {
            try
            {
                return (T)services[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }
    }
}

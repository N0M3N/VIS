using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Desktop.Services;
using System;
using System.Reactive.Subjects;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            base.OnStartup(e);
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder
                .RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(Subject<>))
                .As(typeof(IObservable<>))
                .As(typeof(IObserver<>))
                .SingleInstance();
        }
    }
}

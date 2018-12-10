using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Desktop.Attributes;
using Desktop.Connector;
using Desktop.Services;
using System;
using System.Linq;
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

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            RegisterServices(builder);
            RegisterViewModels(builder);
            RegisterMessages(builder);
            RegisterConnectors(builder);

            container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
            base.OnStartup(e);
        }
        
        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
        }

        private void RegisterConnectors(ContainerBuilder builder)
        {
            builder.RegisterType<ZakazkyConnector>()
                .As<IZakazkyConnector>()
                .InstancePerDependency();
            builder.RegisterType<UzivatelConnector>()
                .As<IUzivatelConnector>()
                .InstancePerDependency();
            builder.RegisterType<StavebniDenikConnector>()
                .As<IStavebniDenikConnector>()
                .InstancePerDependency();
            builder.RegisterType<KalkulaceConnector>()
                .As<IKalkulaceConnector>()
                .InstancePerDependency();
        }

        private void RegisterMessages(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentDataSingleton>()
                .As<CurrentDataSingleton>()
                .SingleInstance();
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

            builder.RegisterType<XmlExportService>()
                .As<IFileExportService>()
                .InstancePerDependency();
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            var viewModels = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes()
                .Where(type => Attribute.IsDefined(type, typeof(ViewModelAttribute))));

            foreach (var viewModel in viewModels)
            {
                var registration = builder.RegisterType(viewModel).AsSelf().PropertiesAutowired();

                var attribute = (ViewModelAttribute)Attribute.GetCustomAttribute(viewModel, typeof(ViewModelAttribute));
                switch (attribute.Scope)
                {
                    case ViewModelAttribute.ScopeType.SingleInstance:
                        registration.SingleInstance();
                        break;
                    case ViewModelAttribute.ScopeType.InstancePerDependency:
                        registration.InstancePerDependency();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(attribute.Scope), @"Unsupported scope");
                }
            }
        }
    }
}

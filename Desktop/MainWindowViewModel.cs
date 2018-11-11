using Desktop.Attributes;
using Desktop.Extensions;
using Desktop.Pages.DetailZakazky;
using Desktop.Services;
using Models;
using Reactive.Bindings;
using System;
using System.Windows.Controls;

namespace Desktop
{
    [ViewModel(Scope = ViewModelAttribute.ScopeType.SingleInstance)]
    public class MainWindowViewModel : IDisposable
    {
        private readonly INavigationService navigation;

        public ReactiveProperty<UzivatelModel> CurrentUser { get; }
        public ReactiveProperty<MenuSelectionEnum> MenuSelection { get; }
        public ReactiveCommand<Type> NavigationCommand { get; }

        public MainWindowViewModel(INavigationService navigation)
        {
            CurrentUser = new ReactiveProperty<UzivatelModel>();
            MenuSelection = new ReactiveProperty<MenuSelectionEnum>(MenuSelectionEnum.None);
            NavigationCommand = ReactiveCommandHelper.Create<Type>(Navigate);
            this.navigation = navigation;
        }

        private void Navigate(Type type)
        {
            var obj = Activator.CreateInstance(type);
            if (obj is Page page)
            {
                navigation.Navigate(page);
            }
        }

        public void Dispose()
        {
            CurrentUser.Dispose();
            MenuSelection.Dispose();
            NavigationCommand.Dispose();
        }
    }

    public enum MenuSelectionEnum
    {
        None,
        Detail,
        Denik,
        Kalkulace
    }
}

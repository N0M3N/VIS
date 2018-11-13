using Desktop.Attributes;
using Desktop.Utils;
using Desktop.Messages;
using Desktop.Pages.ListZakazek;
using Desktop.Services;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop
{
    [ViewModel(Scope = ViewModelAttribute.ScopeType.SingleInstance)]
    internal class MainWindowViewModel : IDisposable
    {
        private readonly INavigationService navigation;
        private readonly NavigateWithZakazkaMessage message;

        public ReactiveProperty<UzivatelModel> CurrentUser { get; }
        public ReactiveProperty<MenuSelectionEnum> MenuSelection { get; }
        public ReactiveCommand<Type> NavigationCommand { get; }

        public MainWindowViewModel(INavigationService navigation, NavigateWithZakazkaMessage message)
        {
            CurrentUser = new ReactiveProperty<UzivatelModel>();
            MenuSelection = new ReactiveProperty<MenuSelectionEnum>(MenuSelectionEnum.None);
            NavigationCommand = ReactiveCommandHelper.Create<Type>(Navigate);
            this.navigation = navigation;
            this.message = message;
        }

        private void Navigate(Type type)
        {
            var obj = Activator.CreateInstance(type);
            message.PageType = type;
            navigation.Navigate(new ListZakazekView());
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

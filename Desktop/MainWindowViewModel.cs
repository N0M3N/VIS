using Desktop.Attributes;
using Desktop.Utils;
using Desktop.Pages.ListZakazek;
using Desktop.Services;
using Reactive.Bindings;
using System;

namespace Desktop
{
    [ViewModel(Scope = ViewModelAttribute.ScopeType.SingleInstance)]
    internal class MainWindowViewModel : IDisposable
    {
        private readonly INavigationService navigation;

        public CurrentDataSingleton CurrentData { get; }
        public ReactiveProperty<MenuSelectionEnum> MenuSelection { get; }
        public ReactiveCommand<Type> NavigationCommand { get; }

        public MainWindowViewModel(INavigationService navigation, CurrentDataSingleton currentData)
        {
            CurrentData = currentData;
            MenuSelection = new ReactiveProperty<MenuSelectionEnum>(MenuSelectionEnum.None);
            NavigationCommand = ReactiveCommandHelper.Create<Type>(Navigate);

            this.navigation = navigation;
        }

        private void Navigate(Type type)
        {
            CurrentData.PageType = type;
            navigation.Navigate(new ListZakazekView());
        }

        public void Dispose()
        {
            CurrentData.Dispose();
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

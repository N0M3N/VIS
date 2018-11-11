using Desktop.Attributes;
using Models;
using Reactive.Bindings;
using System;

namespace Desktop
{
    [ViewModel(Scope = ViewModelAttribute.ScopeType.SingleInstance)]
    public class MainWindowViewModel : IDisposable
    {
        public ReactiveProperty<UzivatelModel> CurrentUser { get; }
        public ReactiveProperty<MenuSelectionEnum> MenuSelection { get; }

        public MainWindowViewModel()
        {
            CurrentUser = new ReactiveProperty<UzivatelModel>();
            MenuSelection = new ReactiveProperty<MenuSelectionEnum>(MenuSelectionEnum.None);
        }

        public void Dispose()
        {
            CurrentUser.Dispose();
            MenuSelection.Dispose();
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

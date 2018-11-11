using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Desktop.Services
{
    public interface INavigationService
    {
        IEnumerable<Type> History { get; }

        void Navigate(Page page);
        void NavigateWithAction(Page page, Action action);

        bool CanGoBackward();
        void GoBackward();

        bool CanGoForward();
        void GoForward();
    }
}

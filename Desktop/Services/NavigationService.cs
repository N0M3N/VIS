using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Desktop.Services
{

    public class NavigationService : INavigationService
    {
        private readonly IObserver<Page> navigation;
        private readonly Stack<TypeWithAction> undo;
        private readonly Stack<TypeWithAction> redo;

        public IEnumerable<Type> History => undo
            .Reverse()
            .Select(x => x.Type)
            .Concat(redo.Select(x => x.Type));

        public NavigationService(IObserver<Page> navigation)
        {
            this.navigation = navigation;
            undo = new Stack<TypeWithAction>();
            redo = new Stack<TypeWithAction>();
        }

        public void Navigate(Page page)
        {
            NavigateWithAction(page, () => { });
        }

        public void NavigateWithAction(Page page, Action action)
        {
            navigation.OnNext(page);
            action();

            redo.Clear();
            undo.Push(new TypeWithAction { Type = page.GetType(), Action = action });
        }

        public bool CanGoBackward() => undo.Count > 0;

        public void GoBackward()
        {
            var page = undo.Pop();
            redo.Push(page);

            var currentPage = undo.Peek();
            navigation.OnNext((Page)Activator.CreateInstance(currentPage.Type));

            currentPage.Action();
        }

        public bool CanGoForward() => redo.Count > 0;

        public void GoForward()
        {
            var page = redo.Pop();
            undo.Push(page);

            navigation.OnNext((Page)Activator.CreateInstance(page.Type));

            page.Action();
        }

        private class TypeWithAction
        {
            public Type Type { get; set; }
            public Action Action { get; set; }
        }

    }
}

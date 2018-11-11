using Reactive.Bindings;
using System;

namespace Desktop.Extensions
{
    public static class ReactiveCommandHelper
    {
        public static ReactiveCommand Create(Action action)
        {
            var command = new ReactiveCommand();
            command.Subscribe(action);
            return command;
        }

        public static ReactiveCommand Create(Action action, IObservable<bool> canExecute)
        {
            var command = new ReactiveCommand(canExecute);
            command.Subscribe(action);
            return command;
        }

        public static ReactiveCommand<T> Create<T>(Action<T> action)
        {
            var command = new ReactiveCommand<T>();
            command.Subscribe(action);
            return command;
        }

        public static ReactiveCommand<T> Create<T>(Action<T> action, IObservable<bool> canExecute)
        {
            var command = new ReactiveCommand<T>(canExecute);
            command.Subscribe(action);
            return command;
        }
    }
}

using Desktop.Attributes;
using Desktop.Utils;
using Reactive.Bindings;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.Pages.Logger
{
    [ViewModel]
    internal class LoggerViewModel : IDisposable
    {
        public ReactiveCollection<LogMessage> Messages { get; }
        private IDisposable Observer;

        public LoggerViewModel(IObservable<LogMessage> observable)
        {
            Messages = new ReactiveCollection<LogMessage>();
            Observer = observable.Subscribe(AddMessage);
        }

        private void AddMessage(LogMessage message)
        {
            Messages.Add(message);
            ShowFor(3000, message);
        }

        private Task ShowFor(int v, LogMessage message)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(v);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Messages.Remove(message);
                });
            });
        }

        public void Dispose()
        {
            Messages.Dispose();
            Observer.Dispose();
        }
    }
}

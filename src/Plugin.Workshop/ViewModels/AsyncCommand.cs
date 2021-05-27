// based on: https://docs.microsoft.com/en-us/archive/msdn-magazine/2014/april/async-programming-patterns-for-asynchronous-mvvm-applications-commands

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Plugin.Workshop.ViewModels
{
    public class AsyncCommand : AsyncCommandBase, INotifyPropertyChanged
    {
        private readonly Func<CancellationToken, Task> _command;
        private readonly CancelAsyncCommand _cancelCommand;

        public AsyncCommand(Func<CancellationToken, Task> command)
        {
            _command = command;
            _cancelCommand = new CancelAsyncCommand();
            CancelCommand = _cancelCommand;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        private async Task<bool> CreateCommand(CancellationToken token)
        {
            await _command(token);
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _cancelCommand.NotifyCommandStarting();
            Execution = new NotifyTaskCompletion<bool>(CreateCommand(_cancelCommand.Token));
            OnPropertyChanged(nameof(Execution));
            RaiseCanExecuteChanged();
            await Execution.TaskCompletion;
            _cancelCommand.NotifyCommandFinished();
            RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private sealed class CancelAsyncCommand : ICommand
        {
            private CancellationTokenSource _cts = new CancellationTokenSource();
            private bool _commandExecuting;
            public CancellationToken Token => _cts.Token;

            public void NotifyCommandStarting()
            {
                _commandExecuting = true;
                if (!_cts.IsCancellationRequested)
                {
                    return;
                }

                _cts = new CancellationTokenSource();
                RaiseCanExecuteChanged();
            }

            public void NotifyCommandFinished()
            {
                _commandExecuting = false;
                RaiseCanExecuteChanged();
            }

            bool ICommand.CanExecute(object parameter)
            {
                return _commandExecuting && !_cts.IsCancellationRequested;
            }

            void ICommand.Execute(object parameter)
            {
                _cts.Cancel();
                RaiseCanExecuteChanged();
            }

            event EventHandler ICommand.CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }

            // ReSharper disable once MemberHidesStaticFromOuterClass
            private static void RaiseCanExecuteChanged()
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}

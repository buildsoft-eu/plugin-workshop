// based on: https://docs.microsoft.com/en-us/archive/msdn-magazine/2014/april/async-programming-patterns-for-asynchronous-mvvm-applications-commands
using System.Threading.Tasks;
using System.Windows.Input;

namespace Plugin.Workshop.ViewModels
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
        NotifyTaskCompletion<bool> Execution { get; }
        ICommand CancelCommand { get; }
    }
}

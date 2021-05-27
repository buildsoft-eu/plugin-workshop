using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Plugin.Example.ViewModels;
using Plugin.Example.Views;

namespace Plugin.Example
{
    public static class Extension
    {
        public static ButtonAwaiter GetAwaiter(this Button button)
        {
            return new() { Button = button };
        }

        public static ConflictsSolvedAwaiter<T> GetAwaiter<T>(
            this ObservableCollection<T> collection)
        where T : IConflictViewModel
        {
            return new() { Conflicts = collection };
        }

        private static Task WithCancellation(
            this Task task,
            CancellationToken token)
        {
            return task
                .ContinueWith(t => t.GetAwaiter().GetResult(), token);
        }

        public static async Task TryCatchCancellationAsync(
            this Task task,
            CancellationToken token,
            Action onCancelled)
        {
            try
            {
                await task.WithCancellation(token);
            }
            catch (TaskCanceledException)
            {
                onCancelled();
                token.ThrowIfCancellationRequested();
            }
        }
    }
}

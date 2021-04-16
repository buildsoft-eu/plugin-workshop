using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Plugin.Example.Views
{
    public class ButtonAwaiter : INotifyCompletion
    {
        public bool IsCompleted => false;

        public void GetResult()
        {
        }

        public Button Button { get; set; }

        public void OnCompleted(Action continuation)
        {
            void RoutedEventHandler(object o, RoutedEventArgs e)
            {
                Button.Click -= RoutedEventHandler;
                continuation();
            }

            Button.Click += RoutedEventHandler;
        }
    }
}

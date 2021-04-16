using System.Windows;

namespace Plugin.Example.Views
{
    public class BindingProxy<T> : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy<T>();
        }

        public T DataContext
        {
            get => (T)GetValue(DataContextProperty);
            set => SetValue(DataContextProperty, value);
        }

        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register(
                nameof(DataContext),
                typeof(T),
                typeof(BindingProxy<T>),
                new UIPropertyMetadata(null));
    }
}

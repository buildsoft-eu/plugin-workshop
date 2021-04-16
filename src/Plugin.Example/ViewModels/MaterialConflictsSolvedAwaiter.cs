using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictsSolvedAwaiter : INotifyCompletion
    {
        public bool IsCompleted => false;

        public void GetResult()
        {
        }

        public ObservableCollection<MaterialConflictViewModel> Conflicts { get; set; }


        private Action _continuation;

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
            foreach (var item in Conflicts)
            {
                item.PropertyChanged += ItemOnPropertyChanged;

            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "MappedTo")
            {
                return;
            }

            if (HasUnmappedItems())
            {
                return;
            }

            foreach (var item in Conflicts)
            {
                item.PropertyChanged -= ItemOnPropertyChanged;
            }

            _continuation();
        }

        private bool HasUnmappedItems()
        {
            return Conflicts.Any(c => c.MappedTo == null);
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public abstract class ConflictViewModelBase<T> : IConflictViewModel
    {
        protected ConflictViewModelBase(Conflict<T> data)
        {
            Data = data;
        }

        public Conflict<T> Data { get; }

        public abstract string Name { get; }

        public string Type =>
            Data.ConflictType switch
            {
                ConflictType.Resolved => Localization.Conflicts.Resolved,
                ConflictType.MissingMapping => Localization.Conflicts.MissingMapping,
                ConflictType.Unknown => Localization.Conflicts.Unknown,
                _ => throw new ArgumentOutOfRangeException()
            };

        private UbsmMappingViewModel _mappedTo;
        public UbsmMappingViewModel MappedTo
        {
            get => _mappedTo;
            set
            {
                _mappedTo = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

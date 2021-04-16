using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Example.Models;

namespace Plugin.Example.ViewModels
{
    public class MaterialConflictViewModel : INotifyPropertyChanged
    {
        public MaterialConflict Data { get; }

        public MaterialConflictViewModel(MaterialConflict data)
        {
            Data = data;
        }

        public string Name => Data.ApiMaterial.Name;

        public string Type =>
            Data.ConflictType switch
            {
                ConflictType.Resolved => Localization.MaterialConflicts.Resolved,
                ConflictType.MissingMapping => Localization.MaterialConflicts.MissingMapping,
                ConflictType.Unknown => Localization.MaterialConflicts.Unknown,
                _ => throw new ArgumentOutOfRangeException()
            };

        private UbsmMaterialViewModel _mappedTo;
        public UbsmMaterialViewModel MappedTo
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

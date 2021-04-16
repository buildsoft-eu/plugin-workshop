using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Example.Models;
using Material = Example.API.Material;

namespace Plugin.Example.Services
{
    public class MaterialConflictResolver : IMaterialConflictResolver
    {
        private readonly Action<IEnumerable<MaterialConflict>> _setConflicts;
        private readonly Func<Task> _waitForContinuationEnabled;
        private readonly Func<Task> _waitForConflictResolutionCompletion;
        private readonly Func<IEnumerable<MaterialMapping>> _getMapping;

        public MaterialConflictResolver(
            Action<IEnumerable<MaterialConflict>> setConflicts,
            Func<Task> waitForContinuationEnabled,
            Func<Task> waitForConflictResolutionCompletion,
            Func<IEnumerable<MaterialMapping>> getMapping)
        {
            _setConflicts = setConflicts;
            _waitForConflictResolutionCompletion = waitForConflictResolutionCompletion;
            _getMapping = getMapping;
            _waitForContinuationEnabled = waitForContinuationEnabled;
        }

        public Task<IEnumerable<MaterialConflict>> DetermineConflictsAsync()
        {
            return Task.FromResult<IEnumerable<MaterialConflict>>(
                new[]
                {
                    new MaterialConflict
                    {
                        ConflictType = ConflictType.MissingMapping,
                        ApiMaterial = new Material{ Name = "Test Material 1" },
                        UbsmMaterial = null
                    },
                    new MaterialConflict
                    {
                        ConflictType = ConflictType.MissingMapping,
                        ApiMaterial = new Material{ Name = "Alpha test material 2" },
                        UbsmMaterial = null
                    }
                });
        }

        public async Task<IEnumerable<MaterialMapping>> ResolveConflictsAsync(
            IEnumerable<MaterialConflict> conflicts)
        {
            _setConflicts(conflicts);
            await _waitForContinuationEnabled();
            await _waitForConflictResolutionCompletion();
            return _getMapping();
        }
    }
}

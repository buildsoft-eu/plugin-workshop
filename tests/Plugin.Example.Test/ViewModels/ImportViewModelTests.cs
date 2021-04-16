using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Plugin.Example.Models;
using Plugin.Example.Services;
using Plugin.Example.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace Plugin.Example.Test.ViewModels
{
    public class ImportViewModelTests
    {
        private readonly ITestOutputHelper _output;

        public ImportViewModelTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private Mock<IMaterialConflictResolver> CreateMaterialConflictResolverMock(
            IEnumerable<MaterialConflict> determinedConflicts,
            IEnumerable<MaterialMapping> resolvedConflicts)
        {
            var mock = new Mock<IMaterialConflictResolver>(MockBehavior.Strict);
            mock
                .Setup(x => x.DetermineConflictsAsync())
                .ReturnsAsync(determinedConflicts);
            mock
                .Setup(x => x.ResolveConflictsAsync(It.IsAny<IEnumerable<MaterialConflict>>()))
                .ReturnsAsync(resolvedConflicts);
            return mock;
        }

        [Fact]
        public async Task Given_NoConflicts_When_ProcessMaterialsAsync_Then_DetermineCalledOnceAndResolveCalledNever()
        {
            // Arrange
            var mock = CreateMaterialConflictResolverMock(
                Enumerable.Empty<MaterialConflict>(),
                Enumerable.Empty<MaterialMapping>());
            var sut = new ImportViewModel
            {
                MaterialConflictResolver = mock.Object
            };

            // Act
            await sut.GetMaterialMappingAsync(CancellationToken.None);

            // Assert
            mock.Verify(
                x => x.DetermineConflictsAsync(),
                Times.Once);
            mock.Verify(
                x => x.ResolveConflictsAsync(It.IsAny<IEnumerable<MaterialConflict>>()),
                Times.Never);
        }

        [Fact]
        public async Task Given_OneConflict_When_ProcessMaterialsAsync_Then_DetermineCalledOnceAndResolveCalledOnce()
        {
            // Arrange
            var conflicts = new[] { new MaterialConflict() };
            var results = Enumerable.Empty<MaterialMapping>();
            var mock = CreateMaterialConflictResolverMock(conflicts, results);
            var sut = new ImportViewModel
            {
                MaterialConflictResolver = mock.Object
            };

            // Act
            await sut.GetMaterialMappingAsync(CancellationToken.None);

            // Assert
            mock.Verify(
                x => x.DetermineConflictsAsync(),
                Times.Once);
            mock.Verify(
                x => x.ResolveConflictsAsync(It.IsAny<IEnumerable<MaterialConflict>>()),
                Times.Once);
        }
    }
}

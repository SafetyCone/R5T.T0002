using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.D0029;


namespace R5T.T0002
{
    public static class IVisualStudioProjectFileExtensions
    {
        public static List<string> GetDependencyProjectFilePaths(this IVisualStudioProjectFile visualStudioProjectFile)
        {
            var dependencyProjectFilePaths = visualStudioProjectFile.ProjectReferences
                .Select(x => x.ProjectFilePath)
                .ToList();

            return dependencyProjectFilePaths;
        }

        public static async Task<List<string>> GetDependencyProjectFilePathsRecursive(this IVisualStudioProjectFile visualStudioProjectFile, IVisualStudioProjectFileSerializer visualStudioProjectFileSerializer)
        {
            var pathAccumulator = new HashSet<string>();

            await visualStudioProjectFile.AccumulateDependencyProjectFilePathsRecursive(visualStudioProjectFileSerializer, pathAccumulator);

            var dependencyProjectFilePaths = pathAccumulator
                .OrderBy(x => x)
                .ToList();

            return dependencyProjectFilePaths;
        }

        private static async Task AccumulateDependencyProjectFilePathsRecursive(this IVisualStudioProjectFile visualStudioProjectFile, IVisualStudioProjectFileSerializer visualStudioProjectFileSerializer, HashSet<string> pathAccumulator)
        {
            var dependencyProjectFilePaths = visualStudioProjectFile.GetDependencyProjectFilePaths();

            foreach (var projectFilePath in dependencyProjectFilePaths)
            {
                // Avoid deserializing the same project file multiple times by testing whether the project file has been visited or not.
                if (!pathAccumulator.Contains(projectFilePath))
                {
                    pathAccumulator.Add(projectFilePath);

                    var projectFile = await visualStudioProjectFileSerializer.DeserializeAsync(projectFilePath);

                    await projectFile.AccumulateDependencyProjectFilePathsRecursive(visualStudioProjectFileSerializer, pathAccumulator);
                }
            }
        }
    }
}

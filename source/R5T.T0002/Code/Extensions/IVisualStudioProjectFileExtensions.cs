using System;
using System.Linq;


namespace R5T.T0002
{
    public static class IVisualStudioProjectFileExtensions
    {
        public static IPackageReference GetPackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name, string versionString)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, versionString, out var packageReference);
            if(!hasPackageReference)
            {
                throw new InvalidOperationException($"Project file does not have package reference:\nName: {name}, Version: {versionString}.");
            }

            return packageReference;
        }

        public static IProjectReference GetProjectReference(this IVisualStudioProjectFile visualStudioProjectFile, string projectFilePath)
        {
            var hasProjectReference = visualStudioProjectFile.HasProjectReference(projectFilePath, out var projectReference);
            if(!hasProjectReference)
            {
                throw new InvalidOperationException($"Project file does not have project reference:\n${projectFilePath}.");
            }

            return projectReference;
        }

        public static bool HasPackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name, string versionString)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, versionString, out _);
            return hasPackageReference;
        }

        public static bool HasProjectReference(this IVisualStudioProjectFile visualStudioProjectFile, string projectFilePath)
        {
            var hasProjectReference = visualStudioProjectFile.HasProjectReference(projectFilePath, out _);
            return hasProjectReference;
        }

        public static bool RemovePackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name, string versionString)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, versionString, out var packageReference);
            if (!hasPackageReference)
            {
                return false;
            }

            visualStudioProjectFile.RemovePackageReference(packageReference);

            return true;
        }

        public static bool RemoveProjectReference(this IVisualStudioProjectFile visualStudioProjectFile, string projectFilePath)
        {
            var hasProjectReference = visualStudioProjectFile.HasProjectReference(projectFilePath, out var projectReference);
            if(!hasProjectReference)
            {
                return false;
            }

            visualStudioProjectFile.RemoveProjectReference(projectReference);

            return true;
        }
    }
}

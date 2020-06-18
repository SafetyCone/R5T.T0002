using System;
using System.Linq;


namespace R5T.T0002
{
    public static class IVisualStudioProjectFileExtensions
    {
        /// <summary>
        /// Method name indicates that we clone the package reference, instead of adding the actual instance.
        /// </summary>
        public static void AddNewPackageReferenceFrom(this IVisualStudioProjectFile visualStudioProjectFile, IPackageReference packageReference)
        {
            visualStudioProjectFile.AddPackageReference(packageReference.Name, packageReference.VersionString);
        }

        /// <summary>
        /// Method name indicates that we clone the project reference, instead of adding the actual instance.
        /// </summary>
        public static void AddNewProjectReferenceFrom(this IVisualStudioProjectFile visualStudioProjectFile, IProjectReference projectReference)
        {
            visualStudioProjectFile.AddProjectReference(projectReference.ProjectFilePath);
        }

        public static void ClearPackageReferences(this IVisualStudioProjectFile visualStudioProjectFile)
        {
            var packageReferences = visualStudioProjectFile.PackageReferences.ToList();
            foreach (var packageReference in packageReferences)
            {
                visualStudioProjectFile.RemovePackageReference(packageReference);
            }
        }

        public static void ClearProjectReferences(this IVisualStudioProjectFile visualStudioProjectFile)
        {
            var projectReferences = visualStudioProjectFile.ProjectReferences.ToList();
            foreach (var projectReference in projectReferences)
            {
                visualStudioProjectFile.RemoveProjectReference(projectReference);
            }
        }

        public static void ClonePackageReferencesFrom(this IVisualStudioProjectFile visualStudioProjectFile, IVisualStudioProjectFile source)
        {
            visualStudioProjectFile.ClearPackageReferences();

            var packageReferences = source.PackageReferences.ToList();
            foreach (var packageReference in packageReferences)
            {
                visualStudioProjectFile.AddNewPackageReferenceFrom(packageReference);
            }
        }

        public static void CloneProjectReferencesFrom(this IVisualStudioProjectFile visualStudioProjectFile, IVisualStudioProjectFile source)
        {
            visualStudioProjectFile.ClearProjectReferences();

            var projectReferences = source.ProjectReferences.ToList();
            foreach(var projectReference in projectReferences)
            {
                visualStudioProjectFile.AddNewProjectReferenceFrom(projectReference);
            }
        }

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

        public static bool HasPackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name, string versionString, out IPackageReference packageReference)
        {
            var hasPackageReferenceByName = visualStudioProjectFile.HasPackageReference(name, out packageReference);
            if(!hasPackageReferenceByName)
            {
                return false;
            }

            var versionStringMatches = packageReference.VersionString == versionString;
            if(versionStringMatches)
            {
                return true;
            }
            else
            {
                packageReference = PackageReferenceHelper.None;

                return false;
            }
        }

        public static bool HasPackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name, string versionString)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, versionString, out _);
            return hasPackageReference;
        }

        public static bool HasPackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, out _);
            return hasPackageReference;
        }

        public static bool HasProjectReference(this IVisualStudioProjectFile visualStudioProjectFile, string projectFilePath)
        {
            var hasProjectReference = visualStudioProjectFile.HasProjectReference(projectFilePath, out _);
            return hasProjectReference;
        }

        public static bool RemovePackageReference(this IVisualStudioProjectFile visualStudioProjectFile, string name)
        {
            var hasPackageReference = visualStudioProjectFile.HasPackageReference(name, out var packageReference);
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

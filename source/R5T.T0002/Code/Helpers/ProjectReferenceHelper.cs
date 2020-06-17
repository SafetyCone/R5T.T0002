using System;


namespace R5T.T0002
{
    public static class ProjectReferenceHelper
    {
        public const IProjectReference None = null;


        public static bool IsNone(IProjectReference projectReference)
        {
            var isNone = projectReference == ProjectReferenceHelper.None;
            return isNone;
        }

        public static bool WasFound(IProjectReference projectReference)
        {
            var wasFound = projectReference != ProjectReferenceHelper.None;
            return wasFound;
        }
    }
}

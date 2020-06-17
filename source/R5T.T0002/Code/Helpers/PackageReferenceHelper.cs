using System;


namespace R5T.T0002
{
    public static class PackageReferenceHelper
    {
        public const IPackageReference None = null;


        public static bool IsNone(IPackageReference packageReference)
        {
            var isNone = packageReference == PackageReferenceHelper.None;
            return isNone;
        }

        public static bool WasFound(IPackageReference packageReference)
        {
            var wasFound = packageReference != PackageReferenceHelper.None;
            return wasFound;
        }
    }
}

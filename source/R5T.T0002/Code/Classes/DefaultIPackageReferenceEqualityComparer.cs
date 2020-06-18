using System;
using System.Collections.Generic;


namespace R5T.T0002
{
    public class DefaultIPackageReferenceEqualityComparer : IEqualityComparer<IPackageReference>
    {
        public static readonly DefaultIPackageReferenceEqualityComparer Instance = new DefaultIPackageReferenceEqualityComparer();


        public bool Equals(IPackageReference x, IPackageReference y)
        {
            var areEqual = true;

            var nameEquals = x.Name == y.Name;
            areEqual &= nameEquals;

            var versionStringEquals = x.VersionString == y.VersionString;
            areEqual &= versionStringEquals;

            return areEqual;
        }

        public int GetHashCode(IPackageReference obj)
        {
            var hashCode = obj.Name.GetHashCode();
            return hashCode;
        }
    }
}

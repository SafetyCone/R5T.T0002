using System;
using System.Collections.Generic;


namespace R5T.T0002
{
    public class DefaultProjectReferenceEqualityComparer : IEqualityComparer<IProjectReference>
    {
        public static readonly DefaultProjectReferenceEqualityComparer Instance = new DefaultProjectReferenceEqualityComparer();


        public bool Equals(IProjectReference x, IProjectReference y)
        {
            var areEqual = true;

            var projectFilePathAreEqual = x.ProjectFilePath == y.ProjectFilePath;
            areEqual &= projectFilePathAreEqual;

            return areEqual;
        }

        public int GetHashCode(IProjectReference obj)
        {
            var hashCode = obj.ProjectFilePath.GetHashCode();
            return hashCode;
        }
    }
}

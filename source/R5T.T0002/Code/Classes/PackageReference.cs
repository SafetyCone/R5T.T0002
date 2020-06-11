using System;


namespace R5T.T0002
{
    public class PackageReference
    {
        public string Name { get; set; }
        // NOT a Version since packages can have version ranges, and/or suffixes ("-rc", "-beta1").
        public string VersionString { get; set; }


        public PackageReference()
        {
        }

        public PackageReference(string name, string versionString)
        {
            this.Name = name;
            this.VersionString = versionString;
        }
    }
}

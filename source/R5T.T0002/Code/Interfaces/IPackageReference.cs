using System;


namespace R5T.T0002
{
    public interface IPackageReference
    {
        string Name { get; set; }
        // NOT a Version since packages can have version ranges, and/or suffixes ("-rc", "-beta1").
        string VersionString { get; set; }
    }
}

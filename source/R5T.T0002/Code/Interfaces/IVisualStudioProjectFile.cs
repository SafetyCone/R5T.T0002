using System;
using System.Collections.Generic;

using R5T.T0003;

using R5T.Ostersund;


namespace R5T.T0002.Abstractions
{
    public interface IVisualStudioProjectFile
    {
        Settable<string> SDK { get; set; }

        Settable<bool> GenerateDocumentationFile { get; set; }
        Settable<bool> IsPackable { get; set; }
        Settable<Version> LanguageVersion { get; set; }
        Settable<List<int>> NoWarn { get; set; }
        Settable<OutputType> OutputType { get; set; }
        Settable<TargetFramework> TargetFramework { get; set; }

        IList<ProjectReference> ProjectReferences { get; }
        IList<PackageReference> PackageReferences { get; }
    }
}

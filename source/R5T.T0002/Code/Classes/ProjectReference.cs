using System;


namespace R5T.T0002
{
    public class ProjectReference : IProjectReference
    {
        public string ProjectFilePath { get; set; }


        public ProjectReference()
        {
        }

        public ProjectReference(string projectFilePath)
        {
            this.ProjectFilePath = projectFilePath;
        }
    }
}

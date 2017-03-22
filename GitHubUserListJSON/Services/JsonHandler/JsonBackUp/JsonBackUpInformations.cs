using System;
using System.IO;

namespace GitHubUserListJSON.Services.JsonHandler.JsonBackUp
{
   public abstract class JsonBackUpInformations
    {
        protected string JsonBackUpDirectory { get; set; }

        public JsonBackUpInformations()
        {
            JsonBackUpDirectory = BackUpDirectoryGenerator();
        }
        protected virtual string BackUpDirectoryGenerator()
        {
            string actualpath = Environment.CurrentDirectory;
            string directory = Path.Combine(actualpath, "lastJSON.json");
            return directory;
        }
    }
}

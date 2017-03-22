using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GitHubUserListJSON.Services.JsonHandler.JsonBackUp;

namespace GitHubUserListJSON.Services.JsonHandler.JsonBackUpCreator
{
    class CreateJsonBackUp: JsonBackUpInformations
    {
        public CreateJsonBackUp(string deserializedJson)
        {
            SaveJsonFile(deserializedJson);
        }
        private void SaveJsonFile(string jsonString)
        {
            File.WriteAllText(JsonBackUpDirectory, jsonString);
        }


    }
}

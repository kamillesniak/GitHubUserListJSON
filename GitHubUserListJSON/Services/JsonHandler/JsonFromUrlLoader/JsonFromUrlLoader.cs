using GitHubUserListJSON.Services.JsonHandler.JsonBackUp.JsonBackUpLoader;
using GitHubUserListJSON.Services.JsonHandler.JsonBackUpCreator;
using System;
using System.Net;


namespace GitHubUserListJSON.Services.JsonHandler.Interfaces
{
    class JsonFromUrlLoader : JsonData, IJsonFromUrlLoader
    {
        private string JsonUrl { get; set; }

        public JsonFromUrlLoader(string _jsonUrl)
        {
            JsonUrl = _jsonUrl;
        }

        public string LoadJsonFromUrl()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    //This json file need to have header to be downloaded
                    client.Headers.Add("User-Agent", "NoUserAgent");
                     string deserializedJsonFile = client.DownloadString(new Uri(JsonUrl));
                    CreateJsonBackUp(deserializedJsonFile);
                    isConnectedFlag = true;
                    return deserializedJsonFile;
                }
            }
            catch
            {
                ReportMessage.Error("Unable to load json file, check your internet connectionn, using last downloaded data\n");
                deserializedJsonFile =  LoadLastBackUp();
                isConnectedFlag = false;
                return deserializedJsonFile;
            }

        }

        private void CreateJsonBackUp(string json)
        {
            var backUp = new CreateJsonBackUp(json);
        }

        private string LoadLastBackUp()
        {
            var lastBackUp = new JsonLastBackUpLoader();
            return lastBackUp.LastJsonFile;

        }
     

    }
}

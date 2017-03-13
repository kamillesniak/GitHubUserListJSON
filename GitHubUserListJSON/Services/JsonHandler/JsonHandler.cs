using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;


namespace GitHubUserListJSON
{
    class JsonHandler: JsonData
    {
   

        public JsonHandler(string _url)
        {
            //Make Json
            jsonBackUpDirectory = GetJsonBackUpDirectory();
            deserializedJsonFile = JsonFileLoader(_url);
            SaveJsonFile(deserializedJsonFile);
            gitHubUsers = FindGitHubUsers(deserializedJsonFile);

        }
        private string JsonFileLoader(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    //This json file need to have header to be downloaded
                    client.Headers.Add("User-Agent", "NoUserAgent");
                    string clientResponse = client.DownloadString(new Uri(url));
                    SaveJsonFile(clientResponse);
                    return clientResponse;
                }
            }
            catch
            {
                ReportMessage.Error("Unable to load json file, check your internet connectionn, using last downloaded data\n");
                isConnectedFlag = false;
                return LoadLastJson();
            }

        }
        private void SaveJsonFile(string jsonString)
        {
            string directory = GetJsonBackUpDirectory();
            File.WriteAllText(directory, jsonString);
        }

        private IList<User> FindGitHubUsers(string jsonfile)
        {
            JArray gitUsersArray = JArray.Parse(jsonfile);
            IList<User> gitUsersList = gitUsersArray.Select(p => new User
            {
                login = (string)p["login"],
                avatarurl = (string)p["avatar_url"]
            }).ToList();
            return gitUsersList;
        }

        #region Last JSON file
        private string GetJsonBackUpDirectory()
        {
            string actualpath = Environment.CurrentDirectory;
            string directory = Path.Combine(actualpath, "lastJSON.json");
            return directory;
        }
        private string LoadLastJson()
        {
            string directory = GetJsonBackUpDirectory();
            if (File.Exists(directory))
            {
                using (StreamReader r = new StreamReader(directory))
                {
                    string json = r.ReadToEnd();
                    return json;
                }

            }
            else
            {
                MessageBox.Show("No back up json file found, connect to the network");
                Application.Current.Shutdown();
                return null;
            }

        }
        #endregion
    }




        
}

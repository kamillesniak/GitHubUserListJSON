using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Windows.Media.Imaging;
using System.IO;


namespace GitHubUserListJSON
{
    class JSON
    {
        public static string LoadJsonFile(string url)
        {         
                try
                {
                    using (WebClient client = new WebClient())
                    {
                    //This json file need to have header to be downloaded
                        client.Headers.Add("User-Agent", "NoUserAgent");
                        string clientResponse =  client.DownloadString(new Uri(url));
                        SaveJson(clientResponse);
                        return clientResponse;
                    }
                }
                catch 
                {
                    Report.Error("Unable to load json file, check your internet connectionn, using last downloaded data\n");
                    return LoadLastJson();
                }
            
        }
        private static void SaveJson(string jsonString)
        {
            string directory = JsonBackUpDirectory();
            File.WriteAllText(directory, jsonString);
        }
        public static IList<UsersData> ParseJson(string jsonfile)
        {
            JArray gitUsersArray = JArray.Parse(jsonfile);
            IList<UsersData> gitUsersList = gitUsersArray.Select(p => new UsersData
            {
                login = (string)p["login"],
                avatarurl = (string)p["avatar_url"]
            }).ToList();
            return gitUsersList;
        }
        #region Last JSON file
        private static string JsonBackUpDirectory()
        {
            string actualpath = Environment.CurrentDirectory;
            string directory = Path.Combine(actualpath, "lastJSON.json");
            return directory;
        }
        private static string LoadLastJson()
        {
            string directory = JsonBackUpDirectory();
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

        public static string LoadUserAvatarURL(IList<UsersData> iList, string actualLogin)
        {
            string avatarURL = string.Empty;
            var query =
                from item in iList
                where item.login == actualLogin
                select item.avatarurl;
            foreach (var item in query)
            {
                avatarURL = item;
            }
            return avatarURL;
        }

        public static BitmapImage UploadAvatar(string url)
        {
            try
            {
                BitmapImage image = new BitmapImage(new Uri(url));
                return image;
            }
            catch
            {
                Report.Error("Unable to load user avatar");
                return null;
            }
        }

    }
}

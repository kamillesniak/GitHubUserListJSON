using System.IO;
using System.Windows;

namespace GitHubUserListJSON.Services.JsonHandler.JsonBackUp.JsonBackUpLoader
{
    class JsonLastBackUpLoader:JsonBackUpInformations
    {
        public  string LastJsonFile { get; set; }

        public JsonLastBackUpLoader()
        {
            LastJsonFile = LoadLastJson();
        }
        private string LoadLastJson()
        {
            if (File.Exists(JsonBackUpDirectory))
            {
                using (StreamReader r = new StreamReader(JsonBackUpDirectory))
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
    }
}

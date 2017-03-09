using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using Octokit;


namespace GitHubUserListJSON
{
    /// <summary>
    /// 1.Load json file from api.github.com/users
    /// 2.Parse json to get name and avatar url stored in UsersData List
    /// 3. Load avatar and informations about actual user repository  
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<UsersData> gitHubUsers;
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://api.github.com/users";
            var jsonModels = new GitHubJson(url);
            var jsonFile = jsonModels.deserializedJsonFile;
            gitHubUsers = jsonModels.gitHubUsers;
            // LoadLoginComboBox(jsonModels.gitHubUsers);
            LoginComboBox =  LoadValuesToControls.LoadLoginComboBox(LoginComboBox, gitHubUsers);
            ChangeActualData();
        }

        #region GitHubAPI
        //GIT HUB API LIMIT: ONLY 60 queries per hour 
        private async void LoadActualUserRepositoryAsync(string userName)
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));

                IReadOnlyList<Repository> userRepositories = await client.Repository.GetAllForUser(userName);
                // LoadRepoComboBox(userRepositories);
                UserRepositoriesComboBox = LoadValuesToControls.LoadRepositoryComboBox(UserRepositoriesComboBox, userRepositories);

                var user = await client.User.Get(userName);
                string repos = user.PublicRepos.ToString();
                RepositoriesCountLabel.Content = repos;
            }
            catch
            {
                Report.Error("Unable to load github data");
            }
        }
        #endregion
        #region Events
        private void LoginComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ChangeActualData();
        }

        private void ChangeActualData()
        {
            string actualLogin = LoginComboBox.Text;
            AvatarImage.Source = UploadAvatar.UploadUserAvatarFromURL(actualLogin, gitHubUsers);

            LoadActualUserRepositoryAsync(actualLogin);

        }
        #endregion

       
    }
}

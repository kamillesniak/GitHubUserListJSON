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
        private IList<UsersData> githubUsers;
        public MainWindow()
        {
            InitializeComponent();

            string url = @"https://api.github.com/users";

            var jsonFile = JSON.LoadJsonFile(url);
            githubUsers =  JSON.ParseJson(jsonFile);

            LoadLoginComboBox(githubUsers);
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
                LoadRepoComboBox(userRepositories);

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
            string avatarURL = JSON.LoadUserAvatarURL(githubUsers, actualLogin);

            LoadActualUserRepositoryAsync(actualLogin);
            UploadAvatar(avatarURL);

        }
        #endregion

        #region LoadValuesToControls
        private void LoadRepoComboBox(IReadOnlyList<Repository> userRepositories)
        {
            UserRepositoriesComboBox.DataContext = userRepositories;
            UserRepositoriesComboBox.DisplayMemberPath = "Name";
            UserRepositoriesComboBox.ItemsSource = userRepositories;
            UserRepositoriesComboBox.SelectedIndex = 0;

        }
        private void LoadLoginComboBox(IList<UsersData> iList)
        {
            LoginComboBox.DataContext = iList;
            LoginComboBox.DisplayMemberPath = "login";
            LoginComboBox.SelectedIndex = 0;
            LoginComboBox.ItemsSource = iList;

        }
        private void UploadAvatar(string url)
        {
            try
            {
                BitmapImage image = JSON.UploadAvatar(url);
                AvatarImage.Source = image;
            }
            catch
            {
                Report.Error("Unable to load avatar");
            }

        }
        #endregion
    }
}

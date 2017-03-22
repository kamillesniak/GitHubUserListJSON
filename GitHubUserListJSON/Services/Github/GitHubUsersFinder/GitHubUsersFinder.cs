using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using GitHubUserListJSON.Services.JsonHandler.Interfaces;

namespace GitHubUserListJSON.Services.Github.GitHubUsersFinder
{
    class GitHubUsersFinder : IGitHubUsersFindercs
    { 

    private string JsonFile { get; set; }
    public List<User> GitHubUsers { get; private set; }

    public GitHubUsersFinder(IJsonFromUrlLoader jsonString)
    {
            JsonFile = jsonString.LoadJsonFromUrl();
            FindGitHubUsers();
    }

    public void FindGitHubUsers()
        {
            JArray gitUsersArray = JArray.Parse(JsonFile);
            GitHubUsers =  gitUsersArray.Select(p => new User
                                                {
                                                   login = (string)p["login"],
                                                   avatarurl = (string)p["avatar_url"]
                                                }).ToList();
        }

    }
}

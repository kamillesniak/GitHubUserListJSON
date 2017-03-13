using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using Octokit;

namespace GitHubUserListJSON
{
   internal static class ControlsValuesLoader
    {
        public static ComboBox LoadLoginComboBox(ComboBox cbox, IList<User> iList)
        {
            cbox.DataContext = iList;
            cbox.DisplayMemberPath = "login";
            cbox.SelectedIndex = 0;
            cbox.ItemsSource = iList;
            return cbox;
        }
        public static ComboBox LoadRepositoryComboBox(ComboBox cbox, IReadOnlyList<Repository> userRepositories)
        {
            cbox.DataContext = userRepositories;
            cbox.DisplayMemberPath = "Name";
            cbox.ItemsSource = userRepositories;
            cbox.SelectedIndex = 0;
            return cbox;
        }
    }
}

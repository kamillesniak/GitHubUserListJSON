using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace GitHubUserListJSON
{


    internal static class UploadAvatar
    {

        public static BitmapImage UploadUserAvatarFromURL(string actualLogin, IList<UsersData> iList)
        {
            try
            {
                string _url = FindUserAvatarUrl(actualLogin, iList);
                BitmapImage image = new BitmapImage(new Uri(_url));
                return image;
            }
            catch
            {
                Report.Error("Unable to load user avatar");
                return null;
            }
        }
        private static string FindUserAvatarUrl(string login, IList<UsersData> users)
        {
            string avatarURL = string.Empty;

            var query =
                from item in users
                where item.login == login
                select item.avatarurl;

            foreach (var item in query)
            {
                avatarURL = item;
            }
            return avatarURL;
        }
    }
}

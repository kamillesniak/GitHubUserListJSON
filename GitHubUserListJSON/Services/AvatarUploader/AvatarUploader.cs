using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;

namespace GitHubUserListJSON
{


    internal static class AvatarUploader
    {

        public static BitmapImage UserAvatarLoader(string actualLogin, IList<User> iList)
        {
            try
            {
                string _url = AvatarUrlFinder(actualLogin, iList);
                BitmapImage image = new BitmapImage(new Uri(_url));
                return image;
            }
            catch
            {
                ReportMessage.Error("Unable to load user avatar");
                return null;
            }
        }
        private static string AvatarUrlFinder(string login, IList<User> users)
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

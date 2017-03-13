using System.Windows;

namespace GitHubUserListJSON
{
    class ReportMessage
    {
        public static void Error(string errormessage)
        {
            MessageBox.Show(errormessage);
        }
    }
}

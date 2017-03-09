using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUserListJSON
{
    internal abstract class JsonData
    {
        public string deserializedJsonFile { get; protected set; }
        public bool isConnectedFlag { get; protected set; } = true;
        public IList<UsersData> gitHubUsers { get; protected set; }
        protected string jsonBackUpDirectory { get; set; }
    }
}

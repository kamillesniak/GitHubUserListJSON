

namespace GitHubUserListJSON
{
    internal abstract class JsonData
    {
        public string deserializedJsonFile { get; protected set; }
        public bool isConnectedFlag { get; protected set; } = true;
    }
}

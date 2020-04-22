namespace Anniversaries.Core
{
    public class BuildInformation
    {
        public BuildInformation(string version, string commitHash, string repositoryUrl)
        {
            this.Version = version;
            this.CommitHash = commitHash;
            this.CommitShortHash = commitHash?.Substring(0, 7);
            this.RepositoryUrl = repositoryUrl;
        }

        public string Version { get; }
        public string CommitHash { get; }
        public string RepositoryUrl { get; }
        public string CommitShortHash { get; }
    }
}
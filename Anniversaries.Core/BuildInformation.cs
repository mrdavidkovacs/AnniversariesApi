using JetBrains.Annotations;

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

        [PublicAPI]
        public string Version { get; }

        [PublicAPI]
        public string CommitHash { get; }

        [PublicAPI]
        public string RepositoryUrl { get; }

        [PublicAPI]
        public string CommitShortHash { get; }
    }
}
using System.IO;
using System.Reflection;

namespace Anniversaries.Core
{
    public class BuildInformationProvider
    {
        private const string BuildInformationFileName = ".buildinfo.json";

        public BuildInformation GetBuildInformation()
        {
            string version;
            string commitHash;
            string repositoryUrl;

            if (File.Exists(BuildInformationFileName))
            {
                string[] content = File.ReadAllLines(BuildInformationFileName);
                repositoryUrl = content[0];
                commitHash = content[1];
                version = content[2];
            }
            else
            {
                repositoryUrl = null;
                commitHash = null;
                version = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;
            }

            return new BuildInformation(version, commitHash, repositoryUrl);
        }
    }
}
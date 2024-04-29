using System.IO;

namespace ArdalisRating.Policies
{
    internal class FilePolicySource
    {
        public string GetPolicyFromSource(string file)
        {
            return File.ReadAllText(file);
        }
    }
}
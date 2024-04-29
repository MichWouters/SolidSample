using System.IO;

namespace ArdalisRating.Policies
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource(string file)
        {
            return File.ReadAllText(file);
        }
    }
}
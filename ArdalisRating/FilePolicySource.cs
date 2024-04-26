using System.IO;

namespace ArdalisRating
{
    internal class FilePolicySource
    {
        public string GetPolicyFromSource(string file)
        {
            return File.ReadAllText(file);
        }
    }
}
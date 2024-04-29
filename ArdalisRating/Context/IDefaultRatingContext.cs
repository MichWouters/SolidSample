using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;

namespace ArdalisRating.Context
{
    public interface IDefaultRatingContext
    {
        RatingEngine Engine { get; set; }
        ConsoleLogger Logger { get; }

        IPolicyRater CreateRaterForPolicy(Policy policy);
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        string LoadPolicyFromFile(string file);
        string LoadPolicyFromURI(string uri);
        void Log(string message);
        void UpdateRating(decimal rating);
    }
}
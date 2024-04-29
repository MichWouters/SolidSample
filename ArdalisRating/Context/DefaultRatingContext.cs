using ArdalisRating.Factories;
using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;
using System;

namespace ArdalisRating.Context
{
    public class DefaultRatingContext : IDefaultRatingContext
    {
          public RatingEngine Engine { get; set; }

        public ConsoleLogger Logger => new ConsoleLogger();

        public IPolicyRater CreateRaterForPolicy(Policy policy, RatingEngine engine)
        {
            return new PolicyRaterFactory(engine, Logger).Create(policy.Type);
        }

        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return new PolicySerializer().RetrievePolicyFromJson(policyJson);
        }

        public Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new NotImplementedException();
        }

        public string LoadPolicyFromFile(string file)
        {
            return new FilePolicySource().GetPolicyFromSource(file);
        }

        public string LoadPolicyFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {
            new ConsoleLogger().WriteMessage(message);
        }

        public void UpdateRating(decimal rating)
        {
            Engine.Rating = rating;
        }
    }
}
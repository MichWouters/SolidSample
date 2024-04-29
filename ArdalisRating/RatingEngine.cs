using ArdalisRating.Factories;
using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {
        ILogger logger = new ConsoleLogger();

        FilePolicySource policySource = new FilePolicySource();
        PolicySerializer policySerializer = new PolicySerializer();


        public decimal Rating { get; set; }

        public void DefineRating()
        {
            PolicyRaterFactory factory = new PolicyRaterFactory(this, logger);

            logger.WriteMessage("Starting rate.");
            logger.WriteMessage("Loading policy.");

            string policyJson = policySource.GetPolicyFromSource("policy.json");
            var policy = policySerializer.RetrievePolicyFromJson(policyJson);

            IPolicyRater policyRater = factory.Create(policy.Type);
            policyRater.Rate(policy);

            logger.WriteMessage("Rating completed.");
        }
    }
}

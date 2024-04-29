using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;
using System;


namespace ArdalisRating.Factories
{
    internal class PolicyRaterFactory
    {
        private RatingEngine engine;
        private ILogger logger;

        public PolicyRaterFactory(RatingEngine engine, ILogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public IPolicyRater Create(PolicyType policyType)
        {
            switch (policyType)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, logger);
                case PolicyType.Flood:
                    return new FloodPolicyRater(engine, logger);
                case PolicyType.Land:
                    return new LandPolicyRater(engine, logger);
                case PolicyType.Life:
                    return new LifePolicyRating(engine, logger);
                default:
                    throw new ArgumentException();
            }
        }
    }
}

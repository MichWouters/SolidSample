using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;
using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : IPolicyRater
    {
        private ILogger logger;
        private RatingEngine engine;

        public AutoPolicyRater(RatingEngine engine, ILogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public void Rate(Policy policy)
        {
            logger.WriteMessage("Rating AUTO policy...");
            logger.WriteMessage("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                logger.WriteMessage("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    engine.Rating = 1000m;
                    return;
                }
                engine.Rating = 900m;
            }
        }
    }
}
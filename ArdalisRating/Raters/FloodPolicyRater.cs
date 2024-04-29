using ArdalisRating.Logging;
using ArdalisRating.Policies;

namespace ArdalisRating.Raters
{
    public class FloodPolicyRater: IPolicyRater
    {
        private ILogger logger;
        private RatingEngine engine;

        public FloodPolicyRater(RatingEngine engine, ILogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public void Rate(Policy policy)
        {
            if (policy.LivesNearOcean)
            {
                engine.Rating *= 100;
            }
        }
    }
}
using ArdalisRating.Logging;
using ArdalisRating.Policies;

namespace ArdalisRating.Raters
{
    public class LandPolicyRater: IPolicyRater
    {
        private ILogger logger;
        private RatingEngine engine;

        public LandPolicyRater(RatingEngine engine, ILogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public void Rate(Policy policy)
        {
            logger.WriteMessage("Rating LAND policy...");
            logger.WriteMessage("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.WriteMessage("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.WriteMessage("Insufficient bond amount.");
                return;
            }

            engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}

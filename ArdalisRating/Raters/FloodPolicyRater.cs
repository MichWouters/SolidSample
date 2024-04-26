namespace ArdalisRating.Raters
{
    internal class FloodPolicyRater: IPolicyRater
    {
        private ConsoleLogger logger;
        private RatingEngine engine;

        public FloodPolicyRater(RatingEngine engine, ConsoleLogger logger)
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
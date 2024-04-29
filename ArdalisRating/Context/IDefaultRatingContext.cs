using ArdalisRating.Logging;
using ArdalisRating.Policies;
using ArdalisRating.Raters;

namespace ArdalisRating.Context
{
    public interface IDefaultRatingContext: ILogger, IJsonPolicyLoader, IFilePolicyLoader
    {
        RatingEngine Engine { get; set; }
        ConsoleLogger Logger { get; }

        IPolicyRater CreateRaterForPolicy(Policy policy, RatingEngine engine);
        
        void UpdateRating(decimal rating);
    }
}
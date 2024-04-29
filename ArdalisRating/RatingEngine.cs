using ArdalisRating.Context;
using ArdalisRating.Raters;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine : IRatingEngine
    {
        private IDefaultRatingContext _context = new DefaultRatingContext();

        public decimal Rating { get; set; }

        public void DefineRating()
        {
            _context.Log("Starting rate.");
            _context.Log("Loading policy.");

            string policyJson = _context.LoadPolicyFromURI("policy.json");
            var policy = _context.GetPolicyFromJsonString(policyJson);

            IPolicyRater policyRater = _context.CreateRaterForPolicy(policy);
            policyRater.Rate(policy);

            _context.Log("Rating completed.");
        }
    }
}
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ArdalisRating.Policies
{
    internal class PolicySerializer
    {
        public Policy RetrievePolicyFromJson(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}

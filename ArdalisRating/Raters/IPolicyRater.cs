using ArdalisRating.Policies;

namespace ArdalisRating.Raters
{
    internal interface IPolicyRater
    {
        void Rate(Policy policy);
    }
}

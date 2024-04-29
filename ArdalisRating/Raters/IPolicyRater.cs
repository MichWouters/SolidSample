using ArdalisRating.Policies;

namespace ArdalisRating.Raters
{
    public interface IPolicyRater
    {
        void Rate(Policy policy);
    }
}

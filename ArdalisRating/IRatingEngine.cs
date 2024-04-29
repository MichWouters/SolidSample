namespace ArdalisRating
{
    public interface IRatingEngine
    {
        decimal Rating { get; set; }

        void DefineRating();
    }
}
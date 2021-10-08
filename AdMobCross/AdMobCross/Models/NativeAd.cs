namespace AdMobCross.Models
{
    public struct NativeAd
    {
        public string Title { get; }
        public string Description { get; }
        public string Image { get; }

        public NativeAd(string title, string description, string image)
        {
            Title = title;
            Description = description;
            Image = image;
        }
    }
}

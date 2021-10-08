namespace AdMobCross.Models
{
    public struct NativeItem
    {
        public string Title { get; }
        public string Description { get; }

        public NativeItem(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

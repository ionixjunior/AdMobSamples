namespace AdMobCross.Models
{
    public struct Item
    {
        public string Title { get; }
        public string Description { get; }

        public Item(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

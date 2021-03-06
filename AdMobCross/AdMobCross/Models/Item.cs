using AdMobCross.Enums;

namespace AdMobCross.Models
{
    public struct Item
    {
        public string Title { get; }
        public string Description { get; }
        public string Image { get; }
        public ItemType Type { get; }

        public Item(string title, string description, string image, ItemType type)
        {
            Title = title;
            Description = description;
            Image = image;
            Type = type;
        }
    }
}

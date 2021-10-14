using AdMobCross.Enums;

namespace AdMobCross.Models
{
    public struct Item
    {
        public string Title { get; }
        public string Description { get; }
        public ItemType Type { get; }

        public Item(string title, string description, ItemType type)
        {
            Title = title;
            Description = description;
            Type = type;
        }
    }
}

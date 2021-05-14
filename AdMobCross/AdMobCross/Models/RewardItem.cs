namespace AdMobCross.Models
{
    public struct RewardItem
    {
        public int Amount { get; }
        public string Type { get; }

        public RewardItem(int amount, string type)
        {
            Amount = amount;
            Type = type;
        }
    }
}

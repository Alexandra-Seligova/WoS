namespace WoS.Quests
{
    internal class TradeQuest : QuestBase
    {
        public string TradeItem { get; private set; }
        public int Quantity { get; private set; }

        public TradeQuest(string title, string description, string tradeItem, int quantity)
        {
            Title = title;
            Description = description;
            TradeItem = tradeItem;
            Quantity = quantity;
            IsCompleted = false;
        }

        public override void CompleteQuest()
        {
            // Specifická logika pro dokončení obchodního úkolu
            base.CompleteQuest();
        }
    }
}
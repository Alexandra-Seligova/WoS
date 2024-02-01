namespace WoS.Quests
{
    internal class ExplorationQuest : QuestBase
    {
        public string TargetLocation { get; private set; }

        public ExplorationQuest(string title, string description, string targetLocation)
        {
            Title = title;
            Description = description;
            TargetLocation = targetLocation;
            IsCompleted = false;
        }

        public override void CompleteQuest()
        {
            // Specifická logika pro dokončení průzkumného úkolu
            base.CompleteQuest();
        }
    }

    // Další třídy úkolů, jako jsou třeba TradeQuest, MiningQuest, CombatQuest atd.
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Quests
{
    internal class MiningQuest : QuestBase
    {
        public string Resource { get; private set; }
        public int RequiredAmount { get; private set; }

        public MiningQuest(string title, string description, string resource, int requiredAmount)
        {
            Title = title;
            Description = description;
            Resource = resource;
            RequiredAmount = requiredAmount;
            IsCompleted = false;
        }

        public override void CompleteQuest()
        {
            // Specifická logika pro dokončení těžebního úkolu
            base.CompleteQuest();
        }
    }
}

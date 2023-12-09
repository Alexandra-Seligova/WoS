using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Quests
{
    internal class CombatQuest : QuestBase
    {
        public string EnemyType { get; private set; }
        public int EnemyCount { get; private set; }

        public CombatQuest(string title, string description, string enemyType, int enemyCount)
        {
            Title = title;
            Description = description;
            EnemyType = enemyType;
            EnemyCount = enemyCount;
            IsCompleted = false;
        }

        public override void CompleteQuest()
        {
            // Specifická logika pro dokončení bojového úkolu
            base.CompleteQuest();
        }
    }
}

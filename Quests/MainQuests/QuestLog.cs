using System.Collections.Generic;
using System.Linq;

namespace WoS.Quests
{
    internal class QuestLog
    {
        private List<QuestBase> quests;
        private QuestBase activeQuest;

        public QuestLog()
        {
            quests = new List<QuestBase>();
            InitializeQuests();
        }

        private void InitializeQuests()
        {
            // Přidání úkolů do seznamu
            quests.Add(new ExplorationQuest("Explore Alpha Sector", "Explore the Alpha Sector for new resources.", "Alpha Sector"));
            quests.Add(new TradeQuest("Trade with Station Zeta", "Trade minerals for fuel at Station Zeta.", "Minerals", 10));
            quests.Add(new MiningQuest("Mine Asteroids", "Mine 50 units of ore from nearby asteroids.", "Ore", 50));
            quests.Add(new CombatQuest("Defeat Pirate Ships", "Defeat 5 pirate ships in the Gamma sector.", "Pirate Ship", 5));
            // Další úkoly...
        }

        public void ActivateQuest(string questTitle)
        {
            var questToActivate = quests.FirstOrDefault(q => q.Title == questTitle);
            if (questToActivate != null && !questToActivate.IsCompleted)
            {
                activeQuest = questToActivate;
                // Další logika pro aktivaci úkolu...
            }
        }

        public void UpdateActiveQuestStatus()
        {
            if (activeQuest != null && !activeQuest.IsCompleted)
            {
                // Zde aktualizovat stav aktivního úkolu...
                // Pokud je úkol dokončen, nastavte activeQuest na null nebo přejděte na další úkol
            }
        }

        // Metody pro získání informací o úkolech, jako je seznam všech úkolů, aktuální aktivní úkol atd.
    }
}

/*
var questLog = new QuestLog();
questLog.ActivateQuest("Explore Alpha Sector");

// V herním cyklu...
questLog.UpdateActiveQuestStatus();
*/
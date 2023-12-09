using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Quests
{
    internal class QuestsManager
    {
        private static QuestsManager _instance;
        public static QuestsManager Instance => _instance ?? (_instance = new QuestsManager());

        private List<QuestBase> quests;

        private QuestsManager()
        {
            quests = new List<QuestBase>();
            // Inicializace nebo načtení úkolů
        }

        public void AddQuest(QuestBase quest)
        {
            quests.Add(quest);
        }

        // Metody pro správu úkolů (Přidání, Odebrání, Získání stavu úkolů atd.)
    }
}
/*

var explorationQuest = new ExplorationQuest("Prozkoumejte Asteroid", "Prozkoumejte asteroid XY-123.", "XY-123");
QuestsManager.Instance.AddQuest(explorationQuest);

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Quests
{
    internal class QuestBase
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public bool IsCompleted { get; protected set; }

        public virtual void CompleteQuest()
        {
            IsCompleted = true;
        }

        // Další společné vlastnosti a metody pro úkoly
    }
}

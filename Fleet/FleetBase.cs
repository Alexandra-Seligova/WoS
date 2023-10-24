using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoS.Fleet
{
    public class FleetBase
    {
        protected List<IControllable> controllables;
        protected IControllable currentControlledObject;

        public FleetBase()
        {
            controllables = new List<IControllable>();
        }

        public void AddControllable(IControllable controllable)
        {
            controllables.Add(controllable);
        }

        public virtual void SwitchControl()
        {
            // Logika pro přepnutí ovládání mezi objekty
        }

        public virtual void SetFleetBehaviorBasedOnCurrentObject()
        {
            // Implementace logiky pro nastavení chování flotily na základě aktuálně ovládaného objektu
        }
    }
}

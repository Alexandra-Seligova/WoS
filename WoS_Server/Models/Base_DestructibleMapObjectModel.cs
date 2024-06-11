namespace WoS_Server.Models
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class Base_DestructibleMapObjectModel : Base_Module
    {
        private float _hp;
        private float _maxHP;
        private float _armor;
        private float _maxArmor;
        private float _structuralIntegrity;
        private float _maxStructuralIntegrity;
        private float _shield;
        private float _maxShield;

        public Dictionary<ResourceType, int> InitialCostResource { get; set; } // nákupní cena
        public Dictionary<ResourceType, int> CurrentCostResource { get; set; } // získatelná cena při zničení
        public float DepreciationRate { get; set; } = 0.6f; // Procentuální pokles ceny při zničení o 60%

        public Base_DestructibleMapObjectModel(int idGlobal, int idUser, Vector3 spawnPlace, int width, int height, int depth)
            : base(idGlobal, idUser, spawnPlace, width, height, depth)
        {
            CanBeDestroyed = true; // Výchozí hodnota je true, což znamená, že objekt může být zničen.

            // Initialize the initial and current cost resources
            InitializeInitialCostResource();

        }
        #region Cost Resource
        /// <summary>
        /// Initializes the InitialCostResource with 0 value for each resource type.
        /// </summary>
        private void InitializeInitialCostResource()
        {
            InitialCostResource = new Dictionary<ResourceType, int>();
            foreach(ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
            {
                InitialCostResource[resourceType] = 0;
            }
            InitializeCurrentCostResource();
        }

        /// <summary>
        /// Initializes the CurrentCostResource based on InitialCostResource and DepreciationRate.
        /// </summary>
        private void InitializeCurrentCostResource()
        {
            CurrentCostResource = new Dictionary<ResourceType, int>();
            if(InitialCostResource != null)
            {
                foreach(var cost in InitialCostResource)
                {
                    CurrentCostResource[cost.Key] = (int)(cost.Value * (1 - DepreciationRate));
                }
            }
        }

        /// <summary>
        /// Updates the InitialCostResource with the given resource type and amount.
        /// </summary>
        /// <param name="resourceType">The type of the resource.</param>
        /// <param name="amount">The amount of the resource.</param>
        public void UpdateInitialCostResource(ResourceType resourceType, int amount)
        {
            if(InitialCostResource.ContainsKey(resourceType))
            {
                InitialCostResource[resourceType] = amount;
            }
            else
            {
                InitialCostResource.Add(resourceType, amount);
            }

            // Update CurrentCostResource based on the new InitialCostResource
            CurrentCostResource[resourceType] = (int)(amount * (1 - DepreciationRate));
        }       /// <summary>
                /// Updates the InitialCostResource with the given dictionary of resource types and amounts.
                /// </summary>
                /// <param name="resourceCosts">A dictionary containing resource types and their corresponding amounts.</param>
        public void UpdateInitialCostResource(Dictionary<ResourceType, int> resourceCosts)
        {
            foreach(var resourceCost in resourceCosts)
            {
                UpdateInitialCostResource(resourceCost.Key, resourceCost.Value);
            }
        }
        #endregion


        #region Damage Handling
        /// <summary>
        /// Applies damage to the object, affecting shield, structural integrity, armor, and HP in that order.
        /// </summary>
        /// <param name="damage">The amount of damage to apply.</param>
        public void ApplyDamage(float damage)
        {
            // Apply damage to shield first
            if(_shield > 0)
            {
                float damageToShield = Math.Min(damage, _shield);
                _shield -= damageToShield;
                damage -= damageToShield;
            }

            // Apply damage to structural integrity if shield is depleted
            if(damage > 0 && _structuralIntegrity > 0)
            {
                float damageToStructuralIntegrity = Math.Min(damage, _structuralIntegrity);
                _structuralIntegrity -= damageToStructuralIntegrity;
                damage -= damageToStructuralIntegrity;
            }

            // Apply damage to armor if structural integrity is depleted
            if(damage > 0 && _armor > 0)
            {
                float damageToArmor = Math.Min(damage, _armor);
                _armor -= damageToArmor;
                damage -= damageToArmor;
            }

            // Apply damage to HP if armor is depleted
            if(damage > 0 && _hp > 0)
            {
                _hp -= damage;
                if(_hp <= 0)
                {
                    _hp = 0;
                    OnDestroyed();
                }
            }
        }

        /// <summary>
        /// Event triggered when the object is destroyed.
        /// </summary>
        protected virtual void OnDestroyed()
        {
            throw new NotImplementedException("Není implementováno zničení objektu");
            // Implement destruction logic here
        }
        #endregion











        // Properties for HP, Armor, Structural Integrity, and Shield with CanBeDestroyed checks
        public float HP
        {
            get => CanBeDestroyed ? _hp : 0;
            set
            {
                if(CanBeDestroyed)
                    _hp = value;
            }
        }

        public float MaxHP
        {
            get => CanBeDestroyed ? _maxHP : 0;
            set
            {
                if(CanBeDestroyed)
                    _maxHP = value;
            }
        }

        public float Armor
        {
            get => CanBeDestroyed ? _armor : 0;
            set
            {
                if(CanBeDestroyed)
                    _armor = value;
            }
        }

        public float MaxArmor
        {
            get => CanBeDestroyed ? _maxArmor : 0;
            set
            {
                if(CanBeDestroyed)
                    _maxArmor = value;
            }
        }

        public float StructuralIntegrity
        {
            get => CanBeDestroyed ? _structuralIntegrity : 0;
            set
            {
                if(CanBeDestroyed)
                    _structuralIntegrity = value;
            }
        }

        public float MaxStructuralIntegrity
        {
            get => CanBeDestroyed ? _maxStructuralIntegrity : 0;
            set
            {
                if(CanBeDestroyed)
                    _maxStructuralIntegrity = value;
            }
        }

        public float Shield
        {
            get => CanBeDestroyed ? _shield : 0;
            set
            {
                if(CanBeDestroyed)
                    _shield = value;
            }
        }

        public float MaxShield
        {
            get => CanBeDestroyed ? _maxShield : 0;
            set
            {
                if(CanBeDestroyed)
                    _maxShield = value;
            }
        }
    }
}

using System;
using UnityEngine;

namespace BehaviorTreeSample.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnDeath;

        public bool IsDead => Health <= 0;
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public virtual void Init(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public virtual void ChangeHealth(int delta)
        {
            Health += delta;

            if (Health > MaxHealth)
                Health = MaxHealth;

            if (IsDead)
                OnDeath?.Invoke();
        }

        //public virtual void SetMaxHealth(int maxHealth)
        //{
        //    if (MaxHealth >= maxHealth)
        //        return;

        //    int delta = maxHealth - MaxHealth;
        //    MaxHealth = maxHealth;
        //    Health += delta;
        //}
    }
}

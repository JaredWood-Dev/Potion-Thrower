using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Potion_Types
{
    public class DamagePotion : Potion
    {
        /*
         * This type of potion is very simple; it does damage.
         * The Acid Vial is a type of damage potion
         */
        
        public Enums.DamageType damageType;
        public int damageAmount;

        void OnCollisionEnter2D(Collision2D collision)
        {
            //if (leftPlayer)
            {
                try
                {
                    collision.gameObject.GetComponent<HealthComponent>().Damage(damageAmount, damageType);
                    DestroyPotion();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    print("Target doesn't have a health component");
                    throw;
                }
            }
        }
    }
}

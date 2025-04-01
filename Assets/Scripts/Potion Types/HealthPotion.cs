using System;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPotion : Potion
{
    /*
     * This potion heals hit points to the target creature.
     */

    public int healAmount;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (!collision.gameObject.GetComponent<HealthComponent>().isObject)
                collision.gameObject.GetComponent<HealthComponent>().ModifyHealth(healAmount);
            TranfserMomentum(collision);
            DestroyPotion();
        }
        catch (NullReferenceException e)
        {
            print("Target does not have health component.");
        }
    }
}

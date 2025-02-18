using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    /*
     * This script handles all the objects that need to have hitpoints and can be destroyed
     * All objects that have this component can have resistances (take half), immunities (take none), or
     * vulnerabilities (take twice)
     */
    
    public int hitPoints;
    public int maxHitPoints;
    
    [Header("Damage Adjustments")]
    public Enums.DamageType[] resistances;
    public Enums.DamageType[] vulnerabilities;
    public Enums.DamageType[] immunities;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    /*
     * Modifies the target's health based on the given amount.
     * Checks for going over max HP and hitting zero
     */
    public void ModifyHealth(int amount)
    {
        if (hitPoints + amount >= maxHitPoints)
        {
            hitPoints = maxHitPoints;
            return;
        }

        if (hitPoints <= 0)
        {
            hitPoints = 0;
            DestroyEntity();
            return;
        }
        hitPoints += amount;
    }

    /*
     * Damages the target, while considering the target's damage adjustments
     */
    public void Damage(int amount, Enums.DamageType damageType)
    {
        int damageDealt = amount;
        
        foreach (var vulnerability in vulnerabilities)
            if (vulnerability == damageType)
                damageDealt *= 2;
        foreach (var resistance in resistances)
            if (resistance == damageType)
                damageDealt /= 2;
        foreach (var immunity in immunities)
            if (immunity == damageType)
                damageDealt = 0;
        
        ModifyHealth(-damageDealt);
    }

    /*
     * Deletes the target 
     */
    public void DestroyEntity()
    {
        if (gameObject.CompareTag("Target"))
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().HitTarget();
        }
        Destroy(gameObject);
    }
}

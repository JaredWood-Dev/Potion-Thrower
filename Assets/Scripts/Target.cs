using UnityEngine;

public class Target : MonoBehaviour
{
    public int hitPoints;

    public void DamageTarget(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}

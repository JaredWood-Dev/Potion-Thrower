using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionQueue : MonoBehaviour
{
    /*
     * This script holds the queue of potions Syruyar has access too.
     * When ever the throws one, another one is provided from the queue.
     */
    
    public GameObject[] initialPotions;
    public Queue<GameObject> potionQueue = new Queue<GameObject>();
    public int maxPotions = -1;
    [Tooltip("This is the potion that is used when the queue is empty.")]
    public GameObject defaultPotion;

    private void Start()
    {
        //Copy the potions into the queue
        foreach (var potion in initialPotions)
        {
            potionQueue.Enqueue(potion);
        }
    }

    public GameObject GetPotion()
    {
        if (potionQueue.Count < 1)
        {
            return defaultPotion;
        }
        return potionQueue.Dequeue();
    }

    public void AddPotion(GameObject potion)
    {
        if (!(potionQueue.Count + 1 > maxPotions) && maxPotions > 0)
        {
            potionQueue.Enqueue(potion);
        }
    }
}

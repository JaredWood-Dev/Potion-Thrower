using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PotionQueueUIDisplay : MonoBehaviour
{
    /*
     * This script handles the UI representation of the potion queue.
     * It keeps that of its potions, and causes all the potions in the stack to fall down once one is removed.
     */
    
    public List<GameObject> potionQueue;
    public GameObject thrower;
    public GameObject startingPositionObject;
    public float radius;

    void Start()
    {
        //At the beginning we need to spawn in the images based on Syruyar's queue
        PotionQueue pq = thrower.GetComponent<PotionQueue>();

        for (int i = 0; i < pq.initialPotions.Length; i++)
        {
            potionQueue.Add(new GameObject());
            potionQueue[i].name = pq.initialPotions[i].name;
            potionQueue[i].AddComponent<RectTransform>().transform.position = startingPositionObject.transform.position;
            potionQueue[i].GetComponent<RectTransform>().transform.position += new Vector3(0f, radius * i, 0f);
            potionQueue[i].AddComponent<Image>().sprite = pq.initialPotions[i].GetComponent<SpriteRenderer>().sprite;
            potionQueue[i].AddComponent<CircleCollider2D>().radius = radius;
            potionQueue[i].AddComponent<Rigidbody2D>();
            potionQueue[i].GetComponent<Image>().SetNativeSize();
            potionQueue[i].transform.SetParent(gameObject.transform);
            potionQueue[i].GetComponent<RectTransform>().localScale.Set(1f, 1f, 1f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float timeToDestroy;

    void Start()
    {
        Invoke("Destroy", timeToDestroy);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

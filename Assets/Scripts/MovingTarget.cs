using System.Collections;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class MovingTarget : Target
{
    [Header("Moving Target")] 
    public float movementSpeed = 1f;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float timeOffset = 0f;

    private GameObject _startPositionGameObject;
    private GameObject _endPositionGameObject;

    void Start()
    {
        //Only do automatic positions if there are appropriate children
        if (transform.GetChild(0) && transform.GetChild(1))
        {
            _startPositionGameObject = transform.GetChild(0).gameObject;
            _endPositionGameObject = transform.GetChild(1).gameObject;

            startPosition = _startPositionGameObject.transform.position;
            endPosition = _endPositionGameObject.transform.position;
        }
    }
    
    void Update()
    {
        transform.position = Vector2.Lerp(startPosition, endPosition, 0.5f * (Mathf.Sin(Time.time * movementSpeed + timeOffset)) + 0.5f);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Thrower : MonoBehaviour
{
    [Header("Throwing Angle")]
    [Range(0,90)]
    public float throwAngle = 0f;
    public float angleSensitivity = 0.5f;
    private float _minThrowAngle = 0f;
    private float _maxThrowAngle = 90f;
    
    public float potionSpinSpeed = 50f;

    [Header("Throwing Power")]
    [Range(0,30)]
    public float throwForce = 0f;
    private float _minThrowForce = 0f;
    private float _maxThrowForce = 30f;
    public float forceSensitivity = 0.5f;

    public GameObject potion;
    private GameObject _activePotion;
    public GameObject head;

    public bool rotateHead;

    [Header("UI Elements")] 
    public Image rotationSelector;
    public Image powerMeter;

    void Start()
    {
        head.transform.position = transform.position + new Vector3(0.1f, 0.75f, 0.1f);
    }

    void Update()
    {
        //Keep Syruyar in the bottom left
        GameObject angleSelector = GameObject.Find("Angle Selector");
        var angleTransform = angleSelector.GetComponent<RectTransform>();
        Vector3 position;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(angleTransform, angleTransform.position, Camera.main, out position);
        gameObject.transform.position = position;
        
        if (Input.GetKeyUp("space"))
        {
            if(_activePotion != null)
                ThrowPotion(_activePotion);
            _activePotion = null;
            //throwForce = 0f;
            GetComponent<Animator>().SetTrigger("Throw");
            
            //Linear Interpolate the value back down
            throwForce = Mathf.Lerp(throwForce, 0, 2f);
            
            //Play throw sound
            GetComponent<AudioSource>().Play();
        }

        if (rotateHead)
        {
            head.transform.rotation = Quaternion.Euler(0, 0, throwAngle);
        }
        
        rotationSelector.rectTransform.rotation = Quaternion.Euler(0, 0, throwAngle);
        powerMeter.fillAmount = ( throwForce / _maxThrowForce );
    }

    void FixedUpdate()
    {
        //While space is held, the throw power increases
        //On release, a potion is thrown, in the indicated direction with the indicated speed
        if (Input.GetKey("space"))
        {
            if (!_activePotion)
            {
                GetComponent<Animator>().SetTrigger("NewPotion");
                _activePotion = Instantiate(potion, transform.position, Quaternion.identity);
                _activePotion.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                _activePotion.transform.position = gameObject.transform.position + new Vector3(-1.35f, 0.35f, 0.0f);
            }
            throwForce += forceSensitivity;
        }
        

        //The left and right inputs change the direction Syruyar throws the potion
        if (Input.GetKey("a"))
        {
            throwAngle += angleSensitivity;
        }
        if (Input.GetKey("d"))
        {
            throwAngle -= angleSensitivity;
        }
        
        //Clamp the values
        throwAngle = Mathf.Clamp(throwAngle, _minThrowAngle, _maxThrowAngle);
        throwForce = Mathf.Clamp(throwForce, _minThrowForce, _maxThrowForce);
    }

    void ThrowPotion(GameObject potion = null)
    {
        potion.transform.rotation = Quaternion.Euler(0, 0, throwAngle);
        Rigidbody2D rb = potion.GetComponent<Rigidbody2D>();
        rb.linearVelocity = potion.transform.right * throwForce;
        rb.constraints = RigidbodyConstraints2D.None;  
        rb.angularVelocity = potionSpinSpeed;
        
        //Update the game manager
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().IncreasePotion();
    }
}

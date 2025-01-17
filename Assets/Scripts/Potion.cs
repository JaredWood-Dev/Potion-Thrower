using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : MonoBehaviour
{
    //The color of the potion inside the bottle
    public Color potionColor;
    public List<Color> possibleColors = new List<Color>();
    public List<Sprite> bottleImages = new List<Sprite>();
    public List<Sprite> solutionImages = new List<Sprite>();
    
    //Shatter Effect
    public ParticleSystem potionEffect;
    
    //Shatter sound - might change implementation later
    public GameObject potionSound;
    
    void Start()
    {
        int chosenIndex = Random.Range(0, bottleImages.Count);
        var potionSolution = transform.GetChild(0).GameObject();
        
        //Choose a random potion color from the list of colors
        potionColor = possibleColors[chosenIndex];
        
        //Choose a random bottle from the list of bottles
        GetComponent<SpriteRenderer>().sprite = bottleImages[chosenIndex];
        potionSolution.GetComponent<SpriteRenderer>().sprite = solutionImages[chosenIndex];
        
        //Change the solution color
        potionSolution.GetComponent<SpriteRenderer>().color = potionColor;
    }

    void Update()
    {
        //Delete Potions if they fall off the screen
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            //Update the game manager
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().HitTarget();
            
            var effect = Instantiate(potionEffect, collision.contacts[0].point, Quaternion.identity);
            var main = effect.main;
            main.startColor = potionColor;
            effect.Play();
            
            //Sound Effect
            Instantiate(potionSound, transform.position, Quaternion.identity);
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void DestroyPotion()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Data")] 
    public int thrownPotions;
    public int totalTargets;
    public float timeElapsed;
    
    [Header("UI Elements")]
    public Text potionText;
    public Text targetText;
    public Text timeText;

    void Start()
    {
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        targetText.text = totalTargets.ToString();
        potionText.text = thrownPotions.ToString();
    }

    public void HitTarget()
    {
        totalTargets--;
        targetText.text = totalTargets.ToString();
    }

    public void IncreasePotion()
    {
        thrownPotions++;
        potionText.text = thrownPotions.ToString();
    }

    public void Update()
    {
        timeElapsed += Time.deltaTime;
        
        int seconds = (int)timeElapsed % 60;
        int minutes = (int)timeElapsed / 60;
        
        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}

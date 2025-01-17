using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    
    public GameObject gameOverPanel;
    public Text finalPotionText;
    public Text finalTimeText;
    
    public bool gameOver;

    void Start()
    {
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        targetText.text = totalTargets.ToString();
        potionText.text = thrownPotions.ToString();
        
        gameOver = false;
        gameOverPanel.SetActive(false);
    }

    public void HitTarget()
    {
        totalTargets--;
        targetText.text = totalTargets.ToString();

        if (totalTargets < 1)
        {
            GameOver();
        }
    }

    public void IncreasePotion()
    {
        thrownPotions++;
        potionText.text = thrownPotions.ToString();
    }

    public void Update()
    {
        if (!gameOver)
            timeElapsed += Time.deltaTime;
        
        timeText.text = GetTime(timeElapsed);
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        
        finalPotionText.text = "Potions Thrown: " + thrownPotions.ToString();
        finalTimeText.text = "Time Elapsed: " + GetTime(timeElapsed);

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCount)
        {
            gameOverPanel.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    string GetTime(float time)
    {
        int seconds = (int)timeElapsed % 60;
        int minutes = (int)timeElapsed / 60;
        
        return $"{minutes:00}:{seconds:00}";
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

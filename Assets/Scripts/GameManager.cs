using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [Header("Game Data")] 
    public int thrownPotions;
    public int totalTargets;
    private int _startingTargetAmount;
    public float timeElapsed;
    
    [Header("UI Elements")]
    public Text potionText;
    public Text targetText;
    public Text timeText;
    
    public GameObject gameOverPanel;
    public Text finalPotionText;
    public Text finalTimeText;
    public Text accuracyText;

    public GameObject pauseMenu;
    
    public bool gameOver;

    [Header("Music Management")] 
    public AudioClip[] currentPlaylist;
    public AudioClip currentSong;

    void Start()
    {
        //When a level load, ensure game is running
        Time.timeScale = 1;
        
        totalTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        targetText.text = totalTargets.ToString();
        potionText.text = thrownPotions.ToString();

        _startingTargetAmount = totalTargets;
        
        gameOver = false;
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        
        //Play music
        GetComponent<AudioSource>().clip = currentPlaylist[0];
        GetComponent<AudioSource>().Play();
        Invoke("FinishSong", currentPlaylist[0].length);
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

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy)
        {
            UnpauseGame();
        }
        
        timeText.text = GetTime(timeElapsed);
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        
        finalPotionText.text = "Potions Thrown: " + thrownPotions.ToString();
        finalTimeText.text = "Time Elapsed: " + GetTime(timeElapsed);
        float percentAccuracy = (_startingTargetAmount / (float)thrownPotions) * 100;
        accuracyText.text = $"Accuracy: {percentAccuracy:00.0}%";

        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
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

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UnpauseGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void FinishSong()
    {
        currentSong = currentPlaylist[Random.Range(0, currentPlaylist.Length)];
        GetComponent<AudioSource>().PlayOneShot(currentSong);

        float nextDuration = currentSong.length;
        
        Invoke("FinishSong", nextDuration);
    }
}

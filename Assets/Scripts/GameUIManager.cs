using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public TextMeshProUGUI finalScoreUI;
    public GameObject scoreInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeUIScore(int scoreToAdd){
        scoreUI.text = scoreToAdd.ToString("D6");
        finalScoreUI.text = scoreToAdd.ToString("D6");
    }

    public void gameOverTrigger(){
        gameOverScreen.SetActive(true);
        scoreInfo.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("GameOverTheme", false);
    }

    public void startLevel(){
        FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Theme", false);
    }

    public void goToMenu(){
        FindObjectOfType<AudioManager>().Stop("GameOverTheme");
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("MenuTheme", false);
    }

    public void victoryScreenToggle()
    {
        FindObjectOfType<AudioManager>().Stop("Theme");
        victoryScreen.SetActive(true);
        scoreInfo.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuTheme", false);
    }
}

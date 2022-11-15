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
    }

    public void startLevel(){
        SceneManager.LoadScene(1);
    }

    public void goToMenu(){
        SceneManager.LoadScene(0);
    }

    public void victoryScreenToggle()
    {
        victoryScreen.SetActive(true);
        scoreInfo.SetActive(true);
    }
}

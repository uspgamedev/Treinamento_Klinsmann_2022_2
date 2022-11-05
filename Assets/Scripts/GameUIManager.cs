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
    public GameObject menuScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeUIScore(int scoreToAdd){
        scoreUI.text = scoreToAdd.ToString("D6");
    }

    public void gameOverTrigger(){
        gameOverScreen.SetActive(true);
    }

    public void startLevel(){
        SceneManager.LoadScene(1);
    }

    public void goToMenu(){
        SceneManager.LoadScene(0);
    }

}

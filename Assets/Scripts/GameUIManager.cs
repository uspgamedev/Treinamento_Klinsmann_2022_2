using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeUIScore(int scoreToAdd){
        scoreUI.text = scoreToAdd.ToString("D6");
    }
}

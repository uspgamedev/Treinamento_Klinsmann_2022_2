using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void restartLevel(){
        Debug.Log("Clique!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

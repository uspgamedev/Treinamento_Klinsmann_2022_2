using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instance;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Pause(){
        FindObjectOfType<AudioManager>().StopSFX();
        Time.timeScale = 0f;
    }

    public void Resume(){
        Time.timeScale = 1f;
    }
}

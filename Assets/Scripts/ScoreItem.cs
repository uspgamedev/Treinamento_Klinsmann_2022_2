using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreItem : MonoBehaviour
{
    public int scoreToAdd;
    int numberOfUses = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && numberOfUses == 0){
            col.gameObject.GetComponent<PlayerBehavior>().addScore(scoreToAdd);
            FindObjectOfType<AudioManager>().Play("Score");
            Debug.Log(col.gameObject.GetComponent<PlayerBehavior>().score);
            numberOfUses = 1;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyMovement : MonoBehaviour
{
    public GameObject enemyToTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D triggered){
        if(triggered.gameObject.tag == "MainCamera") 
            enemyToTrigger.GetComponent<Enemy>().isTriggered = true;
    }
}

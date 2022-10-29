using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "MainCamera")
            enemy.GetComponent<EnemyBehavior>().isTriggered = true;
    }
}

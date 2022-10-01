using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Transform EnemyPos;
    float speed = 2.0f;
    float dist = 0;
    float distMax;
    int direction = 1;
    Vector3 MovementDirection; 

    void Start()
    {
        EnemyPos = GetComponent<Transform>();  
        if(gameObject.tag == "GroundEnemy"){
            speed = 2.0f;
            distMax = 25.0f;
        }      
        else {
            speed = 6.0f;
            distMax = 12.0f;
        }
    }

    void Update()
    {
        MovementDirection = gameObject.tag == "GroundEnemy" ? new Vector3(1, 0, 0) : new Vector3(0, 1, 0);
        MovementDirection *= speed;
        MovementDirection *= Time.deltaTime;
        dist += MovementDirection.magnitude;
        EnemyPos.Translate(MovementDirection*direction);
        if(dist >= distMax) {
            direction *= -1;
            dist = 0;
        }
    }

}

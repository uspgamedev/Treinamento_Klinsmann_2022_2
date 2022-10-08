using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : Enemy
{
    public float ymoveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyBody.position.y <= -2.18){
            enemyBody.velocity = new Vector2(0, ymoveSpeed);
        }
    }
}

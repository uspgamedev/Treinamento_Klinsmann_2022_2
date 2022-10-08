using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : Enemy
{
    public float xmoveSpeed;
    void Start()
    {
        enemyBody.gravityScale = 0;
        enemyBody.velocity = new Vector2(xmoveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Ground"){ 
            xmoveSpeed *= -1;
            enemyBody.velocity = new Vector2(xmoveSpeed, 0);
        }
    }
}

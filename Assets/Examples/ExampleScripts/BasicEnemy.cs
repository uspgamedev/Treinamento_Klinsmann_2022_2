using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public float xmoveSpeed;
    public float ymoveSpeed;

    void enemyJump(){
        Vector2 verticalDirection = new Vector2(enemyBody.velocity.x, ymoveSpeed);
        enemyBody.velocity = verticalDirection;
    }
    
    void Start()
    {
        
    }

    void horizontalMovement(){
        Vector2 horizontalDirection = new Vector2(xmoveSpeed, enemyBody.velocity.y);
        enemyBody.velocity = horizontalDirection;
    }

    void FixedUpdate()
    {
        if(!isTriggered) enemyBody.velocity = new Vector2(0, 0);
        else horizontalMovement();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground")
            enemyJump();
        if(collision.gameObject.tag == "BasicEnemy")
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
}

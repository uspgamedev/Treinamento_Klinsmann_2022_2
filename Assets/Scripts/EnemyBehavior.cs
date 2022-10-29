using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Rigidbody2D enemyBody;
    public float xSpeed, ySpeed;
    public bool isTriggered = false;
    public bool facingRight = true;
    public bool jumping = true;
    public bool flying = false;
    public float yFlyingAltitude = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTriggered){
             enemyBody.velocity = new Vector2(xSpeed, enemyBody.velocity.y);

            if(flying && enemyBody.position.y <= yFlyingAltitude)
                enemyBody.velocity = new Vector2(0, ySpeed);
            if (xSpeed < 0 && facingRight)
                flip();
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        if(isTriggered && collision.gameObject.tag == "Ground" && jumping)
            enemyBody.velocity = new Vector2(0, ySpeed);
    }
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}

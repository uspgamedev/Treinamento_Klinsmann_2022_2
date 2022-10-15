using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowerMov : MonoBehaviour
{
    public float xSpeed;
    public Rigidbody2D enemyBody;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemyBody.velocity = new Vector2(direction*xSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            Debug.Log(gameObject.tag);
            direction *= -1;
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BoatPlatform"){
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}

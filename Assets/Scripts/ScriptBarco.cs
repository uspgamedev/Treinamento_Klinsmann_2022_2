using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBarco : MonoBehaviour
{
    public float xSpeed;
    public Rigidbody2D enemyBody;
    public Transform startPos, pos1, pos2;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            Debug.Log("transform.position == pos1.position");
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            Debug.Log("transform.position == pos2.position");
        }

        //enemyBody.velocity = new Vector2(direction*xSpeed, 0);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, xSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        // Gizmos.DrawLine(pos1.position, pos2.position);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            Debug.Log("COLLISION");
            xSpeed *= -1;
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "BoatPlatform"){
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}

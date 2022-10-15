using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemy : MonoBehaviour
{
    public float jumpPosition;
    public Rigidbody2D enemyBody;
    public float ySpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enemyBody.position.y <= jumpPosition)
            enemyBody.velocity = new Vector2(0, ySpeed);
    }
}

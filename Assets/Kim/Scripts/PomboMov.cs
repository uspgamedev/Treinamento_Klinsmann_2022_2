using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomboMov : MonoBehaviour
{
    public Rigidbody2D enemyBody;
    public float xSpeed, ySpeed;
    public bool isTriggered = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if(isTriggered) enemyBody.velocity = new Vector2(xSpeed, enemyBody.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform playerTransform;
    public float offsetx, offsety, minY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posY = playerTransform.position.y < minY ? minY: playerTransform.position.y;
        transform.position = new Vector3(playerTransform.position.x+offsetx, posY + offsety, -10);
    }
}

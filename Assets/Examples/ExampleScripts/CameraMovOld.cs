using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovOld : MonoBehaviour
{
    
    Transform CameraPos;
    public float speed = 30.0f;

    void Start()
    {
        CameraPos = GetComponent<Transform>();
    }

    
    void Update()
    {
        float HTranslation = Input.GetAxis("Horizontal") * speed;
        float VTranslation = Input.GetAxis("Vertical") * speed;

        HTranslation *= Time.deltaTime;
        VTranslation *= Time.deltaTime;

        Vector3 MovementVector = new Vector3(HTranslation, VTranslation, 0);

        CameraPos.Translate(MovementVector);
    }
}

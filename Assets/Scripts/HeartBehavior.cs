using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    public int restoredLife;
    int numberOfUses;
    // Start is called before the first frame update
    void Start()
    {
        numberOfUses = 0;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && numberOfUses == 0){
            col.gameObject.GetComponent<PlayerBehavior>().RestoreLife(restoredLife);
            FindObjectOfType<AudioManager>().Play("RestoreLife");
            numberOfUses = 1;
            Destroy(this.gameObject);
        }
    }
}

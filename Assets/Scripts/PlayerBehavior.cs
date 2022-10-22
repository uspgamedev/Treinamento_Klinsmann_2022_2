using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 20;
    int currentHealth;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Verificar quando tem colisão da capivara com algum inimigo para dar dano
        if(Input.GetKeyDown(KeyCode.KeypadEnter)){
            TakeDamage(4);
        }
    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy"){
            TakeDamage(4);
        }
    }
}

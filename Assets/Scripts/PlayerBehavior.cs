using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private SimpleFlash flash;
    public HealthBar healthBar;
    public int maxHealth = 20;
    int currentHealth;
    public int score = 0;
    public GameUIManager gameUIManager;
    [SerializeField] private GameObject player;

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
        if(currentHealth < 0){
            playerDeath();
        }
    }

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("damage");
        flash.Flash();
    }

    public void RestoreLife(int life){
        currentHealth += life;
        Debug.Log("Aumentou vida");
        healthBar.SetHealth(currentHealth);
    }

    public void addScore(int scoreToAdd){
        score += scoreToAdd;
        gameUIManager.changeUIScore(score);
    }

    public void playerDeath(){
        gameUIManager.gameOverTrigger();
    }

    void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Enemy"){
            FindObjectOfType<AudioManager>().Play("Damage");
            TakeDamage(4);
        }
        if (other.gameObject.tag == "BoatPlatform")
        {
            player.transform.parent = other.gameObject.transform;

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        player.transform.parent = null;
    }
}

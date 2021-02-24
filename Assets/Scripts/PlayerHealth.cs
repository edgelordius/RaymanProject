using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int maxLives = 3;
    public int currentLives;

    public HealthBar healthBar;
    public Image life1;
    public Image life2;
    public Image life3;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)){
            TakeDamage(20);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Swamp"){
            TakeDamage(20);
            CheckLives();
        }
    }

    void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
    void CheckLives(){
        if(currentHealth == 0 && currentLives == 3){
            life3.enabled = false;
            currentLives --;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        if(currentHealth == 0 && currentLives == 2){
            life2.enabled = false;
            currentLives --;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        if(currentHealth == 0 && currentLives == 1){
            life1.enabled = false;
            currentLives --;
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
        if(currentHealth == 0 && currentLives == 0){
            return;
            //Enter GameOver Screen here.
        }
    }
}

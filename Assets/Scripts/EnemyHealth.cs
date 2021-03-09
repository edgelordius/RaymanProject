using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    Animator aiAnim;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag == "BasicEnemy"){
            maxHealth = 50;
        }
        else if (this.gameObject.tag == "FlyingEnemy"){
            maxHealth = 100;
        }
        currentHealth = maxHealth;
        aiAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageFromPlayer(int damage){
        currentHealth -= damage;
        Debug.Log(this + "took " + damage + " damage from the player");
        if(currentHealth <= 0){
            aiAnim.Play("Base Layer.Death");
            Destroy(this.gameObject, 1);
        }
    }
}

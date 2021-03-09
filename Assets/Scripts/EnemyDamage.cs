using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    PlayerHealth playerHealthScript;
    EnemyHealth enemyHealthScript;

    Animator aiAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        enemyHealthScript = this.gameObject.GetComponent<EnemyHealth>();
        aiAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            aiAnim.Play("Base Layer.Run");
            StartCoroutine(RepeatAttack());
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            StopCoroutine(RepeatAttack());
            aiAnim.Play("Base Layer.Blend Tree");
        }
    }

    IEnumerator RepeatAttack(){
        if(this.gameObject.tag == "BasicEnemy"){
            if(enemyHealthScript.currentHealth > 0){
                Debug.Log("Yes, this is working");
                yield return new WaitForSeconds(0.1f);
                aiAnim.Play("Base Layer.Attack");
                yield return new WaitForSeconds(0.5f);
                playerHealthScript.TakeDamage(25);
            }
            else if(enemyHealthScript.currentHealth <= 0){
                aiAnim.SetInteger("health", 0);
            }
        }
    }
}

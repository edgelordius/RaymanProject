using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistDamage : MonoBehaviour
{

    EnemyHealth enemyHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other){
        if(other.gameObject.tag == "BasicEnemy"){
            enemyHealthScript = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.TakeDamageFromPlayer(20);
        }
        else if(other.gameObject.tag == "FlyingEnemy"){
            enemyHealthScript = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.TakeDamageFromPlayer(20);
        }
    }
}
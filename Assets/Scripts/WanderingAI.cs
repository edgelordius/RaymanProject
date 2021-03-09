using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    Transform target;
    NavMeshAgent agent;
    float timer;

    Animator aiAnim;

    public GameObject playerVar;

    Vector3 distanceCheck;

    void OnEnable(){
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        aiAnim = this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerVar = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distanceCheck = playerVar.transform.position;
        if(Vector3.Distance(this.transform.position, distanceCheck) > 15.0f){
            if(timer >= wanderTimer){
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
            Debug.Log("New random postion found");
            }
        }
        else if (Vector3.Distance(this.transform.position, distanceCheck) <= 15.0f){
            agent.SetDestination(playerVar.transform.position);
            Debug.Log("Target is " + agent.destination);
        }
        aiAnim.SetFloat("Move", agent.velocity.magnitude);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask){
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}

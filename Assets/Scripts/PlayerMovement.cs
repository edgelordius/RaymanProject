using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private List<GameObject> fists = new List<GameObject>();
    public GameObject leftFist;
    public GameObject rightFist;
    public float speed = 10.0f;
    public float jumpHeight = 500.0f;
    public bool isGrounded;
    public Rigidbody rb;
    Vector3 vel;
    int jumps = 0;

    public GameObject handR;
    public GameObject handL;
    public float handSpeed;
    public Transform handRTransform;
    public Transform handLTransform;

    float lastFiredTime = 0.0f;
    float fistFiringDelay = 0.5f;
    float fistHasReturnedDistance = 2.0f;

    Animator animBody;
    Animator animHead;
    Animator animLShoe;
    Animator animRShoe;
    Animator animLHand;
    Animator animRHand;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fists.Add(Instantiate(rightFist));
        fists.Add(Instantiate(leftFist));
        foreach(GameObject f in fists) {
            f.SetActive(false);
        }
        animBody = GameObject.Find("Player/SK_Rayman_Body1").GetComponent<Animator>();
        animHead = GameObject.Find("Player/Main Camera/SK_Rayman_Head").GetComponent<Animator>();
        animLShoe = GameObject.Find("Player/SK_Rayman_LShoe").GetComponent<Animator>();
        animRShoe = GameObject.Find("Player/SK_Rayman_RShoe").GetComponent<Animator>();
        animLHand = GameObject.Find("Player/SK_Rayman_LFist").GetComponent<Animator>();
        animRHand = GameObject.Find("Player/SK_Rayman_RFist").GetComponent<Animator>();
    }

    void handle_returned_fists() 
    {
        GameObject[] fistsInTheWorld = GameObject.FindGameObjectsWithTag("Fist");
        foreach(GameObject fistInTheWorld in fistsInTheWorld) 
        {
            if(fistInTheWorld.GetComponent<FistScript>().fist_is_returning()) {
                if(Vector3.Distance(fistInTheWorld.transform.position, transform.position) < fistHasReturnedDistance) 
                {
                    fistInTheWorld.SetActive(false);
                    fists.Add(fistInTheWorld);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forwardBackward = Input.GetAxis("Vertical") * speed;
        float leftRight = Input.GetAxis("Horizontal") * speed;
        forwardBackward *= Time.deltaTime;
        leftRight *= Time.deltaTime;
        transform.Translate(leftRight, 0, forwardBackward);
        
        if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0){
            animBody.SetFloat("Speed", 0);
            animLHand.SetFloat("Speed", 0);
            animLShoe.SetFloat("Speed", 0);
            animRHand.SetFloat("Speed", 0);
            animRShoe.SetFloat("Speed", 0);
        }
        else if (Input.GetAxis("Vertical")>0 || Input.GetAxis("Horizontal")>0 || Input.GetAxis("Vertical")<0 || Input.GetAxis("Horizontal")<0){
            animBody.SetFloat("Speed", 1);
            animLHand.SetFloat("Speed", 1);
            animLShoe.SetFloat("Speed", 1);
            animRHand.SetFloat("Speed", 1);
            animRShoe.SetFloat("Speed", 1);
        }
        
        if(jumps == 0){
            if (Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.JoystickButton0)){
                Debug.Log("hi");
                AudioManager.instance.Play("jump");
                AudioManager.instance.Stop("raymanflying");
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                animBody.SetInteger("Jumps", 1);
                animHead.SetInteger("Jumps", 1);
                animLHand.SetInteger("Jumps", 1);
                animLShoe.SetInteger("Jumps", 1);
                animRHand.SetInteger("Jumps", 1);
                animRShoe.SetInteger("Jumps", 1);
            }
        }
        else if(jumps == 1){
            if(Input.GetKeyDown(KeyCode.JoystickButton0)){
                jumps = 2;
                animBody.SetInteger("Jumps", 2);
                animHead.SetInteger("Jumps", 2);
                animLHand.SetInteger("Jumps", 2);
                animLShoe.SetInteger("Jumps", 2);
                animRHand.SetInteger("Jumps", 2);
                animRShoe.SetInteger("Jumps", 2);
            }
        }
        else if(jumps == 2){
            if (/*Input.GetButton("Jump"))||*/Input.GetKey(KeyCode.JoystickButton0)){
                rb.useGravity=false;
                vel.y = -9.81f/5;
                rb.velocity = vel;
            }
            else if(Input.GetButtonUp("Jump")||Input.GetKeyUp(KeyCode.JoystickButton0)){
                rb.useGravity=true;
                Debug.Log("Gravity");
            }
        }
        if(Input.GetAxis("Fire1") > 0 && Time.time > (lastFiredTime + fistFiringDelay)){
            Debug.Log("Firing");
            lastFiredTime = Time.time;
            if(fists.Count > 0) 
            {
                GameObject fist = fists[0];
                fists.RemoveAt(0);
                fist.SetActive(true);
                if(fist.name.Contains("RightFist")) {
                    fist.transform.position = handR.transform.position;
                    fist.GetComponent<FistScript>().set_origin(handR);
                } else if(fist.name.Contains("LeftFist")) {
                    fist.transform.position = handL.transform.position;
                    fist.GetComponent<FistScript>().set_origin(handL);
                }
                fist.GetComponent<FistScript>().set_direction(transform.forward);
                fist.GetComponent<FistScript>().set_speed(handSpeed);                
            }
        }
        handle_returned_fists();
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Ground"||other.gameObject.tag == "Swamp"){
            //isGrounded = true;
            Debug.Log("bye");
            AudioManager.instance.Stop("raymanflying");
            AudioManager.instance.Play("jumpland");
            jumps = 0;
            rb.useGravity=true;
            Debug.Log("Gravity");
            animBody.SetInteger("Jumps", 0);
            animHead.SetInteger("Jumps", 0);
            animLHand.SetInteger("Jumps", 0);
            animLShoe.SetInteger("Jumps", 0);
            animRHand.SetInteger("Jumps", 0);
            animRShoe.SetInteger("Jumps", 0);
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.tag == "Ground"||other.gameObject.tag == "Swamp"){
            //isGrounded = false;
            jumps++;
        }
    }

 }

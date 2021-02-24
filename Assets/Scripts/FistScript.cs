using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    private Vector3 fistDirection = Vector3.forward;
    private float fistSpeed = 15.0f;
    private GameObject fistOrigin;
    private float fistTravelOutTime = 1.3f;
    private float timeInFlight = 0.0f;
    private bool returningToRayman;

    void OnEnable() 
    {
        timeInFlight = 0.0f;
        fistOrigin = gameObject;
        returningToRayman = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void set_origin(GameObject origin) 
    {
        fistOrigin = origin;
    }

    public void set_direction(Vector3 dir) 
    {
        fistDirection = dir;
    }
    
    public void set_speed(float speed)
    {
        fistSpeed = speed;
    }

    public bool fist_is_returning() 
    {
        return returningToRayman;
    }

    // Update is called once per frame
    void Update()
    {
        timeInFlight += Time.deltaTime;
        move_fist();    
    }

    void move_fist() 
    {
        if(timeInFlight > fistTravelOutTime) 
        { // Uh-oh! We are on our way *back* to "Rayman"
            fistDirection = (fistOrigin.transform.position - transform.position);
            returningToRayman = true;
        }
        transform.Translate(fistDirection * Time.deltaTime * fistSpeed);
    }
}

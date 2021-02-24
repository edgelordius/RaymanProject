using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    public float speed = 10F;
    public float rotationSpeed = 100.0F;

    void Update ()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetButton("Fire1"))
        {
            this.GetComponent<Rigidbody>().AddForce(0, 10, 0);
        }
    }
}

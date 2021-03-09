using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float horizontalSpeed = 5.0f;
    public float verticalSpeed = 5.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Player"){
            yaw += horizontalSpeed * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0, yaw, 0.0f);
        }
        else if(this.gameObject.tag == "MainCamera"){
            yaw += horizontalSpeed * Input.GetAxis("Mouse X");
            pitch += verticalSpeed * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch * -1, yaw, 0.0f);
        }
        /*yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch += verticalSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch * -1, yaw, 0.0f);*/
    }
}

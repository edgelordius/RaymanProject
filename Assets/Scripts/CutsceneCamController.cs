using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamController : MonoBehaviour
{

    GameObject playerCamera;
    GameObject tempHead;
    Animator camAnim;

    GameObject playerVar;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = GameObject.Find("CutsceneCam").GetComponent<Animator>();
        tempHead = GameObject.Find("TempHead");
        playerVar = GameObject.Find("Player");
        playerVar.GetComponent<PlayerMovement>().enabled = false;
        playerVar.GetComponent<CameraMovement>().enabled = false;
        playerCamera = GameObject.Find("Player/Main Camera");
        playerCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(camAnim.GetCurrentAnimatorStateInfo(0).IsName("CutsceneEnd")){
            playerVar.GetComponent<PlayerMovement>().enabled = true;
            playerVar.GetComponent<CameraMovement>().enabled = true;
            playerCamera.SetActive(true);
            tempHead.SetActive(false);
            GameObject cutCam = GameObject.Find("CutsceneCam");
            cutCam.SetActive(false);
        }
    }
}

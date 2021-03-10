using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject helpMenuUI;
    public GameObject pauseFirstButton;
    public GameObject helpFirstButton;

    GameObject m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_EventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton7)) {
            if (IsPaused){
                Resume();
                Debug.Log("Resuming...");
            }
            else {
                Pause();
                Debug.Log("Pausing...");
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<CameraMovement>().enabled = true;
        GameObject.Find("Player/Main Camera").GetComponent<CameraMovement>().enabled = true;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(pauseFirstButton);
        Time.timeScale = 0f;
        IsPaused = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("Player").GetComponent<CameraMovement>().enabled = false;
        GameObject.Find("Player/Main Camera").GetComponent<CameraMovement>().enabled = false;
    }

    public void LoadHelp(){
        helpMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(helpFirstButton);
    }

    public void BackToPaused(){
        helpMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(pauseFirstButton);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void RestartLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Whitebox");
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("Player").GetComponent<CameraMovement>().enabled = true;
        GameObject.Find("Player/Main Camera").GetComponent<CameraMovement>().enabled = true;
    }
}

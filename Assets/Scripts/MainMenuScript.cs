using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject mainMenuUI;
    public GameObject htpMenuUI;
    public GameObject creditsMenuUI;

    public GameObject mainFirstButton;
    public GameObject htpFirstButton;
    public GameObject creditsFirstButton;

    GameObject m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_EventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadHTP(){
        htpMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(htpFirstButton);
    }

    public void LoadCredits(){
        creditsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(creditsFirstButton);
    }

    public void BackToMain(){
        htpMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mainFirstButton);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void StartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Whitebox");
    }
}

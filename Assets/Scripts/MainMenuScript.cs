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
    public GameObject optionsMenuUI;

    public GameObject mainFirstButton;
    public GameObject htpFirstButton;
    public GameObject creditsFirstButton;
    public GameObject optionsFirstButton;

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
        optionsMenuUI.SetActive(true);
        htpMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(htpFirstButton);
    }

    public void LoadCredits(){
        creditsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        htpMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(creditsFirstButton);
    }

    public void LoadOptions()
    {
        optionsMenuUI.SetActive(true);
        htpMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        m_EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(optionsFirstButton);
    }

    public void BackToMain(){
        htpMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
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

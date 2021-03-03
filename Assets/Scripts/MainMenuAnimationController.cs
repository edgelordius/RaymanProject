using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationController : MonoBehaviour
{

    bool IsMainMenu = true;
    bool IsOptionsMenu;
    bool IsCreditsMenu;

    Animator cog1Anim;
    Animator cog2Anim;
    public Animator menuAnim;
    public Animator opAnim;
    public Animator crAnim;

    // Start is called before the first frame update
    void Start()
    {
        cog1Anim = GameObject.Find("Cog1").GetComponent<Animator>();
        cog2Anim = GameObject.Find("Cog2").GetComponent<Animator>();
        menuAnim = GameObject.Find("Canvas/MainMenuPanel/Main").GetComponent<Animator>();
        opAnim = GameObject.Find("Canvas/MainMenuPanel/Options").GetComponent<Animator>();
        crAnim = GameObject.Find("Canvas/MainMenuPanel/Credits").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftArrowPressed(){
        if(IsMainMenu == true){
            cog1Anim.Play("Base Layer.Cog1LeftArrowOnce");
            cog2Anim.Play("Base Layer.Cog2LeftArrowOnce");
            menuAnim.Play("Base Layer.MenuMoveRight");
            crAnim.Play("Base Layer.CrMoveRightFromLeft");
            IsMainMenu = false;
            IsCreditsMenu = true;
        }
        else if(IsOptionsMenu == true){
            cog1Anim.Play("Base Layer.Cog1LeftArrowThrice");
            cog2Anim.Play("Base Layer.Cog2LeftArrowThrice");
            opAnim.Play("Base Layer.OpMoveRight");
            menuAnim.Play("Base Layer.MenuMoveRightFromLeft");
            IsOptionsMenu = false;
            IsMainMenu = true;
        }
        else if(IsCreditsMenu == true){
            cog1Anim.Play("Base Layer.Cog1LeftArrowTwice");
            cog2Anim.Play("Base Layer.Cog2LeftArrowTwice");
            crAnim.Play("Base Layer.CrMoveRight");
            opAnim.Play("Base Layer.OpMoveRightFromLeft");
            IsCreditsMenu = false;
            IsOptionsMenu = true;
        }
    }
    public void RightArrowPressed(){
        if(IsMainMenu == true){
            cog1Anim.Play("Base Layer.Cog1RightArrowOnce");
            cog2Anim.Play("Base Layer.Cog2RightArrowOnce");
            menuAnim.Play("Base Layer.MenuMoveLeft");
            opAnim.Play("Base Layer.OpMoveLeftFromRight");
            IsMainMenu = false;
            IsOptionsMenu = true;
        }
        else if(IsOptionsMenu == true){
            cog1Anim.Play("Base Layer.Cog1RightArrowTwice");
            cog2Anim.Play("Base Layer.Cog2RightArrowTwice");
            opAnim.Play("Base Layer.OpMoveLeft");
            crAnim.Play("Base Layer.CrMoveLeftFromRight");
            IsOptionsMenu = false;
            IsCreditsMenu = true;
        }
        else if(IsCreditsMenu == true){
            cog1Anim.Play("Base Layer.Cog1RightArrowThrice");
            cog2Anim.Play("Base Layer.Cog2RightArrowThrice");
            crAnim.Play("Base Layer.CrMoveLeft");
            menuAnim.Play("Base Layer.MenuMoveLeftFromRight");
            IsCreditsMenu = false;
            IsMainMenu = true;
        }
    }

    public void OpenOptionsAnim(){
        IsMainMenu = false;
        IsOptionsMenu = true;
        cog1Anim.Play("Base Layer.Cog1RightArrowOnce");
        cog2Anim.Play("Base Layer.Cog2RightArrowOnce");
        menuAnim.Play("Base Layer.MenuMoveLeft");
        opAnim.Play("Base Layer.OpMoveLeftFromRight");
    }

    public void OpenCreditsAnim(){
        IsMainMenu = false;
        IsCreditsMenu = true;
        cog1Anim.Play("Base Layer.Cog1GoToCredits");
        cog2Anim.Play("Base Layer.Cog2GoToCredits");
        menuAnim.Play("Base Layer.MenuMoveLeft");
        crAnim.Play("Base Layer.CrMoveLeftFromRight");
    }

    public void BackToMainFromOptions(){
        IsOptionsMenu = false;
        IsMainMenu = true;
        cog1Anim.Play("Base Layer.Cog1LeftArrowOnce");
        cog2Anim.Play("Base Layer.Cog2LeftArrowOnce");
        opAnim.Play("Base Layer.OpMoveRight");
        menuAnim.Play("Base Layer.MenuMoveRightFromLeft");
    }

    public void BackToMainFromCredits(){
        IsCreditsMenu = false;
        IsMainMenu = true;
        cog1Anim.Play("Base Layer.Cog1BTMCredits");
        cog2Anim.Play("Base Layer.Cog2BTMCredits");
        crAnim.Play("Base Layer.CrMoveRight");
        menuAnim.Play("Base Layer.MenuMoveRightFromLeft");
    }
}

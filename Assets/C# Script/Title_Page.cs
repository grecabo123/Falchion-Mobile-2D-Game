using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title_Page : MonoBehaviour
{

    public Button Play;
    public Button Option;
    public Button Exit;

    public GameObject Play_btn;
    public GameObject Exit_btn;
    public GameObject Option_btn;
    public GameObject panel_for_buttons;

    public GameObject credits;

    public GameObject Menu_option;

    public GameObject LoadScene;
    public GameObject Menu_Title;

    public void Option_Application()
    {
        panel_for_buttons.SetActive(false);
        Menu_option.SetActive(true);
    }
    public void Play_Application()
    {
        Menu_Title.SetActive(false);
        LoadScene.SetActive(true);
        //SceneManager.LoadScene(2);
    }

    public void Exit_Application()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void Credits()
    {
        credits.SetActive(true);
        Menu_option.SetActive(false);
    }

    public void Credits_Back_button()
    {
        credits.SetActive(false);
        Menu_option.SetActive(true);
    }
    public void Main_Menu()
    {
        panel_for_buttons.SetActive(true);
        Menu_option.SetActive(false);
    }

    
}

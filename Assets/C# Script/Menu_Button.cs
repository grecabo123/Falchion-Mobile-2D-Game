using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour
{

    protected Player ply;

    public GameObject restart;
    public GameObject Return_town;
    public GameObject exit;
    public GameObject Panel_btn;
    public GameObject loading;
    public GameObject Game_design;

    
    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(4);
        Panel_btn.SetActive(false);
        
    }

    public void Return_Town()
    {
        loading.SetActive(true);
        Game_design.SetActive(false);
        Destroy(ply);
    }

    public void Exit_Application()
    {
        Application.Quit();
        Debug.Log("Quit");
        Panel_btn.SetActive(false);
    }
}

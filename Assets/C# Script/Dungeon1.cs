using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Dungeon1 : MonoBehaviour
{


    public GameObject Quest1;
    public GameObject Game_design;
    public GameObject panel;

    protected Boss_alert boss;

    

    void Start()
    {
        panel.SetActive(true);
        Game_design.SetActive(true);
        Quest1.SetActive(false);
        boss = FindObjectOfType<Boss_alert>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("no fire");
            Popup_Message();
           
        }
    }

   



    public void Popup_Message()
    {
        
        Quest1.SetActive(true);
       
    }

    public void Cancel_Quest()
    {
        Quest1.SetActive(false);
    }

}

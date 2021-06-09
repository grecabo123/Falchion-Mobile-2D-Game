using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Town : MonoBehaviour
{
   

    public AudioSource src;
    public GameObject game_design;
    public GameObject town_modal;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Return_Town();
        }
    }

    public void Return_Town()
    {
        town_modal.SetActive(true);
    }


}

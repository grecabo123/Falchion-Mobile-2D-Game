using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Instruction : MonoBehaviour
{
    [SerializeField]
    public GameObject controller;
    bool ispause = false;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Controller_info();
        }
    }

    public void Controller_info()
    {
        controller.SetActive(true);
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(4);
    }

    public void Modal_info()
    {
        controller.SetActive(false);
    }

  
    

}

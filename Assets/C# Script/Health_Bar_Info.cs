using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar_Info : MonoBehaviour
{
    [SerializeField]
    public GameObject health;
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
        health.SetActive(true);
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(4);
    }
    public void Modal_info()
    {
        health.SetActive(false);
    }
}

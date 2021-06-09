using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    public GameObject npc;
    bool ispause = false;


    void Start()
    {
        npc.SetActive(false);
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
        npc.SetActive(true);
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(4);
    }

    public void Modal_info()
    {
        npc.SetActive(false);
    }
}

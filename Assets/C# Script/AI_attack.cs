using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_attack : MonoBehaviour
{

    protected Enemy alt;


    void Start()
    {
        alt = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("daw");
            
        }
    }
}

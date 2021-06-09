using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Farmer_NPC : MonoBehaviour
{
    BoxCollider2D box;
    protected bool up = false;
    public GameObject quest1;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

  
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talk();
        }
    }


    public void talk()
    {
        
    }

    public void Up_pressed(bool _up)
    {
        up = _up;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep_Lava : MonoBehaviour
{

    public GameObject menu;
    public GameObject ply;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ply.SetActive(false);
            menu.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField]
    public GameObject bag;
    bool ispause = false;


    void Start()
    {
        bag.SetActive(false);
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
        bag.SetActive(true);
        StartCoroutine(Fadeout());
    }

    IEnumerator Fadeout()
    {
        yield return new WaitForSeconds(4);
    }

    public void Modal_info()
    {
        bag.SetActive(false);
    }
}

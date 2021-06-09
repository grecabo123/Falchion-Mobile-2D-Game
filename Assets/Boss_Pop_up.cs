using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Pop_up : MonoBehaviour
{

    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            boss.SetActive(true);
        }
    }


}

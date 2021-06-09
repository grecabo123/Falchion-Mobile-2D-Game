using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    protected Player ply;

    // Start is called before the first frame update
    void Start()
    {
        ply = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetLife()
    {
       
        
            Destroy(gameObject);
        
        
    }
}

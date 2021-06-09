using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    //Enemy body dmg
    int body = 5;
   
    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            
        }
    }
}


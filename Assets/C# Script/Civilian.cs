using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    Animator animate;
    SpriteRenderer spr;
    Rigidbody2D rigid;

    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;

    private float waitTime;
    private int randomSpot;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        animate = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        animate.Play("civilian");
        
        

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {

            if (waitTime <= 0)
            {

                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                if (randomSpot == 0)
                {

                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (randomSpot == 1)
                {

                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

            }
            else
            {
                waitTime -= Time.deltaTime;

            }

        }
    }
}

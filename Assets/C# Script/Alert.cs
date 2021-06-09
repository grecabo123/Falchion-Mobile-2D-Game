using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    [SerializeField]
    Transform player;
    BoxCollider2D box;
    Rigidbody2D rigid;
    Animator animate;
    protected Enemy AI;

    public int maxhealth = 10;
    int currenthealth;

    private float speed = 20;

    [SerializeField]
    private float agrorange;
    bool attacking;
    bool isdeath;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        AI = FindObjectOfType<Enemy>();
        isdeath = false;

    }

    
    private void FixedUpdate()
    {
        float attack = 15f;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        float dist = Vector2.Distance(transform.position, player.position);
        Debug.DrawRay(transform.position, forward, Color.green);
        //print(dist);
        
        if(dist < agrorange)
        {
            Debug.Log("Alert");
            Chase_Player();
           
        }
        else
        {
            Patrol();
        }
    }

    void Chase_Player()
    {
        if(transform.position.x < player.position.x && !isdeath)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.velocity = new Vector2(20, rigid.velocity.y);
            if (!isdeath)
            {
                isdeath = true;
                animate.Play("Lizard_death");
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }
        }
        else if (transform.position.x > player.position.x && !isdeath)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
           rigid.velocity = new Vector2(-20 , rigid.velocity.y);
            if (!isdeath)
            {
                isdeath = true;
                animate.Play("Lizard_death");
                rigid.velocity = new Vector2(0, rigid.velocity.y);
            }
        }
        else
        {
            animate.Play("Lizard_death");
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }

    }

    void Patrol()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
        StartCoroutine(Patrol_Ai());
    }

    IEnumerator Patrol_Ai()
    {
        yield return new WaitForSeconds(2);
        AI.Walk_lizard();
    }

   
}

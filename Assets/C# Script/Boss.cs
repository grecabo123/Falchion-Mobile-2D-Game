using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Components
    Animator animate;
    Rigidbody2D rigid;
    SpriteRenderer spr;
    BoxCollider2D box;

    public int health = 200;
    int currenthealt;
    //Materials
    private Material mats_white;
    private Material mat_default;

    [Header("Player Damage Info")]
    int normal_hit_damage = 3;
    int jump_attack_damage = 3;
    int line_drive_damage = 5;
    int red_slash_damage = 7;

    [Header("Ground")]
    [SerializeField]
    Transform groundchk;
    [SerializeField]
    public LayerMask layer;
    public bool isGrounded;

    [Header("Components for Points")]
    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;
    private float waitTime;
    private int randomSpot;

    public bool IsbossAtk;
    bool isdeath;

    public GameObject Portal;




    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
       // mats_white = Resources.Load("whiteflash", typeof(Material)) as Material;
        currenthealt = health;
        Portal.SetActive(false);

    }


    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundchk.position, 3f, layer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


        //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //if (isGrounded)
        //    if (!IsbossAtk)
        //    {
        //        animate.Play("Demon_walk");
        //    }


        //if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        //{

        //    if (waitTime <= 0)
        //    {
        //        randomSpot = Random.Range(0, moveSpots.Length);
        //        waitTime = startWaitTime;
        //        if (randomSpot == 0)
        //        {

        //            transform.rotation = Quaternion.Euler(0, 0, 0);
        //        }
        //        else if (randomSpot == 1)
        //        {

        //            transform.rotation = Quaternion.Euler(0, 180, 0);
        //        }

        //    }
        //    else
        //    {
        //        waitTime -= Time.deltaTime;

        //    }

        //}
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.CompareTag("normal_hit"))
    //    {
    //        currenthealt -= normal_hit_damage;
    //        animate.Play("Demon_hurt");
    //       spr.material = mats_white;
    //        SoundManager.PlaySoundsEnemy("Hurt");
    //        if (currenthealt <= 0) 
    //        {

    //            currenthealt = 0;
    //            Death();
    //        }
    //    }
    //}

    //void Death()
    //{
    //    if(isGrounded && !isdeath)
    //    {
    //        isdeath = true;
    //        animate.Play("Demon_death");
    //        GetComponent<Collider2D>().enabled = false;
    //        this.enabled = false;
    //        StartCoroutine(FadeOut());
    //    }

    //}

    //IEnumerator FadeOut()
    //{
    //    yield return new WaitForSeconds(3);
    //    //add sfx music for dead
    //    Destroy(gameObject);
    //    SoundManager.PlaySoundsEnemy("Death");
    //    Portal.SetActive(true);
    //}

    //private void Reset_Materials()
    //{
    //    spr.material = mat_default;
    //}


    public void Invisible()
    {
        if (box.isTrigger == false)
        {
            box.isTrigger = true;
            StartCoroutine(Walk_through());
        }
    }

    IEnumerator Walk_through()
    {
        yield return new WaitForSeconds(2);
        box.isTrigger = false;
    }






}

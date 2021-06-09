using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    protected Player ply;
    protected ProgressBar Pb;
    protected Alert alt;
    //health for mobs
    public int maxhealth = 10;
    int currenthealth;

    //Components
    Animator animate;
    SpriteRenderer spr;
    Rigidbody2D rigid;
    BoxCollider2D box;
    Color default_color;

    //Materials
    private Material mats_white;
    private Material mat_default;

    public float speed;
    public float startWaitTime;
    public Transform[] moveSpots;

    private float waitTime;
    private int randomSpot;

    [SerializeField]
    Transform groundchk;

    public bool isGrounded;
    public bool lizard_attack;
    public LayerMask layer;

    //check if death
    public bool isdeath;
    [SerializeField]
    public float time_fade_out;
    public float holding_time;


    //Enemy Lizard Dmg
    int body_dmg = 20;
    public bool hurt;
    float enemy_attack = 0f;
    float atk_speed = 1f;




    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        animate = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        alt = FindObjectOfType<Alert>();
        mats_white = Resources.Load("whiteflash", typeof(Material)) as Material;
        mat_default = spr.material;
        currenthealth = maxhealth;
        isdeath = false;
        holding_time = time_fade_out;
        default_color = spr.color;
    }

    private void FixedUpdate()
    {

        //float dist = Vector2.Distance(transform.position, player.position);

        if (Physics2D.OverlapCircle(groundchk.position, 2f, layer))
        {
            isGrounded = true;
        }
        else
        {
            if (!lizard_attack && !isdeath)
            {
                isGrounded = false;
            }

        }
    }

    void Update()
    {
        Walk_lizard();
    }

    public void Walk_lizard()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (isGrounded)
            if (!lizard_attack)
            {
                animate.Play("Lizard_walk");
            }


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

    //Lizard is attacking

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag.Equals("Player"))
    //    {
            
    //        if (isGrounded)
    //            if (!lizard_attack && isGrounded && !hurt)
    //            {
    //                hurt = true;
    //                lizard_attack = true;
    //                animate.Play("Lizard_attack");
    //                Invoke("attack", .5f);
    //            }
    //    }
    //}


    

    //Normal Attack
    public void Normal_attack_dmg(int normal_hit)
    {
        currenthealth -= normal_hit;
        animate.Play("Lizard_hurt");
        spr.material = mats_white;
        SoundManager.PlaySoundsEnemy("Hurt");
        Invoke("Default_materials", .1f);
        
        if (currenthealth <= 0 && isGrounded && !isdeath)
        {
            currenthealth = 0;
            isdeath = true;
            animate.Play("Lizard_death");
            
            rigid.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            StartCoroutine(FadeOut());
        }
       
    }

    private void Default_materials()
    {
        spr.material = mat_default;
    }

    public void Jump_attack(int jump)
    {
        currenthealth -= jump;
        animate.Play("Lizard_hurt");
        SoundManager.PlaySoundSFX("hurt_enemy");
        if (currenthealth <= 0 && isGrounded && !isdeath)
        {
            currenthealth = 0;
            isdeath = true;
            animate.Play("Lizard_death");
            rigid.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            StartCoroutine(FadeOut());
        }
    }


    //skills
    public void Stike_skill(int strike)
    {
        currenthealth -= strike;
        animate.Play("Lizard_hurt");
        SoundManager.PlaySoundSFX("hurt_enemy");
        if (currenthealth <= 0 && isGrounded && !isdeath)
        {
            currenthealth = 0;
            isdeath = true;
            animate.Play("Lizard_death");
            rigid.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            StartCoroutine(FadeOut());
        }
    }

    public void Red_slash(int red)
    {
        currenthealth -= red;
        animate.Play("Lizard_hurt");
        SoundManager.PlaySoundSFX("hurt_enemy");
        if (currenthealth <= 0 && isGrounded && !isdeath)
        {
            currenthealth = 0;
            isdeath = true;
            animate.Play("Lizard_death");
            rigid.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            StartCoroutine(FadeOut());
        }
    }


    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


    //Invisible when player collide to enemy

    public void Invi()
    {
        if(box.isTrigger == false)
        {
            Debug.Log("12");
            box.isTrigger = true;
            StartCoroutine(walk());
        }
    }

    IEnumerator walk()
    {
        yield return new WaitForSeconds(2);
        box.isTrigger = false;
    }
 

}


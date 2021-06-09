using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_alert : MonoBehaviour
{
    [SerializeField]
    Transform player;
    BoxCollider2D box;
    Rigidbody2D rigid;
    Animator animate;
    SpriteRenderer spr;
    protected Boss AI;

    protected ProgressBar pb;
    protected Player ply;

    [Header("Player Damage Info")]
    int normal_hit_damage = 3;
    int jump_attack_damage = 3;
    int line_drive_damage = 5;
    int red_slash_damage = 7;

    public int health = 200;
    int currenthealt;
    //Materials
    private Material mats_white;
    private Material mat_default;

    [SerializeField]
    private float agrorange;

    [SerializeField]
    Transform groundchk;
    public LayerMask layer;

    bool isGrounded;

    public GameObject Portal;
    bool isdeath;
    bool attacking;
    private float wait = 2;

    public float waiting_time;
    public float time = 5;

    [SerializeField]
    GameObject boss_spear;

    public GameObject heart;
    public GameObject town;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        AI = FindObjectOfType<Boss>();
        spr = GetComponent<SpriteRenderer>();
        currenthealt = health;
        pb = FindObjectOfType<ProgressBar>();
        pb.BarValue = currenthealt;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        ply = FindObjectOfType<Player>();
    }


    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundchk.position, 3f, layer))
        {
            isGrounded = true;
        }
        else
        {
            if(!attacking)
            isGrounded = false;
        }


        float attack = 15f;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        float dist = Vector2.Distance(transform.position, player.position);
        Debug.DrawRay(transform.position, forward, Color.green);
       //

        if (dist < agrorange)
        {
            Debug.Log("Alert");
            Chase_Player();

        }
        else if(dist > agrorange)
        {
            attack_ai();
        }
       
    }


    void attack_ai()
    {
        waiting_time -= Time.deltaTime;
        if(waiting_time <= 0 && !attacking && !isdeath)
        {
            attacking = true;
            animate.Play("Demon_attack");
            Invoke("Reset", .1f);
            waiting_time = time;
            if (attacking)
            {
                boss_spear.SetActive(false);
                StartCoroutine(Disable_spear());
            }
        }
        
       
    }

    IEnumerator Disable_spear()
    {
        yield return new WaitForSeconds(2);
        boss_spear.SetActive(true);
    }

    private void Reset()
    {
        attacking = false;
    }

    void Chase_Player()
    {
        if (transform.position.x <= player.position.x)
        {
            if (isGrounded)

                if (!attacking)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    rigid.velocity = new Vector2(20, rigid.velocity.y);
                    animate.Play("Demon_walk");
                    if (!isdeath)
                    {
                        isdeath = false;
                        StartCoroutine(Rest_Enemy());
                    }

                }
        }
        else if (transform.position.x >= player.position.x)
        {
            if (isGrounded)

                if (!attacking)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    rigid.velocity = new Vector2(-20, rigid.velocity.y);
                    animate.Play("Demon_walk");
                    if (!isdeath)
                    {
                        isdeath = false;
                        StartCoroutine(Rest_Enemy());
                    }
                }
        }
      
    }


    public void idle()
    {
        if (isGrounded)
            if (!attacking)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                animate.Play("Demon_idle");
                StartCoroutine(Rest_Enemy());
            }
    }

    IEnumerator Rest_Enemy()
    {
        
            yield return new WaitForSeconds(3);
            attack_ai();
      
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("normal_hit"))
        {
            currenthealt -= normal_hit_damage;
            animate.Play("Demon_hurt");
            // spr.material = mats_white;
            SoundManager.PlaySoundsEnemy("Hurt");
            if (currenthealt <= 0)
            {

                currenthealt = 0;
                Death();
            }

        }
        else if (coll.CompareTag("Strike"))
        {
            currenthealt -= line_drive_damage;
            animate.Play("Demon_hurt");
            // spr.material = mats_white;
            SoundManager.PlaySoundsEnemy("Hurt");
            if (currenthealt <= 0)
            {

                currenthealt = 0;
                Death();
            }
        }
        else if (coll.CompareTag("jump_attack"))
        {
            currenthealt -= jump_attack_damage;
            animate.Play("Demon_hurt");
            // spr.material = mats_white;
            SoundManager.PlaySoundsEnemy("Hurt");
            if (currenthealt <= 0)
            {

                currenthealt = 0;
                Death();
            }
        }
        else if (coll.CompareTag("red_slash"))
        {
            currenthealt -= red_slash_damage;
            animate.Play("Demon_hurt");
            // spr.material = mats_white;
            SoundManager.PlaySoundsEnemy("Hurt");
            if (currenthealt <= 0)
            {

                currenthealt = 0;
                Death();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("normal_hit"))
        {
            Debug.Log("dwa");
        }
        else if (coll.CompareTag("Strike"))
        {
            
        }
        else if (coll.CompareTag("jump_attack"))
        {
            
        }
        else if (coll.CompareTag("red_slash"))
        {
           
        }
    }

    public void Death()
    {
        if (isGrounded && !isdeath)
        {
            isdeath = true;
            animate.Play("Demon_death");
            SoundManager.PlaySoundsEnemy("Death");
            rigid.velocity = new Vector2(0, 0);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            StartCoroutine(FadeOut());

        }

    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3);
        //add sfx music for dead
        Destroy(gameObject);
        heart.SetActive(true);
        
        Portal.SetActive(true);
        
    }

    private void Reset_Materials()
    {
        spr.material = mat_default;
    }


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

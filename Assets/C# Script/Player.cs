using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI txt;
    int coin_counter;

    //Jump class
    protected Jump jump_btn;
    protected bool jump;
    protected Menu_Panel menu_p;

    protected Boss boss;
    protected Enemy mobs;
    protected Farmer_NPC npc;
    protected Boss_alert boss_alert;

    //health
    public ProgressBar Pb;

    [Header("Lizard Damage Info")]
    public int Body_Damage = 3;
    public int Spear_Damage = 4;

    [Header("Boss Damage")]
    public int Body_Boss = 3;
    public int Boss_weapon = 2;


    //Controller
    protected bool up = false;
    protected bool down = false;
    protected bool left = false;
    protected bool right = false;

    //Materials
    private Material mats_white;
    private Material mat_default;

    //Components
    Animator animate;
    Rigidbody2D rigid;
    SpriteRenderer spr;
    Transform trn;
    BoxCollider2D box;

    //boolean for attacking
    public bool isattacking;
    public bool jump_attack;
    public bool line_drive;
    public bool red_sword;

    //groundchk
    [SerializeField]
    Transform groundchk;
    public bool isGrounded;

    //Layer for Ground
    public LayerMask layer;
    public float time;

    //layer for enemy
    [Header("Hit Damage")]
    [SerializeField]
    Transform normal_atk_pos;
    public LayerMask enemy;

    //Object Dmg from Player
    public GameObject normal_hit;
    public GameObject jump_attack_hit;
    public GameObject line_drive_hit;
    public GameObject red_slash_hit;

    //damage
    int normal_hit_damage = 3;
    int jump_attack_damage = 3;
    int line_drive_damage = 5;
    int red_slash_damage = 7;

    //health for Player

    public int maxhealth = 100;
    int currenthealth;

    float take_dmg_time = 0f;
    float atk_speed = 1f;
    //coin count
    int coin_count = 0;

    //Life Object
    [SerializeField]
    public GameObject life;
    int life_player = 8;


    
    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        mobs = FindObjectOfType<Enemy>();
        trn = GetComponent<Transform>();
        boss = FindObjectOfType<Boss>();
        npc = FindObjectOfType<Farmer_NPC>();
        box = GetComponent<BoxCollider2D>();
        currenthealth = maxhealth;
        Pb = FindObjectOfType<ProgressBar>();
        Pb.BarValue = currenthealth;
        mats_white = Resources.Load("whiteflash", typeof(Material)) as Material;
        mat_default = spr.material;
        menu_p = FindObjectOfType<Menu_Panel>();
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundchk.position, 3f, layer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            if(!isattacking && !jump_attack && !red_sword)
            {
                animate.Play("Player_jump");
            }
           
        }
    }

    void Update()
    {
        PlayerControl();
        Player_Jump();
        Player_attack();
        Player_jump_attack();
        Player_Line_drive();
        Player_sword_red();
    }



    void PlayerControl()
    {
        if (up == true)
        {
            
        }
        else if (down == true || Input.GetKey("s"))
        {
            if(isGrounded && !isattacking && !line_drive && !red_sword)
            animate.Play("Player_crouch");
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            if (right == true || Input.GetKey("d"))
            {
                
                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded && !isattacking && !line_drive && !red_sword)
                {
                    rigid.velocity = new Vector2(15, 65);
                }
            }
            else if (left == true || Input.GetKey("a"))
            {
                
                transform.rotation = Quaternion.Euler(0, 180, 0);
                if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded && !isattacking && !line_drive && !red_sword)
                {
                    rigid.velocity = new Vector2(-15, 65);
                }
            }
        }
        else if (right == true || Input.GetKey("d"))
        {
                rigid.velocity = new Vector2(30, rigid.velocity.y);
                if (isGrounded && !isattacking && !line_drive && !red_sword)
                    animate.Play("Player_run");
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (left == true || Input.GetKey("a"))
        {
                rigid.velocity = new Vector2(-30, rigid.velocity.y);
                if (isGrounded && !isattacking && !line_drive && !red_sword)
                    animate.Play("Player_run");
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            if(isGrounded)
                if (!isattacking && !line_drive && !red_sword)
                {
                    animate.Play("Player_idle");
                }
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
 }

    void Player_Jump()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
        {
            animate.Play("Player_jump");
            rigid.velocity = new Vector2(rigid.velocity.x, 70);
        }

    }
    void Player_attack()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1") && isGrounded && !isattacking && !line_drive)
        {
            SoundManager.PlaySoundSFX("air_slash");
            normal_hit.SetActive(false);
            isattacking = true;
            animate.Play("Player_attack");
            normal_hit.SetActive(true);
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            Invoke("Reset", .5f);
        }
    }

    void Player_jump_attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !jump_attack)
        { 
            if (!isGrounded)
            {
                SoundManager.PlaySoundSFX("air_slash");
                jump_attack_hit.SetActive(false);
                jump_attack = true;
                animate.Play("Player_jump_attack");
                jump_attack_hit.SetActive(true);
                Invoke("jump_atk", .5f);
            }
          
        }
    }

   public void Player_Line_drive()
    {
        Vector3 flip = transform.localScale;
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !line_drive && isGrounded)
        {
            line_drive_hit.SetActive(false);
            line_drive = true;
            animate.Play("Player_Line_Drive");
            line_drive_hit.SetActive(true);
            rigid.velocity = new Vector2(40, rigid.velocity.y);
            Invoke("Reset", .5f);
        }
    }
  public  void Player_sword_red()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire3") && !red_sword && isGrounded)
        {
            red_slash_hit.SetActive(false);
            red_sword = true;
            animate.Play("Player_sword_red");
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            Invoke("Sword_red_Reset", .6f);
            red_slash_hit.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            Enemy enemy = coll.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Normal_attack_dmg(normal_hit_damage);
            }
            else if (enemy != null)
            {
                enemy.Jump_attack(jump_attack_damage);
            }
            else if (enemy != null)
            {
                enemy.Stike_skill(line_drive_damage);
            }
            else if (enemy != null)
            {
                enemy.Red_slash(red_slash_damage);
            }
        }
        if (coll.CompareTag("Coin"))
        {
            Coin coin = coll.transform.GetComponent<Coin>();
            if(coin != null)
            {
                coin.GetCoin();
                coin_count++;
                Debug.Log(coin_count);
                txt.SetText(coin_count.ToString());
               
            }
        }
        else if (coll.CompareTag("Lava"))
        {
            Lava lava = coll.transform.GetComponent<Lava>();
            if(lava != null)
            {
                lava.Lava_dmg(currenthealth);
            }
        }
        else if (coll.CompareTag("Life"))
        {
            Life lif = coll.transform.GetComponent<Life>();
            if(lif != null)
            {

                if (currenthealth < maxhealth)
                {
                    currenthealth += life_player;
                    lif.GetLife();
                    Pb.BarValue = currenthealth;
                }
                else if (currenthealth > maxhealth)
                {
                    currenthealth = 100;
                    Pb.BarValue = maxhealth;
                    lif.GetLife();
                }
            }
        }
        else if (coll.CompareTag("Boss_spear"))
        {
            spr.material = mats_white;
            Invoke("Reset_white", .1f);
            rigid.AddForce(Vector2.up * 20);
            if (currenthealth >= 0)
            {
                currenthealth -= Boss_weapon;
                SoundManager.PlaySoundSFX("hurt_enemy");
                Pb.BarValue = currenthealth;
                if (currenthealth <= 0)
                {
                    currenthealth = 0;
                    Death();
                }
            }
        }
       
    }

  

    //Collision For Mobs & Bosses
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Enemy"))
        {
            spr.material = mats_white;
            Invoke("Reset_white", .1f);
            if (currenthealth >= 0)
            {
                currenthealth -= Body_Damage;
                mobs.Invi();
                SoundManager.PlaySoundSFX("Player_hurt");
                rigid.velocity = new Vector2(20, rigid.velocity.y);
                Pb.BarValue = currenthealth;
            }
            else if (currenthealth <= 0)
            {
                currenthealth = 0;
                Death();

            }

        }
        else if (coll.gameObject.tag.Equals("Boss"))
        {
            spr.material = mats_white;
            Invoke("Reset_white", .1f);
            if (currenthealth >= 0)
            {
                currenthealth -= Body_Boss;
                boss.Invisible();
                SoundManager.PlaySoundSFX("hurt_enemy");
                rigid.velocity = new Vector2(20, rigid.velocity.y);
                Pb.BarValue = currenthealth;
                if (currenthealth <= 0)
                {
                    currenthealth = 0;
                    Death();
                }
            }
        }
    }

    //current health 
    public void Current_Health(int health)
    {
        currenthealth = health;
        
        if (currenthealth <= 0)
        {
            currenthealth = 0;
            Death();
        }
        else if(currenthealth > maxhealth)
        {
            currenthealth = 100;
        }
    }

   public void Death()
    {
       
        this.enabled = false;
        if(isGrounded)
            animate.Play("Player_stop");

        StartCoroutine(Player_death());
    }

    IEnumerator Player_death()
    {
        //GetComponent<Collider2D>().enabled = false;
        
        yield return new WaitForSeconds(1);
        SoundManager.PlaySoundsEnemy("Hurt");
        Destroy(gameObject);
       
        Menu();
        boss_alert.idle();

    }

    public void Menu()
    {
        menu_p.Display();
    }
  

    public void Restart()
    {

    }

    public void Return_Town()
    {

    }

    public void Pause()
    {

    }

    private void Reset_white()
    {
        spr.material = mat_default;
    }
    private void Reset()
    {
        line_drive = false;
        isattacking = false;
    }
    private void jump_atk()
    {
        jump_attack = false;
    }
    private void Sword_red_Reset()
    {
        red_sword = false;
    }


    private void Normal_jump()
    {
        jump = false;
    }

    public void up_pressed(bool _up)
    {
        up = _up;
    }

    public void down_pressed(bool _down)
    {
        down = _down;
    }
    public void left_pressed(bool _left)
    {
        left = _left;
    }
    public void right_pressed(bool _right)
    {
        right = _right;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    protected Player ply;

    public ProgressBar Pb;

    Animator animate;
    Rigidbody2D rigid;

    //lava dmg
    int heat = 3;

    void Start()
    {
        animate = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        Pb = FindObjectOfType<ProgressBar>();
    }



    public void Lava_dmg(int life_player)
    {
        life_player -= heat;
        SoundManager.PlaySoundSFX("Hurt");
        StartCoroutine(Lava_update(life_player));
    }


    IEnumerator Lava_update(int life)
    {
        yield return new WaitForSeconds(2);
        Pb.BarValue = life;
        New_Update_Life(life);
       
    }


    public void New_Update_Life(int player)
    {
        ply = FindObjectOfType<Player>();
        ply.Current_Health(player);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Ground"))
        {
            
        }
    }
}

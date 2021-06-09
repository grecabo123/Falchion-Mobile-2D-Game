using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip running, red_slash, normal_slash, jump_slash, Coin, hurt,enemy_hurt,death;
    static AudioSource src;

    // Start is called before the first frame update
    void Start()
    {
        //Player
        normal_slash = Resources.Load<AudioClip>("sword_slash");
        Coin = Resources.Load<AudioClip>("Coin");
        jump_slash = Resources.Load<AudioClip>("air_slash");
        hurt = Resources.Load<AudioClip>("Player_hurt");



        //For Enemy
        enemy_hurt = Resources.Load<AudioClip>("Hurt");
        death = Resources.Load<AudioClip>("Death");

        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player
    public static void PlaySoundSFX(string clip)
    {
        switch (clip)
        {
            case "sword_slash":
                src.PlayOneShot(normal_slash);
                break;
            case "Coin":
                src.PlayOneShot(Coin);
                break;
            case "air_slash":
                src.PlayOneShot(jump_slash);
                break;
            case "Player_hurt":
                src.PlayOneShot(hurt);
                break;
        }
    }


    //Enemy
    public static void PlaySoundsEnemy(string name)
    {
        switch (name)
        {
            case "Hurt":
                src.PlayOneShot(enemy_hurt);
                break;
            case "Death":
                src.PlayOneShot(death);
                break;
        }
    }
}

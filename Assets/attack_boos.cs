using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_boos : MonoBehaviour
{

    Animator animate;
    bool attacking;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            attacking = true;
            int index = UnityEngine.Random.Range(1, 3);
            animate.Play("Demon_attack" + index);
            Invoke("Reset", .5f);
        }
    }
    public void Reset()
    {
        attacking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Teleport : MonoBehaviour
{
    public GameObject Portal,Player;

    protected bool up = false;

    [SerializeField]
    Transform door1;

    BoxCollider2D box;
    private float dir;


    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dir = CrossPlatformInputManager.GetAxisRaw("Vertical");
        //Mathf.Abs(dir);
        Debug.Log(dir);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Mathf.Abs(dir) >= 0)
        {

                StartCoroutine(Magic_door());
                Player.SetActive(false);
                Debug.Log("AWD");
        }
    }

    IEnumerator Magic_door()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(door1.transform.position.x, door1.transform.position.y);
        Player.SetActive(true);
    }

    public void up_pressed(bool _up)
    {
        up = _up;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Panel : MonoBehaviour
{

    public GameObject Menu_btn;


    // Start is called before the first frame update
    void Start()
    {
        Menu_btn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display()
    {
        Menu_btn.SetActive(true);
    }
}

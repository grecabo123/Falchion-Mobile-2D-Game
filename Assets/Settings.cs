using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField]
    public GameObject skill1;
    [SerializeField]
    public GameObject skill;
    [SerializeField]
    public GameObject modal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Modal()
    {
        modal.SetActive(true);
    }

    public void center()
    {
        skill1.SetActive(true);
        skill.SetActive(false);
        modal.SetActive(false);
    }

    public void right_corner()
    {
        skill1.SetActive(false);
        skill.SetActive(true);
        modal.SetActive(false);
    }
}

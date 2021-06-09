using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [HideInInspector]
    public bool jump;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jump = false;
    }
}

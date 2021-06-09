using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Skill : MonoBehaviour
{

    [Header("Ability 1")]
    public Image btn;
    public Button line;
    public float cooldown = 10;
    bool iscooldown = false;

    private Player ply;


    // Start is called before the first frame update
    void Start()
    {
        btn.fillAmount = 0;
        ply = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Line_skill();
    }

    private void Line_skill()
    {
        if (iscooldown == false && CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            ply.Player_Line_drive();
            iscooldown = true;
            btn.fillAmount = 1;
        }

        if (iscooldown)
        {
            btn.fillAmount -= 1 / cooldown * Time.deltaTime;
           
            if(btn.fillAmount <= 0){
                btn.fillAmount = 1;
                iscooldown = false;
            }
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huge : MonoBehaviour
{
    public GameObject town;

    protected Boss_alert boss;

    public void destroy()
    {
        boss.Death();
        Destroy(gameObject);
        town.SetActive(true);
    }
}

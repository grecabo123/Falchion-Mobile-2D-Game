using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_a : MonoBehaviour
{
    public GameObject town;

    protected Boss_alert boss;
    public GameObject door;
    public void destroy()
    {
        boss.Death();
        Destroy(boss);
        town.SetActive(true);
        door.SetActive(true);
        Debug.Log("dwa");
    }
}

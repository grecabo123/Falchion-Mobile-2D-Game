using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject ply;
    public GameObject modal_town;

    public void Destroy_object()
    {
        ply.SetActive(false);
        modal_town.SetActive(false);
    }
}

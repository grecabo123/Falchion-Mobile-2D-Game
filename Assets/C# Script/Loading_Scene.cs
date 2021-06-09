using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Scene : MonoBehaviour
{
    public GameObject Loadlvl;
    public Slider slide;

    public void LoadLevel(int scene)
    {
        Debug.Log(scene);
        StartCoroutine(Loadscene(scene));
    }

    IEnumerator Loadscene(int scene)
    {
        AsyncOperation syn = SceneManager.LoadSceneAsync(scene);
        Loadlvl.SetActive(true);
        while (!syn.isDone)
        {

            float progress = Mathf.Clamp01(syn.progress / .9f);
            slide.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }
}

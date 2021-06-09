using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenBarSystem : MonoBehaviour {


    protected Town twn;
    public GameObject design;
    public GameObject bar;
    public Text loadingText;
    public bool backGroundImageAndLoop;
    public float LoopTime;
    public GameObject[] backgroundImages;
    [Range(0,1f)]public float vignetteEfectVolue;
    AsyncOperation async;
    Image vignetteEfect;
    [SerializeField]
    public int scene;


    public void loadingScreen ()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Loading());
    }

    public void Return_town(int town)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Back_to_Town(town));
    }

    private void Start()
    {
        vignetteEfect = transform.Find("VignetteEfect").GetComponent<Image>();
        vignetteEfect.color = new Color(vignetteEfect.color.r,vignetteEfect.color.g,vignetteEfect.color.b,vignetteEfectVolue);

        if (backGroundImageAndLoop)
            StartCoroutine(transitionImage());
    }

    IEnumerator transitionImage ()
    {
        for (int i = 0; i < backgroundImages.Length; i++)
        {
            yield return new WaitForSeconds(LoopTime);
            for (int j = 0; j < backgroundImages.Length; j++)
                backgroundImages[j].SetActive(false);
            backgroundImages[i].SetActive(true);           
        }
    }

    //Restart
    IEnumerator Loading ()
    {
        async = SceneManager.LoadSceneAsync(scene);
        async.allowSceneActivation = false;

        // Continue until the installation is completed
        while (async.isDone == false)
        {
            bar.transform.localScale = new Vector3(async.progress,0.9f,1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    //Back to Town
    IEnumerator Back_to_Town(int town)
    {
        async = SceneManager.LoadSceneAsync(town);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            bar.transform.localScale = new Vector3(async.progress, 0.9f, 1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    // Dungeon 1
    public void Dungeon_1(int quest)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(Quest1(quest));
    }

    //Back to Town
    IEnumerator Quest1(int quest)
    {
        async = SceneManager.LoadSceneAsync(quest);
        async.allowSceneActivation = false;

       
        while (async.isDone == false)
        {
            bar.transform.localScale = new Vector3(async.progress, 0.9f, 1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }



    //starting to town

    public void Goto_Town(int scene_town)
    {
        this.gameObject.SetActive(true);
        design.SetActive(false);

        StartCoroutine(Town_Scene(scene_town));
    }

    IEnumerator Town_Scene(int town)
    {
        
        async = SceneManager.LoadSceneAsync(town);
        async.allowSceneActivation = false;
        Debug.Log(town);

       
        while (async.isDone == false)
        {
            bar.transform.localScale = new Vector3(async.progress, 0.9f, 1);

            if (loadingText != null)
                loadingText.text = "%" + (100 * bar.transform.localScale.x).ToString("####");

            if (async.progress == 0.9f)
            {
                bar.transform.localScale = new Vector3(1, 0.9f, 1);
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }




}

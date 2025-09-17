using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class loadingScripts : MonoBehaviour
{
    public static loadingScripts instance;
    [SerializeField] private GameObject loadingObject;
    [SerializeField] private Image progressBar;
    private float target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadLevel(string levelName)
    {
        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(levelName);
        scene.allowSceneActivation = false;

        loadingObject.SetActive(true);

        do
        {
            await Task.Delay(100); // Wait for 100 milliseconds
            target = scene.progress;
        } 
        while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        loadingObject.SetActive(false);
    }

    private void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3f * Time.deltaTime);
    }
}


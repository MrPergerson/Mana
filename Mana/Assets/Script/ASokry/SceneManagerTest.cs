using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerTest : MonoBehaviour
{
    public GameObject sceneToLoad;
    public bool loadScene = false;

    private void Update()
    {
        if (loadScene && sceneToLoad != null)
        {
            UpdateScene(sceneToLoad.name);
            loadScene = false;
        }
    }

    public void UpdateScene(string scene)
    {
        if (!IsSceneLoaded(scene))
        {
            LoadAdditonalScene(scene);
        }
        else
        {
            UnLoadAdditonalScene(scene);
        }
    }

    private void LoadAdditonalScene(string sceneToLoadName)
    {
        SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);
    }

    private void UnLoadAdditonalScene(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(sceneToLoadName);
    }

    private bool IsSceneLoaded(string sceneName)
    {
        for (int i=0; i<SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }

        return false;
    }
}

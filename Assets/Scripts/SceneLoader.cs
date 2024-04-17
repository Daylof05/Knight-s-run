using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Méthode pour charger la scène par son nom
    public void LoadSceneByName(string sceneName)
    {
        if (!gameObject.activeInHierarchy)
        {
            Debug.LogError("GameObject with SceneLoader is not active!");
            return;
        }

        Debug.Log("Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

}


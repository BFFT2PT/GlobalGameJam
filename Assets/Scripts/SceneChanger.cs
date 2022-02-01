using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    string _nextSceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
}

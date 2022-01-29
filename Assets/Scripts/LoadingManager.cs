using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    string _sceneName;
    [SerializeField]
    GameObject _blackCover;
    [SerializeField]
    GameObject _fadeIn;
    [SerializeField]
    float _animationDuration;

    AsyncOperation loadOperation;

    private void Start()
    {
        _blackCover.SetActive(false);
        StartCoroutine("LoadDelay");
        loadOperation = SceneManager.LoadSceneAsync(_sceneName);
        loadOperation.allowSceneActivation = false;
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(_animationDuration);
        _fadeIn.SetActive(true);
        yield return new WaitForSeconds(1);
        loadOperation.allowSceneActivation = true;
    }
}

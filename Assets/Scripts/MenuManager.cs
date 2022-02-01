using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject _fadingOut;

    public void PlayButton()
    {
        _fadingOut.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField]
    GameObject _invisibleButton;
    [SerializeField]
    GameObject _fadingOut;

    public void EnableButton()
    {
        _invisibleButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        _fadingOut.SetActive(true);
    }
}

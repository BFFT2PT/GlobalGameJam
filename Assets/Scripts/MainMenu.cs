using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    float minLevel;
    [SerializeField]
    float maxLevel;

    public void SelectLevel()
    {
        float randomLevel = Random.Range(minLevel, maxLevel);
        SceneManager.LoadScene(randomLevel.ToString());
    }

    public void Quit()
    {
        Application.Quit();
    }
}

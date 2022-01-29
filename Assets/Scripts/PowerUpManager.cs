using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;

    [SerializeField]
    GameObject[] powerUps;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject ShufflePowerUps()
    {
        return powerUps[Random.Range(0, powerUps.Length)];
    }
}

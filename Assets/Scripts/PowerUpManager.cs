using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] powerUps;

    GameObject ShufflePowerUps()
    {
        return powerUps[Random.Range(0, powerUps.Length)];
    }
}

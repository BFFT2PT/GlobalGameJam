using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringPowerUp : MonoBehaviour
{
    [SerializeField]
    string _powerUpType;

    public string SendString()
    {
        return _powerUpType;
    }
}

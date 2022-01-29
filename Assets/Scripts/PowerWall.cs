using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWall : PowerUp
{
    [SerializeField]
    float destroyTime = 4f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}

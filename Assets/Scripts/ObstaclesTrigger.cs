using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {            
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        ObstaclesSpawner.instance.SpawnObstacles();
    }
}

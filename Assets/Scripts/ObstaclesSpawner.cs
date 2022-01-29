using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public static ObstaclesSpawner instance;

    [SerializeField]
    GameObject[] _obstaclesPrefabs;
    [SerializeField]
    Transform _spawnTransform;

    bool canSpawn; //Esta variável serve para este script saber se pode fazer spawn ou não


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeSpawnState(bool newBool)
    {
        canSpawn = newBool;
    }
    public void SpawnObstacles()
    {
        if(canSpawn)
        {
            int rand = Random.Range(0, _obstaclesPrefabs.Length);

            Instantiate(_obstaclesPrefabs[rand], _spawnTransform.position, Quaternion.identity);
        }
    }
}

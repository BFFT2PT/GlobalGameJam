using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerThunder : PowerUp
{
    [SerializeField]
    GameObject thunderPrefab;
    [SerializeField]
    GameObject cloudPrefab;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float distanceBetweenClouds;
    [SerializeField]
    float destroyTime;

    private void Start()
    {
        StartCoroutine(SpearRainRoutine());
    }

    IEnumerator SpearRainRoutine()
    {
        Vector2 thunderPos = new Vector2(opponent.transform.position.x + offset.x, opponent.transform.position.y + offset.y);

        for (int i = 0; i < 5; i++)
        {
            GameObject thunder = Instantiate(thunderPrefab, thunderPos, thunderPrefab.transform.rotation);
            thunder.GetComponent<Rigidbody2D>().AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);

            GameObject cloud = Instantiate(cloudPrefab, thunderPos, thunderPrefab.transform.rotation);
            
            thunderPos = new Vector2(thunderPos.x - distanceBetweenClouds, thunderPos.y);

            Destroy(thunder, destroyTime);
            Destroy(cloud, destroyTime);

            yield return new WaitForSeconds(0.2f);
        }
    }
}

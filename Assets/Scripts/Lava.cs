using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    PlayerMovement playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerScript == null && collision.tag == "Player")
        {
            playerScript = collision.GetComponent<PlayerMovement>();
        }
    }

    private void OnDestroy()
    {
        if(playerScript != null)
        {
            playerScript.DefaultSpeed();
        }
    }
}

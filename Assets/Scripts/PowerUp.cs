using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    GameObject[] targets;
    protected GameObject opponent;

    [SerializeField]
    protected Vector2 offset;

    // Start is called before the first frame update
    void Awake()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
    }

    public void FindOpponentPlayer(GameObject playerWhoActivated)
    {
        for(int i = 0; i < targets.Length; i++)
        {
            if(targets[i] != playerWhoActivated)
            {
                opponent = targets[i];
            }
        }

        transform.position = new Vector2(opponent.transform.position.x + offset.x, opponent.transform.position.y + offset.y);
    }
}

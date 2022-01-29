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

    public override void FindOpponentPlayer(GameObject playerWhoActivated)
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != playerWhoActivated)
            {
                opponent = targets[i];
            }
        }

        if (opponent.name == "TopPlayer")
        {
            transform.position = new Vector2(opponent.transform.position.x + offset.x, 3.5f);
            sr.sprite = sprites[0];
        }
        else
        {
            transform.position = new Vector2(opponent.transform.position.x + offset.x, -1.8f);
            sr.sprite = sprites[1];
        }
    }
}

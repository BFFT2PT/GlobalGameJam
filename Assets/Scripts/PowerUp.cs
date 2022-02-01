using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected SpriteRenderer sr;
    protected GameObject[] targets;
    protected GameObject opponent;

    [SerializeField]
    protected Vector2 offset;
    [SerializeField]
    protected Sprite[] sprites;
    [SerializeField]
    protected float destroyTime;

    protected Vector2 pos;


    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        targets = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Start()
    {
        if (destroyTime > 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }

    public virtual void FindOpponentPlayer(GameObject playerWhoActivated)
    {
        for(int i = 0; i < targets.Length; i++)
        {
            if(targets[i] != playerWhoActivated)
            {
                opponent = targets[i];
            }
        }

        if (sprites.Length > 0)
        {
            if (opponent.name == "TopPlayer")
            {
                sr.sprite = sprites[0];
            }
            else
            {
                sr.sprite = sprites[1];
            }
        }
        /*
        if(opponent.name == "BottomPlayer")
        {
            if(opponent.transform.position.y + offset.y > -3.6f)
            {
                pos = new Vector2(opponent.transform.position.x + offset.x, -3.3f);
            }
        }
        else
        {
            pos = new Vector2(opponent.transform.position.x + offset.x, opponent.transform.position.y + offset.y);
        } */

        transform.position = new Vector2(opponent.transform.position.x + offset.x, opponent.transform.position.y + offset.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBall : PowerUp
{
    [SerializeField]
    float _movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        MovingLeft();
    }

    void MovingLeft()
    {
        transform.Translate(Vector2.left * _movementSpeed * Time.deltaTime);
    }
}

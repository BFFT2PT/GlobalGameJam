using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMissile : PowerUp
{
    [SerializeField]
    float _movementSpeed;
    [SerializeField]
    float _moveTowardsSpeed;
    [SerializeField]
    float _updateTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTarget());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _movementSpeed * Time.deltaTime);

        if(transform.position.x > opponent.transform.position.x)
        {
            transform.right = (opponent.transform.position - transform.position) * -1;
        }
    }

    IEnumerator UpdateTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, opponent.transform.position.y), _moveTowardsSpeed);
        yield return new WaitForSeconds(_updateTime);
        StartCoroutine(UpdateTarget());
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed;

    private void Update()
    {
        transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);
    }
}

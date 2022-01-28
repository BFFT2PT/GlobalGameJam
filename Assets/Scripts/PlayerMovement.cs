using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed;

    [SerializeField]
    string _jumpInput;
    [SerializeField]
    string _slideInput;

    bool isGrounded = true;
    Rigidbody2D thisRig;
    [SerializeField]
    float _jumpForce;
    [SerializeField]
    string _respectiveFloorTag;

    BoxCollider2D thisCollider;
    Vector2 colliderDefaultSize;
    Animator thisAnimator;
    bool isSliding;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<BoxCollider2D>();
        thisAnimator = GetComponent<Animator>();
        colliderDefaultSize = thisCollider.size;
    }

    private void Update()
    {
        MovingRight();
    }

    void MovingRight()
    {
        transform.Translate(Vector2.right * _movementSpeed * Time.deltaTime);

        PlayerJump();
        PlayerSlide();
    }

    void PlayerJump()
    {
        if(isGrounded && Input.GetButtonDown(_jumpInput))
        {
            thisRig.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void PlayerSlide()
    {
        if(isGrounded && Input.GetButton(_slideInput))
        {
            isSliding = true;
            thisAnimator.SetBool("IsSliding", true);
            thisCollider.size = colliderDefaultSize / 2;
        }

        if(isSliding && Input.GetButtonUp(_slideInput))
        {
            thisAnimator.SetBool("IsSliding", false);
            thisCollider.size = colliderDefaultSize;
            isSliding = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == _respectiveFloorTag)
        {
            isGrounded = true;
        }
    }
}

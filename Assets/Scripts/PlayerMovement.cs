using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float _movementSpeed;

    [SerializeField]
    string _jumpInput;
    [SerializeField]
    string _slideInput;
    [SerializeField]
    string _powerUpInput;

    bool isGrounded;
    Rigidbody2D thisRig;
    [SerializeField]
    float _jumpForce;

    [SerializeField]
    float _thunderTime;

    BoxCollider2D thisCollider;
    Vector2 colliderDefaultSize;
    Animator thisAnimator;
    bool isSliding;
    float defaultSpeed;
    bool coroutineStarted;

    GameObject currentPowerUp;
    PowerUpManager powManager;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<BoxCollider2D>();
        thisAnimator = GetComponent<Animator>();
        colliderDefaultSize = thisCollider.size;

        powManager = PowerUpManager.instance;
        defaultSpeed = _movementSpeed;
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
        PlayerPowerUp();
        FloorDetection();
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

    void PlayerPowerUp()
    {
        if (Input.GetButtonDown(_powerUpInput) && currentPowerUp)
        {
            GameObject pow = Instantiate(currentPowerUp);
            pow.GetComponent<PowerUp>().FindOpponentPlayer(gameObject);
            currentPowerUp = null;
        }
    }

    void FloorDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

        if(hit.collider != null && hit.collider.tag == "Floor")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            currentPowerUp = powManager.ShufflePowerUps();
        }

        if (collision.gameObject.tag == "Lava")
        {
            _movementSpeed /= 2;
        }

        if(collision.gameObject.tag == "Thunder")
        {
            StartCoroutine(SlowedDownRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!coroutineStarted)
        {
            _movementSpeed = defaultSpeed;
        }
    }

    IEnumerator SlowedDownRoutine()
    {
        coroutineStarted = true;
        _movementSpeed /= 2;
        yield return new WaitForSeconds(_thunderTime);
        _movementSpeed = defaultSpeed;
        coroutineStarted = false;
    }
}

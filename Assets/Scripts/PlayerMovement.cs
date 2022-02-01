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
    string _horizontalInput;
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
    SpriteRenderer thisSprite;
    bool isSliding;
    float defaultSpeed;
    bool coroutineStarted;

    GameObject currentPowerUp;
    PowerUpManager powManager;
    DisplayPowerUp _displayScript;

    private void Start()
    {
        thisRig = GetComponent<Rigidbody2D>();
        thisCollider = GetComponent<BoxCollider2D>();
        thisAnimator = GetComponent<Animator>();
        thisSprite = GetComponent<SpriteRenderer>();
        _displayScript = GetComponent<DisplayPowerUp>();
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
        HorizontalMovement();
        PlayerJump();
        PlayerSlide();
        PlayerPowerUp();
        FloorDetection();
    }

    void HorizontalMovement()
    {
        float inputX = Input.GetAxisRaw(_horizontalInput);

        if(inputX != 0)
        {
            thisAnimator.SetBool("IsWalking", true);
            switch(inputX)
            {
                case -1: thisSprite.flipX = true;
                    break;
                case 1: thisSprite.flipX = false;
                    break;
            }
        }
        else
        {
            thisAnimator.SetBool("IsWalking", false);
        }

        transform.Translate(new Vector2(inputX, 0) * _movementSpeed * Time.deltaTime);
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
            _displayScript.HideIcon();
            currentPowerUp = null;
        }
    }

    void FloorDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if(hit.collider != null && hit.collider.tag == "Floor")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        thisAnimator.SetBool("IsGrounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            currentPowerUp = powManager.ShufflePowerUps();
            currentPowerUp.GetComponent<StringPowerUp>().SendString();
            _displayScript.ChangeIcon(currentPowerUp.GetComponent<StringPowerUp>().SendString());
            Destroy(collision.gameObject);
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

    public void DefaultSpeed()
    {
        _movementSpeed = defaultSpeed;
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

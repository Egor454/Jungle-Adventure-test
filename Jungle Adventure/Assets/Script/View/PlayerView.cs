using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask itIsEnemy;
    [SerializeField] private int extraJumpValue;
    [SerializeField] private Animator anim;

    private Rigidbody2D rb;
    private BoxCollider2D boxC;
    private SpriteRenderer sprite;
    private Transform transforms;

    private float timeLeft = 2f;
    private bool invulnerability = false;

    public event UnityAction <float> ChangedPosition;
    public event UnityAction<Collider2D> PlayerTakeCoin;
    public event UnityAction<Collision2D> PlayerKillEnemy;
    public event UnityAction PlayerEnteredThePortal;
    public event UnityAction GetDamagePlatform;
    public event UnityAction DeathPlayer;
    public event UnityAction<Collider2D>  HealPlayer;

    private bool isGrounded;
    private bool isEnemy;
    private int extraJump;
    private float moveInput = 0;
    private bool facingRight = true;


    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        transforms = GetComponent<Transform>();
 
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isEnemy = Physics2D.OverlapCircle(enemyCheck.position, checkRadius, itIsEnemy);
        anim.SetBool("Ground", isGrounded);
        anim.SetBool("Enemy", isEnemy);
        anim.SetFloat("vSpeed", rb.velocity.y);
        if (invulnerability)
        {
            InvulnerabilityTimer();
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1;
            ChangedPosition?.Invoke(moveInput);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1;
            ChangedPosition?.Invoke(moveInput);
        }
        if (facingRight == false && moveInput == 1)
        {
            Flip();
        }else if (facingRight == true && moveInput == -1)
        {
            Flip();
        }
       
    }
    private void Update()
    {

        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetBool("Ground", false);
        }
    }
    public void ChangePositionView(float playerMove)
    {
        transforms.Translate(playerMove, 0, 0);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3  Scaler = transforms.localScale;
        if(facingRight == false)
        {
            Scaler.x = (float)-1.5;
        }
        else
        {
            Scaler.x = (float)1.5;
        }
        transforms.localScale = Scaler;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (isEnemy)
            {
                PlayerKillEnemy?.Invoke(other);
            }
        }
        if (other.gameObject.tag == "DamagePlatform")
        {
            GetDamagePlatform?.Invoke();
        }
        if (other.gameObject.tag == "Death")
        {
            DeathPlayer?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            PlayerTakeCoin?.Invoke(collision);
        }
        if (collision.gameObject.tag == "Chest")
        {
            PlayerTakeCoin?.Invoke(collision);
        }
        if (collision.gameObject.tag == "Portal")
        {
            PlayerEnteredThePortal?.Invoke();
        }
        if (collision.gameObject.tag == "HealthPotion")
        {
            HealPlayer?.Invoke(collision);
        }
    }
    public void EnableInvulnerability()
    {
        gameObject.layer = 10;
        sprite.color = new Color(1f, 1f, 1f, 0.5f);
        invulnerability = true;
    }
    private void  InvulnerabilityTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            invulnerability = false;
            gameObject.layer = 0;
            sprite.color = new Color(1f, 1f, 1f, 1f);
            timeLeft = 2f;
        }

    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PlayerView : MonoBehaviour
{
    #region SerializeField

    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask itIsEnemy;
    [SerializeField] private int extraJumpValue;
    [SerializeField] private Animator anim;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] AudioClip runMusic;
    [SerializeField] AudioClip getCoinMusic;
    [SerializeField] AudioClip getHealPotionMusic;
    [SerializeField] AudioClip getDamageMusic;
    [SerializeField] AudioClip jumpMusic;

    #endregion SerializeField

    #region UnitAction

    public event UnityAction<float> ChangedPosition;
    public event UnityAction<Collider2D> PlayerTakeCoin;
    public event UnityAction<Collision2D> PlayerKillEnemy;
    public event UnityAction PlayerEnteredThePortal;
    public event UnityAction GetDamagePlatform;
    public event UnityAction DeathPlayer;
    public event UnityAction<Collider2D> HealPlayer;

    #endregion UnitAction

    #region Private Fields

    private Rigidbody2D rb;
    private BoxCollider2D boxC;
    private SpriteRenderer sprite;
    private Transform transforms;

    private float timeLeft = 2f;
    private bool invulnerability = false;

    private bool isGrounded;
    private bool isEnemy;
    private int extraJump;
    private float moveInput = 0;
    private bool facingRight = true;
    private float time = 0.4f;

    private bool soundSettings;

    #endregion Private Fields

    #region Private Methods

    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        boxC = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        transforms = GetComponent<Transform>();
        soundSettings = System.Convert.ToBoolean(PlayerPrefs.GetString("SoundSettings"));

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
            if (soundSettings)
            {
                if (isGrounded == true)
                {
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        if (soundSettings)
                            audioSource.PlayOneShot(runMusic);
                        time = 0.4f;
                    }
                }
            }
            ChangedPosition?.Invoke(moveInput);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1;
            if (soundSettings)
            {
                if (isGrounded == true)
                {
                    time -= Time.deltaTime;
                    if (time < 0)
                    {
                        if (soundSettings)
                            audioSource.PlayOneShot(runMusic);
                        time = 0.4f;
                    }
                }
            }
              
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
            if (soundSettings)
                audioSource.PlayOneShot(jumpMusic);
            anim.SetBool("Ground", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3  Scaler = transforms.localScale;
        if(facingRight == false)
        {
            if(gameObject.name == "HeavyBandit")
            {
                Scaler.x = (float)-2;
            }
            else
            {
                Scaler.x = (float)-1.5;
            }
        }
        else
        {
            if (gameObject.name == "HeavyBandit")
            {
                Scaler.x = (float)2;
            }
            else
            {
                Scaler.x = (float)1.5;
            }
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
                return;
            }
            if (soundSettings)
                audioSource.PlayOneShot(getDamageMusic);
        }
        if (other.gameObject.tag == "DamagePlatform")
        {
            if (soundSettings)
                audioSource.PlayOneShot(getDamageMusic);
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
            if (soundSettings)
                audioSource.PlayOneShot(getCoinMusic);
            PlayerTakeCoin?.Invoke(collision);
        }
        if (collision.gameObject.tag == "Chest")
        {
            if (soundSettings)
                audioSource.PlayOneShot(getCoinMusic);
            PlayerTakeCoin?.Invoke(collision);
        }
        if (collision.gameObject.tag == "Portal")
        {
            PlayerEnteredThePortal?.Invoke();
        }
        if (collision.gameObject.tag == "HealthPotion")
        {
            if (soundSettings)
                audioSource.PlayOneShot(getHealPotionMusic);
            HealPlayer?.Invoke(collision);
        }
    }
    private void InvulnerabilityTimer()
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

    #endregion Private Methods

    #region Public Methods

    public void ChangePositionView(float playerMove)
    {
        transforms.Translate(playerMove, 0, 0);
    }
    public void EnableInvulnerability()
    {
        gameObject.layer = 10;
        sprite.color = new Color(1f, 1f, 1f, 0.5f);
        invulnerability = true;
    }

    #endregion Public Methods

}

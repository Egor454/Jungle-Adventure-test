using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerView : MonoBehaviour
{
    private float moveInput = 0;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    private bool facingRight = true;

    public event UnityAction <float> ChangedPosition;

    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    private int extraJump;
    [SerializeField] private int extraJumpValue;
    [SerializeField] private Animator anim;
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
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
        transform.Translate(playerMove, 0, 0);
    }

   public void Flip()
    {
        facingRight = !facingRight;
        Vector3  Scaler = transform.localScale;
        if(facingRight == false)
        {
            Scaler.x = (float)-1.5;
        }
        else
        {
            Scaler.x = (float)1.5;
        } 
        transform.localScale = Scaler;
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    int b = 3;
    //}
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            print(other.gameObject.name);
        }
        if (other.gameObject.tag == "DamagePlatform")
        {
            print(other.gameObject.name);
        }
    }
}

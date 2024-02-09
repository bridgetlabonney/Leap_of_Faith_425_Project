using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO
//player needs animations


public class Player : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public int health;

    private Animator animations;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Awake()
    {

        health = 3;
        animations = GetComponent<Animator>();
       

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //not on ground, falling state
        if (!IsGrounded())
        {
            animations.SetBool("isFalling", true);
        }
        if (IsGrounded())
        {
            animations.SetBool("isFalling", false);
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //enters jump state when jumping
            animations.SetInteger("Jump", 1);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            //exit jump state when not jumping
            animations.SetInteger("Jump", 0);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (rb.velocity.x > 0 && animations.GetBool("isFalling") != true)
        {
            animations.SetBool("IsWalking", true);
        }
        else
        {
            animations.SetBool("IsWalking", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

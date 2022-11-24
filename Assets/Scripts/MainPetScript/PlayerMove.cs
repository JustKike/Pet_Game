using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;
    Rigidbody2D rb2D;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public float y;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (Checkground.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (Checkground.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (Checkground.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        if (rb2D.velocity.y>0)
        {
            animator.SetBool("Falling", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            y = 95;
            transform.rotation = Quaternion.Euler(0, y, 0);
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            animator.SetBool("Run", true);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
             y = -95;
            transform.rotation = Quaternion.Euler(0, y, 0);
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            animator.SetBool("Run", true);
        }

        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (betterJump)
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

    }
}

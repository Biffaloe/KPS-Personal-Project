using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class P_Field_Movement : MonoBehaviour
{
    public Animator anim;

    public LayerMask WhatIsGround;
    public BoxCollider2D GroundCheck;
    public float JumpForce;
    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2.0f;
    public float RunSpeed = 40f;
    [Range(0, .3f)] public float MovementSmoothing = .05f;

    private Rigidbody2D rb;
    private Vector3 Velocity = Vector3.zero;
    private Vector2 Playervelocity;
    private float horizontalMove = 0f;
    private bool isJumping = false;
    private bool Grounded;
    private bool facingLeft;
    private bool unPause = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        facingLeft = true;
    }
    private void Update()
    {
        if (StateMachine.Inactive)
        {
            if (unPause)
            {
                rb.gravityScale = 1f;
                rb.velocity = Playervelocity;
                unPause = false;
            }
            horizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

            if (Input.GetButtonDown("Jump"))
                isJumping = true;

            if (rb.velocity.y < 0)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if (!StateMachine.Inactive)
        {
            Playervelocity = rb.velocity;
            rb.velocity = new Vector2(0,0);
            rb.gravityScale = 0f;
            unPause = true;
        }
    }

    private void FixedUpdate()
    {
        if (GameMaster.menu_State == Menu_State.Inactive)
        {
            Move();
            Jump();
            Flip(horizontalMove);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision = GroundCheck;
        if (collision.IsTouchingLayers(WhatIsGround))
        {
            Grounded = true;
            Debug.Log("Grounded is true");
        }
    }

    private void Move()
    {
        Vector3 targetVelocity = new Vector2(horizontalMove * RunSpeed, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, MovementSmoothing);
    }

    private void Jump()
    {
        if (isJumping && Grounded)
        {
            Grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        isJumping = false;
    }

    private void Flip(float Horizontal)
    {
        if (Horizontal < 0 && !facingLeft ||Horizontal > 0 && facingLeft)
        {
            facingLeft = !facingLeft;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}

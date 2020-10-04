using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Animator animator;
    public PlayerSfx playerSfx;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Transform render;
    private float speed = 40f;
    private float maxSpeed = 5f;
    private float jumpSpeed = 16f;
    private bool isGrounded = true;
    private int platformMask;
    private int boxMask;

    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        platformMask = LayerMask.GetMask("Platform", "Box");
        boxMask = LayerMask.GetMask("Box");
        render = transform.GetChild(0).transform;
    }

    void Update()
    {
        var grounded = IsGrounded();
        if (!isGrounded && grounded)
        {
                playerSfx.PlayLandSound();
        }

        if (grounded) {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForce(Right(new Vector2(speed, 0), grounded));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForce(Left(new Vector2(-speed, 0), grounded));
        }

        MaxSpeed();

        if (IsWalking())
        {
            playerSfx.PlayWalk();
        }

        var spd = Mathf.Abs(body.velocity.x);

        animator.SetFloat("speed", spd);

        animator.SetFloat("speedy", body.velocity.y);

        if (IsPushing() && spd > 0.01f) {
            animator.SetBool("pushing", true);
            render.localPosition = new Vector2(-0.6f, -0.1f);
        } else {
            animator.SetBool("pushing", false);
            render.localPosition = new Vector2(0f, -0.1f);
        }
    }

    private void MaxSpeed()
    {
        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        } else if(body.velocity.x < -maxSpeed) {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }
    }

    private Vector2 Right(Vector2 spd, bool grounded) {
        if (!grounded)
        {
            var inAirSpeed = spd.x * 0.5f;

            if (spd.x >= inAirSpeed)
            {
                spd = new Vector2(inAirSpeed, spd.y);
            }
        }

        transform.localRotation = Quaternion.Euler(0, 0, 0);

        return spd;
    }

    private Vector2 Left(Vector2 speed, bool grounded)
    {
        if (!grounded)
        {
            var inAirSpeed = speed.x * 0.5f;

            if (speed.x <= inAirSpeed)
            {
                speed = new Vector2(inAirSpeed, speed.y);
            }
        }

        transform.localRotation = Quaternion.Euler(0, 180, 0);

        return speed;
    }

    private bool IsPushing() {
        var hit = Physics2D.Raycast(transform.position, transform.right, 0.7f, boxMask);

        Debug.DrawRay(transform.position, transform.right * 0.7f);

        return hit.collider != null;
    }

    private bool IsGrounded() {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, platformMask);

        return hit.collider != null;
    }

    public bool IsWalking() {
        if (body.velocity.x > 0.1f || body.velocity.x < -0.1f) {
            return isGrounded;
        }

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public PlayerSfx playerSfx;
    public LayerMask mask;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;
    private float speed = 40f;
    private float maxSpeed = 5f;
    private float jumpSpeed = 16f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        body = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        var grounded = IsGrounded();

        if (grounded) {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                playerSfx.PlayJumpSound();
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

    private Vector2 Right(Vector2 speed, bool grounded) {
        if (!grounded)
        {
            var inAirSpeed = speed.x * 0.1f;

            if (speed.x > inAirSpeed)
            {
                speed = new Vector2(inAirSpeed, speed.y);
            }
        }

        transform.localRotation = Quaternion.Euler(0, 0, 0);

        return speed;
    }

    private Vector2 Left(Vector2 speed, bool grounded)
    {
        if (!grounded)
        {
            var inAirSpeed = speed.x * 0.1f;

            if (speed.x < inAirSpeed)
            {
                speed = new Vector2(inAirSpeed, speed.y);
            }
        }

        transform.localRotation = Quaternion.Euler(0, 180, 0);

        return speed;
    }

    private bool IsGrounded() {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, mask);

        return hit.collider != null;
    }

    public bool IsWalking() {
        if (body.velocity.x > 0.1f || body.velocity.x < -0.1f) {
            return true;
        }

        return false;
    }
}

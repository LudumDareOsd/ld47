using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public LayerMask mask;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float speed = 15f;
    private float jumpSpeed = 33f;
    void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var grounded = IsGrounded();

        if (grounded) {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            }
        }
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = Walk(new Vector2(speed, body.velocity.y), grounded);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = Walk(new Vector2(-speed, body.velocity.y), grounded);
        }
    }

    private Vector2 Walk(Vector2 speed, bool grounded) {

        if (!grounded) {
            speed = new Vector2(speed.x * 0.5f, speed.y);
        }

        return speed;
    }

    private bool IsGrounded() {
        var hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, mask);

        return hit.collider != null;
    }
}

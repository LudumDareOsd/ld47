using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Trigger
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    private SpriteRenderer sr;
    public LeverSfx leverSfx;
    public void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (collision is BoxCollider2D)) {
            Eval();
        }
        
    }

    private void Eval() {

        leverSfx.PlayPullLever();

        if (active)
        {
            sr.sprite = activeSprite;
            active = false;
        }
        else
        {
            sr.sprite = inActiveSprite;
            active = true;
        }
    }
}

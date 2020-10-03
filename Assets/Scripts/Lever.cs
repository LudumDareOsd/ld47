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
        sr.sprite = active ? activeSprite : inActiveSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        leverSfx.PlayPullLever();
        if (active)
        {
            active = false;
        }
        else {
            active = true;
        }
    }

    protected override void onActivate()
    {
        sr.sprite = activeSprite;
    }

    protected override void onInActivate()
    {
        sr.sprite = inActiveSprite;
    }
}

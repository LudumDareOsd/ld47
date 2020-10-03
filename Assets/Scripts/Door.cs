using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Reciver
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        if (IsActive()) {
            sr.sprite = activeSprite;
            boxCollider.enabled = false;
        }
        else {
            sr.sprite = inActiveSprite;
            boxCollider.enabled = true;
        }
    }
}

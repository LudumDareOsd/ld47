using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Reciver
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    private SpriteRenderer sr;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (IsActive()) {
            sr.sprite = activeSprite;
        }
        else {
            sr.sprite = inActiveSprite;
        }
    }
}

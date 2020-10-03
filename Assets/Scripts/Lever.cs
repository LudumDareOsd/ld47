using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Trigger
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    private SpriteRenderer sr;
    public void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            active = false;
        }
        else {
            active = true;
        }
        
        Eval();
    }


    private void Eval() {
        if (active) {
            sr.sprite = activeSprite;
        } else {
            sr.sprite = inActiveSprite;
        }
    }
}

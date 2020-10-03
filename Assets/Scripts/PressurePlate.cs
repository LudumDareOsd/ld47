using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PressurePlate : Trigger
{
    public Sprite activeSprite;
    public Sprite interSprite;
    public Sprite inactiveSprite;

    private SpriteRenderer sr;
    private int count = 0;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Eval();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        count++;
        Eval();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        count--;
        Eval();
    }

    private void Eval() {

        if (count >= 1)
        {
            active = true;
        }
        else {
            active = false;
        }

        if (active)
        {
            sr.sprite = activeSprite;
        } else {
            sr.sprite = inactiveSprite;
        }
    }
}

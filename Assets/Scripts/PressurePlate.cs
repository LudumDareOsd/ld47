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
    public PressurePlateSfx plateSfx;
    protected int count = 0;
    protected SpriteRenderer sr;
    
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        active = IsActive();
        sr.sprite = GetSprite();
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

    virtual protected void Eval() {
        var wasActive = active;
        active = IsActive();
        if (wasActive != active)
        {
            if (active)
            {
                Activate();
            }
            else 
            {
                InActivate();
            }
        }
    }
    virtual protected bool IsActive()
    {
        return count >= 1;
    }
    virtual protected Sprite GetSprite()
    {
        return active ? activeSprite : inactiveSprite;
    }
    protected void Activate()
    {
        plateSfx.PlayActiveSound();
        sr.sprite = activeSprite;
    }

    protected void InActivate()
    {
        plateSfx.PlayInactiveSound();
        sr.sprite = inactiveSprite;
    }
}

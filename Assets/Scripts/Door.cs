using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Door : Reciver
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;

    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;
    public EnvironmentSfx environmentSfx;
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr.sprite = IsActive() ? activeSprite : inActiveSprite;
    }

    protected override void onActivated()
    {
        sr.sprite = activeSprite;
        boxCollider.enabled = false;
        environmentSfx.PlayOpenDoor();
    }

    protected override void onDeActivated()
    {
        sr.sprite = inActiveSprite;
        boxCollider.enabled = true;
        environmentSfx.PlayCloseDoor();
    }
}

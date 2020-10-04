using Assets.Scripts;
using UnityEngine;

public class Door : Reciver
{
    public Sprite activeSprite;
    public Sprite inActiveSprite;
    public DoorSfx doorSfx;

    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void onActivated()
    {
        sr.sprite = activeSprite;
        boxCollider.enabled = false;
        doorSfx.PlayOpenDoor();
    }

    protected override void onDeActivated()
    {
        sr.sprite = inActiveSprite;
        boxCollider.enabled = true;
        doorSfx.PlayCloseDoor();
    }
}

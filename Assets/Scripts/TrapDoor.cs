using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class TrapDoor : Reciver
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
            var active = IsActive();
            boxCollider.enabled = active;
            sr.sprite = active ? activeSprite : inActiveSprite;
        }

        protected override void onActivated()
        {
            sr.sprite = activeSprite;
            boxCollider.enabled = false;
            doorSfx.PlayOpenDoor();

            transform.localPosition += new Vector3(1f, -1f);
        }

        protected override void onDeActivated()
        {
            sr.sprite = inActiveSprite;
            boxCollider.enabled = true;
            doorSfx.PlayCloseDoor();

            transform.localPosition -= new Vector3(1f, -1f);
        }
    }
}
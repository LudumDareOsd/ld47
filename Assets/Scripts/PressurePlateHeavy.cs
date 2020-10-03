using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts
{
    public class PressurePlateHeavy : PressurePlate
    {
        private int numberOfHits = 0;

        public void Update()
        {
            var hits = Physics2D.RaycastAll(transform.position + new Vector3(0, 0.2f, 0), Vector2.up, 1.5f).Select(it => it.collider).ToList();
            // var hits2 = Physics2D.RaycastAll(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up, 2f).Select(it => it.collider).ToList();

            // var hits = hits1.Union(hits2).ToList();

            numberOfHits = hits.Count;

            Debug.DrawRay(transform.position + new Vector3(0, 0.2f, 0), Vector2.up * 1.5f, Color.green);
            //Debug.DrawRay(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up * 2f, Color.green);

            Eval();
        }

        override
        protected void Eval()
        {
            if (count >= 1 && numberOfHits >= 2) {
                active = true;
            } else { 
                active = false;
            }
        }
        protected override void onActivate()
        {
            sr.sprite = activeSprite;
        }

        protected override void onInActivate()
        {
            if (count >= 1 && numberOfHits >= 1)
            {
                sr.sprite = interSprite;
            }
            else
            {
                sr.sprite = inactiveSprite;
            }
        }
    }
}
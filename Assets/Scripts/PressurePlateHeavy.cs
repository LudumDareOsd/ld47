using UnityEngine;
using System.Collections;
using System.Linq;

namespace Assets.Scripts
{
    public class PressurePlateHeavy : PressurePlate
    {
        private int prevNumberOfHits = 0;
        private int numberOfHits = 0;
        public void Update()
        {
            var hits = Physics2D.RaycastAll(transform.position + new Vector3(0, 0.2f, 0), Vector2.up, 1.5f).Select(it => it.collider).ToList();
            // var hits2 = Physics2D.RaycastAll(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up, 2f).Select(it => it.collider).ToList();

            // var hits = hits1.Union(hits2).ToList();
            prevNumberOfHits = numberOfHits;
            numberOfHits = hits.Count;

            Debug.DrawRay(transform.position + new Vector3(0, 0.2f, 0), Vector2.up * 1.5f, Color.green);
            //Debug.DrawRay(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up * 2f, Color.green);

            Eval();
        }

        protected override bool IsActive()
        {
            return count >= 1 && numberOfHits >= 4;
        }

        protected override Sprite GetSprite()
        {
            if (active)
            {
                return activeSprite;
            }
            else if (numberOfHits >= 2)
            {
                return interSprite;
            }
            else
            {
                return inactiveSprite;
            }
        }

        override
        protected void Eval()
        {
            var wasActive = active;
            active = IsActive();
            if (active) {
                if (wasActive != active)
                {
                    Activate();
                }
            } else if (numberOfHits >= 2) {
                if (prevNumberOfHits != numberOfHits)
                {
                    sr.sprite = interSprite;
                    plateSfx.PlayInterSound();

                }
                
            } else {
                if (prevNumberOfHits != numberOfHits)
                {
                    InActivate();
                }
            }
        }
    }
}
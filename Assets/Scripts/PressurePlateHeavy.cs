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
            var hits1 = Physics2D.RaycastAll(transform.position + new Vector3(-0.25f, 0.2f, 0), Vector2.up, 2f).Select(it => it.collider).ToList();
            var hits2 = Physics2D.RaycastAll(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up, 2f).Select(it => it.collider).ToList();

            var hits = hits1.Union(hits2).ToList();

            numberOfHits = hits.Count;

            Debug.DrawRay(transform.position + new Vector3(-0.25f, 0.2f, 0), Vector2.up * 2f, Color.green);
            Debug.DrawRay(transform.position + new Vector3(0.25f, 0.2f, 0), Vector2.up * 2f, Color.green);

            Eval();
        }

        override
        protected void Eval()
        {
            if (count >= 1 && numberOfHits >= 2) {
                active = true;
                sr.sprite = activeSprite;
            } else if (count >= 1 && numberOfHits >= 1) {
                sr.sprite = interSprite;
                active = false;
            } else {
                sr.sprite = inactiveSprite;
                active = false;
            }
        }
    }
}
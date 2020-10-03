using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class PressurePlateHeavy : PressurePlate
    {
        protected void Eval()
        {

            if (count >= 1)
            {
                active = true;
            }
            else
            {
                active = false;
            }

            if (active)
            {
                sr.sprite = activeSprite;
            }
            else
            {
                sr.sprite = inactiveSprite;
            }
        }
    }
}
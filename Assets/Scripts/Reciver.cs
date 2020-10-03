using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public class Reciver : MonoBehaviour
    {
        public List<Trigger> triggers = new List<Trigger>();

        protected bool IsActive() {

            var active = true;

            foreach(var trigger in triggers)
            {
                if(!trigger.active)
                {
                    active = false;
                }
            }

            return active;
        }
    }
}
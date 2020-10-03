using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public abstract class Reciver : MonoBehaviour
    {
        public List<Trigger> triggers = new List<Trigger>();
        private bool isActive;
        protected abstract void onActivated();
        protected abstract void onDeActivated();
        protected bool IsActive()
        {
            return triggers.All(trigger => trigger.active);
        }
        public virtual void Update()
        {
            var active = IsActive();
            if (active != isActive)
            {
                if (active)
                {
                    onActivated();
                }
                else
                {
                    onDeActivated();
                }
            }
            isActive = active;
        }
    }
}
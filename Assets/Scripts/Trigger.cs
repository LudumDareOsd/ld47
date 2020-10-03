using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public abstract class Trigger : MonoBehaviour
    {
        protected abstract void onActivate();
        protected abstract void onInActivate();
        private bool _active = false;
        public bool active 
        { 
            get { return _active; } 
            set 
            {
                _active = value; 
                
                if (_active)
                {
                    onActivate();
                }
                else
                {
                    onInActivate();
                }
            } 
        }
    }
}
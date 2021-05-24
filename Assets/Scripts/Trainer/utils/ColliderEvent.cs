using UnityEngine;
using System;
using UnityEngine.Events;
/// <summary>
/// Dispatch events from this collider
/// </summary>
/// 

namespace cyraxchel.trainer.utils
{
    public class ColliderEvent : MonoBehaviour
    {
        /// <summary>
        /// Event for mouse click
        /// </summary>
        public event Action OnClick = delegate { };
        /// <summary>
        /// Event for mouse press
        /// </summary>
        public event Action OnPress = delegate { };



        private void OnMouseDown()
        {
            OnPress.Invoke();
        }

        private void OnMouseUpAsButton()
        {
            OnClick.Invoke();
        }

        /// <summary>
        /// Add collider event to and check existing it on gameobject
        /// Also check existing Collider on gameobject and adding simple BoxCollider if not when add new ColliderEvent
        /// </summary>
        /// <param name="target">GO for adding component</param>
        /// <returns>Instance of Collider event, attached to input GO</returns>
        public static ColliderEvent AddColliderEvent(GameObject target)
        {
            ColliderEvent cevent = target.GetComponent<ColliderEvent>();
            if (cevent == null)
            {
                //check collider existing
                Collider coll = target.GetComponent<Collider>();
                if (coll == null)
                {
                    target.AddComponent<BoxCollider>();
                }
                cevent = target.AddComponent<ColliderEvent>();
            }
            return cevent;
        }
    }
}
using System;
using UnityEngine;

namespace Additional
{
    public class DamageDealer : MonoBehaviour
    {
        private static readonly int IsHitted = Animator.StringToHash("isHitted");
        [SerializeField] private float damage = 2.0f;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.GetComponent<Health>()) return;

            if (!other.gameObject.GetComponent<Health>().Alive()) return;
            
            other.gameObject.GetComponent<Health>().anim.SetTrigger(IsHitted);
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        
    }
}
 
using System;
using TMPro;
using UnityEngine;

namespace Additional
{
    public class DamageDealer : MonoBehaviour
    {
        private static readonly int IsHitted = Animator.StringToHash("isHitted");

        private const float TimeToDestroy = 3.0f;
        private float _currentTimeToDestroy;
        
        [SerializeField] private float damage = 2.0f;

        private void Awake()
        {
            _currentTimeToDestroy = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Damageable")) return;
            
            if (!other.gameObject.GetComponent<Health>()) return;

            if (!other.gameObject.GetComponent<Health>().Alive()) return;

            other.gameObject.GetComponent<Health>().TakeDamage(damage);
                
            other.gameObject.GetComponent<Health>().anim.SetTrigger(IsHitted);
            Destroy(gameObject);
        }

        private void Update()
        {
            _currentTimeToDestroy += Time.deltaTime;

            if (_currentTimeToDestroy > TimeToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}
 
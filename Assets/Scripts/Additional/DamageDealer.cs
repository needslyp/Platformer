using UnityEngine;

namespace Additional
{
    public class DamageDealer : MonoBehaviour
    {
        protected static readonly int IsHitted = Animator.StringToHash("isHitted");

        [SerializeField] protected float damage = 2.0f;

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Damageable")) return;

            var health = other.gameObject.GetComponent<Health>();
            if (health == null || !health.Alive()) return;

            health.TakeDamage(damage);
            health.anim.SetTrigger(IsHitted);
        }
    }
}
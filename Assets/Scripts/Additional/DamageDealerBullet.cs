using UnityEngine;

namespace Additional
{
    public class DamageDealerBullet : DamageDealer
    {
        private const float TimeToDestroy = 3.0f;
        private float _currentTimeToDestroy;

        private void Awake()
        {
            _currentTimeToDestroy = 0;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.CompareTag("Damageable"))
            {
                Destroy(gameObject);
            }
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
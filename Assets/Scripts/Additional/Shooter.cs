using UnityEngine;

namespace Additional
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private GameObject bullet;
        [SerializeField] private float fireSpeed = 2.0f;
        public void Shoot(bool direction)
        {
            var currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            var currentBulletRender = currentBullet.GetComponent<SpriteRenderer>();
            var currentBulletRb = currentBullet.GetComponent<Rigidbody2D>();

            var speed = direction ? fireSpeed : -fireSpeed;
            currentBulletRender.flipX = !direction;
            currentBulletRb.velocity = new Vector2(speed, currentBulletRb.velocity.y);
        }
    }
}
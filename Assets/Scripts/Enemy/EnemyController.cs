using Additional;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        private static readonly int Velocity = Animator.StringToHash("Velocity");
        
        [SerializeField] private float speed = 2.0f;
        [SerializeField] private float timeToRevert;

        [SerializeField] private Animator anim;
        [SerializeField] private SpriteRenderer spr;
        
        [SerializeField] private Health health;

        private const float IdleState = 0;
        private const float WalkState = 1;
        private const float RevertState = 2;

        private float _currentState, _currentTimeToRevert;

        private Rigidbody2D _rb;

        private void Start()
        {
            _currentState = WalkState;
            _currentTimeToRevert = 0;
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_currentTimeToRevert > timeToRevert)
            {
                _currentTimeToRevert = 0;
                _currentState = RevertState;
            }

            switch (_currentState)
            {
                case IdleState:
                    _currentTimeToRevert += Time.deltaTime;
                    break;
                case WalkState:
                    _rb.velocity = Vector2.right * speed;
                    break;
                case RevertState:
                    spr.flipX = !spr.flipX;
                    speed *= -1;
                    _currentState = WalkState;
                    break;
            }
        
            anim.SetFloat(Velocity, _rb.velocity.magnitude);
            
            if (!health.Alive()) Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("EnemyStopper"))
            {
                _currentState = IdleState;
            }
        }
    }
}

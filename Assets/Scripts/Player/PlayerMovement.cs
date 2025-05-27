using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        private static readonly int IsJumping = Animator.StringToHash("isJumping");
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsFalling = Animator.StringToHash("isFalling");

        [Header("Movement vars")]
        [SerializeField] private float jumpForce = 3f;
        [SerializeField] private bool isGrounded = false;
           
        [Header("Settings")]    
        [SerializeField] private Transform colliderTransform;

        [SerializeField] private AnimationCurve curve;
        [SerializeField] private float jumpOffset = 0.2f;
        [SerializeField] private LayerMask groundMask;
        
        private Rigidbody2D _rb;
        private SpriteRenderer _sprite;
        private Animator _anim;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var overlapCirclePosition = colliderTransform.position;
            isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
            if (isGrounded)
            {
                _anim.SetBool(IsJumping, false);
                _anim.SetBool(IsFalling, false);
            }
            else
            {
                _anim.SetBool(IsFalling, true);
            }
        }

        public void Move(float direction, bool isJumpButtonPressed)
        {
            if (isJumpButtonPressed && isGrounded) {
                Jump();
                _anim.SetBool(IsJumping, true);
            }

            if (Mathf.Abs(direction) > 0.1f)
            {
                HorizontalMovement(direction);
                
                _anim.SetBool(IsRunning, isGrounded);
                
            }
            else
            {
                _anim.SetBool(IsRunning, false);
            }
        }

        private void Jump()
        {
            if (isGrounded)
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }

        private void HorizontalMovement(float direction)
        {
            _rb.velocity = new Vector2(curve.Evaluate(direction), _rb.velocity.y);
            _sprite.flipX = direction < 0;
        }
    }
}

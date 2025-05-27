using Additional;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Shooter))]
    public class PlayerInput : MonoBehaviour
    {
        private static readonly int IsThrowing = Animator.StringToHash("isThrowing");
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
        private static readonly int CountAttack = Animator.StringToHash("countAttack");

        [SerializeField] private ThrowPoint point;
        [SerializeField] private Health health;

        private PlayerMovement _playerMovement;
        private Shooter _shooter;

        private Animator _anim;
        private int _attackCounter = 0;

        private bool _isFacingRight = true;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _shooter = GetComponent<Shooter>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (!health.Alive()) return;
            
            var horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
            var isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

            _isFacingRight = horizontalDirection switch
            {
                > 0 => true,
                < 0 => false,
                _ => _isFacingRight
            };
            
            point.Flip(_isFacingRight); 

            if (Input.GetButtonDown(GlobalStringVars.Fire1))
            {
                _anim.SetBool(IsAttacking, true);
                _anim.SetInteger(CountAttack, _attackCounter);
                _attackCounter = (_attackCounter + 1) % 3;
            }
            else
            {
                _anim.SetBool(IsAttacking, false);
            }

            if (Input.GetButtonDown(GlobalStringVars.Fire2))
            {
                _anim.SetBool(IsThrowing, true);
                _shooter.Shoot(_isFacingRight);
            }
            else
            {
                _anim.SetBool(IsThrowing, false);
            }

            _playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }
    }
}

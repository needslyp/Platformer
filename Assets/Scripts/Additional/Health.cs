using UnityEngine;

namespace Additional
{
    public class Health : MonoBehaviour
    {
        private static readonly int IsDead = Animator.StringToHash("isDead");
        
        [SerializeField] public Animator anim;
        [SerializeField] private SpriteRenderer healthBarFill;
        private Vector3 _originalScale;

        [SerializeField] private float maxHealth = 10f;
        
        private float _currentHealth;
        private bool _isAlive;
        private Message _messageScript;
        private void Awake()
        {
            _currentHealth = maxHealth;
            _isAlive = true;
            
            if (healthBarFill != null)
            {
                _originalScale = healthBarFill.transform.localScale;
                UpdateHealthBar();
            }

            _messageScript = GetComponent<Message>();
        }

        public void TakeDamage(float damage)
        {
            if (_isAlive)
            {
                _currentHealth -= damage;
                
                if (healthBarFill != null)
                    UpdateHealthBar();
            }

            if (_currentHealth > 0) return;
            
            _isAlive = false;
            anim.SetBool(IsDead, true);
            _messageScript.ShowMessage("СМЕРТЬ");
        }
        
        public void TakeHeal(float points)
        {
            if (!_isAlive) return;
        
            _currentHealth = _currentHealth + points > maxHealth ? maxHealth : (_currentHealth + points);

            if (healthBarFill != null)
                UpdateHealthBar();
        }

        public bool Alive()
        {
            return _isAlive;
        }

        private void UpdateHealthBar()
        {
            if (healthBarFill == null) return;
        
            var healthPercent = _currentHealth / maxHealth * _originalScale.x;
            
            healthBarFill.transform.localScale = new Vector3(healthPercent, 1, 1);
        }
    }
}

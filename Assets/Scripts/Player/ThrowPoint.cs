using System;
using UnityEngine;

namespace Player
{
    public class ThrowPoint : MonoBehaviour
    {
        [SerializeField] private bool isFacingRight = true;
        [SerializeField] private Vector3 rightPosition;
        [SerializeField] private Vector3 leftPosition;

        private void Update()
        {
            transform.localPosition = isFacingRight ? rightPosition : leftPosition;
        }
        
        public void Flip(bool facingRight)
        {
            isFacingRight = facingRight;
        }
    }
}

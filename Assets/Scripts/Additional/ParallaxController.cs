using UnityEngine;

namespace Additional
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform[] layers;
        [SerializeField] private float[] coeffitients;

        private int _layerCounter;
        private void Start()
        {
            _layerCounter = layers.Length;
        }
        
        private void Update()
        {
            for (var i = 0; i < _layerCounter; i++)
            {
                layers[i].position = transform.position * coeffitients[i];
            }
        }
    }
}

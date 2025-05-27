using UnityEngine;
using UnityEngine.UI;

namespace Additional
{
    public class Message : MonoBehaviour
    {
        public GameObject messagePanel;

        private Text _messageText;

        private void Awake()
        {
            if (messagePanel == null) return;
            
            messagePanel.SetActive(false);
            _messageText = messagePanel.GetComponentInChildren<Text>();
        }
        
        public void ShowMessage(string newMessage)
        {   
            if (messagePanel == null) return;
            
            _messageText.text = newMessage;
            messagePanel.SetActive(true);
        }
        
        public void HideMessage()
        {
            if (messagePanel == null) return;
            
            messagePanel.SetActive(false);
        }
    }
}
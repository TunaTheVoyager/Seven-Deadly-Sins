using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameJam
{
    public class PlayerGui : MonoBehaviour
    {
        Health _playerHealth;
        
        private void Start()
        {
            _playerHealth = GetComponent<Health>();
        }
        
        public float fontSize = 20f; // Yazı tipi boyutunu ayarlamak için kullanılacak boyut

        private GUIStyle guiStyle = new GUIStyle();

        private void OnGUI()
        {
            guiStyle.fontSize = Mathf.RoundToInt(fontSize);
            GUI.Label(new Rect(5, 5, 400, 400), "Health: " + _playerHealth,guiStyle);
        }
    }
}

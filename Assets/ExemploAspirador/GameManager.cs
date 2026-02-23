using UnityEngine;
using TMPro;

namespace ExemploAspirador
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI perception;
        public TextMeshProUGUI action;
        
        public void SetPerception(string perception)
        {
            this.perception.text = perception;            
        }

        public void SetAction(string action)
        {
            this.action.text = action;
        }
    }
}


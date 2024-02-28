using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.Spot
{
    public class SpotModel : MonoBehaviour
    {
        [Header("Collider")] [SerializeField]
        private Collider m_colliderSpot = null;
       
        [Header("TextCounter")] [SerializeField]
        private TextMeshProUGUI m_textCounter = null;

        
        public TextMeshProUGUI TextCounter => m_textCounter;
        public Collider ColliderSpot => m_colliderSpot;

    }

}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.Spot
{
    public class SpotModel : MonoBehaviour
    {
        [Header("TypeItem")]
        [SerializeField] private ExtractType m_extractType = ExtractType.Unset;
        [Header("Collider")] 
        [SerializeField] private Collider m_colliderSpot = null;
       
        [Header("TextCounter")] 
        [SerializeField]private TextMeshProUGUI m_textCounter = null;
        [SerializeField]private TextMeshProUGUI m_textMustBe = null;
        
        public TextMeshProUGUI TextCounter => m_textCounter;
        public TextMeshProUGUI TextMustBe => m_textMustBe;
        public Collider ColliderSpot => m_colliderSpot;
        public ExtractType ExtractType => m_extractType;

    }

}

using TMPro;
using UnityEngine;

namespace Core.MainUi
{
    public class MainUiModel : MonoBehaviour
    {

        [Header("TextInfo")] 
        [SerializeField]  private TextMeshProUGUI m_woodCount = null;
        [SerializeField]  private TextMeshProUGUI m_lumberCount = null;
        [SerializeField]  private TextMeshProUGUI m_stoneCount = null;
        [SerializeField]  private TextMeshProUGUI m_crystallCount = null;
        
        public  TextMeshProUGUI  WoodCount => m_woodCount;
        public  TextMeshProUGUI  LumberCount => m_lumberCount;
        public  TextMeshProUGUI  StoneCount => m_stoneCount;
        public  TextMeshProUGUI  CrystallCount => m_crystallCount;

    }
}
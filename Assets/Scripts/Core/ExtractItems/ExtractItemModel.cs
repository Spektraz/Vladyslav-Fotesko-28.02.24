using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemModel : MonoBehaviour
    {
        [Header("GameObject")]
        [SerializeField] private GameObject m_gameObjectItem = null;
        [Header("ToolsType")] 
        [SerializeField] private ToolsName m_toolsName = ToolsName.Unset;
        [Header("Extract Type")] 
        [SerializeField] private ExtractType m_extractType = ExtractType.Unset;
        [Header("TextInfo")] 
        [SerializeField]  private int m_ItemCount = 0;
     
       public GameObject GameObjectItem => m_gameObjectItem;
       public  ToolsName  ToolsName => m_toolsName;
       public  ExtractType  ExtractType => m_extractType;
       public int ItemCount => m_ItemCount;
   
    }
}
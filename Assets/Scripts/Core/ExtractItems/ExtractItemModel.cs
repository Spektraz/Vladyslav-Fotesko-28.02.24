using System.Collections.Generic;
using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemModel : MonoBehaviour
    {
        [Header("GameObject")]
        [SerializeField] private List<GameObject> m_gameObjectListItem = null;
        [SerializeField] private GameObject m_gameObjectItem = null;
        [Header("Collider")]
        [SerializeField] private Collider m_colliderItem = null;
        [Header("ToolsType")] 
        [SerializeField] private ToolsName m_toolsName = ToolsName.Unset;
        [Header("Extract Type")] 
        [SerializeField] private ExtractType m_extractType = ExtractType.Unset;
        [Header("TextInfo")] 
        [SerializeField]  private int m_ItemCount = 0;
        
        public List<GameObject> GameObjectListItem => m_gameObjectListItem;
       public GameObject GameObjectItem => m_gameObjectItem;
       public Collider ColliderItem => m_colliderItem;
       public  ToolsName  ToolsName => m_toolsName;
       public  ExtractType  ExtractType => m_extractType;
       public int ItemCount => m_ItemCount;
   
    }
}
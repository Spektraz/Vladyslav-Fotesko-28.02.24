
using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemModel : MonoBehaviour
    { 
        [Header("ToolsType")] 
        [SerializeField] private ToolsName m_toolsName = ToolsName.Unset;
     [Header("TextInfo")] 
     [SerializeField]  private int m_woodCount = 0;
     

     public  ToolsName  ToolsName => m_toolsName;
     public int WoodCount => m_woodCount;
   
    }
}
using System.Collections.Generic;
using UnityEngine;


namespace Core.Terrain
{
    public class TerrainModel : MonoBehaviour
    {
        [Header("Canvas")] 
        [SerializeField] private List<Canvas> m_canvasListZone = null;
        [Header("ZoneSquare")]
        [SerializeField] private List<SpriteRenderer> m_spriteListZone = null;
        [Header("ZoneTerrain")]
        [SerializeField] private List<GameObject> m_objectListZone = null;
        [Header("Collider")]
        [SerializeField] private List<Collider> m_colliderZone = null;
        [SerializeField] private List<Collider> m_colliderReloadZone = null;
        public List<GameObject> ObjectListZone => m_objectListZone;
        public List<Canvas>  CanvasListZone => m_canvasListZone;
        public List<Collider> ColliderZone => m_colliderZone;
        public List<Collider> ColliderReloadZone => m_colliderReloadZone;
        public List<SpriteRenderer> SpriteListZone => m_spriteListZone;
        
    }
}


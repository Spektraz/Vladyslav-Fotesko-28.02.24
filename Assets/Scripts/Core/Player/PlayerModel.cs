using UnityEngine;

namespace Core.Player
{
    public class PlayerModel : MonoBehaviour
    {

        [Header("GameObject")] 
        [SerializeField]  private GameObject m_characterObject = null;
        [SerializeField]  private GameObject m_presetObject = null;
        [Header("Animator")] 
        [SerializeField]  private Animator m_characterAnimator = null;
        
        [Header("Tools")]
        [SerializeField]  private MeshRenderer m_axeMeshRenderer = null;
        [SerializeField]  private MeshRenderer m_crunchMeshRenderer = null;
        public  GameObject  CharacterObject => m_characterObject; 
        public  GameObject  PresetObject => m_presetObject;
        public  Animator  CharacterAnimator => m_characterAnimator;
        public  MeshRenderer  AxeMeshRenderer => m_axeMeshRenderer;
        public  MeshRenderer  CrunchMeshRenderer => m_crunchMeshRenderer;
    }
}
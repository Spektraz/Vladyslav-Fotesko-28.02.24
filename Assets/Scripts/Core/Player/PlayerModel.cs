using UnityEngine;

namespace Core.Player
{
    public class PlayerModel : MonoBehaviour
    {

        [Header("Animator")] 
        [SerializeField]  private Animator m_characterAnimator = null;
        
        [Header("Tools")]
        [SerializeField]  private MeshRenderer m_axeMeshRenderer = null;
        [SerializeField]  private MeshRenderer m_crunchMeshRenderer = null;
        public  Animator  CharacterAnimator => m_characterAnimator;
        public  MeshRenderer  AxeMeshRenderer => m_axeMeshRenderer;
        public  MeshRenderer  CrunchMeshRenderer => m_crunchMeshRenderer;
    }
}
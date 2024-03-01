using UnityEngine;

namespace Core.Wall
{
    public class WallView : MonoBehaviour
    {
        [SerializeField] private WallModel m_viewModel = null;
        private WallController m_controller = null;

        private void Start()
        {
            m_controller = new WallController(m_viewModel);
          
        }

        private void OnTriggerEnter(Collider other)
        {        
            m_controller.TriggerEnter();        
        }
    }
}
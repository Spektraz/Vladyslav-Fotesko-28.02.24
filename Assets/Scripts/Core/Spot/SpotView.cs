using UnityEngine;

namespace Core.Spot
{
    public class SpotView : MonoBehaviour
    {
        [SerializeField] private SpotModel m_viewModel = null;
        private SpotController m_controller = null;

        private void Start()
        {
            m_controller = new SpotController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnTriggerEnter(Collider other)
        {
            m_controller.TriggerEnter();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }

}

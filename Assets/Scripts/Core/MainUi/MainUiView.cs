using UnityEngine;

namespace Core.MainUi
{
    public class MainUiView : MonoBehaviour
    {
        [SerializeField] private MainUiModel m_viewModel = null;
        private MainUiController m_controller = null;

        private void Start()
        {
            m_controller = new MainUiController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}


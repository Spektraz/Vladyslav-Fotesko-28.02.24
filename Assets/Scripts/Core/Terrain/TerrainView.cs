using UnityEngine;

namespace Core.Terrain
{
    public class TerrainView : MonoBehaviour
    {

        [SerializeField] private TerrainModel m_viewModel = null;
        private TerrainController m_controller = null;

        private void Start()
        {
            m_controller = new TerrainController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}


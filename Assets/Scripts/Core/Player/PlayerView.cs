using System;
using UnityEngine;

namespace Core.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerModel m_viewModel = null;
        private PlayerController m_controller = null;

        private void Start()
        {
            m_controller = new PlayerController(m_viewModel);
            m_controller.Initialize();
        }
        

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }

}
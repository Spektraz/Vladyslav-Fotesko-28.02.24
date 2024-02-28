using System;
using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemView : MonoBehaviour
    {

        [SerializeField] private ExtractItemModel m_viewModel = null;
        private ExtractItemController m_controller = null;

        private void Start()
        {
            m_controller = new ExtractItemController(m_viewModel);
            m_controller.Initialize();
        }
  

        private void OnTriggerEnter(Collider other)
        {
          
            m_controller.TriggerEnter();
        }
        private void OnTriggerExit(Collider other)
        {
          
            m_controller.TriggerExit();
        }
        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}
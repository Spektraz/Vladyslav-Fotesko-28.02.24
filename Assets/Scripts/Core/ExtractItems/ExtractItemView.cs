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
        }
  

        private void OnTriggerEnter(Collider other)
        {
          
            m_controller.TriggerEnter();
            StartCoroutine(m_controller.DestroyObjects());
        }

        private void Update()
        {
            m_controller.RotateObject();
        }

        private void OnTriggerExit(Collider other)
        {
          
            m_controller.TriggerExit();
        }
      
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemController 
    {

        private ExtractItemModel m_viewModel = null;
        private float speedDestroy = 10;
        private string m_animDestroy = "Destroy";
        private string m_animCreate = "Create";
        private bool m_isRotate = false;
        public ExtractItemController(ExtractItemModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
          
            InitializeEvents();
        }

        public void TriggerEnter()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(m_viewModel.ToolsName);
        }

        public void TriggerExit()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(ToolsName.Unset);
        }
        private void InitializeEvents()
        {
            
        }
       
        private void DisposeEvents()
        {
          
        }

        public void RotateObject()
        {
            if (m_isRotate)
                m_viewModel.GameObjectItem.transform.Rotate(0, 0, speedDestroy * Time.deltaTime);
        }
        public IEnumerator DestroyObjects()
        {
            yield return new WaitForSeconds(1.5f);
            m_isRotate = true;
            yield return new WaitForSeconds(2.5f);
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(ToolsName.Unset);
            m_viewModel.GameObjectItem.SetActive(false);
            ApplicationContainer.Instance.EventHolder.OnAddItems(m_viewModel.ItemCount, m_viewModel.ExtractType);
            m_isRotate = false;
            yield return new WaitForSeconds(5.0f);
            Debug.Log("REload");
            m_viewModel.GameObjectItem.transform.rotation = new Quaternion(0, 0, 0 , 0);
            m_viewModel.GameObjectItem.SetActive(true);
        }
     
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
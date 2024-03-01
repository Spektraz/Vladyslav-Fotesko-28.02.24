using System;
using System.Collections;
using UnityEngine;

namespace Core.ExtractItems
{
    public class ExtractItemController 
    {

        private ExtractItemModel m_viewModel = null;
        private int m_countDispose = 0;
        private float m_speedDestroy = 10;      
        private bool m_isRotate = false;
        public ExtractItemController(ExtractItemModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public void TriggerEnter()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(m_viewModel.ToolsName);
        }

        public void TriggerExit()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(ToolsName.Unset);
        }
      
        public void RotateObject()
        {
            if (m_isRotate)
                m_viewModel.GameObjectItem.transform.Rotate(0, 0, m_speedDestroy * Time.deltaTime);
        }
        public IEnumerator DestroyObjects()
        {
            yield return new WaitForSeconds(0.5f);
            DisposeObject();
            yield return new WaitForSeconds(1.0f);
            DisposeObject();
            yield return new WaitForSeconds(1.5f);
            DisposeObject();
            m_isRotate = true;
            yield return new WaitForSeconds(2.5f);
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtract(ToolsName.Unset);
            m_viewModel.GameObjectItem.SetActive(false);
            m_viewModel.ColliderItem.enabled = false;
            ApplicationContainer.Instance.EventHolder.OnAddItems(m_viewModel.ItemCount, m_viewModel.ExtractType);
            m_isRotate = false;
            yield return new WaitForSeconds(5.0f);
            m_viewModel.GameObjectItem.transform.rotation = new Quaternion(0, 0, 0 , 0);
            CreateObject();
            m_viewModel.GameObjectItem.SetActive(true);
            m_viewModel.ColliderItem.enabled = true;
            m_countDispose = 0;
        }

        private void DisposeObject()
        {
            if(m_viewModel.GameObjectListItem == null)
                return;
            if (m_countDispose >= 3)
                m_countDispose -= 1;         
            m_viewModel.GameObjectListItem[m_countDispose].SetActive(false);        
            m_countDispose += 1;
        }

        private void CreateObject()
        {
            if (m_viewModel.GameObjectListItem == null)
                return;
            foreach (var var in m_viewModel.GameObjectListItem)
            {
                var.SetActive(true);
            }
        }
     
    }
}
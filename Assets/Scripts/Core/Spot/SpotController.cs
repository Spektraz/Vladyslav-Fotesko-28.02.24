using Core.MainUi;
using System;
using UnityEngine;

namespace Core.Spot
{
    public class SpotController 
    {

        private SpotModel m_viewModel = null;
        private string maxCount = null;
        private bool isUpdate = false;
        public SpotController(SpotModel viewModel)
        {
            m_viewModel = viewModel; 
            maxCount = m_viewModel.TextMustBe.text.Substring(1);        
        }
        public void Initialize()
        {
            SetCounter(0);
            InitializeEvents();
        }

        public void TriggerEnter()
        {
            isUpdate = false;
            int countNow = 0;
            int.TryParse(m_viewModel.TextCounter.ToString(), out countNow);
            ApplicationContainer.Instance.EventHolder.OnSpendItems(Convert.ToInt32(maxCount),  countNow, m_viewModel.ExtractType);
        }

        private void InitializeEvents()
        {
            Debug.Log("InitializeEvents");
            ApplicationContainer.Instance.EventHolder.OnMaxItemsEvent += SetCounter;
            ApplicationContainer.Instance.EventHolder.OnSetUpdateScoreEvent += SetScore;
        }
    
        private void SetCounter(int count)
        {        
            m_viewModel.TextCounter.text = count.ToString();          
            if (count == Convert.ToInt32(maxCount))
            {
                ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                ApplicationContainer.Instance.EventHolder.OnChangeSpot();
                m_viewModel.TextCounter.text = "0";
                      
            }
        }
        private void SetScore(bool isState)
        {
            Debug.Log("SetScore");
            m_viewModel.TextCounter.text = "0";        
        }
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnMaxItemsEvent -= SetCounter;
            ApplicationContainer.Instance.EventHolder.OnSetUpdateScoreEvent -= SetScore;
        }

     
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
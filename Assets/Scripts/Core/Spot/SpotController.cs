using System;
using UnityEngine;

namespace Core.Spot
{
    public class SpotController 
    {

        private SpotModel m_viewModel = null;
        private string maxCount = null;
        private int nowCount = 0;
        public SpotController(SpotModel viewModel)
        {
            m_viewModel = viewModel; 
            maxCount = m_viewModel.TextMustBe.text.Substring(1);        
        }
        public void Initialize()
        {
        
            InitializeEvents();
        }

        public void TriggerEnter()
        {
         
            int countNow = 0;
            int.TryParse(m_viewModel.TextCounter.ToString(), out countNow);
            ApplicationContainer.Instance.EventHolder.OnSpendItems(Convert.ToInt32(maxCount),  countNow, m_viewModel.ExtractType);
        }

        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnMaxItemsEvent += SetCounter;
            ApplicationContainer.Instance.EventHolder.OnSetUpdateScoreEvent += SetScore;
        }
    
        private void SetCounter(int count, int index)
        {
            if (index == m_viewModel.IndexSpot)
            {
                nowCount = index;
                m_viewModel.TextCounter.text = count.ToString();
                if (count == Convert.ToInt32(maxCount))
                {                
                    ApplicationContainer.Instance.EventHolder.OnChangeSpot();
                    ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                }
                return;
            }
            ApplicationContainer.Instance.EventHolder.OnScoreLast(count);
        }
        private void SetScore(bool isState)
        {

            if (isState)
            {
                if(m_viewModel.IndexSpot > nowCount)
                     m_viewModel.TextCounter.text = "0";
                  
            }
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
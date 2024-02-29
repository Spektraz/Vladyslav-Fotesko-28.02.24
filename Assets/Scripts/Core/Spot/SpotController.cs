using System;

namespace Core.Spot
{
    public class SpotController 
    {

        private SpotModel m_viewModel = null;
       
        public SpotController(SpotModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            SetCounter(0);
            InitializeEvents();
        }

        public void TriggerEnter()
        {
            ApplicationContainer.Instance.EventHolder.OnChangeCountSpot(Convert.ToInt32(m_viewModel.TextMustBe.text), m_viewModel.ExtractType);
        }

        private void InitializeEvents()
        {
            
        }

        private void SetCounter(int count)
        {
            m_viewModel.TextCounter.text = count.ToString();
        }
        private void DisposeEvents()
        {
          
        }

     
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
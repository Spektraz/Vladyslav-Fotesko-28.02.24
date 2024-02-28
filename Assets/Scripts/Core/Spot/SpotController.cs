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
          
            InitializeEvents();
        }

        public void TriggerEnter()
        {
        //    ApplicationContainer.Instance.EventHolder.OnChangeCountSpot();
        }

        private void InitializeEvents()
        {
            
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
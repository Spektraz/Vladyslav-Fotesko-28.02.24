using System;
namespace Core.MainUi
{
    public class MainUiController 
    {

        private MainUiModel m_viewModel = null;
      
        public MainUiController(MainUiModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            InitializeCounters();
            InitializeEvents();
        }

        private void InitializeCounters()
        {
            
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
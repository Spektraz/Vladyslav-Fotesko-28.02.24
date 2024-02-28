using System;
namespace Core.ExtractItems
{
    public class ExtractItemController 
    {

        private ExtractItemModel m_viewModel = null;
       
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

     
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
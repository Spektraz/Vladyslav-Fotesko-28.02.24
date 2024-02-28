using System;

namespace Core.Player
{
    public class PlayerController 
    {

        private PlayerModel m_viewModel = null;
        private string m_axeExtractAnimation = "Axe";
        private string m_runExtractAnimation = "Run";
        
        public PlayerController(PlayerModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
          
            InitializeEvents();
        }

      

        private void InitializeEvents()
        {
                ApplicationContainer.Instance.EventHolder.OnSwitchToExtractEvent += TakeWeapon;
        }
       
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchToExtractEvent -= TakeWeapon;
        }

        private void TakeWeapon(ToolsName toolsName)
        {
            m_viewModel.CharacterAnimator.SetBool(m_axeExtractAnimation , true);
            if (toolsName == ToolsName.Axe)
            {
                m_viewModel.AxeMeshRenderer.enabled = true;
                m_viewModel.CrunchMeshRenderer.enabled = false;
            }
            else if(toolsName == ToolsName.Nails)
            {
                m_viewModel.AxeMeshRenderer.enabled = false;
                m_viewModel.CrunchMeshRenderer.enabled = true;
            }
            else
            {
                m_viewModel.CharacterAnimator.SetBool(m_axeExtractAnimation , false);
            }
        }

        public void SetRun()
        {
            m_viewModel.CharacterAnimator.SetBool(m_runExtractAnimation, true);
        }
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
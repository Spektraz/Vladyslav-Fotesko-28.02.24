using System;
using UnityEngine.SceneManagement;

namespace Core.Wall
{
    public class WallController 
    {
        private WallModel m_viewModel = null;
        public WallController(WallModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void TriggerEnter()
        {
            SceneManager.LoadScene(GlobalConst.ReloadScene);
        }

    }
}
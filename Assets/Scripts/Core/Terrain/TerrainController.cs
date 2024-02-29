using System;
namespace Core.Terrain
{
    public class TerrainController 
    {

        private TerrainModel m_viewModel = null;
        private int countOpen = 0;
        public TerrainController(TerrainModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            InitializeTerrains();
            InitializeEvents();
        }
        private void InitializeTerrains()
        {
            SwitchOnZone();
        }

        private void InitializeEvents()
        {
          //    ApplicationContainer.Instance.EventHolder.OnChangeCountSpotEvent += SwitchOnCollector;
        }
        private void SwitchOnZone()
        {
            SwitchOffZone();
            m_viewModel.CanvasListZone[countOpen].enabled = true;
            m_viewModel.SpriteListZone[countOpen].enabled = true;
        }

        private void SwitchOffZone()
        {
            for (int i = 0; i < m_viewModel.SpriteListZone.Count; i++)
            {
                m_viewModel.CanvasListZone[i].enabled = false;
                m_viewModel.SpriteListZone[i].enabled = false;
                if(countOpen <= i)
                {
                 m_viewModel.ObjectListZone[i].SetActive(false);
                }
            }
        }
        private void SwitchOnCollector(int countRes)
        {
            
        }

        public void AddNewZone()
        {
            countOpen++;
        }
        private void DisposeEvents()
        {
         //   ApplicationContainer.Instance.EventHolder.OnChangeCountSpotEvent -= SwitchOnCollector;
        }
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}


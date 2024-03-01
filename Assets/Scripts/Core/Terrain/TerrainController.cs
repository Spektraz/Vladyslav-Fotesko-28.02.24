using System;
using UnityEngine;

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
            countOpen = Load();
            SwitchOnZone();
        }

        private void InitializeEvents()
        {
             ApplicationContainer.Instance.EventHolder.OnChangeSpotEvent += AddZone;
        }
        private void SwitchOnZone()
        {
            SwitchOffZone();         

            for (int i = 0; i < countOpen; i++)
            {
                if (countOpen > 0)
                {
                    m_viewModel.ObjectListZone[countOpen - 1].SetActive(true);
                    m_viewModel.ColliderReloadZone[i].enabled = false;
                   
                }
               
            }
            m_viewModel.CanvasListZone[countOpen].enabled = true;
            m_viewModel.SpriteListZone[countOpen].enabled = true;
            m_viewModel.ColliderZone[countOpen].enabled = true;

        }

        private void SwitchOffZone()
        {
            for (int i = 0; i < m_viewModel.SpriteListZone.Count; i++)
            {
                m_viewModel.CanvasListZone[i].enabled = false;
                m_viewModel.SpriteListZone[i].enabled = false;
                m_viewModel.ColliderZone[i].enabled = false;
                m_viewModel.ColliderReloadZone[i].enabled = true;
                if (countOpen <= i)
                {
                 m_viewModel.ObjectListZone[i].SetActive(false);
                }
            }
        }
        private void AddZone()
        {         
            countOpen += 1;
            Save(countOpen);
            SwitchOnZone();
        }
        private void Save(int save)
        {
            SaveManager.Save(GlobalConst.Titles, save);
        }
        private int Load()
        {
            var result = SaveManager.LoadInt(GlobalConst.Titles);
            return result;
        }
        private void DisposeEvents()
        {
           ApplicationContainer.Instance.EventHolder.OnChangeSpotEvent -= AddZone;
        }
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}


using System;
using UnityEngine;

namespace Core.MainUi
{
    public class MainUiController 
    {

        private MainUiModel m_viewModel = null;
        private InventoryStruct inventory;
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
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent += AddInCounter;
            ApplicationContainer.Instance.EventHolder.OnChangeCountSpotEvent += SpendInCounter;
        }
       
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent -= AddInCounter;
          
        }

        private void AddInCounter(int itemCount, ExtractType extractType)
        {
            switch (extractType)
            {
                case ExtractType.Wood:
                    inventory.Wood += itemCount;
                    m_viewModel.WoodCount.text = inventory.Wood.ToString();
                    break;
                case ExtractType.Lumber:
                    inventory.Lumber += itemCount;
                    m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                    break;
                case ExtractType.Stone:
                    inventory.Stone += itemCount;
                    m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    break;
                case ExtractType.Crystall:
                    inventory.Crystall += itemCount;
                    m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                    break;
            }
        }

        private void SpendInCounter(int itemCount, ExtractType extractType)
        {
            switch (extractType)
            {
                case ExtractType.Wood:
                    inventory.Wood -= itemCount;
                    m_viewModel.WoodCount.text = inventory.Wood.ToString();
                    break;
                case ExtractType.Lumber:
                    inventory.Lumber -= itemCount;
                    m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                    break;
                case ExtractType.Stone:
                    inventory.Stone -= itemCount;
                    m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    break;
                case ExtractType.Crystall:
                    inventory.Crystall -= itemCount;
                    m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                    break;
            }
        }

        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
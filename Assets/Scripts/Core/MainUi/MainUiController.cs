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
            ApplicationContainer.Instance.EventHolder.OnSpendItemsEvent += SpendInCounter;
        }
       
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent -= AddInCounter;
            ApplicationContainer.Instance.EventHolder.OnSpendItemsEvent -= SpendInCounter;

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
                    if (inventory.Wood >= GlobalConst.LumberToWoodCount)
                    {
                        int result = inventory.Wood / GlobalConst.LumberToWoodCount;
                        inventory.Lumber += result;
                        inventory.Wood -= (result * GlobalConst.LumberToWoodCount);
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                        m_viewModel.WoodCount.text = inventory.Wood.ToString();
                    }
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

        private void SpendInCounter(int itemMustBe, int itemHave, ExtractType extractType)
        {
            switch (extractType)
            {
                case ExtractType.Wood:
                    if (inventory.Wood > itemMustBe)
                    {
                        inventory.Wood -= itemMustBe;
                        m_viewModel.WoodCount.text = inventory.Wood.ToString();
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe);
                    }
                    else
                    {
                        int result = 0;
                        inventory.ResultZone += itemHave + inventory.Wood;
                        //  inventory.ResultZone += itemHave + inventory.Wood;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone);
                        if (inventory.ResultZone >= itemMustBe)
                        {
                            result =  inventory.ResultZone - itemMustBe;
                            inventory.ResultZone = 0;   
                        }
                        inventory.Wood = result;
                        m_viewModel.WoodCount.text  = inventory.Wood.ToString();
                    }
                    break;
                case ExtractType.Lumber:
                    inventory.Lumber -= itemMustBe;
                    m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                    break;
                case ExtractType.Stone:
                    inventory.Stone -= itemMustBe;
                    m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    break;
                case ExtractType.Crystall:
                    inventory.Crystall -= itemMustBe;
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
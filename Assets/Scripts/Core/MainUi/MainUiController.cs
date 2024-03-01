using System;
using System.Diagnostics;
using UnityEngine;


namespace Core.MainUi
{
    public class MainUiController 
    {

        private MainUiModel m_viewModel = null;
        private InventoryStruct inventory;
        private int resultSpend = 0;
        private int currentSpot = 0;
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
            ApplicationContainer.Instance.EventHolder.OnScoreLastEvent += ChangeScore;
        }

        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent -= AddInCounter;
            ApplicationContainer.Instance.EventHolder.OnSpendItemsEvent -= SpendInCounter;
            ApplicationContainer.Instance.EventHolder.OnScoreLastEvent -= ChangeScore;

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
                        currentSpot += 1;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        int result = 0;
                        inventory.ResultZone += itemHave + inventory.Wood;                  
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        if (inventory.ResultZone >= itemMustBe)
                        {
                            currentSpot += 1;
                            result =  inventory.ResultZone - itemMustBe;
                            inventory.ResultZone = 0;
                            m_viewModel.WoodCount.text = result.ToString();
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                        }
                        inventory.Wood = result;
                        m_viewModel.WoodCount.text  = inventory.Wood.ToString();
                    }
                    break;
                case ExtractType.Lumber:
                    if (inventory.Lumber > itemMustBe)
                    {
                        inventory.Lumber -= itemMustBe;
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                        currentSpot += 1;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        int result = 0;
                        inventory.ResultZone += itemHave + inventory.Lumber;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        if (inventory.ResultZone >= itemMustBe)
                        {
                            currentSpot += 1;
                            result = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone = 0;
                            m_viewModel.LumberCount.text = result.ToString();
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                        }
                        inventory.Lumber = result;
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                    }
                    break;
                case ExtractType.Stone:
                    if (inventory.Stone > itemMustBe)
                    {
                        inventory.Stone -= itemMustBe;
                        m_viewModel.StoneCount.text = inventory.Stone.ToString();
                        currentSpot += 1;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        int result = 0;
                        inventory.ResultZone += itemHave + inventory.Stone;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        if (inventory.ResultZone >= itemMustBe)
                        {
                            currentSpot += 1;
                            result = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone = 0;
                            m_viewModel.StoneCount.text = result.ToString();
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                        }
                        inventory.Stone = result;
                        m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    }
                    break;
                case ExtractType.Crystall:
                    if (inventory.Crystall > itemMustBe)
                    {
                        inventory.Crystall -= itemMustBe;
                        m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                        currentSpot += 1;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        int result = 0;
                        inventory.ResultZone += itemHave + inventory.Crystall;
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        if (inventory.ResultZone >= itemMustBe)
                        {
                            currentSpot += 1;
                            result = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone = 0;
                            m_viewModel.CrystallCount.text = result.ToString();
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                        }
                        inventory.Crystall = result;
                        m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                    }
                    break;
            }
        }
        private void ChangeScore(int count)
        {
            if (resultSpend != count)
                ApplicationContainer.Instance.EventHolder.OnSetUpdateScoreEvent(true);
            else
                resultSpend = count;
        }
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
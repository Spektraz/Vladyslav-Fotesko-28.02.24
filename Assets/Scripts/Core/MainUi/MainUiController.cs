using System;
using System.Diagnostics;
using Unity.VisualScripting;
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
           
            int WoodCount = SaveManager.LoadInt(GlobalConst.ResouresWood);
            int LumberCount = SaveManager.LoadInt(GlobalConst.ResouresLumber);
            int StoneCount = SaveManager.LoadInt(GlobalConst.ResouresStone);
            int CrystallCount = SaveManager.LoadInt(GlobalConst.ResouresCrystall);
            currentSpot = SaveManager.LoadInt(GlobalConst.Titles);
            inventory.Wood = WoodCount;
            inventory.Lumber = LumberCount;
            inventory.Stone = StoneCount;
            inventory.Crystall = CrystallCount;
            m_viewModel.WoodCount.text = inventory.Wood.ToString();
            m_viewModel.LumberCount.text = inventory.Lumber.ToString();
            m_viewModel.StoneCount.text = inventory.Stone.ToString();
            m_viewModel.CrystallCount.text = inventory.Crystall.ToString();

        }
        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent += AddInCounter;
            ApplicationContainer.Instance.EventHolder.OnSpendItemsEvent += SpendInCounter;
            ApplicationContainer.Instance.EventHolder.OnScoreLastEvent += ChangeScore;
            ApplicationContainer.Instance.EventHolder.OnChangeSpotEvent += ReloadResult;
        }

        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnAddItemsEvent -= AddInCounter;
            ApplicationContainer.Instance.EventHolder.OnSpendItemsEvent -= SpendInCounter;
            ApplicationContainer.Instance.EventHolder.OnScoreLastEvent -= ChangeScore;
            ApplicationContainer.Instance.EventHolder.OnChangeSpotEvent -= ReloadResult;
        }

        private void AddInCounter(int itemCount, ExtractType extractType)
        {
            switch (extractType)
            {
                case ExtractType.Wood:
                    inventory.Wood += itemCount;
                    m_viewModel.WoodCount.text = inventory.Wood.ToString();
                    Save(GlobalConst.ResouresWood, inventory.Wood);               
                    break;
                case ExtractType.Lumber:
                    if (inventory.Wood >= GlobalConst.LumberToWoodCount)
                    {
                        int result = inventory.Wood / GlobalConst.LumberToWoodCount;
                        inventory.Lumber += result;
                        inventory.Wood -= (result * GlobalConst.LumberToWoodCount);
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                        m_viewModel.WoodCount.text = inventory.Wood.ToString();
                        Save(GlobalConst.ResouresWood, inventory.Wood);
                        Save(GlobalConst.ResouresLumber, inventory.Lumber);                  
                    }
                    break;
                case ExtractType.Stone:
                    inventory.Stone += itemCount;
                    m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    Save(GlobalConst.ResouresStone, inventory.Stone);                   
                    break;
                case ExtractType.Crystall:
                    inventory.Crystall += itemCount;
                    m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                    Save(GlobalConst.ResouresCrystall, inventory.Crystall);                  
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
                        Save(GlobalConst.ResouresWood, inventory.Wood);
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        inventory.ResultZone += itemHave + inventory.Wood;                     
                        if (inventory.ResultZone > itemMustBe)                   
                        {
                            int number = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone -= number;                           
                            inventory.Wood = number;
                            currentSpot += 1;                        
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        }
                        else
                        {
                            inventory.Wood = 0;
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot + 1);
                        }
                        Save(GlobalConst.ResouresWood, inventory.Wood);
                        m_viewModel.WoodCount.text = inventory.Wood.ToString();    
                    }
                    break;
                case ExtractType.Lumber:
                    if (inventory.Lumber > itemMustBe)
                    {
                        inventory.Lumber -= itemMustBe;
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                        currentSpot += 1;
                        Save(GlobalConst.ResouresLumber, inventory.Lumber);
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        inventory.ResultZone += itemHave + inventory.Lumber;
                        if (inventory.ResultZone > itemMustBe)
                        {
                            int number = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone -= number;
                            inventory.Lumber = number;
                            currentSpot += 1;
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        }
                        else
                        {
                            inventory.Lumber = 0;
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot + 1);
                        }
                        Save(GlobalConst.ResouresLumber, inventory.Lumber);
                        m_viewModel.LumberCount.text = inventory.Lumber.ToString();
                    }
                    break;
                case ExtractType.Stone:
                    if (inventory.Stone > itemMustBe)
                    {
                        inventory.Stone -= itemMustBe;
                        m_viewModel.StoneCount.text = inventory.Stone.ToString();
                        currentSpot += 1;
                        Save(GlobalConst.ResouresStone, inventory.Stone);
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                    }
                    else
                    {
                        inventory.ResultZone += itemHave + inventory.Stone;
                        if (inventory.ResultZone > itemMustBe)
                        {
                            int number = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone -= number;
                            inventory.Stone = number;
                            currentSpot += 1;
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        }
                        else
                        {
                            inventory.Stone = 0;
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot + 1);
                        }
                        Save(GlobalConst.ResouresStone, inventory.Stone);
                        m_viewModel.StoneCount.text = inventory.Stone.ToString();
                    }
                    break;
                case ExtractType.Crystall:
                    if (inventory.Crystall > itemMustBe)
                    {
                        inventory.Crystall -= itemMustBe;
                        m_viewModel.CrystallCount.text = inventory.Crystall.ToString();
                        currentSpot += 1;
                        Save(GlobalConst.ResouresCrystall, inventory.Crystall);
                        ApplicationContainer.Instance.EventHolder.OnMaxItems(itemMustBe, currentSpot);
                        ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);

                    }
                    else
                    {
                        inventory.ResultZone += itemHave + inventory.Crystall;
                        if (inventory.ResultZone > itemMustBe)
                        {
                          
                            int number = inventory.ResultZone - itemMustBe;
                            inventory.ResultZone -= number;
                            inventory.Crystall = number;
                            currentSpot += 1;                          
                            ApplicationContainer.Instance.EventHolder.OnSetUpdateScore(true);
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot);
                        }
                        else
                        {
                                            
                            inventory.Crystall = 0;
                            ApplicationContainer.Instance.EventHolder.OnMaxItems(inventory.ResultZone, currentSpot + 1);
                            
                        }
                        Save(GlobalConst.ResouresCrystall, inventory.Crystall);
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
            {            
                resultSpend = count;
            }
        }
        private void Save(string name, int score)
        {
            SaveManager.Save(name, score);
        }
      
        private void ReloadResult()
        {
            inventory.ResultZone = 0;
        }
        public void Dispose()
        {
            DisposeEvents();
        }
    }
}
using UnityEngine;
namespace System
{
    public class EventHolder 
    {
        public Action<int, int, ExtractType> OnSpendItemsEvent;
        public void OnSpendItems(int count, int itemHave, ExtractType extractType)
        {
            var temp = OnSpendItemsEvent;
            temp?.Invoke(count, itemHave,extractType);
        }
        public Action<ToolsName> OnSwitchToExtractEvent;
        public void OnSwitchToExtract(ToolsName toolsName)
        {
            var temp = OnSwitchToExtractEvent;
            temp?.Invoke(toolsName);
        }
        public Action<Vector2> OnPositionJoystickEvent;
        public void OnPositionJoystick(Vector2 posJoystick)
        {
            var temp = OnPositionJoystickEvent;
            temp?.Invoke(posJoystick);
        }
        public Action<bool> OnStopJoystickEvent;
        public void OnStopJoystick(bool stateJoystick)
        {
            var temp = OnStopJoystickEvent;
            temp?.Invoke(stateJoystick);
        }
        public Action<int,ExtractType> OnAddItemsEvent;
        public void OnAddItems(int itemsMustBeCount, ExtractType extractType)
        {
            var temp = OnAddItemsEvent;
            temp?.Invoke(itemsMustBeCount,extractType);
        }
        public Action<int, int> OnMaxItemsEvent;
        public void OnMaxItems(int itemsCount, int index)
        {
            var temp = OnMaxItemsEvent;
            temp?.Invoke(itemsCount, index);
        }
      
        public Action OnChangeSpotEvent;
        public void OnChangeSpot()
        {
            var temp = OnChangeSpotEvent;
            temp?.Invoke();
        }
        public Action<bool> OnSetUpdateScoreEvent;
        public void OnSetUpdateScore(bool isState)
        {
            var temp = OnSetUpdateScoreEvent;
            temp?.Invoke(isState);
        }
        public Action<int> OnScoreLastEvent;
        public void OnScoreLast(int itemsCount)
        {
            var temp = OnScoreLastEvent;
            temp?.Invoke(itemsCount);
        }
    }
}

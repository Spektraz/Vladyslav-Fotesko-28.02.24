using UnityEngine;
namespace System
{
    public class EventHolder 
    {
        public Action<int, ExtractType> OnChangeCountSpotEvent;
        public void OnChangeCountSpot(int count,  ExtractType extractType)
        {
            var temp = OnChangeCountSpotEvent;
            temp?.Invoke(count,extractType);
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
        public void OnAddItems(int itemsCount, ExtractType extractType)
        {
            var temp = OnAddItemsEvent;
            temp?.Invoke(itemsCount,extractType);
        }
    }
}

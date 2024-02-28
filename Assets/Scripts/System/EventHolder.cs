namespace System
{
    public class EventHolder 
    {
        public Action<int> OnChangeCountSpotEvent;
        public void OnChangeCountSpot(int count)
        {
            var temp = OnChangeCountSpotEvent;
            temp?.Invoke(count);
        }
        public Action<ToolsName> OnSwitchToExtractEvent;
        public void OnSwitchToExtract(ToolsName toolsName)
        {
            var temp = OnSwitchToExtractEvent;
            temp?.Invoke(toolsName);
        }
    }
}

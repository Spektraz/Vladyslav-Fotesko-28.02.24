using UnityEngine;

namespace System
{
    public class GlobalConst 
    {
        [Header("Save")]
        public const string Titles = "Titles";
        public const string ResouresWood = "ResouresWood";
        public const string ResouresLumber = "ResouresLumber";
        public const string ResouresStone = "ResouresStone";
        public const string ResouresCrystall = "ResouresCrystall";
        public const string PositionPlayerX = "PositionPlayerX";
        public const string PositionPlayerY = "PositionPlayerY";
        public const string PositionPlayerZ = "PositionPlayerZ";
        [Header("Scene")]
        public const string GameScene = "Scenes/Game";
        public const string ReloadScene = "Scenes/SampleScene";
        [Header("NameAnimation")]
        public const string AxeAnimation = "Axe";
        public const string RunAnimation = "Run";
        public const string FinishAnimation = "Finish";
        [Header("Count")] 
        public const int LumberCount = 5;
        public const int LumberToWoodCount = 3;
        public const int ObjectPartDestroy = 3;
        public const float ObjectSpeedDestroy = 10.0f;
        [Header("Coordination")]
        public const int SpeedRotationPlayer = 360;
        public const float SpeedMovePlayer = 3.0f;
        public const float StartCoordPlayer = 3.88f;
      

    }
}

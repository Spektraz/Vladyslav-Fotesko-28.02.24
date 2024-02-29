using UnityEngine;

namespace System
{
    public class GlobalConst 
    {
        [Header("Save")]
        public const string SoundKey = "Sound";
        public const string CoinsString = "CoinsStringss";
        public const string CoinsInt = "CoinsIntss";
        public const string SceneMainGame = "MainScene";
        [Header("Scene")]
        public const string GameScene = "Scenes/Game";
        public const string ReloadScene = "Scenes/SampleScene";
        
        [Header("Count")] 
        public const int LumberCount = 5;
        public const int LumberToWoodCount = 3;

        [Header("MaxCoins")] 
        public const int CoinsK = 10000;
        public const int CoinsM = 10000000;
        public const int CoinsDivisorK = 1000;
        public const int CoinsDivisorM = 1000000;
    }
}

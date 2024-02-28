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
        [Header("Animation")]
        public const string WheelTrigger = "Spin";

        [Header("Coins")] 
        public const int StartNumber = 1;
        public const int FinishNumber = 100;
        public const int WinCoins = 10;

        [Header("MaxCoins")] 
        public const int CoinsK = 10000;
        public const int CoinsM = 10000000;
        public const int CoinsDivisorK = 1000;
        public const int CoinsDivisorM = 1000000;
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meta
{
    public class ReloadScene : MonoBehaviour
    {
        public void ButtonClick()
        {
            SceneManager.LoadScene(GlobalConst.GameScene);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Core.Wall
{
    public class WallController 
    {
        private WallModel m_viewModel = null;
        public WallController(WallModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void TriggerEnter()
        {           
            SaveManager.DeleteKeys(new string[] { GlobalConst.PositionPlayerX, GlobalConst.PositionPlayerY, GlobalConst.PositionPlayerZ }, () => {
                // Обратный вызов выполняется после завершения удаления ключей
                // Загрузка сцены только после удаления ключей
                SceneManager.LoadScene(GlobalConst.GameScene);
            });
            //    SaveManager.DeleteKey(GlobalConst.PositionPlayerX);
            //SaveManager.DeleteKey(GlobalConst.PositionPlayerY);
            //SaveManager.DeleteKey(GlobalConst.PositionPlayerZ);

        }         
        public IEnumerator LoadSceneReload()
        {
            yield return new WaitForSeconds(0.2f);
          //  SceneManager.LoadScene(GlobalConst.ReloadScene);
        }
    }
}
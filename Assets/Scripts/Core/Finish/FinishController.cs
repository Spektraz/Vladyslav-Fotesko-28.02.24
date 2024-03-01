using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController
{
    private FinishModel m_viewModel = null;
    private string m_finishAnimName = null;
    public FinishController(FinishModel viewModel)
    {
        m_viewModel = viewModel;
        m_finishAnimName = GlobalConst.FinishAnimation;
    }
    public void TriggerEnter()
    {
        m_viewModel.FinishParticle.Play();
    }
    public IEnumerator FinishGame()
    {
        m_viewModel.FinishAnimator.SetTrigger(m_finishAnimName);
        yield return new WaitForSeconds(1.5f);
        SaveManager.DeleteData();
        SceneManager.LoadScene(GlobalConst.ReloadScene);
    }
   

}

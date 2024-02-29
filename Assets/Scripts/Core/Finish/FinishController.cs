using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController
{
    private FinishModel m_viewModel = null;
    private string m_finishAnimName = "Finish";
    public FinishController(FinishModel viewModel)
    {
        m_viewModel = viewModel;
    }
    public void TriggerEnter()
    {
        m_viewModel.FinishParticle.Play();
    }
    public IEnumerator FinishGame()
    {
        m_viewModel.FinishAnimator.SetTrigger(m_finishAnimName);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(GlobalConst.ReloadScene);
    }
   

}

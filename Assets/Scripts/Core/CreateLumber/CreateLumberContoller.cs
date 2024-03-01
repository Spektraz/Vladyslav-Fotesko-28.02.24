using System;


public class CreateLumberContoller 
{
    private CreateLumberModel m_viewModel = null;
    private string m_lumberAnimName = "CreateLumber";
    public CreateLumberContoller(CreateLumberModel viewModel)
    {
        m_viewModel = viewModel;
        m_viewModel.LumberCanvas.enabled = false;
    }
    public void SetParticle()
    {
        m_viewModel.LumberParticle.Play();
        ApplicationContainer.Instance.EventHolder.OnAddItems(GlobalConst.LumberCount, ExtractType.Lumber);
    }
    public void TriggerEnter()
    {
        m_viewModel.LumberAnimator.SetTrigger(m_lumberAnimName);
        m_viewModel.LumberCanvas.enabled = true;
    }
    public void TriggerExit()
    {
        m_viewModel.LumberAnimator.SetTrigger(m_lumberAnimName);
        m_viewModel.LumberCanvas.enabled = false;
    }
}

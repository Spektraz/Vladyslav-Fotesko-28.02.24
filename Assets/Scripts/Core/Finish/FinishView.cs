using UnityEngine;

public class FinishView : MonoBehaviour
{

    [SerializeField] private FinishModel m_viewModel = null;
    private FinishController m_controller = null;

    private void Start()
    {
        m_controller = new FinishController(m_viewModel);
     
    }


    private void OnTriggerEnter(Collider other)
    {

        m_controller.TriggerEnter();
        StartCoroutine(m_controller.FinishGame());
    }
}

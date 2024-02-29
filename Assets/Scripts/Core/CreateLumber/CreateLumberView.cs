using UnityEngine;

public class CreateLumberView : MonoBehaviour
{
    [SerializeField] private CreateLumberModel m_viewModel = null;
    private CreateLumberContoller m_controller = null;

    private void Start()
    {
        m_controller = new CreateLumberContoller(m_viewModel);

    }
    private void SetParticle()
    {
        m_controller.SetParticle();
    }

    private void OnTriggerEnter(Collider other)
    {

        m_controller.TriggerEnter();
     
    }
}

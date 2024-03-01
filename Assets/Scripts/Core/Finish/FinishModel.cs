using UnityEngine;

public class FinishModel : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private ParticleSystem m_finishParticle = null;
    [Header("Animation")]
    [SerializeField] private Animator m_finishAnimator = null;
    public ParticleSystem FinishParticle => m_finishParticle;
    public Animator FinishAnimator => m_finishAnimator;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLumberModel : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private ParticleSystem m_lumberParticle = null;
    [Header("Animation")]
    [SerializeField] private Animator m_lumberAnimator = null;
    public ParticleSystem LumberParticle => m_lumberParticle;
    public Animator LumberAnimator => m_lumberAnimator;
}

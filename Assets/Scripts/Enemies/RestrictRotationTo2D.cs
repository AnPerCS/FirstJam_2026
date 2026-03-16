using UnityEngine;
using UnityEngine.AI;

public class RestrictRotationTo2D : MonoBehaviour
{
    NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        m_Agent.updateRotation = false;
        m_Agent.updateUpAxis = false;
    }
}

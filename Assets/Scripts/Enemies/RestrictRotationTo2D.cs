using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RestrictRotationTo2D : MonoBehaviour
{
    NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        m_Agent.updateRotation = false;
        m_Agent.updateUpAxis = false;
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}

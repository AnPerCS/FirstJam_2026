using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Self] Melee Attack [Target]", category: "Action", id: "3fd348c2121db8a8930e7678b45a4cba")]
public partial class MeleeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Damage;

    protected override Status OnStart()
    {
        Transform selfTransform = Self.Value.transform;
        int playerLayerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(selfTransform.position, ((Vector2)Target.Value.transform.position - (Vector2)selfTransform.position).normalized, 10, playerLayerMask);
        if (hit.collider != null)
        {
            hit.collider.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
        }
        else
        {
            MonoBehaviour.print("nothing hit");
        }

        return Status.Success;
    }
}


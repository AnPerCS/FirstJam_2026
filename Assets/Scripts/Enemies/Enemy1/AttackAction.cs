using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Self] Melee Attack [Target] with [AttackRange] Range", category: "Action", id: "3fd348c2121db8a8930e7678b45a4cba")]
public partial class MeleeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Damage;
    [SerializeReference] public BlackboardVariable<float> AttackRange;

    protected override Status OnStart()
    {
        if (Self.Value == null || Target.Value == null) return Status.Failure;

        Transform selfTransform = Self.Value.transform;
        Vector2 startPos = selfTransform.position;
        Vector2 targetPos = Target.Value.position;
        Vector2 direction = (targetPos - startPos).normalized;

        float range = AttackRange.Value;

        int playerLayerMask = LayerMask.GetMask("Player");

        RaycastHit2D hit = Physics2D.Raycast(startPos, direction, range, playerLayerMask);

        Debug.DrawRay(startPos, direction * range, hit.collider != null ? Color.red : Color.green, 0.5f);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Damage.Value);
            }
        }

        return Status.Success;
    }
}
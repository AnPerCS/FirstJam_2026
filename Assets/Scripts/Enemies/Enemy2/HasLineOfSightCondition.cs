using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasNoLineOfSight", story: "[Self] has no line of sight of [Player], [AttackRange] ray distance", category: "Conditions", id: "4faaf4cd921034e8844c6a8a5912523e")]
public partial class HasLineOfSightCondition : Condition // Don't Change Class name, it will break the behavior graph >:(
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<float> AttackRange;

    public override bool IsTrue()
    {
        Vector2 selfPosition= Self.Value.transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(selfPosition, ((Vector2)Player.Value.transform.position - selfPosition).normalized, AttackRange);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Obstacle"))
            {
                return true;
            }
            else if (hit.collider.gameObject.CompareTag("Player"))
            {
                return false;
            }
        }

        return true;
    }
}

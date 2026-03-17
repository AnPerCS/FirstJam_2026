using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToTarget", story: "Move [Transform] To [Target] . [speed] Speed", category: "Action", id: "0a9921a2a82c83f8fa125cae75a73b71")]
public partial class MoveToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Transform;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<float> Speed;
    [SerializeReference] public BlackboardVariable<float> DistanceThreshold;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector2 direction = (Target.Value.position - Transform.Value.position).normalized;
        Transform.Value.Translate(direction * Speed * Time.deltaTime);
        if (Vector2.Distance(Transform.Value.position, Target.Value.position) <= DistanceThreshold)
        {
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}


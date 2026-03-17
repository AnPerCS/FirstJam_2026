using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Projectile Attack", story: "[Self] [EnemyProjectilePool] Attack at [PlayerTransform]", category: "Action", id: "709fe87988314161dbe1e4dba9cd07f5")]
public partial class ProjectileAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<EnemyProjectilePool> EnemyProjectilePool;
    [SerializeReference] public BlackboardVariable<Transform> PlayerTransform;
    protected override Status OnStart()
    {
        GameObject projectileObj = EnemyProjectilePool.Value.Pool.Get();
        projectileObj.transform.up = PlayerTransform.Value.position - Self.Value.transform.position;
        projectileObj.transform.position = Self.Value.transform.position;
        return Status.Success;
    }
}


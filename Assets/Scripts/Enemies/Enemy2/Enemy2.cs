using UnityEngine;

public class Enemy2 : Enemy
{
    protected override void Awake()
    {
        base.Awake();

        behaviorAgent.BlackboardReference.SetVariableValue("EnemyProjectilePool", GameManager.instance.EnemyProjectilePool);
    }

    protected override void OnDamaged()
    {


        base.OnDamaged();
    }

    protected override void OnDeath()
    {



        base.OnDeath();
    }
}

using System;
using Unity.Behavior;
using Unity.VisualScripting;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DecrementVariable", story: "Decrement [float]", category: "Action", id: "4dfaaba9db0d4b193f482ba5844a2faa")]
public partial class DecrementVariableAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Float;
    protected override Status OnStart()
    {
        Float.Value--;
        return Status.Running;
    }
}


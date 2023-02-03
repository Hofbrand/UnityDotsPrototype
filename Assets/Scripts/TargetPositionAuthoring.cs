using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TargetPostionAuthoring : MonoBehaviour
{
    public float3 value;
}

public class TargetPositionBaker : Baker<TargetPostionAuthoring>
{
    public override void Bake(TargetPostionAuthoring authoring)
    {
        AddComponent(new TargetPosition
        {
            value = authoring.value
        });
    }
}
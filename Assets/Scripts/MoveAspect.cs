using System.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public readonly partial struct MoveAspect : IAspect
{
    private readonly Entity entity;

    private readonly TransformAspect transformAspect;
    private readonly RefRO<Speed> speed;
    private readonly RefRW<TargetPosition> targetPosition;

    public void Move(float deltaTime)
    {

        float3 direction = math.normalize(targetPosition.ValueRW.value - transformAspect.LocalPosition);
        transformAspect.LocalPosition += direction * deltaTime * speed.ValueRO.value;
    }

    public void Random(RefRW<RandomComponent> randomComponent)
    {
        float reachedTargetDistance = .5f;
        if (math.distance(transformAspect.LocalPosition, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomPosition(randomComponent);
        }
    }


    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return randomComponent.ValueRW.random.NextFloat3(-15f, 15f);
    }

}

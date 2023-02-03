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
    private readonly RefRW<RandomComponent> random;

    public void Move(float deltaTime)
    {

        float3 direction = math.normalize(targetPosition.ValueRW.value - transformAspect.LocalPosition);
        transformAspect.LocalPosition += direction * deltaTime * speed.ValueRO.value;

        float reachedTargetDistance = .5f;
        if (math.distance(transformAspect.LocalPosition, targetPosition.ValueRW.value) < reachedTargetDistance)
        {
            targetPosition.ValueRW.value = GetRandomPosition(random); 
        }
    }


    private float3 GetRandomPosition(RefRW<RandomComponent> randomComponent)
    {
        return randomComponent.ValueRW.random.NextFloat3(0, 15f);
    }

}

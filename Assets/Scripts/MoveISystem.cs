using System.Diagnostics;
using Unity.Burst;
using Unity.Entities;

[BurstCompile]
public partial struct MoveISystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new MoveJob
        {
            DeltaTime = SystemAPI.Time.DeltaTime,
        }.Run();
    }
}

public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    public void Execute(MoveAspect aspect) {

            aspect.Move(DeltaTime);
        } 
}

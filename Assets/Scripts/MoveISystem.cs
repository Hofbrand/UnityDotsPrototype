using System.Diagnostics;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
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
        var deltaTime = SystemAPI.Time.DeltaTime;
        var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        var moveJob = new MoveJob
        {
            DeltaTime = deltaTime
        }.ScheduleParallel(state.Dependency);

        moveJob.Complete();

        new RandomJob
        {
            RandomComponent = randomComponent
        }.Run();
    }
}

[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    public void Execute(MoveAspect aspect) {

            aspect.Move(DeltaTime);
        } 
}

[BurstCompile]
public partial struct RandomJob : IJobEntity
{  
    [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> RandomComponent;

    public void Execute(MoveAspect aspect)
    {

        aspect.Random(RandomComponent);
    }
}

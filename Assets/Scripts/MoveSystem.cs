using System.Diagnostics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        foreach ( MoveAspect moveAspect in SystemAPI.Query<MoveAspect>())
       {
            moveAspect.Move(SystemAPI.Time.DeltaTime);
            
       }
    }
}
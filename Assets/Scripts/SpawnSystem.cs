using Unity.Burst;
using Unity.Entities;

public partial class SpawnSystem : SystemBase
{

    protected override void OnUpdate()
    {
        EntityQuery playerEntitiesQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var spawnerComponent = SystemAPI.GetSingleton<SpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        var buffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        if(playerEntitiesQuery.CalculateEntityCount() < spawnerComponent.maxPrefabAmount)
        {
            Entity spawnedEntity = buffer.Instantiate(spawnerComponent.prefabEntity);
            buffer.SetComponent(spawnedEntity, new Speed
            {
                value = randomComponent.ValueRW.random.NextFloat(1f, 10f)
            });
        }
    }
}


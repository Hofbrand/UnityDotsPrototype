using Unity.Burst;
using Unity.Entities;

public partial class SpawnSystem : SystemBase
{

    protected override void OnUpdate()
    {
        EntityQuery playerEntitiesQuery = EntityManager.CreateEntityQuery(typeof(PlayerTag));
        var spawnerComponent = SystemAPI.GetSingleton<SpawnerComponent>();

        if(playerEntitiesQuery.CalculateEntityCount() < spawnerComponent.maxPrefabAmount)
        {
            EntityManager.Instantiate(spawnerComponent.prefabEntity);
        }
    }
}


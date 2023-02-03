using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public float maxPregabAmount;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        AddComponent(new SpawnerComponent
        {
            prefabEntity = GetEntity(authoring.prefab),
            maxPrefabAmount = authoring.maxPregabAmount
        }) ;
    }
}
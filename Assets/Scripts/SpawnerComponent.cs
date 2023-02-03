using Unity.Entities;
using UnityEngine;

public struct SpawnerComponent : IComponentData
{
    public Entity prefabEntity;
    public float maxPrefabAmount;
}

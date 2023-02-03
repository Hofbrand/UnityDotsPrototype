using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TagAuthoring : MonoBehaviour
{
}

public class TagBaker : Baker<TagAuthoring>
{
    public override void Bake(TagAuthoring authoring)
    {
        AddComponent(new PlayerTag());
    }
}
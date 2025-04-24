using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public struct ChasePlayer : IComponentData
{
    public float3 movement;
}

public class ChasePlayerAuthoring : MonoBehaviour
{
    public class Baker : Baker<ChasePlayerAuthoring>
    {
        public override void Bake(ChasePlayerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new ChasePlayer
            {
                movement = new float3
                {
                    x = Random.Range(-1f, 1f),
                    y = Random.Range(0.1f, 1f),
                    z = Random.Range(-1f, 1f)
                }
            });

            Debug.Log($"Baking ChasePlayer.");
        }
    }
}

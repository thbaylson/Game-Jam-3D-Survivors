using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct ChasePlayerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<ChasePlayer>();
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (var (localTransformRef, movementRef) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<ChasePlayer>>().WithNone<Player>())
        {
            localTransformRef.ValueRW = localTransformRef.ValueRO.Translate(movementRef.ValueRO.movement * SystemAPI.Time.DeltaTime);
        }
    }
}

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class SpawnAnimatedEntitiesSystem : SystemBase
{
    protected override void OnUpdate()
    {
        if (!Keyboard.current.spaceKey.wasPressedThisFrame) return;

        SpawnEntitiesConfig config = SystemAPI.GetSingleton<SpawnEntitiesConfig>();

        EntityCommandBuffer ecb = new EntityCommandBuffer(WorldUpdateAllocator);

        foreach (var localTransformRef in SystemAPI.Query<RefRO<LocalTransform>>().WithAny<SpawnEntitiesConfig>())
        {
            Entity spawnedEntity = ecb.Instantiate(config.prefabEntity);

            LocalTransform initialTransform = new LocalTransform
            {
                Position = localTransformRef.ValueRO.Position,
                Scale = 1f,
                Rotation = quaternion.identity,
            };
            ecb.SetComponent(spawnedEntity, initialTransform);

            // Instantiate corresponding GameObject (Prefab with Animator)
            var animatorPrefab = ECSAnimatorPrefabManager.Instance.animatorPrefab;
            var animatorGO = Object.Instantiate(animatorPrefab, initialTransform.Position, Quaternion.identity);

            var link = animatorGO.GetComponent<AnimatorEntityLink>();
            link.linkedEntity = spawnedEntity;
        }

        ecb.Playback(EntityManager);
    }
}

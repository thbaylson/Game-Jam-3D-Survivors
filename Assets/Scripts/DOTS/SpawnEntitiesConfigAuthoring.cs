//using Unity.Entities;
//using UnityEngine;

//public struct SpawnEntitiesConfig : IComponentData
//{
//    public Entity prefabEntity;
//}

//public class SpawnEntitiesConfigAuthoring : MonoBehaviour
//{
//    public GameObject prefab;
//    //public GameObject AnimatorPrefab; // Reference to Animator GameObject prefab

//    public class Baker : Baker<SpawnEntitiesConfigAuthoring>
//    {
//        public override void Bake(SpawnEntitiesConfigAuthoring authoring)
//        {
//            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

//            AddComponent(entity, new SpawnEntitiesConfig
//            {
//                prefabEntity = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
//            });
//        }
//    }
//}

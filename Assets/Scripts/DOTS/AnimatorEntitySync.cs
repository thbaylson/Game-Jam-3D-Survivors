using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class AnimatorEntitySync : MonoBehaviour
{
    private Animator animator;
    private EntityManager entityManager;
    public AnimatorEntityLink entityLink;

    void Start()
    {
        animator = entityLink.animator;
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    void Update()
    {
        if (!entityManager.Exists(entityLink.linkedEntity))
        {
            Destroy(gameObject);
            return;
        }

        LocalTransform localTransform = entityManager.GetComponentData<LocalTransform>(entityLink.linkedEntity);

        // Sync position from entity to GameObject
        this.transform.position = localTransform.Position;

        // Update Animator parameters from ECS components (e.g., speed, attacking)
        // Example:
        //if (entityManager.HasComponent<Velocity>(entityLink.linkedEntity))
        //{
        //    var velocity = entityManager.GetComponentData<Velocity>(entityLink.linkedEntity);
        //    animator.SetFloat("Speed", velocity.value);
        //}

        //if (entityManager.HasComponent<AttackState>(entityLink.linkedEntity))
        //{
        //    var attackState = entityManager.GetComponentData<AttackState>(entityLink.linkedEntity);
        //    animator.SetBool("IsAttacking", attackState.isAttacking);
        //}
    }
}

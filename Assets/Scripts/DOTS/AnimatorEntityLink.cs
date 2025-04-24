using Unity.Entities;
using UnityEngine;

// Animators are managed components, so we need to take extra steps to link them to the entity system.
public class AnimatorEntityLink : MonoBehaviour
{
    public Animator animator;
    public Entity linkedEntity;
}

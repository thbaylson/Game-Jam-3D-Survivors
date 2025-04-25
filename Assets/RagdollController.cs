using System.Collections;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;

    void Start()
    {
        SetRagdollState(false); // Start with ragdoll off
    }

    public void SetRagdollState(bool isRagdoll)
    {
        animator.enabled = !isRagdoll;

        foreach (Rigidbody rb in ragdollBodies)
            rb.isKinematic = !isRagdoll;

        foreach (Collider col in ragdollColliders)
            col.enabled = isRagdoll;
    }

    public IEnumerator RagdollRoutine(float duration)
    {
        SetRagdollState(true);  // Turn on ragdoll
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

    public void EnableRagdoll() => SetRagdollState(true);
    public void DisableRagdoll() => SetRagdollState(false);
}

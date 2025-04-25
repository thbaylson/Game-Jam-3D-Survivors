using System.Collections;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody[] ragdollBodies; //rigidbodies
    [SerializeField] public Collider[] ragdollColliders;
    [SerializeField] private float _forceAmount;
    [SerializeField] private string ragdollLayerName = "CantCollideWithPlayer";
    [SerializeField] private string normalEnemyLayer = "Enemy";

    void Start()
    {
        SetRagdollState(false); // Start with ragdoll off
    }

    public void SetRagdollState(bool isRagdoll)
    {
        Vector3 randomDir = Random.onUnitSphere; // random direction
        animator.enabled = !isRagdoll;

        foreach (Rigidbody rb in ragdollBodies)
            rb.isKinematic = !isRagdoll;
        foreach(Rigidbody rb in ragdollBodies)
            rb.AddForce(randomDir * _forceAmount, ForceMode.Impulse);
        foreach (Collider col in ragdollColliders)
            col.enabled = isRagdoll;

        // Set layer for all colliders' GameObjects
        int newLayer = LayerMask.NameToLayer(isRagdoll ? ragdollLayerName : normalEnemyLayer);
        foreach (Collider col in ragdollColliders)
            SetLayerRecursively(col.gameObject, newLayer);
    }
    private void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
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

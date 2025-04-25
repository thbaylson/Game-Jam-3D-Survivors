using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorAttackTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private RagdollController ragdollController;
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        ragdollController = GetComponentInParent<RagdollController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("Attacking");
            EnableRagdollTemporarily(3f);        }
    }
    public void EnableRagdollTemporarily(float duration)
    {
        StartCoroutine(RagdollRoutine(duration));
    }

    private IEnumerator RagdollRoutine(float duration)
    {
        ragdollController.SetRagdollState(true);  // Turn on ragdoll
        yield return new WaitForSeconds(duration);
        ragdollController.SetRagdollState(false); // Turn it back off
    }
}

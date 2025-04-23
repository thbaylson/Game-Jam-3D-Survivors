using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectorAttackTrigger : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
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
        }
    }
}

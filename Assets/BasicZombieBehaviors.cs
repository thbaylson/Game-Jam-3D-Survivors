using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombieBehaviors : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] public GameObject player;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _randomAnimationChoice;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _minRunSpeed;
    [SerializeField] private float _maxRunSpeed;

    private Health healthComponent;
    private RagdollController ragdollController;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<Health>();
        ragdollController = GetComponent<RagdollController>();

        _anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        _randomAnimationChoice = Random.Range(0, 3); //choose between the three different movement types so they're not all doing the same shit
        _anim.SetFloat("Moving", _randomAnimationChoice);
        _anim.speed = Random.Range(.95f, 1.05f); //randomizes speed to make the characters looked more randomly animated instead of being in step and shit
        _runSpeed = Random.Range(_minRunSpeed, _maxRunSpeed); //if these values are going to scale up with difficulty, we'll need a plan here, but for now this will work
        _navMeshAgent.speed = _runSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = player.transform.position;

        if(healthComponent.CurrentHealth <= 0)
        {
            StartCoroutine(ragdollController.RagdollRoutine(3f));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombieBehaviors : MonoBehaviour, IPoolable
{
    [SerializeField] public GameObject player;
    [SerializeField] private Animator _animChoice;
    [SerializeField] private Animator _anim;
    [SerializeField] private int _randomAnimationChoice;
    [SerializeField] private float _runSpeed = 3.5f;

    private Health healthComponent;
    private RagdollController ragdollController;
    private GameObject prefabRef;

    void Awake()
    {
        // Need to get components here otherwise they'll be null when OnSpawn is called.
        healthComponent = GetComponent<Health>();
        ragdollController = GetComponent<RagdollController>();
        _anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("ZombieAnim");        
        player = GameObject.FindGameObjectWithTag("Player");
        _randomAnimationChoice = Random.Range(0, obj.Length);
        _animChoice = obj[_randomAnimationChoice].GetComponent<Animator>();
        _anim.runtimeAnimatorController = _animChoice.runtimeAnimatorController;
        float randomOffsetTime = Random.Range(.5f, 1.5f);
        _anim.speed = randomOffsetTime;
    }

    private void Update()
    {
        
        if (healthComponent.CurrentHealth <= 0)
        {
            // Duration here means how long the body will stay ragdolled before despawning.
            StartCoroutine(ragdollController.RagdollRoutine(duration: 3f, OnDespawn));
        }
        else
        {
            MoveTo(player.transform.position);
        }
    }

    public void MoveTo(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _runSpeed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

    public void SetPrefabRef(GameObject prefabRef) => this.prefabRef = prefabRef;

    public void OnSpawn()
    {
        healthComponent.CurrentHealth = healthComponent.MaxHealth;
        ragdollController.SetRagdollState(false);
    }

    public void OnDespawn() => PoolManager.Instance.Despawn(prefabRef, gameObject);
}

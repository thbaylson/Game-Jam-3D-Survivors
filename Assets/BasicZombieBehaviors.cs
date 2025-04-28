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
    [SerializeField] private int _exp = 8;

    private Health healthComponent;
    private RagdollController ragdollController;
    private GameObject prefabRef;
    private bool isDead;

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
        player = FindFirstObjectByType<PlayerExperience>().gameObject;
        _randomAnimationChoice = Random.Range(0, obj.Length);
        _animChoice = obj[_randomAnimationChoice].GetComponent<Animator>();
        _anim.runtimeAnimatorController = _animChoice.runtimeAnimatorController;
        float randomOffsetTime = Random.Range(.9f, 1.1f);
        _anim.speed = randomOffsetTime;
    }

    private void Update()
    {
        if (isDead) return;

        if (healthComponent.CurrentHealth <= 0)
        {
            isDead = true;

            if (player != null)
            {
                player.GetComponent<PlayerExperience>()?.Add(_exp);
            }

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
        isDead = false;
        healthComponent.CurrentHealth = healthComponent.MaxHealth;
        ragdollController.SetRagdollState(false);
    }

    public void OnDespawn()
    {
        // Having this here means there's a delay before the player gets the exp,
        //  but it also doesn't work in Update- above the Coroutine call.

        PoolManager.Instance.Despawn(prefabRef, gameObject);
    }
}

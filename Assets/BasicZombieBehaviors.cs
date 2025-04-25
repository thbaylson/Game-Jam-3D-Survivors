using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class BasicZombieBehaviors : MonoBehaviour
{
    
    [SerializeField] public GameObject player;
    [SerializeField] private Animator _animChoice;
    [SerializeField] private Animator _anim;
    [SerializeField] private int _randomAnimationChoice;
    [SerializeField] private float _runSpeed =3.5f;
    
  
   
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject [] obj = GameObject.FindGameObjectsWithTag("ZombieAnim");
        _anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        _randomAnimationChoice = Random.Range(0, 3);
        _animChoice = obj[_randomAnimationChoice].GetComponent<Animator>();
        _anim.runtimeAnimatorController = _animChoice.runtimeAnimatorController;
        float randomOffsetTime = Random.Range(.5f, 1.5f);
        _anim.speed = randomOffsetTime;



    }
    public void MoveTo(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _runSpeed * Time.deltaTime);
        transform.LookAt(targetPosition);
    }

}

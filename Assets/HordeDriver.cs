using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HordeDriver : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target; // usually the player
    public List<BasicZombieBehaviors> followers;
    public float spacing = 1.5f;
    
    void Update()
    {
        agent.SetDestination(target.position);

        for (int i = 0; i < followers.Count; i++)
        {
            Vector3 offset = new Vector3(
                Mathf.Sin(i) * spacing,
                0,
                Mathf.Cos(i) * spacing
            );
            Vector3 desiredPos = transform.position + offset;
            followers[i].MoveTo(desiredPos);
        }
    }
}

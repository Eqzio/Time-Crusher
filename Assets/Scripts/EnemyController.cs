using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    public GameObject Player;
    public float AttackDistance = 10.0f;
    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)] public float AttackProbability = 0.5f;
    

   
    void Start ()
        {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
        }
	
    void Update ()
    {
        if (_navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            bool follow = (dist < FollowDistance);
            bool hit = false;
            if (follow)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - AttackProbability) && dist < AttackDistance)
                {
                    hit = true;
                }
            }

            if (follow)
            {
                _navMeshAgent.SetDestination(Player.transform.position);
            }

            if (!follow || hit)
            {
                _navMeshAgent.SetDestination(transform.position);
                
                _animator.SetBool("Hit", hit);
                _animator.SetBool("Move", follow);
            }
        }






    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float lookRadius = 10f;
    [SerializeField] internal float health = 0f;
    [SerializeField] private GameObject target;

    private NavMeshAgent nma;
    private Animator animator;
    private bool follow = false;
    internal bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance <= lookRadius && distance > nma.stoppingDistance)
            {
                follow = true;
            }

            if (follow)
            {
                animator.SetBool("Run", true);
                CoreFunctionality(distance);
            }
            else
            {
                animator.SetBool("Run", false);
            }
            if (distance <= nma.stoppingDistance)
            {
                animator.SetBool("Attack", true);
            }
        }
        else
        {
            animator.SetBool("Death", true);
        }
    }

    private void CoreFunctionality(float distance)
    {
        nma.SetDestination(target.transform.position);
        if(distance <= nma.stoppingDistance)
        {
            follow = false;
        }
    }

    public void AttackOn()
    {
        attacking = true;
    }

    public void AttackOff()
    {
        attacking = false;
    }
}

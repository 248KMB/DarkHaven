using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator spiderAnimator;

    public Transform player; // Reference to the target (player or character)

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    //bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        spiderAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        /* May not use this.
         * 
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        */
        if (!playerInSightRange && !playerInAttackRange)
        {
            spiderAnimator.SetBool("IsIdle", true);
            spiderAnimator.SetBool("IsWalk", false);
            spiderAnimator.SetBool("IsAttack", false);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        spiderAnimator.SetBool("IsIdle", false);
        spiderAnimator.SetBool("IsWalk", true);
        spiderAnimator.SetBool("IsAttack", false);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        spiderAnimator.SetBool("IsIdle", false);
        spiderAnimator.SetBool("IsWalk", false);
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack code here
            spiderAnimator.SetBool("IsAttack", true);
        }
    }
}

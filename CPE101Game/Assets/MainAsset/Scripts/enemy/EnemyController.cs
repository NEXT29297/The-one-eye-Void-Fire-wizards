using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    public Animator animator;
    [SerializeField] float attackRange;
    bool playerInAttackRange;
    public LayerMask playerLayer;
    public GameObject ATKHitBox;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (!playerInAttackRange)
        {
            agent.SetDestination(target.position);
        }
        else if (playerInAttackRange)
        {
            Vector3 direction = (target.position - this.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * 50);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01"))
            {
                agent.SetDestination(transform.position);
                animator.SetTrigger("attack");
            }
        }
    }

    void EnableAttack()
    {
        ATKHitBox.SetActive(!ATKHitBox.activeSelf);
    }
    
    void DisableAttack()
    {
        ATKHitBox.SetActive(!ATKHitBox.activeSelf);
    }
}

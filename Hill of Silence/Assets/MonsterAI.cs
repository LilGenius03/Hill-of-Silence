using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player; 
    public float followRange = 15f; 
    public float attackRange = 2f; 
    public float speed = 3.5f; 

    private Animator animator;
    private bool isAttacking = false; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);


        if (distanceToPlayer <= followRange && distanceToPlayer > attackRange)
        {
            FollowPlayer();
        }

        else if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }

        else
        {
            Idle();
        }
    }

    void FollowPlayer()
    {
        isAttacking = false;
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);


        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);  
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
    }

    void Idle()
    {
        isAttacking = false;
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
    }
}



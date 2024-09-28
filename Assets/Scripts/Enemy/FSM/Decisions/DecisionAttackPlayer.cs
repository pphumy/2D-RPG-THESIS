using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerMask;

    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }

    public override bool Decide()
    {
        return PlayerOntriggerAttackRange();
    }
    private bool PlayerOntriggerAttackRange()
    {
        if (enemy.Player == null) return false;
        Collider2D playerCollider = 
            Physics2D.OverlapCircle(enemy.transform.position, attackRange, playerMask);
        if(playerCollider != null)
        {
            return true;
        }
        return false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

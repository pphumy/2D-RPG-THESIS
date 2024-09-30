using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon initialWeappon;
    [SerializeField] private Transform[] attackPositions;
    


    private PlayerActions actions;
    private PlayerMovement playerMovement;
    private PlayerMana playerMana;
    private PlayerAnimation playerAnimation;
    private EnemyBrain enemyTarget;
    private Coroutine attackCoroutine;

    private Transform currentAttackPosition;
    private float currentAttackRotation;
    private void Awake()
    {
        playerMana = GetComponent<PlayerMana>();
        
        actions = new PlayerActions();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    private void Start()
    {
        actions.Attack.ClickAttack.performed += ctx => Attack();
    }

    private void Update()
    {
        GetFirePosition();
    }
    private void Attack()
    {
        if (enemyTarget == null) return;
        
        if(attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            StartCoroutine(DelayAtk());
        }
        attackCoroutine = StartCoroutine(IEAttack());
    }

    private IEnumerator DelayAtk()
    {
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator IEAttack()
    {
        if(currentAttackPosition != null)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0f,0f,currentAttackRotation));
            Projectile projectile = Instantiate(initialWeappon.ProjectilePrefab, currentAttackPosition.position, rotation);
            projectile.Direction = Vector3.up;
            playerMana.ConsumeMana(initialWeappon.RequiredMana);
        }

        playerAnimation.SetAtkAnimation(true);
        yield return new WaitForSeconds(0.25f);
        playerAnimation.SetAtkAnimation(false);
    }

    private void GetFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;
        switch (moveDirection.x)
        {
            case > 0f:
                currentAttackPosition = attackPositions[1];
                currentAttackRotation = -90f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[3];
                currentAttackRotation = -270f;
                break;
        }

        switch (moveDirection.y)
        {
            case > 0f:
                currentAttackPosition = attackPositions[0];
                currentAttackRotation = 0f;
                break;
            case < 0f:
                currentAttackPosition = attackPositions[2];
                currentAttackRotation = -180f;
                break;
        }
    }
    private void EnemySelectedCallback(EnemyBrain enemySelected)
    {
        enemyTarget = enemySelected;
    }

    private void NoEnemySelectedCallback()
    {
        enemyTarget = null;
    }

    private void OnEnable()
    {
        actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNullSelectedEvent += NoEnemySelectedCallback;
    }
    private void OnDisable()
    {
        actions.Disable();
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNullSelectedEvent -= NoEnemySelectedCallback;
    }
}

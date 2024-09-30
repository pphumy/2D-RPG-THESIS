using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDamageable
{
    [Header("Config")]

    [SerializeField] private float speed;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Rigidbody2D rb2D;


    public Vector2 MoveDirection => moveDirection;

    private PlayerAnimation playerAnimation;
    private PlayerActions actions;
    private Player player;
    private Vector2 moveDirection;

    private void Awake()
    {
        actions = new PlayerActions();
        player = GetComponent<Player>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.Health <= 0f)
        {
            PlayerDead();
        }
        ReadMovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.Stats.Health <= 0f) return;
        rb2D.MovePosition(rb2D.position+moveDirection*(speed*Time.fixedDeltaTime));
    }

    private void ReadMovementInput()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection.Equals(Vector2.zero))
        {
            playerAnimation.SetMovingAnimation(false);
            return;
        }
        
        playerAnimation.SetMovingAnimation(true);
        playerAnimation.SetMovingAnimation(moveDirection);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    public void TakeDamage(float amount)
    {
        if (stats.Health <= 0f) return;
        stats.Health -= amount;
        DamageManager.Instance.ShowDamageText(amount, transform);
        if (stats.Health <= 0f)
        {
            stats.Health = 0f;
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerAnimation.SetDeadAnimation();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2D;

    private PlayerActions actions;
    private Vector2 moveDirection;

    private void Awake()
    {
        actions = new PlayerActions();
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2D.MovePosition(rb2D.position+moveDirection*(speed*Time.fixedDeltaTime));
    }

    private void ReadMovementInput()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        
    }
}

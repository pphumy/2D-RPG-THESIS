using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private readonly int MoveX = Animator.StringToHash("MoveX");
    private readonly int MoveY = Animator.StringToHash("MoveY");
    private readonly int Moving = Animator.StringToHash("Moving");
    private readonly int Dead = Animator.StringToHash("Dead");
    private readonly int Revive = Animator.StringToHash("Revive");

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetDeadAnimation()
    {
        animator.SetTrigger(Dead);
    }
    public void SetMovingAnimation(bool value)
    {
        animator.SetBool(Moving, value);
    }
    public void SetMovingAnimation(Vector2 dir)
    {
        animator.SetFloat(MoveX, dir.x);
        animator.SetFloat(MoveY, dir.y);
    }
    
    public void OnInit()
    {
        SetMovingAnimation(Vector2.down);
        animator.SetTrigger(Revive);
    }
}

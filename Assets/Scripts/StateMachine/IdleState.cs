using UnityEngine;

public class IdleState : IPlayerState
{
    private Animator animator;

    public IdleState(Animator animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.SetFloat("Speed", 0f);
    }

    public void Update() { }

    public void Exit() { }
}

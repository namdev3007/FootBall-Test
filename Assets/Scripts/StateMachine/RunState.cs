using UnityEngine;

public class RunState : IPlayerState
{
    private Animator animator;

    public RunState(Animator animator)
    {
        this.animator = animator;
    }

    public void Enter()
    {
        animator.SetFloat("Speed", 1f);
    }

    public void Update() { }

    public void Exit() { }
}

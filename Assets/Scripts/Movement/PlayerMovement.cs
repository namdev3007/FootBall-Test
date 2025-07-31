using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody rb;
    private IPlayerInput input;

    private PlayerStateMachine stateMachine;
    private IPlayerState idleState;
    private IPlayerState runState;
    public Animator animator;

    private void Awake()
    {
        rb.freezeRotation = true;

        input = new KeyboardInput();

        stateMachine = new PlayerStateMachine();
        idleState = new IdleState(animator);
        runState = new RunState(animator);
        stateMachine.ChangeState(idleState);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0f, z).normalized;
        Vector3 newVelocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.z * moveSpeed);
        rb.velocity = newVelocity;

        if (moveDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            stateMachine.ChangeState(runState);
        }
        else
        {
            stateMachine.ChangeState(idleState);
        }

        stateMachine.Update();
    }
}

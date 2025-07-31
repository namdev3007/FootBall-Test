using UnityEngine;

public class BallKickController : MonoBehaviour
{
    public float kickForce = 10f;
    public GameObject ball;

    [Header("Goals")]
    public Transform goal1;
    public Transform goal2;

    private void Start()
    {
        // Lắng nghe sự kiện từ UI
        if (UIManager.Instance != null)
            UIManager.Instance.OnKickPressed.AddListener(KickBallToNearestGoal);
    }

    public void KickBallToNearestGoal()
    {
        if (ball == null || goal1 == null || goal2 == null)
        {
            return;
        }

        Transform nearestGoal = GetNearestGoal();
        Vector3 direction = (nearestGoal.position - ball.transform.position).normalized;

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(direction * kickForce + Vector3.up * 3f, ForceMode.Impulse);
        }
    }

    private Transform GetNearestGoal()
    {
        float distanceToGoal1 = Vector3.Distance(ball.transform.position, goal1.position);
        float distanceToGoal2 = Vector3.Distance(ball.transform.position, goal2.position);
        return distanceToGoal1 < distanceToGoal2 ? goal1 : goal2;
    }
}

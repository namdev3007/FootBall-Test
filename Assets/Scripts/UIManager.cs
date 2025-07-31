using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    public GameObject kickButton;
    public GameObject autoKickButton;

    [Header("Controller")]
    public BallKickController currentBall;

    [Header("Auto Kick Settings")]
    public Transform playerTransform;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ShowKickButton()
    {
        if (kickButton != null)
            kickButton.SetActive(true);
    }

    public void HideKickButton()
    {
        if (kickButton != null)
            kickButton.SetActive(false);
    }

    public void OnKickButtonClicked()
    {
        if (currentBall != null)
            currentBall.KickBallToNearestGoal();
        else
            Debug.LogWarning("No current ball selected!");
    }

    public void OnAutoKickButtonClicked()
    {

        BallKickController[] allBalls = FindObjectsOfType<BallKickController>();
        if (allBalls.Length == 0 || playerTransform == null)
        {
            return;
        }

        BallKickController farthestBall = null;
        float maxDistance = -1f;

        foreach (var ball in allBalls)
        {
            float dist = Vector3.Distance(ball.transform.position, playerTransform.position);
            if (dist > maxDistance)
            {
                maxDistance = dist;
                farthestBall = ball;
            }
        }

        if (farthestBall != null)
        {
            farthestBall.KickBallToNearestGoal();

            CameraManager.Instance.SwitchToBallCam(farthestBall.ball.transform);
            CameraManager.Instance.SwitchToPlayerCamWithDelay(2f);
        }
    }
}

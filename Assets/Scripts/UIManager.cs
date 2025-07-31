using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Elements")]
    public GameObject kickButton;

    [Header("Events")]
    public UnityEvent OnKickPressed;

    public BallKickController currentBall;

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
            currentBall.KickBallToNearestGoal();
    }

}

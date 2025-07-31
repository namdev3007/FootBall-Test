using UnityEngine;

public class KickArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallKickController ball = other.GetComponent<BallKickController>();
        if (ball != null)
        {
            UIManager.Instance.currentBall = ball;
            UIManager.Instance.ShowKickButton();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BallKickController ball = other.GetComponent<BallKickController>();
        if (ball != null && UIManager.Instance.currentBall == ball)
        {
            UIManager.Instance.currentBall = null;
            UIManager.Instance.HideKickButton();
        }
    }

}

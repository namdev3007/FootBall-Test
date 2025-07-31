using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public CinemachineVirtualCamera playerCam;
    public CinemachineVirtualCamera ballCam;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void SwitchToBallCam(Transform ballTransform)
    {
        if (ballCam != null && ballTransform != null)
        {
            ballCam.Follow = ballTransform;
            ballCam.LookAt = ballTransform;
        }

        playerCam.Priority = 0;
        ballCam.Priority = 10;
    }

    public void SwitchToPlayerCam()
    {
        playerCam.Priority = 10;
        ballCam.Priority = 0;
    }

    public void SwitchToPlayerCamWithDelay(float delay)
    {
        StartCoroutine(DelayedSwitch(delay));
    }

    private IEnumerator DelayedSwitch(float delay)
    {
        yield return new WaitForSeconds(delay);
        SwitchToPlayerCam();
    }
}
